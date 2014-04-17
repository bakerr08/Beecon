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
            cGetProcedures oGet = new cGetProcedures();
            List<string> oUsers = oGet.GetAllUsers();
            Console.WindowWidth = 172;
            foreach (string user in oUsers)
            {
                Console.WriteLine(user);


            }
            
            Console.ReadLine();
        }
    }
}
