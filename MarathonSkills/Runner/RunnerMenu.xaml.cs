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

namespace MarathonSkills.Runner
{
    /// <summary>
    /// Логика взаимодействия для RunnerMenu.xaml
    /// </summary>
    public partial class RunnerMenu : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        int id;
        public RunnerMenu(int _id)
        {
            InitializeComponent();
            id = _id;
        }

        private void btn_regmarathon_Click(object sender, RoutedEventArgs e)
        {
            RegMarathon rg = new RegMarathon(id);
            NavigationService.Navigate(rg);
        }

        private void btn_myresult_Click(object sender, RoutedEventArgs e)
        {
            MyResults rg = new MyResults(id);
            NavigationService.Navigate(rg);
        }

        private void btn_editprofile_Click(object sender, RoutedEventArgs e)
        {
            List<User> user = db.User.ToList();

            EditProfile ep = new EditProfile(user.Where(x => x.ID == id).ToList());
            this.NavigationService.Navigate(ep);
        }

        private void btn_sponsor_Click(object sender, RoutedEventArgs e)
        {
            MySponsor rg = new MySponsor(id);
            NavigationService.Navigate(rg);
        }

        private void btn_contact_Click(object sender, RoutedEventArgs e)
        {
            ContactCoordinator cc = new ContactCoordinator();
            cc.Show();
        }
    }
}
