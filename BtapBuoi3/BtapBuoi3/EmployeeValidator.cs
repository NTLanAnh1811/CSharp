using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtapBuoi3
{
    public static class EmployeeValidator
    {
        public static bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Trim().Length >= 2;
        }
        public static bool ValidateNumber(double value)
        {
            return value >= 0;
        }
    }
}
