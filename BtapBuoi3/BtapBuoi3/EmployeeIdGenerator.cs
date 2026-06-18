using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtapBuoi3
{
    public static class EmployeeIdGenerator
    {
        private static int currentId = 0;
        public static string GenerateId()
        {
            currentId++;
            return $"NV{currentId:D3}";
        }
    }
}
