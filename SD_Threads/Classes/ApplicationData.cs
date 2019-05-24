using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Threads.Classes
{
    public static class ApplicationData
    {
        public static List<CakeLayer> CakeDough = new List<CakeLayer>();

        public static List<CakeLayer> CakeCustards = new List<CakeLayer>();

        public static List<CakeLayer> CakeToppings = new List<CakeLayer>();

        public static Random Rnd = new Random();
    }
}
