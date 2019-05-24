using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Threads.Classes
{
    public class Cake
    {
        public CakeLayer[] CakeLayers;

        public int CakeCost;

        public Cake()
        {
            CakeLayers = new CakeLayer[ApplicationData.Rnd.Next(2, 7)];
            CakeCost = 0;
        }

        public Cake CreateCake()
        {
            int layer = 0;
            int withTopping = ApplicationData.Rnd.Next(2);
            if (withTopping == 0)
            {
                layer = ApplicationData.Rnd.Next(ApplicationData.CakeDough.Count);
                CakeLayer cakeLayer = ApplicationData.CakeDough[layer];
                for (int i = 0; i < CakeLayers.Length; i += 2)
                {
                    CakeLayers[i] = cakeLayer;
                    CakeCost += cakeLayer.SaleCost;
                }

                layer = ApplicationData.Rnd.Next(ApplicationData.CakeCustards.Count);
                cakeLayer = ApplicationData.CakeCustards[layer];
                for (int i = 1; i < CakeLayers.Length; i += 2)
                {
                    CakeLayers[i] = cakeLayer;
                    CakeCost += cakeLayer.SaleCost;
                }
            }
            else
            {
                layer = ApplicationData.Rnd.Next(ApplicationData.CakeDough.Count);
                CakeLayer cakeLayer = ApplicationData.CakeDough[layer];
                for (int i = 0; i < CakeLayers.Length - 1; i += 2)
                {
                    CakeLayers[i] = cakeLayer;
                    CakeCost += cakeLayer.SaleCost;
                }

                layer = ApplicationData.Rnd.Next(ApplicationData.CakeCustards.Count);
                cakeLayer = ApplicationData.CakeCustards[layer];
                for (int i = 1; i < CakeLayers.Length - 1; i += 2)
                {
                    CakeLayers[i] = cakeLayer;
                    CakeCost += cakeLayer.SaleCost;
                }

                layer = ApplicationData.Rnd.Next(ApplicationData.CakeToppings.Count);
                cakeLayer = ApplicationData.CakeToppings[layer];
                CakeLayers[CakeLayers.Length - 1] = cakeLayer;
                CakeCost += cakeLayer.SaleCost;
            }

            return this;
        }
    }
}
