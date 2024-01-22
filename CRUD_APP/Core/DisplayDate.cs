using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework.core_app
{
    public static class DisplayDate
    {
        public static string displayDateTime()
        {
            DateTime currentDateTime = DateTime.Now;
            return $"{currentDateTime:HH:mm:ss dd/MM/yyyy}";
        }

    }
}
