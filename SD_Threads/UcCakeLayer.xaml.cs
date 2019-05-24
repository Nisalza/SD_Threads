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
    /// Логика взаимодействия для UcCakeLayer.xaml
    /// </summary>
    public partial class UcCakeLayer : UserControl
    {
        public CakeLayer Current;

        public UcCakeLayer()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Current != null)
            {
                btnLayer.Background = new SolidColorBrush(Color.FromRgb(Current.Red, Current.Green, Current.Blue));
                
                switch (Current.CakeLayerType)
                {
                    case CakeLayerType.CakeLayer:
                        Height = 20;
                        break;

                    case CakeLayerType.Cream:
                        Height = 15;
                        break;

                    case CakeLayerType.Topping:
                        Height = 10;
                        break;
                }
            }
        }

        private void btnLayer_Click(object sender, RoutedEventArgs e)
        {
            ((StackPanel)Parent).Children.Remove(this);
        }
    }
}
