using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webdev.Interfaces;
using webdev.Models;
using System.Linq;
using System.Diagnostics;

namespace ListOfLinks.Controllers
{
    public class ShortLinkController : Controller
    {
        private ILinksRepository _repository;
        public ShortLinkController(ILinksRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/{link}")]
        public IActionResult RedirectUrl(string link)
        {
            var fullLink = _repository.DecodeLink(link);
            return Redirect(fullLink);
        }
    }
}