using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private string message;
        StudentManager studentManager = new StudentManager();
        DepartmentManager departmentManager = new DepartmentManager();
        TeacherManager teacherManager = new TeacherManager();
        DesignationManager designationManager = new DesignationManager();
        //
        // GET: /Student/
        public ActionResult Index()
        {
            List<Student> students = studentManager.GetAll.ToList();

            return View(students);
        }


        // GET: /Student/Create
        [HttpGet]
        public ActionResult Save()
        {

            IEnumerable<Department> departments = departmentManager.GetAll();

            ViewBag.Departments = departments;
            return View();
        }

        //
        // POST: /Student/Create
        [HttpPost]
        public ActionResult Save(Student aStudent)
        {
            try
            {

                ViewBag.alart = studentManager.Save(aStudent);

                IEnumerable<Department> departments = departmentManager.GetAll();

                ViewBag.Departments = departments;
                //ViewBag.Message = message;
                ViewBag.StudentInfo = aStudent;

                return View();
                //return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                ViewBag.alart = new AlartType(exception.InnerException.Message,"danger");
                //ViewBag.Message = message;
                return View();
            }
        }




    }
}
