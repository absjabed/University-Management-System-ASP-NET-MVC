using System.Collections.Generic;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class DesignationManager
    {
        DesignationGateway designationGateway=new DesignationGateway();
        public IEnumerable<Designation> GetAll
        {

            get { return designationGateway.GetAll; }
        } 
    }
}