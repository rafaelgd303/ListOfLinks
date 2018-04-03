using System.Collections.Generic;
using webdev.Models;

namespace ListOfLinks.Models
{
    public class SearchResult
    {
        public IEnumerable<LinkResult> MyProperty { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public int CurrentPage { get; set; }
        public int MaxPage { get; set; }
    }

    public class LinkResult
    {
        public LinkResult(Link link)
        {
            Id = link.Id;
            FullLink = link.FullLink;
            ShortLink = link.ShortLink;
        }
        public int Id { get; set; }
        public string FullLink { get; set; }
        public string ShortLink { get; set; }
    }
}