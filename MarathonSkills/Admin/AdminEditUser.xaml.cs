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
    /// Логика взаимодействия для AdminEditUser.xaml
    /// </summary>
    public partial class AdminEditUser : Page
    {
        List<string> role = new List<string>()
        {
            "User",
            "Admin",
            "Coordinator",
        };
        List<User> us = new List<User>();
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        string pas = "";
        int id = 0;
        public AdminEditUser(User user)
        {
            InitializeComponent();
            txbEmail.Text = user.Email;
            txb_name.Text = user.Name;
            txb_surname.Text = user.Surname;
            cmbRole.SelectedValue = user.Role;
            cmbRole.ItemsSource = role;
            txb_pass.Password = user.Password;
            txb_repeatpass.Password = user.Password;
            id = user.ID;
        }


        private void txb_pass_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_pass.Foreground = Brushes.Black;
        }
        private void txb_repeatpass_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_repeatpass.Foreground = Brushes.Black;
        }
        private void txb_name_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_name.Text = "";
            txb_name.Foreground = Brushes.Black;
        }
        private void txb_surname_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_surname.Text = "";
            txb_surname.Foreground = Brushes.Black;
        }

        private void btn_Reg_Click(object sender, RoutedEventArgs e)
        {
            if (txb_name.Text != "" && txb_pass.Password != "" && txb_repeatpass.Password != "" && txb_surname.Text != "" && cmbRole.SelectedItem != null)
            {
                if (txb_pass.Password == txb_repeatpass.Password)
                {
                    if (Validate.IsValidEmail(txbEmail.Text))
                    {
                        if (Validate.IsString(txb_name.Text))
                        {
                            if (Validate.IsString(txb_surname.Text))
                            {
                                try
                                {
                                    foreach (User p in db.User)
                                    {
                                        if (p.ID == id)
                                        {
                                            p.Email = txbEmail.Text;
                                            p.Password = txb_pass.Password;
                                            p.Name = txb_name.Text;
                                            p.Surname = txb_surname.Text;
                                            p.Role = Convert.ToString(cmbRole.SelectedItem);
                                        }
                                    }
                                    db.SaveChanges();
                                    this.NavigationService.Navigate(new Uri("Admin/UserManagement.xaml", UriKind.Relative));
                                }
                                catch
                                {
                                    MessageBox.Show("Не удалось отредактировать пользователя", "Ошибка");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не валидная фамилия", "Ошибка");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не валидное имя", "Ошибка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не валидный e-mail", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Пороли не совпадают", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Поля не заполнены", "Ошибка");
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Admin/UserManagement.xaml", UriKind.Relative));
        }
    }
}
