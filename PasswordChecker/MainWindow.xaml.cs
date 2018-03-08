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


namespace PwdChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        

        private void pwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            int[] statistics = new int[5];

            //char count
            statistics[0] = pwdBox.Password.Length;
            //caps
            statistics[1] = pwdBox.Password.Count(char.IsUpper);
            //small
            statistics[2] = pwdBox.Password.Count(char.IsLower);
            //numbers
            statistics[3] = pwdBox.Password.Count(char.IsNumber);

            //all the res are special chars
            statistics[4] = pwdBox.Password.Length - (statistics[1] + statistics[2] + statistics[3] + statistics[4]);


            //update the UI

            txtcharCount.Text = "Char count:" + statistics[0].ToString();
            txtCapitalLetters.Text = "Capital letters" + statistics[1].ToString();
            txtSmallLetters.Text = "Small letters" + statistics[2].ToString();
            txtNumbers.Text = "Numbers:" + statistics[3].ToString();
            txtSpecial.Text = "Special chars" + statistics[4].ToString();


            //calculate how many different categories are in use on pwd

            int categoryCount = 0;
            for (int i = 1; i < 5; i++)
            {
                if (statistics[i] > 0)
                {
                    categoryCount++;
                }
            }
            if (statistics[0] > 15 && categoryCount > 3)
            {
                //good pwd
                txtCheckMessage.Content = "Good";
                txtCheckMessage.Background = new SolidColorBrush(Colors.Green);
            }

            else if (statistics[0] > 12 && categoryCount > 2)
            {
                txtCheckMessage.Content = "Moderate";
                txtCheckMessage.Background = new SolidColorBrush(Colors.LightGreen);
            }

            else if (statistics[0] > 8 && categoryCount > 1)
            {
                txtCheckMessage.Content = "Fair";
                txtCheckMessage.Background = new SolidColorBrush(Colors.Yellow);
            }


            else
            {
                //poor
                txtCheckMessage.Content = "Poor";
                txtCheckMessage.Background = new SolidColorBrush(Colors.Red);
            }




        }
    }
}
