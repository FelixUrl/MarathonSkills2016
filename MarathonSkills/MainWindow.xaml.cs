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
using System.Windows.Threading;

namespace MarathonSkills
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2021, 09, 01);
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            mainFrame.NavigationService.Navigate(new Uri("ChoicePage.xaml", UriKind.Relative));
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            txb_Time.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void btn_back_Click_1(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.GoBack();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Uri("ChoicePage.xaml", UriKind.Relative));
        }
    }
}
