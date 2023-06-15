// Programın ilk çalışmaya başladığı dosyadır. 
// Pizza Order Form'u çalıştırarak başlatır

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Order
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PizzaOrderForm());

        }
    }
}
