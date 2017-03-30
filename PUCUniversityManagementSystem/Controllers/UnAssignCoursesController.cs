using System;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class UnAssignCoursesController : Controller
    {
        CourseManager courseManager=new CourseManager();
        //
        // GET: /UnAssignCourses/
        [HttpGet]
        public ActionResult UnAssign()
        {
            ViewBag.alart = new AlartType("Unassign all the courses.", "danger");
            return View();
        }
        [HttpPost]
        public ActionResult UnAssign(int? id)
        {
            ViewBag.alart = courseManager.UnAssignCourses();
            return View();
        }
	}
}