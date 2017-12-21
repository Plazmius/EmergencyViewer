using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyEventComponent.Exceptions
{
    public class InvalidDateException : EmergencyEventComponentException
    {
        private DateTime invalidDate;

        public InvalidDateException(DateTime date, string message)
            : base(message)
        {
            invalidDate = date;
        }
    }
}
