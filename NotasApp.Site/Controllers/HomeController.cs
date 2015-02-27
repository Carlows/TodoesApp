using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotasApp.Domain.Repositories;

namespace NotasApp.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoItemsRepository _repoItems;

        public HomeController(ITodoItemsRepository repoItems)
        {
            _repoItems = repoItems;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(_repoItems.GetToDoItems());
        }
    }
}
