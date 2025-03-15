using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace Orderly
{
    public static class Session
    {
        public static string CurrentUsername { get; set; }
        public static int EmployeeID { get; set; }  // ✅ Thêm EmployeeID vào Session
        public static DateTime CheckInTime { get; set; } = DateTime.MinValue;
        public static System.Windows.Forms.Timer WorkTimer { get; set; } = null;

        public static void InitializeTimer(EventHandler tickHandler)
        {
            if (WorkTimer == null)
            {
                WorkTimer = new System.Windows.Forms.Timer();
                WorkTimer.Interval = 1000;
                WorkTimer.Tick += tickHandler;
            }
        }
    }
}
