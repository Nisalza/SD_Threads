using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using SD_Threads.Classes;

namespace SD_Threads
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            ApplicationData.ValueChanged += ChangeIncomeValue;
        }

        private void LoadData()
        {
            List<CakeLayer> cakeLayers = new List<CakeLayer>();
            XmlSerializer xml = new XmlSerializer(typeof(List<CakeLayer>));
            using (TextReader reader = new StreamReader("CakeLayers.xml"))
            {
                cakeLayers = (List<CakeLayer>)xml.Deserialize(reader);
            }

            foreach (CakeLayer cl in cakeLayers)
            {
                switch (cl.CakeLayerType)
                {
                    case CakeLayerType.CakeLayer:
                        ApplicationData.CakeDough.Add(cl);
                        break;

                    case CakeLayerType.Cream:
                        ApplicationData.CakeCustards.Add(cl);
                        break;

                    case CakeLayerType.Topping:
                        ApplicationData.CakeToppings.Add(cl);
                        break;
                }
            }
        }

        private void CreateCakeLayer(CakeLayer layer)
        {
            if (Board.Children.Count < 7)
            {
                UcCakeLayer cakeLayer = new UcCakeLayer { Current = layer };
                Board.Children.Add(cakeLayer);
            }
        }

        //todo переименовать кнопки
        private void btnBiscuitLayer_Click(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeDough[0]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeDough[1]);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeDough[2]);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeDough[3]);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeDough[4]);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeCustards[0]);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeCustards[1]);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeCustards[2]);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeCustards[3]);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeCustards[4]);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeToppings[0]);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeToppings[1]);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeToppings[2]);
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeToppings[3]);
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            CreateCakeLayer(ApplicationData.CakeToppings[4]);
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            foreach (UcCakeLayer c in Board.Children)
            {
                ApplicationData.Income -= c.Current.PurchaseCost;
            }
            
            Board.Children.Clear();
        }

        private void ChangeIncomeValue(object sender, EventArgs e)
        {
            tbIncome.Text = ApplicationData.Income.ToString();
        }
    }
}
