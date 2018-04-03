using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webdev.Interfaces;
using webdev.Models;

namespace webdev.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkRepository repository;
        private int itemsPerPage = 10;
        public LinkController(ILinkRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Link = repository.GetLink();
            return View(Link);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Link link)
        {
            repository.AddLink(link);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete(Link link)
        {
            repository.Delete(link);
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
            repository.Update(link);
            return Redirect("Index");
        }
    }
}