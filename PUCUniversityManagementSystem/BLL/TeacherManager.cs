using System.Collections.Generic;
using System.Text.RegularExpressions;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class TeacherManager
    {
        TeacherGateway teacherGateway=new TeacherGateway();
        public IEnumerable<Teacher> GetAll
        {
            get { return teacherGateway.GetAll; }
        }

        public AlartType Save(Teacher teacher)
        {
            if (!(IsEmailAddressValid(teacher.Email)))
            {
                return new AlartType("Please! Enter a valid email address", "danger");
            }
            if (IsEmailAddressExits(teacher.Email))
            {
                return new AlartType("Email address must be unique", "warning");
            }
            if (teacherGateway.Insert(teacher) > 0)
            {
                return new AlartType("Saved Sucessfully", "success");
            }
            return new AlartType("Failed to save","danger");
        }

        private bool IsEmailAddressExits(string email)
        {
            Teacher aTeacher =teacherGateway.GetTeacherByEmailAddress(email);
            if (aTeacher != null)
            {
                return true;
            }
            return false;
        }

        private bool IsEmailAddressValid(string email)
        {

            Regex validEmailRegex = CreateValidEmailRegex();

            bool isValid = validEmailRegex.IsMatch(email);

            return isValid;
            //if (email.Contains(".com") && ((email.Contains("@gmail")) || (email.Contains("@yahoo")) || (email.Contains("@yahoo")) || (email.Contains("@mail")) || (email.Contains("@live")) || (email.Contains("@outlook"))))
            //{
            //    return true;
            //}
            //return false;
        }
        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }
    }
}