using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogTodoApp.DataAccessLayer;
using BlogTodoApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogTodoApp.Controllers
{
    public class HomeController : Controller
    {

        TodoManager todoManager { get; set; }

        public HomeController(TodoManager todoManager)
        {
            this.todoManager = todoManager;
        }

        /* Butun Todo'lari Listeleme */
        public IActionResult Index()
        {
            var todos = todoManager.GetList();
            return View(todos);
        }

        /* Yeni Bir Todo Ekleme */
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Todo todo)
        {
            todoManager.Create(todo);
            return RedirectToAction("Index");
        }

        /* Belirli Bir Todo Guncelleme */
        public IActionResult Guncelle(string Id)
        {
            var todo = todoManager.GetById(Id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult Guncelle(string Id, Todo todo)
        {
            var item = todoManager.GetById(Id);
            item.Title = todo.Title;
            item.Date = todo.Date;
            item.Completed = todo.Completed;
            todoManager.Update(Id, item);
            return RedirectToAction("Index");
        }

        /* Belirli Bir Todo Silmek */
        public IActionResult Sil(string Id)
        {
            var todo = todoManager.GetById(Id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult Sil(string Id, IFormCollection collection)
        {
            todoManager.Delete(Id);
            return RedirectToAction("Index");
        }

    }
}