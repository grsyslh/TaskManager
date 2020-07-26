using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Abstract;
using TaskManager.DataAccess.Concrete.EFCore;
using TaskManager.Entity;

namespace TaskManager.WebUI.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _context;

        public TasksController(ITaskService context)
        {
            _context = context;
        }

        // GET: Tasks
        public IActionResult Index(string tarihAraligi)
        {
            var taskList = _context.GetAllTasks().OrderBy(t => t.TaskDate).ToList();
            if (!String.IsNullOrEmpty(tarihAraligi))
            {
                switch (tarihAraligi)
                {
                    case "Günlük":
                        taskList = taskList.Where(t => t.TaskDate.Day > DateTime.Now.AddDays(-1).Day && t.TaskDate.Day < DateTime.Now.AddDays(1).Day).ToList();
                        break;
                    case "Haftalık":
                        taskList = taskList.Where(t => t.TaskDate.Date > DateTime.Now.AddDays(-1).Date && t.TaskDate < DateTime.Now.AddDays(7)).ToList();
                        break;
                    case "Aylık":
                        taskList = taskList.Where(t => t.TaskDate.Month == DateTime.Now.Month).ToList();
                        break;
                }
            }


            return View(taskList);
        }


        [HttpPost]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Search(string searchText)
        {
            if (!String.IsNullOrEmpty(searchText))
            {
                var taskList = _context.GetAllTasks().FindAll(t => t.Header.ToLower().Contains(searchText.ToLower()) || t.Body.ToLower().Contains(searchText.ToLower()));
                return View(taskList);
            }
            else
            {
                return View();
            }

        }

        // GET: Tasks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = _context.GetAllTasks()
                .FirstOrDefault(m => m.TasksId == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TasksId,Header,Body,TaskDate")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                _context.Create(tasks);
                return RedirectToAction("Index");
            }
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = _context.GetById(id.GetValueOrDefault());
            if (tasks == null)
            {
                return NotFound();
            }
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TasksId,Header,Body,TaskDate")] Tasks tasks)
        {
            if (id != tasks.TasksId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasks);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasksExists(tasks.TasksId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = _context.GetAllTasks()
                .FirstOrDefault(m => m.TasksId == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tasks = _context.GetById(id);
            _context.Delete(tasks);
            return RedirectToAction("Index");
        }

        private bool TasksExists(int id)
        {
            return _context.GetAllTasks().Any(e => e.TasksId == id);
        }
    }
}
