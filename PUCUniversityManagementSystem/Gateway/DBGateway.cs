using System.Data.SqlClient;
using System.Web.Configuration;

namespace UniversityManagementSystem.Gateway
{
    public class DBGateway
    {
        private SqlConnection connectionObj;

        public SqlConnection ConnectionObj
        {
            get
            {
                return connectionObj;
            }
        }

        public SqlCommand CommandObj
        {
            get
            {
                commandObj.Connection = connectionObj;
                return commandObj;
            }
        }

        private SqlCommand commandObj;

        public DBGateway()
        {
            connectionObj = new SqlConnection(WebConfigurationManager.ConnectionStrings["UniversityDB"].ConnectionString);
            commandObj=new SqlCommand();
        }
    }
}