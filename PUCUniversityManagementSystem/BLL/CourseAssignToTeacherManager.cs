using System.Collections.Generic;
using System.Linq;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class CourseAssignToTeacherManager
    {
        CourseAssignToTeacherGateway courseAssignToTeacherGateway=new CourseAssignToTeacherGateway();
        public AlartType Save(CourseAssignToTeacher courseAssign)
        {

            CourseAssignToTeacher courseAssignTo = GetAll.ToList().Find(ca => ca.CourseId == courseAssign.CourseId && ca.Status);

            if (courseAssignTo==null)
            {
                if (courseAssignToTeacherGateway.Insert(courseAssign) > 0)
                {
                    return new AlartType("Assigned successfully", "success");
                }
                return new AlartType("Failed to save", "danger");  
            }

            return new AlartType("Overlaping not allowed!", "warning");
        }


        public IEnumerable<CourseAssignToTeacher> GetAll
        {
            get { return courseAssignToTeacherGateway.GetAll; }
        } 

    }
}