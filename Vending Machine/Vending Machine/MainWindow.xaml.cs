using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Vending_Machine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Machine _machine = new Machine();

        public MainWindow()
        {
            InitializeComponent();
            textBoxDisplay.Text = _machine.DisplayText;
        }

        /// <summary>
        /// Select a coin to place into the machine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender == imagePenny)
                _machine.InsertCoin(new Penny());
            else if (sender == imageNickel)
                _machine.InsertCoin(new Nickel());
            else if (sender == imageDime)
                _machine.InsertCoin(new Dime());
            else if (sender == imageQuarter)
                _machine.InsertCoin(new Quarter());
            else
                _machine.InsertCoin(GetRandomBadCoin());

            textBoxDisplay.Text = _machine.DisplayText;
        }

        /// <summary>
        /// Select a product to purchase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonProduct_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;

            if (sender == buttonCola)
            {
                success = _machine.PurchaseItem(new Cola());
                if (success)
                {
                    textBoxProductDispenser.Text = "Cola Dispensed";
                    textBoxCoinDispenser.Text = _machine.CoinReturnText;
                }
            }
            else if (sender == buttonChips)
            {
                success = _machine.PurchaseItem(new Chips());
                if (success)
                {
                    textBoxProductDispenser.Text = "Chips Dispensed";
                    textBoxCoinDispenser.Text = _machine.CoinReturnText;
                }
            }
            else if (sender == buttonCandy)
            {
                success = _machine.PurchaseItem(new Candy());
                if (success)
                {
                    textBoxProductDispenser.Text = "Candy Dispensed";
                    textBoxCoinDispenser.Text = _machine.CoinReturnText;
                }
            }

            textBoxDisplay.Text = _machine.DisplayText;

            List<Products> soldOuts = _machine.FindSoldOutProducts();
            var uriSource = new Uri("Images/soldout.png", UriKind.Relative);

            foreach (var item in soldOuts)
            {
                if (item.GetType() == typeof(Cola))
                {
                    buttonCola.IsEnabled = false;
                    imageCola.Source = new BitmapImage(uriSource);
                }
                else if (item.GetType() == typeof(Chips))
                {
                    buttonChips.IsEnabled = false;
                    imageChips.Source = new BitmapImage(uriSource);
                }
                else if (item.GetType() == typeof(Candy))
                {
                    buttonCandy.IsEnabled = false;
                    imageCandy.Source = new BitmapImage(uriSource);
                }
            }

            ProcessUITasks();
            Thread.Sleep(1000);

            if (success)
                _machine.SetDisplayText("INSERT COINS");

            textBoxDisplay.Text = _machine.DisplayText;
        }

        /// <summary>
        /// Allow customer to request their money be returned
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            _machine.CoinsInserted.RefundCoins();

            textBoxCoinDispenser.Text = "Coins Refunded";

            _machine.SetDisplayText("INSERT COINS");
            textBoxDisplay.Text = _machine.DisplayText;
        }

        /// <summary>
        /// Updates the UI
        /// </summary>
        public static void ProcessUITasks()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(delegate (object parameter)
            {
                frame.Continue = false;
                return null;
            }), null);
            Dispatcher.PushFrame(frame);
        }

        /// <summary>
        /// Generates a random slug
        /// </summary>
        /// <returns>A coin with invalid values</returns>
        private Coin GetRandomBadCoin()
        {
            Random rand = new Random();
            int num = rand.Next(1, 4);

            switch (num)
            {
                case 1:
                    return new Nickel(4.0M);
                case 2:
                    return new Dime(17.01M);
                default:
                    return new Quarter(1.85M);
            }
        }

        /// <summary>
        /// Refill the sold out products
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefillProduct_Click(object sender, RoutedEventArgs e)
        {
            _machine.RefillProduct();

            buttonCola.IsEnabled = true;
            var uriSource = new Uri("Images/Coca-Cola.png", UriKind.Relative);
            imageCola.Source = new BitmapImage(uriSource);

            buttonChips.IsEnabled = true;
            uriSource = new Uri("Images/lays-classic.png", UriKind.Relative);
            imageChips.Source = new BitmapImage(uriSource);

            buttonCandy.IsEnabled = true;
            uriSource = new Uri("Images/twix.png", UriKind.Relative);
            imageCandy.Source = new BitmapImage(uriSource);
        }

        /// <summary>
        /// Refill the money in the machine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefillMoney_Click(object sender, RoutedEventArgs e)
        {
            _machine.CoinsInInventory.RefillCoins();
            _machine.ExactChangeOnly = false;
            _machine.SetDisplayText("INSERT COINS");
            textBoxDisplay.Text = _machine.DisplayText;
        }

        /// <summary>
        /// Clears the product dispenser when the customer retrieves their item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxProductDispenser_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBoxProductDispenser.Text = "";
        }

        /// <summary>
        /// Clears the coin dispenser when the customer retrieves their item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCoinDispenser_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBoxCoinDispenser.Text = "";
        }
    }
}