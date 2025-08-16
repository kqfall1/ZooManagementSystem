using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementLib
{
    public class InvalidSelectionException : Exception
    {
        public InvalidSelectionException(string listBoxName) : base ($"ListBox {listBoxName} must be selected.") {}
    }
}
