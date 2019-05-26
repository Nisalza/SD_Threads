using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Threads.Classes
{
    [Serializable]
    public class CakeLayer
    {
        public CakeLayer()
        {

        }

        public CakeLayer(int id, string layerName, string layerNameRu, byte red, byte green, byte blue, byte purchaseCost, byte saleCost, CakeLayerType cakeLayerType)
        {
            Id = id;
            LayerName = layerName;
            LayerNameRu = layerNameRu;
            Red = red;
            Green = green;
            Blue = blue;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
            CakeLayerType = cakeLayerType;
        }

        public int Id { get; set; }

        public string LayerName { get; set; }

        public string LayerNameRu { get; set; }

        public byte Red { get; set; }

        public byte Green { get; set; }

        public byte Blue { get; set; }

        public byte PurchaseCost { get; set; }

        public byte SaleCost { get; set; }

        public CakeLayerType CakeLayerType { get; set; }

    }

    public enum CakeLayerType : byte
    {
        CakeLayer,
        Cream,
        Topping
    }
}
