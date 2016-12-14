using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SharepointTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ClientContext("**url**"))
            {
                context.Credentials = new SharePointOnlineCredentials("**username**", GetPassword("**password**"));

                List list = context.Web.Lists.GetByTitle("SPAR Stores");

                CamlQuery query = CamlQuery.CreateAllItemsQuery(100);
                ListItemCollection items = list.GetItems(query);

                context.Load(items);
                context.ExecuteQuery();

                Console.Write(items.Count);
            }
        }

        static SecureString GetPassword(string password)
        {
            var securePassword = new SecureString();

            foreach (var ch in password)
                securePassword.AppendChar(ch);

            return securePassword;
        }
    }
}
