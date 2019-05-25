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
                    if (IncomeValueChanged == null) return;
                    IncomeValueChanged(Income, EventArgs.Empty);
                }
            }
        }

        public static event EventHandler IncomeValueChanged;

        private static ushort _happyClients;

        public static ushort HappyClients
        {
            get => _happyClients;
            set
            {
                if (_happyClients != value)
                {
                    _happyClients = value;
                    if (RatingValueChanged == null) return;
                    RatingValueChanged(HappyClients, EventArgs.Empty);
                }
            }
        }

        private static ushort _worryClients;

        public static ushort WorryClients
        {
            get => _worryClients;
            set
            {
                if (_worryClients != value)
                {
                    _worryClients = value;
                    if (RatingValueChanged == null) return;
                    RatingValueChanged(WorryClients, EventArgs.Empty);
                }
            }
        }

        private static int _sumRating;

        public static int SumRating
        {
            get => _sumRating;
            set
            {
                if (_sumRating != value)
                {
                    _sumRating = value;
                    if (RatingValueChanged == null) return;
                    RatingValueChanged(SumRating, EventArgs.Empty);
                }
            }
        }

        public static event EventHandler RatingValueChanged;
    }
}
