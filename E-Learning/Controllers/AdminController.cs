using E_Learning.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Learning.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private static StudentService studentService = new StudentService();

        [HttpGet]
        public ActionResult Index()
        {
            return View("Empty");
        }

        [HttpGet]
        public ActionResult ManageStudents()
        {
            var students = studentService.GetAllStudents().Select(student => ViewModelFactory.GetStudentViewModelFromStudent(student)).ToList();
            return View("ViewAllStudents", students);
        }

        [HttpGet]
        public ActionResult ManageTeachers()
        {
            return View("ViewAllTeachers");
        }

        [HttpGet]
        public ActionResult ManageAssistents()
        {
            return View("ViewAllAssistents");
        }

        [HttpGet]
        public ActionResult ManageAdmins()
        {
            return View("ViewAllAdmins");
        }

        [HttpGet]
        public ActionResult ViewReports()
        {
            return View("Empty");
        }

        [HttpGet]
        public ActionResult ViewLogs()
        {
            return View("Empty");
        }

        [HttpGet]
        public ActionResult CreateMail()
        {
            return View("Empty");
        }

        [HttpGet]
        public ActionResult EnterForum()
        {
            return View("Empty");
        }
        
    }
}
