using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementLib
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException() : base("You cannot use Login() when activeInstance is null or activeInstance.IsLoggedIn = True.") {}
    }
}
