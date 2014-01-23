using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using TestMembershipProvider;
using System.Configuration;
using System.Collections.Specialized;

namespace Debugger
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllUsers();
            CreateUser();
        }

        static void GetAllUsers()
        {
            MyCustomMemberships provider = new MyCustomMemberships();
            provider.Initialize(null, null);
            int totalRecords;
            MembershipUserCollection users = provider.GetAllUsers(0, 3, out totalRecords);
            foreach (MembershipUser user in users)
            {
                Console.WriteLine(user.UserName);
            }
            Console.WriteLine("done!");
            Console.ReadLine();
        }

        static void CreateUser()
        {
            MyCustomMemberships provider = new MyCustomMemberships();
            provider.Initialize(null, null);
            MembershipCreateStatus mcs;
            MembershipUser mu = provider.CreateUser("david", "ABCdefg1234$", "david@esri.com", "dogs name", "wags", true, null, out mcs);
            
            if(mu != null){

                Console.WriteLine(mu.UserName + " has been added to the user store!");
            }else{
                string status = GetErrorMessage(mcs);
                Console.WriteLine(status);
            }
            Console.WriteLine("done!");
            Console.ReadLine();
            
        }

        static string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}
