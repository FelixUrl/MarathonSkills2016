using MarathonSkills.AdminController;
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

namespace MarathonSkills.Admin
{
    /// <summary>
    /// Логика взаимодействия для ManageCharities.xaml
    /// </summary>
    public partial class ManageCharities : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        public ManageCharities()
        {
            InitializeComponent();
            FundDb.ItemsSource = db.Fund.ToList();
        }

        private void btnAddFund_Click(object sender, RoutedEventArgs e)
        {        
            this.NavigationService.Navigate(new Uri("AdminController/AddCharity.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Fund fun = FundDb.SelectedValue as Fund;
            EditCharity aed = new EditCharity(fun);
            this.NavigationService.Navigate(aed);

        }
    }
}
