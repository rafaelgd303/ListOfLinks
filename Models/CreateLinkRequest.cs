using webdev.Models;

namespace ListOfLinks.Models
{
    public class CreateLinkRequest
    {
        public string FullLink { get; set; }
        public string ShortLink { get; set; }
        public Link GetLink()
        {
            var link = new Link
            {
                FullLink = this.FullLink,
                ShortLink= this.ShortLink
            };
            return link;
        }
    }
}