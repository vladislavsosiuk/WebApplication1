using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Managers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        IStudentManager studentManager;

        public AdminController()
        {
            studentManager = new StudentManager();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public ActionResult Edit(int id=0)
        {
            if (id == 0)
                return RedirectToAction("Index");
            var student = studentManager.GetStudent(id);
            if(student==null)
                return RedirectToAction("Index");
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if(ModelState.IsValid)
            {
                studentManager.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            studentManager.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}