using System.Collections.Generic;
using System.Linq;
using webdev.Interfaces;
using webdev.Models;
using HashidsNet;
using ListOfLinks;
using Microsoft.EntityFrameworkCore;

namespace webdev.Repository
{
    public class LinkRepository : ILinkRepository
    {
        private List<Link> _Link;
        private readonly LinkDbContext _context;

        public LinkRepository(LinkDbContext context)
        {
            _context = context;
        }

        public void AddLink(Link link) 
        {
            var hashids = new Hashids(link.FullLink);
            var id = hashids.Encode(1, 2, 3);
            var numbers = hashids.Decode(id);
            link.ShortLink = id;
            link.Id = _context.Links.Count();
            _context.Add(link);
            _context.SaveChanges();
        }

        public string DecodeLink(string link)
        {
            var decoder = new Hashids(link);
            var decodedLink = _Link.Where(l => l.ShortLink == link).FirstOrDefault();
            return decodedLink.FullLink;
        }        

        public List<Link> GetLink() 
        {
            return _context.Links.ToList();
        }

        public void Delete(Link link) 
        {
            Link linkToDelete = _context.Links.Find(link.Id);
            _context.Links.Remove(linkToDelete);
            _context.SaveChanges();
        }

        public void Update(Link link) 
        {
            _context.Links.Attach(link);
            _context.Entry(link).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}