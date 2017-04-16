using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoApp.Web.Models;
using System.Web.Mvc;

namespace TodoApp.Web.Controllers
{
    public class TasksController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //hello
        //hello2

        public ActionResult GetAll()
        {
            TasksDBEntities context = new TasksDBEntities();
            var tasks = context.list_tasks.Select(task => new Task
            {
                Id = task.Id,
                Name = task.Task,
                CreatedDate = task.Task_date,
            });
            return Json(tasks, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string task, string date)
        {
            TasksDBEntities context = new TasksDBEntities();
            var newListItem = new list_tasks { Task = task, Task_date = DateTime.Parse(date) };
            var added = context.list_tasks.Add(newListItem);
            context.SaveChanges();

            var result = new Task
            {
                Id = added.Id,
                Name = added.Task,
                CreatedDate = added.Task_date,
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            TasksDBEntities context = new TasksDBEntities();
            var deleted = context.list_tasks.Find(id);
            context.list_tasks.Remove(deleted);
            context.SaveChanges();

            return Json(deleted, JsonRequestBehavior.AllowGet);
        }
    }
}