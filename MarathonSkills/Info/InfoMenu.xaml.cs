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

namespace MarathonSkills.Info
{
    /// <summary>
    /// Логика взаимодействия для InfoMenu.xaml
    /// </summary>
    public partial class InfoMenu : Page
    {
        public InfoMenu()
        {
            InitializeComponent();
        }

        private void btn_bmicalc_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Info/BMIcalculator.xaml", UriKind.Relative));
        }

        private void btn_bmrcalc_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Info/BMRcalculator.xaml", UriKind.Relative));
        }

        private void btn_lastresult_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Runner/PerviousResult.xaml", UriKind.Relative));
        }

        private void btn_listfund_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Info/ListFund.xaml", UriKind.Relative));
        }

        private void btn_marathon_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Info/InteractiveMap.xaml", UriKind.Relative));
        }

        private void btn_statsmarathon_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Info/HowLongs.xaml", UriKind.Relative));
        }
    }
}
