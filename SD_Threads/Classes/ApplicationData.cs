using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Defaults;

namespace SD_Threads.Classes
{
    [Synchronization]
    public static class ApplicationData
    {
        public static List<CakeLayer> CakeDough = new List<CakeLayer>();

        public static List<CakeLayer> CakeCustards = new List<CakeLayer>();

        public static List<CakeLayer> CakeToppings = new List<CakeLayer>();

        public static Random Rnd = new Random();

        private static int _income;

        public static int Income
        {
            get => _income;
            set
            {
                if (_income != value)
                {
                    _income = value;
                    if (ValueChanged == null) return;
                    ValueChanged(Income, EventArgs.Empty);
                }
            }
        }

        public static event EventHandler ValueChanged;

        public static ushort HappyClients { get; set; }

        public static ushort WorryClients { get; set; }

        public static byte Rating { get; set; }
    }
}
