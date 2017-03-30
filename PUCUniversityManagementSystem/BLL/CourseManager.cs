using System.Collections.Generic;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class CourseManager
    {
        CourseGateway courseGateway=new CourseGateway();
        public IEnumerable<Course> GetAll
        {
            get { return courseGateway.GetAll; }
        } 
        public AlartType Save(Course aCourse)
        {
            if (!(IsCorseCodeValid(aCourse)))
            {

                return new AlartType("Course code must be at least 5 character of length", "warning");
            }
            if (IsCourseCodeExits(aCourse.Code))
            {
                return new AlartType("Course code Already Exists ! Code must be unique", "danger");
               
            }
            if (IsCourseNameExits(aCourse.Name))
            {
               return new AlartType("Course Name Already Exists ! Name must be unique", "danger");
              
            }
            if (courseGateway.Insert(aCourse) > 0)
            {
                return new AlartType("Saved Successfully", "success"); 
            }
                return new AlartType("Failed to save","danger");
        }

        private bool IsCourseNameExits(string name)
        {

            Course course = courseGateway.GetCourseByName(name);
            if (course != null)
            {
                return true;
            }

            return false;  
        }

        private bool IsCourseCodeExits(string code)
        {
            Course course = courseGateway.GetCourseByCode(code.ToUpper());
            
            if (course != null)
            {
                return true;
            }
            
            return false;
        }

        private bool IsCorseCodeValid(Course aCourse)
        {
            if (aCourse.Code.Length > 5)
            {
                return true;
            }
            return false;

        }

        public IEnumerable<CourseViewModel> GetCourseViewModels
        {
            get { return courseGateway.GetCourseViewModels; }
        }

        public IEnumerable<Course> GetCoursesTakenByaStudentById(int id)
        {
            return courseGateway.GetCoursesTakeByaStudentByStudentId(id);
        } 
         public AlartType UnAssignCourses()
        {
             if (courseGateway.UnAssignCourse() > 0)
             {
                 return new AlartType("Unassign Courses Successfully!","success");
             }
             return new AlartType("Failed to unassign","danger");
        }

         public IEnumerable<Course> GetCourseByDepartmentId(int departmentId)
         {
             return courseGateway.GetCourseByDepartmentId(departmentId);
         }
    }
}