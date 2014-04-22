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
            CGetProcedures oGet = new CGetProcedures();
            List<string> oUsers = oGet.GetAllUsers();


            Console.WindowWidth = 172;
            foreach (string user in oUsers)
            {
                Console.WriteLine(user);
            }
            
            List<string> TagPrivacyTypes = oGet.GetAllTagPrivacyTypes();
            foreach (string TagPrivacyType in TagPrivacyTypes)
            {
                Console.WriteLine(TagPrivacyType);


            }
            List<string> Tags = oGet.GetAllTags();
            foreach (string Tag in Tags)
            {
                Console.WriteLine(Tag);


            }
            List<string> TagRatings = oGet.GetAllTagRatings();
            foreach (string TagRating in TagRatings)
            {
                Console.WriteLine(TagRating);


            }
            List<string> Categories = oGet.GetAllCategories();
            foreach (string Category in Categories)
            {
                Console.WriteLine(Category);
            }
            List<string> TagCategories = oGet.GetAllTagCategories();
            foreach (string TagCategory in TagCategories)
            {
                Console.WriteLine(TagCategory);
            }
            List<string> FriendLists = oGet.GetAllFriendLists();
            foreach (string FriendList in FriendLists)
            {
                Console.WriteLine(FriendList);
            }
            List<string> TagsVisited = oGet.GetAllTagsVisited();
            foreach (string TagVisits in TagsVisited)
            {
                Console.WriteLine(TagVisits);
            }
            List<string> Invites = oGet.GetAllInvites();
            foreach (string Invite in Invites)
            {
                Console.WriteLine(Invite);
            }




















            Console.ReadLine();
        }
    }
}
