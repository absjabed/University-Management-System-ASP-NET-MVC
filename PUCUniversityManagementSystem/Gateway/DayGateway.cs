using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class DayGateway:DBGateway
    {
        public IEnumerable<Day> GetAllDays
        {
            get
            {
                try
                {
                    var dayList = new List<Day>();
                    CommandObj.CommandText = "SELECT * FROM Day";
                    ConnectionObj.Open();
                    SqlDataReader reader = CommandObj.ExecuteReader();

                    while (reader.Read())
                    {
                        var day = new Day
                        {
                            Id = Convert.ToInt32(reader["Id"].ToString()),
                            Name = reader["Name"].ToString()
                        };
                        dayList.Add(day);
                    }
                    reader.Close();
                    return dayList;
                }
                catch (Exception exception)
                {
                    throw new Exception("Unable to collect days",exception);
                }
	    finally
	    {
            ConnectionObj.Close();
            CommandObj.Dispose();
	    }
            }
        }
    }
}