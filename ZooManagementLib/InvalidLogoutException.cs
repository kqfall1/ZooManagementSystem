using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementLib
{
    public class InvalidLogoutException : Exception
    {
        public InvalidLogoutException() : base("You cannot use Logout() when activeInstance is null or activeInstance.IsLoggedIn = False.") {}
    }
}
