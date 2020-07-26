using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManager.Business.Abstract;

namespace TaskManager.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ITaskService _context;
        public HomeController(ITaskService context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _context.GetAllTasks();
            return View(tasks);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
