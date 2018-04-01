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
        [HttpGet("short/{link}")]
        public IActionResult Index(string link)
        {
            //var cos = _repository.GetLinks();
            Debug.Write(link);
            //var ttt = cos.First().FullLink;
            // var links = _repository.GetLinks();
            // return View(links);
            return Redirect(link);
        }
    }
}