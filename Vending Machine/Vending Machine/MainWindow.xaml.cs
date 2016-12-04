using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
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

        private void buttonProduct_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;

            if (sender == buttonCola)
            {
                success = _machine.PurchaseItem(new Cola());
            }
            else if (sender == buttonChips)
            {
                success = _machine.PurchaseItem(new Chips());
            }
            else if (sender == buttonCandy)
            {
                success = _machine.PurchaseItem(new Candy());
            }

            textBoxDisplay.Text = _machine.DisplayText;

            ProcessUITasks();
            Thread.Sleep(1000);

            if (success)
                _machine.SetDisplayText("INSERT COINS");

            textBoxDisplay.Text = _machine.DisplayText;
        }

        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            _machine.CoinsInserted.RefundCoins();

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
    }
}