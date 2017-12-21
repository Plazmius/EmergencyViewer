using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyEventComponent.Exceptions
{
    public class InvalidStringException : Exception
    {
        private string invalidStr;

        public InvalidStringException(string str, string message)
            : base(message)
        {
            invalidStr = str;
        }
    }
}
