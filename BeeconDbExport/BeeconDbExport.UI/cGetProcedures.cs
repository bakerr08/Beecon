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
        List<string> sUsers = new List<string>();
        public List<string> GetAllUsers()
        {
            //BeeconDBConnectionString
            SqlConnection con = new SqlConnection(BeeconDbExport.UI.Properties.Settings.Default.BeeconDBConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "spGetAllUsers";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            con.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            while (reader.Read())
            {
                string sUser = "";
                for (int i = 0; i < 10; i++)
			{
               
                    sUser = SafeGetString(reader, i) + ",";

			}
                sUsers.Add(sUser);				
				}
            con.Close();
            return sUsers;
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
            List<string> sTags = new List<string>();
            //BeeconDBConnectionString
            SqlConnection con = new SqlConnection(BeeconDbExport.UI.Properties.Settings.Default.BeeconDBConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "spGetAllTags";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            con.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            while (reader.Read())
            {
                string sTag = "";
                for (int i = 0; i < 10; i++)
                {

                    sTag = SafeGetString(reader, i) + ",";

                }
                sTags.Add(sTag);
            }
            con.Close();
            return sTags;
        }

        public List<string> GetAllTagPrivacyTypes()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTagRatings()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTagCategories()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllFriendLists()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTagsVisited()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllInvites()
        {
            throw new NotImplementedException();
        }
    }

}
