using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private AlartType message;
        TeacherManager teacherManager=new TeacherManager();
        DesignationManager designationManager=new DesignationManager();
        DepartmentManager departmentManager=new DepartmentManager();
        //
        // GET: /Teacher/
        public ActionResult Index()
        {
            List<Teacher> teachers = teacherManager.GetAll.ToList();   
            return View(teachers);
        }

        //
        // GET: /Teacher/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //
        // GET: /Teacher/Create
        public ActionResult Save()
        {
            IEnumerable<dynamic> desinationList = designationManager.GetAll;
            IEnumerable<Department> departments = departmentManager.GetAll();
            ViewBag.Designations = desinationList;
            ViewBag.Departments = departments;
            return View();
        }

        //
        // POST: /Teacher/Create
        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            try
            {
                message = teacherManager.Save(teacher);
                IEnumerable<Designation> desinationList = designationManager.GetAll;
                IEnumerable<Department> departments = departmentManager.GetAll();
                ViewBag.Designations = desinationList;
                ViewBag.Departments = departments;
                ViewBag.alart = message;
                return View();
                //return RedirectToAction("Index");
            }
            catch(Exception exception)
            {
                message.Message = exception.Message;
                if (exception.InnerException != null)
                {
                    message.Message += "<br/>System Error:" + exception.InnerException.Message;

                }
                ViewBag.alart = message;
                return View();
            }
        }

    }
}
