using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webdev.Interfaces;
using webdev.Models;

namespace webdev.Controllers
{
    public class LinkController : Controller
    {
        private ILinkRepository _repository;
        
        public LinkController(ILinkRepository LinkRepository)
        {
            _repository = LinkRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Link = _repository.GetLink();
            return View(Link);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Link link)
        {
            _repository.AddLink(link);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete(Link link)
        {
            _repository.Delete(link);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Edit(Link link) 
        {
            return View(link);
        }
        
        [HttpPost]
        public IActionResult Update(Link link) 
        {
            _repository.Update(link);
            return Redirect("Index");
        }
    }
}