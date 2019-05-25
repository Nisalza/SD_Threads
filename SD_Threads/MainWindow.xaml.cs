using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
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
        private readonly BackgroundWorker _bw;
        private readonly SynchronizationContext _sc;
        private int _ordersCount = 0;
        private object _obj;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            ApplicationData.IncomeValueChanged += ChangeIncomeIncomeValue;
            ApplicationData.RatingValueChanged += ChangeRatingValue;
            _obj = new object();
            _sc = SynchronizationContext.Current;
            _bw = new BackgroundWorker();
            _bw.RunWorkerAsync();
            _bw.DoWork += TestOrdersCount;
            Thread thread = new Thread(StartClientsQueue) { Priority = ThreadPriority.Lowest, IsBackground = true };
            thread.Start();
        }

        private void StartClientsQueue()
        {
            int i = 0;
            while (true)
            {
                if (_ordersCount < 5)
                {
                    if (ApplicationData.Rnd.Next(2) == 1)
                    {
                        ++i;
                        ThreadPool.QueueUserWorkItem(CreateClient, i);
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private void CreateClient(object state)
        {
            UcClient current = null;
            _sc.Send(async x => { current = await AddClient((int)state); }, null);
            while (current.Mood > 0)
            {
                Thread.Sleep(1000 * ApplicationData.Rnd.Next(1, 8));
                lock (_obj)
                {
                    _sc.Post(x => { current?.DecClientMood((int)state); }, null);
                }
            }
            Thread.CurrentThread.Abort();
        }

        private async Task<UcClient> AddClient(int threadId)
        {
            UcClient client = new UcClient
            {
                Current = new Cake().CreateCake(),
                tbOrderId = {Text = threadId.ToString()}
            };

            OrdersTable.Children.Add(client);

            return client;
        }

        private void TestOrdersCount(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(250);
                if (_bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                _sc.Post(x => { UpdateOrdersCount(); }, null);
            }
        }

        private void LoadData()
        {
            List<CakeLayer> cakeLayers;
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

        #region Кнопки

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

        #endregion
        
        private void btnDeleteCake_Click(object sender, RoutedEventArgs e)
        {
            foreach (UcCakeLayer c in Board.Children)
            {
                ApplicationData.Income -= c.Current.PurchaseCost;
            }
            
            Board.Children.Clear();
        }

        private void ChangeIncomeIncomeValue(object sender, EventArgs e)
        {
            tbIncome.Text = ApplicationData.Income.ToString();
        }

        private void ChangeRatingValue(object sender, EventArgs e)
        {
            double rating = (double)ApplicationData.SumRating / (double)(ApplicationData.WorryClients + ApplicationData.HappyClients);
            tbRating.Text = $"{rating:0.#}";
            tbHappyClients.Text = ApplicationData.HappyClients.ToString();
            tbWorryClients.Text = ApplicationData.WorryClients.ToString();
        }

        public void UpdateOrdersCount()
        {
            _ordersCount = OrdersTable.Children.Count;
            tbOrdersCount.Text = _ordersCount.ToString();
        }

        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            Cake cake = new Cake {CakeLayers = new CakeLayer[Board.Children.Count]};
            for (int i = 0; i < Board.Children.Count; ++i)
            {
                cake.CakeLayers[i] = ((UcCakeLayer) Board.Children[i]).Current;
            }

            UcClient client = null;
            foreach (UcClient c in OrdersTable.Children)
            {
                if (c.Current == cake)
                {
                    client = c;
                    break;
                }
            }
            if (client != null)
            {
                ++ApplicationData.HappyClients;
                ApplicationData.SumRating += client.Mood;
                ApplicationData.Income += client.Current.CakeCost;
                OrdersTable.Children.Remove(client);
                Board.Children.Clear();
                bStatus.Background = Brushes.Chartreuse;
            }
            else
            {
                bStatus.Background = Brushes.Red;
            }
        }
    }
}
