using System.Collections.Generic;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class SemesterManager
    {
        SemesterGateway semesterGateway=new SemesterGateway();
        public List<Semester> GetAll
        {
            get { return semesterGateway.GetAll; }
        }
    }
}