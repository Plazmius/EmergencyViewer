using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyEventComponent.Exceptions
{
    public class EmergencyEventComponentException : Exception
    {
        public EmergencyEventComponentException(string message) : base(message)
        {

        }
    }
}
