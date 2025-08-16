//Quinn Keenan, 301504914, 08/08/2025

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementLib
{
    public class InvalidInputException : Exception
    {
        //I also occasionally use this to display inputValues rather than the names of variables as well. 
        public InvalidInputException(string inputName) : base($"Input for {inputName} is invalid!") {}
    }
}
