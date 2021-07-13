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

namespace MarathonSkills.Sponsor
{
    /// <summary>
    /// Логика взаимодействия для ThanksPay.xaml
    /// </summary>
    public partial class ThanksPay : Page
    {
        public string S { get; }

        public ThanksPay(string s, string fund, string user)
        {
            InitializeComponent();
            S = s;
            txt_price.Text = S;
            txt_fund.Text = fund;
            txbUser.Text = user;
        }
        private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {

        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ChoicePage.xaml", UriKind.Relative));
        }
    }
}
