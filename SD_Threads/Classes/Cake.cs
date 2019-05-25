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

        private int _cakeCost;

        private int _doughCount;

        private int _creamCount;

        private int _toppingCount;

        public int CakeCost => _cakeCost;

        public int DoughCount => _doughCount;

        public int CreamCount => _creamCount;

        public int ToppingCount => _toppingCount;

        public Cake()
        {
            CakeLayers = new CakeLayer[ApplicationData.Rnd.Next(2, 7)];
            _cakeCost = _doughCount = _creamCount = _toppingCount = 0;
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
                    _cakeCost += cakeLayer.SaleCost;
                    ++_doughCount;
                }

                layer = ApplicationData.Rnd.Next(ApplicationData.CakeCustards.Count);
                cakeLayer = ApplicationData.CakeCustards[layer];
                for (int i = 1; i < CakeLayers.Length; i += 2)
                {
                    CakeLayers[i] = cakeLayer;
                    _cakeCost += cakeLayer.SaleCost;
                    ++_creamCount;
                }
            }
            else
            {
                layer = ApplicationData.Rnd.Next(ApplicationData.CakeDough.Count);
                CakeLayer cakeLayer = ApplicationData.CakeDough[layer];
                for (int i = 0; i < CakeLayers.Length - 1; i += 2)
                {
                    CakeLayers[i] = cakeLayer;
                    _cakeCost += cakeLayer.SaleCost;
                    ++_doughCount;
                }

                layer = ApplicationData.Rnd.Next(ApplicationData.CakeCustards.Count);
                cakeLayer = ApplicationData.CakeCustards[layer];
                for (int i = 1; i < CakeLayers.Length - 1; i += 2)
                {
                    CakeLayers[i] = cakeLayer;
                    _cakeCost += cakeLayer.SaleCost;
                    ++_creamCount;
                }

                layer = ApplicationData.Rnd.Next(ApplicationData.CakeToppings.Count);
                cakeLayer = ApplicationData.CakeToppings[layer];
                CakeLayers[CakeLayers.Length - 1] = cakeLayer;
                _cakeCost += cakeLayer.SaleCost;
                ++_toppingCount;
            }

            return this;
        }

        public static bool operator ==(Cake cake1, Cake cake2)
        {
            CakeLayer layer1 = null, layer2 = null;
            int? len = 0;
            if ((len = cake1?.CakeLayers.Length) == cake2?.CakeLayers.Length)
            {
                for (int i = 0; i < len; ++i)
                {
                    layer1 = cake1.CakeLayers[i];
                    layer2 = cake2.CakeLayers[i];
                    if (layer1.LayerName != layer2.LayerName || layer1.CakeLayerType != layer2.CakeLayerType)
                    {
                        return false;
                    }
                }

                return true;
            }
            return false;
        }

        public static bool operator !=(Cake cake1, Cake cake2)
        {
            CakeLayer layer1 = null, layer2 = null;
            int? len = 0;
            if ((len = cake1?.CakeLayers.Length) == cake2?.CakeLayers.Length)
            {
                for (int i = 0; i < len; ++i)
                {
                    layer1 = cake1.CakeLayers[i];
                    layer2 = cake2.CakeLayers[i];
                    if (layer1.LayerName != layer2.LayerName || layer1.CakeLayerType != layer2.CakeLayerType)
                    {
                        return true;
                    }
                }

                return false;
            }
            return true;
        }
    }
}
