using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AlartType
    {
        public string Message { get; set; }
        public string Type { get; set; }

        public AlartType(string message, string type)
        {
            Message = message;
            Type = type;
        }
    }
}