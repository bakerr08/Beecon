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
			// oleDbCommand1.CommandText = "UpdateAuthor";
			// oleDbCommand1.CommandType = System.Data.CommandType.StoredProcedure;

			// oleDbCommand1.Parameters["au_id"].Value = "172-32-1176";
			// oleDbCommand1.Parameters["au_lname"].Value = "White";
			// oleDbCommand1.Parameters["au_fname"].Value = "Johnson";

			// oleDbConnection1.Open();
			// oleDbCommand1.ExecuteNonQuery();
			// oleDbConnection1.Close();
			// int returnValue;

			// oleDbCommand1.CommandText = "CountAuthors";
			// oleDbCommand1.CommandType = CommandType.StoredProcedure;

			// oleDbConnection1.Open();
			// oleDbCommand1.ExecuteNonQuery();
			// oleDbConnection1.Close();

			// returnValue = (int)(oleDbCommand1.Parameters["retvalue"].Value);
			// MessageBox.Show("Return Value = " + returnValue.ToString());

        }
    }
}
