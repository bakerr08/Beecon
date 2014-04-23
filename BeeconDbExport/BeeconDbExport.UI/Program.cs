using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeconDbExport.UI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine(System.Environment.MachineName);
            CGetProcedures oGet = new CGetProcedures();
           
            List<string> oRows = new List<string>();
            oRows.AddRange(oGet.GetAllUsers());


            

            oRows.AddRange(oGet.GetAllTagPrivacyTypes());
            
            oRows.AddRange(oGet.GetAllTags());
            
            oRows.AddRange(oGet.GetAllTagRatings());
            
            oRows.AddRange(oGet.GetAllCategories());
            
            oRows.AddRange(oGet.GetAllTagCategories());
            
            oRows.AddRange(oGet.GetAllFriendLists());
           
            oRows.AddRange(oGet.GetAllTagsVisited());
            
            oRows.AddRange(oGet.GetAllInvites());
            Console.WindowWidth = 172;
            foreach (string row in oRows)
            {
                Console.WriteLine(row);
            }



            Console.ReadLine();
        }
    }
}
