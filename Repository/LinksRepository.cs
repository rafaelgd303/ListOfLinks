using System.Collections.Generic;
using System.Linq;
using webdev.Interfaces;
using webdev.Models;
using HashidsNet;

namespace webdev.Repository
{
    public class LinkRepository : ILinkRepository
    {
        private List<Link> _Link;

        public LinkRepository()
        {
            _Link = new List<Link>();
        }

        public void AddLink(Link link) 
        {
            var hashids = new Hashids(link.FullLink);
            var id = hashids.Encode(1, 2, 3);
            var numbers = hashids.Decode(id);
            link.ShortLink = id;
            link.Id = _Link.Count;
            _Link.Add(link);
        }

        public string DecodeLink(string link)
        {
            var decoder = new Hashids(link);
            var decodedLink = _Link.Where(l => l.ShortLink == link).FirstOrDefault();
            return decodedLink.FullLink;
        }        

        public List<Link> GetLink() 
        {
            return _Link;
        }

        public void Delete(Link link) 
        {
            var linkToDelete = _Link
                .SingleOrDefault(element => element.ShortLink == link.ShortLink && element.FullLink == link.FullLink);
            _Link.Remove(linkToDelete);
        }

        public void Update(Link link) 
        {
            var linkToUpdateIndex = _Link.FindIndex(element => element.Id == link.Id);
            if(linkToUpdateIndex != -1) 
            {
                var hashids = new Hashids(link.FullLink);
                var id = hashids.Encode(1, 2, 3);
                var numbers = hashids.Decode(id);
                link.ShortLink = id;
                _Link[linkToUpdateIndex] = link;

            }
        }
    }
}