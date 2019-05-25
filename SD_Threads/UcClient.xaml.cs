using System;
using System.Collections.Generic;
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
using SD_Threads.Classes;

namespace SD_Threads
{
    /// <summary>
    /// Логика взаимодействия для UcClient.xaml
    /// </summary>
    public partial class UcClient : UserControl
    {
        public Cake Current;

        public UcClient()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Current != null)
            {
                CakeLayer cl;

                if (Current.DoughCount > 0)
                {
                    cl = Current.CakeLayers.First();
                    bDoughColor.Background = new SolidColorBrush(Color.FromRgb(cl.Red, cl.Green, cl.Blue));
                    tbDoughName.Text = cl.LayerNameRu;
                    tbDoughCount.Text = Current.DoughCount.ToString();
                }
                else
                {
                    gDough.Visibility = Visibility.Hidden;
                }

                if (Current.CreamCount > 0)
                {
                    cl = Current.CakeLayers[1];
                    bCreamColor.Background = new SolidColorBrush(Color.FromRgb(cl.Red, cl.Green, cl.Blue));
                    tbCreamName.Text = cl.LayerNameRu;
                    tbCreamCount.Text = Current.CreamCount.ToString();
                }
                else
                {
                    gCream.Visibility = Visibility.Hidden;
                }

                if (Current.ToppingCount > 0)
                {
                    cl = Current.CakeLayers.Last();
                    bToppingColor.Background = new SolidColorBrush(Color.FromRgb(cl.Red, cl.Green, cl.Blue));
                    tbToppingName.Text = cl.LayerNameRu;
                    tbToppingCount.Text = Current.ToppingCount.ToString();
                }
                else
                {
                    gTopping.Visibility = Visibility.Hidden;
                }

                tbCakeCost.Text = Current.CakeCost.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ++ApplicationData.WorryClients;
            ((StackPanel)Parent).Children.Remove(this);
        }
    }
}
