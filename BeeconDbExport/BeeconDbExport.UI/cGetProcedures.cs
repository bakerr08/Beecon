using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;      // For the database connections and objects.
namespace BeeconDbExport.UI
{
    public class cGetProcedures
    {
        BeeconDB beeconDBD = new BeeconDB();

        public void GetAllUsers()
        {
            //BeeconDBConnectionString
            SqlConnection con = new SqlConnection(BeeconDbExport.UI.Properties.Settings.Default.BeeconDBConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "StoredProcedureName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            con.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            con.Close();

        }
    }
}
