using System.Collections.Generic;
using webdev.Models;

namespace webdev.Interfaces
{
    public interface ILinkRepository
    {
         List<Link> GetLink();
         void AddLink(Link link);
         void Delete(Link link);
         void Update(Link link);
         string DecodeLink(string link);
    }
}