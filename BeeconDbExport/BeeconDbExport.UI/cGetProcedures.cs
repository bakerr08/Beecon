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
    public class CGetProcedures
    {
        BeeconDB beeconDBD = new BeeconDB();
        private string sConnectionString = "";
        public CGetProcedures()
        {
            if (System.Environment.MachineName == "JOSHUA-WIN7")
            {
                sConnectionString = BeeconDbExport.UI.Properties.Settings.Default.HomeBeeconDBConnectionString;
                
            }
            else
            {
                sConnectionString = BeeconDbExport.UI.Properties.Settings.Default.BeeconDBConnectionString;


            }
           
               
            
        }
        public List<string> GetAllUsers()
        {
            return GetFromProcedure("spGetAllUsers", 10);
        }
        private static string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                var firstColType = reader.GetFieldType(colIndex);

                string stype = firstColType.Name;
                switch (stype)
                {
                    case "String":
                        return reader.GetString(colIndex);
                    case "Int32":
                        return reader.GetInt32(colIndex).ToString();
                    case "DateTime":
                        return reader.GetDateTime(colIndex).ToString();
                    case "Double":
                        return reader.GetDouble(colIndex).ToString();
                    case "Boolean":
                        return reader.GetBoolean(colIndex).ToString();
                    default:
                        return "";
                }
                
            }
            else
                return string.Empty;
        }

        public List<string> GetAllTags()
        {
            return GetFromProcedure("spGetAllTag", 9);
        }

        public List<string> GetAllTagPrivacyTypes()
        {
            return GetFromProcedure("spGetAllTagPrivacyType", 2);
        }

        private List<string> GetFromProcedure(string vsProcedureName, int columns)
        {
            List<string> rows = new List<string>();
            //BeeconDBConnectionString
            SqlConnection con = new SqlConnection(sConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = vsProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            con.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            while (reader.Read())
            {
                string row = "";
                for (int i = 0; i < columns; i++)
                {

                    row = SafeGetString(reader, i) + ",";

                }
                rows.Add(row);
            }
            con.Close();
            return rows;
        }
        public List<string> GetAllTagRatings()
        {
            return GetFromProcedure("spGetAllTagRating", 4);
        }

        public List<string> GetAllCategories()
        {
            return GetFromProcedure("spGetAllCategory", 2);
        }

        public List<string> GetAllTagCategories()
        {
            return GetFromProcedure("spGetAllTagCategory", 2);
        }

        public List<string> GetAllFriendLists()
        {
            return GetFromProcedure("spGetAllFriendList", 4);
        }

        public List<string> GetAllTagsVisited()
        {
            return GetFromProcedure("spGetAllTagVisited", 4);
        }

        public List<string> GetAllInvites()
        {
            return GetFromProcedure("spGetAllInvites", 6);
        }

       
    }

}
