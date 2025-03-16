using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
namespace Orderly
{
    public static class Session
    {
        public static string CurrentUsername { get; set; }
        public static int EmployeeID { get; set; }  // Thêm EmployeeID vào Session
    }
}   
