using System.Collections.Generic;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class DayManager
    {
        DayGateway dayGateway=new DayGateway();
        public IEnumerable<Day> GetAllDays
        {
            get { return dayGateway.GetAllDays; }
        } 
    }
}