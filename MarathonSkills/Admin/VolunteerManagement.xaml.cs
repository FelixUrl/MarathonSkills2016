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
    /// Логика взаимодействия для VolunteerManagement.xaml
    /// </summary>
    public partial class VolunteerManagement : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        List<string> sort = new List<string>()
        {
            "Имени",
            "Фамилии",
            "Стране",
            "Полу",
        };
        public VolunteerManagement()
        {
            InitializeComponent();
            VolunteerDG.ItemsSource = db.Volunteer.ToList();
            cmbSort.ItemsSource = sort;
        }


        private void btnAddVol_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AdminController/ImportVolunteers.xaml", UriKind.Relative));
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSort.SelectedItem != null)
            {
                List<Volunteer> bdList = db.Volunteer.ToList();
                if (cmbSort.SelectedItem == "Имени")
                {
                    var sortByName = from b in bdList
                                  
                                     orderby b.Name
                                     select b;
                    VolunteerDG.ItemsSource = sortByName;
                }
                else if (cmbSort.SelectedItem == "Фамилии")
                {
                    var sortBySurName = from b in bdList
                                        orderby b.Surname
                                        select b;
                    VolunteerDG.ItemsSource = sortBySurName;
                }
                else if (cmbSort.SelectedItem == "Стране")
                {
                    var sortByCountry = from b in bdList
                                      orderby b.Country
                                      select b;
                    VolunteerDG.ItemsSource = sortByCountry;
                }
                else if (cmbSort.SelectedItem == "Полу")
                {
                    var sortByGender = from b in bdList
                                        orderby b.Gender
                                        select b;
                    VolunteerDG.ItemsSource = sortByGender;
                }
            }
        }
    }
}
