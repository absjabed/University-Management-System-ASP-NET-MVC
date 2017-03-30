using System.Collections.Generic;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway=new DepartmentGateway();
        public IEnumerable<Department> GetAll()
        {
            return departmentGateway.GetAll();
        }

        public AlartType Save(Department aDepartment)
        {
            if (!(IsDepartmentCodeValid(aDepartment)))
            {
                return new AlartType("Department code must be between 2 to 7 character length", "warning");
            }
            if (IsDepartmentCodeExits(aDepartment))
            {
                return new AlartType("Department Code Already Exists. Department Code must be unique", "danger");
            }
            if (IsDepartmentNameExits(aDepartment))
            {
                return new AlartType("Department Name Already Exists. Department Name must be uinque", "danger");
            }
            if (departmentGateway.Insert(aDepartment) > 0)
            {
                return new AlartType("Saved Successfully", "success");
            }
            return new AlartType("Failed to save","danger");
        }

        private bool IsDepartmentNameExits(Department aDepartment)
        {
            Department dept = departmentGateway.GetDepartmentByName(aDepartment.Name);
            
            if (dept != null)
            {
                return true;
            }
            return false;
        }

        private bool IsDepartmentCodeExits(Department aDepartment)
        {
            Department dept = departmentGateway.GetDepartmentByCode(aDepartment.Code.ToUpper());
                
            if (dept!=null)
            {
                return true;
            }
            return false;

            
        }

        private bool IsDepartmentCodeValid(Department
            aDepartment)
        {
            if (aDepartment.Code.Length >= 2 || aDepartment.Code.Length <= 7)
            {
                return true;
            }
            return false;
        }
    }
}