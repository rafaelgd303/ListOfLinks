using System.Collections.Generic;
using System.Linq;
using webdev.Interfaces;
using webdev.Models;
using HashidsNet;

namespace webdev.Repository
{
    public class LinksRepository : ILinksRepository
    {
        private List<Link> _links;

        public LinksRepository()
        {
            _links = new List<Link>();
        }

        public void AddLink(Link link) 
        {
            var hashids = new Hashids(link.FullLink);
            var id = hashids.Encode(1, 2, 3);
            var numbers = hashids.Decode(id);
            link.ShortLink = id;
            link.Id = _links.Count;
            _links.Add(link);
        }

        public string DecodeLink(string link)
        {
            var decoder = new Hashids(link);
            var numbers = decoder.Decode(link).FirstOrDefault();
            return _links.FirstOrDefault(l => l.Id == numbers).FullLink;
        }        

        public List<Link> GetLinks() 
        {
            return _links;
        }

        public void Delete(Link link) 
        {
            var linkToDelete = _links
                .SingleOrDefault(element => element.ShortLink == link.ShortLink && element.FullLink == link.FullLink);
            _links.Remove(linkToDelete);
        }

        public void Update(Link link) 
        {
            var linkToUpdateIndex = _links.FindIndex(element => element.Id == link.Id);
            if(linkToUpdateIndex != -1) 
            {
                var hashids = new Hashids(link.FullLink);
                var id = hashids.Encode(1, 2, 3);
                var numbers = hashids.Decode(id);
                link.ShortLink = id;
                _links[linkToUpdateIndex] = link;

            }
        }
    }
}