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

namespace MarathonSkills.AdminController
{
    /// <summary>
    /// Логика взаимодействия для AddNewUser.xaml
    /// </summary>
    public partial class AddNewUser : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        List<string> role = new List<string>()
        {
            "User",
            "Admin",
            "Coordinator",
        };
        public AddNewUser()
        {
            InitializeComponent();
            cmbRole.ItemsSource = role;
        }

        private void txb_email_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_email.Text = "";
            txb_email.Foreground = Brushes.Black;
        }
        private void txb_pass_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_pass.Text = "";
            txb_pass.Foreground = Brushes.Black;
        }
        private void txb_repeatpass_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_repeatpass.Text = "";
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
            if (txb_email.Text != "" && txb_name.Text != "" && txb_pass.Text != "" && txb_repeatpass.Text != "" && txb_surname.Text != "" && txb_email.Text != "Email" && txb_surname.Text != "Фамилия")
            {
                if (txb_pass.Text == txb_repeatpass.Text)
                {
                    if (Validate.IsValidEmail(txb_email.Text))
                    {
                        var check = (from b in db.User
                                     where b.Email == txb_email.Text
                                     select b).SingleOrDefault();
                        if(check == null)
                        {
                            if (Validate.IsString(txb_name.Text))
                            {
                                if (Validate.IsString(txb_surname.Text))
                                {
                                    try
                                    {
                                        User user = new User
                                        {
                                            Email = txb_email.Text,
                                            Password = txb_pass.Text,
                                            Name = txb_name.Text,
                                            Surname = txb_surname.Text,
                                            Role = Convert.ToString(cmbRole.SelectedItem),
                                        };
                                        db.User.Add(user);
                                        db.SaveChanges();
                                        this.NavigationService.Navigate(new Uri("Admin/UserManagement.xaml", UriKind.Relative));
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Не удалось выполнить операцию", "Ошибка");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Некорректная фамилия", "Ошибка валидации");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Некорректное имя", "Ошибка валидации");
                            }
                        }
                        else
                        {
                            MessageBox.Show("такой e-mail уже есть в бд", "Ошибка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Некорректный e-mail", "Ошибка валидации");
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
