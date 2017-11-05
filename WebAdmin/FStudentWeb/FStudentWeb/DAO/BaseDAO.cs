using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FStudentWeb.DAO
{
    interface IBaseDAO
    {

    }
    class BaseDAO: IBaseDAO
    {
        public static SqlConnection GetConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["studentdataEntities"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            return con;
        }
    }
}
