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
using MarathonSkills;

namespace MarathonSkills.Admin
{
    /// <summary>
    /// Логика взаимодействия для UserManagement.xaml
    /// </summary>
    public partial class UserManagement : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        List<string> sort = new List<string>()
        {
            "Имени",
            "Фамилии",
            "Email",
        };
        List<string> role = new List<string>()
        {
            "User",
            "Admin",
            "Coordinator",
        };
        public UserManagement()
        {
            InitializeComponent();
            UserInAdmin.ItemsSource = db.User.ToList();
            cmbRole.ItemsSource = role;
            cmbSortBy.ItemsSource = sort;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AdminController/AddNewUser.xaml", UriKind.Relative));
        }

        private void btnUser_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (txbFind.Text == "")
            {
                List<User> bdList = db.User.ToList();

                if (cmbRole.SelectedItem != null)
                {
                    if (cmbSortBy.SelectedItem == "Имени")
                    {
                        var sortByName = from b in bdList
                                         where b.Role == cmbRole.SelectedItem.ToString()
                                         orderby b.Name
                                         select b;
                        UserInAdmin.ItemsSource = sortByName;
                    }
                    else if (cmbSortBy.SelectedItem == "Фамилии")
                    {
                        var sortBySurName = from b in bdList
                                            where b.Role == cmbRole.SelectedItem.ToString()
                                            orderby b.Surname
                                            select b;
                        UserInAdmin.ItemsSource = sortBySurName;
                    }
                    else if (cmbSortBy.SelectedItem == "Email")
                    {
                        var sortByEmail = from b in bdList
                                          where b.Role == cmbRole.SelectedItem.ToString()
                                          orderby b.Surname
                                          select b;
                        UserInAdmin.ItemsSource = sortByEmail;
                    }
                    else if (cmbSortBy.SelectedItem == null)
                    {
                        UserInAdmin.ItemsSource = db.User.Where(itemF => itemF.Role == cmbRole.SelectedItem).ToList();
                    }
                    else
                    {
                        UserInAdmin.ItemsSource = db.User.ToList();
                    }
                }
                else
                {
                    if (cmbSortBy.SelectedItem == "Имени")
                    {
                        var sortByName = from b in bdList
                                         orderby b.Name
                                         select b;
                        UserInAdmin.ItemsSource = sortByName;
                    }
                    else if (cmbSortBy.SelectedItem == "Фамилии")
                    {
                        var sortBySurName = from b in bdList
                                            orderby b.Surname
                                            select b;
                        UserInAdmin.ItemsSource = sortBySurName;
                    }
                    else if (cmbSortBy.SelectedItem == "Email")
                    {
                        var sortByEmail = from b in bdList
                                          orderby b.Surname
                                          select b;
                        UserInAdmin.ItemsSource = sortByEmail;
                    }  
                    else if (cmbSortBy.SelectedItem == null)
                    {
                        UserInAdmin.ItemsSource = db.User.Where(itemF => itemF.Role == cmbRole.SelectedItem).ToList();
                    }
                    else
                    {
                        UserInAdmin.ItemsSource = db.User.ToList();
                    }
                }
            }
            else
            {
                UserInAdmin.ItemsSource = db.User.Where(itemF => itemF.Name == txbFind.Text).ToList();
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            UserInAdmin.ItemsSource = db.User.ToList();
            cmbRole.SelectedItem = null;
            cmbSortBy.SelectedItem = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = UserInAdmin.SelectedValue as User;
            AdminEditUser aed = new AdminEditUser(user);
            this.NavigationService.Navigate(aed);
        }
    }
}
