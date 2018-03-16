using System.Collections.Generic;
using System.Linq;
using webdev.Interfaces;
using webdev.Models;

namespace webdev.Repository
{
    public class LinksRepository : ILinksRepository
    {
        private List<Link> _links;

        public LinksRepository()
        {
            _links = new List<Link>
            {
                new Link { Id = 0, FullLink = "Lód", ShortLink = "Jacek Dukaj" },
                new Link { Id = 1, FullLink = "Valis", ShortLink = "Philip K. Dick" }
            };
        }

        public void AddLink(Link link) 
        {
            link.Id = _links.Count;
            _links.Add(link);
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
                _links[linkToUpdateIndex] = link;
        }
    }
}