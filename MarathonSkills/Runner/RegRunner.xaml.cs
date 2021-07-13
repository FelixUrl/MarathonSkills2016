using Microsoft.Win32;
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

namespace MarathonSkills.Runner
{
    /// <summary>
    /// Логика взаимодействия для RegRunner.xaml
    /// </summary>
    public partial class RegRunner : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        public RegRunner()
        {
            InitializeComponent();
            var gender = new List<string> { "Male", "Female" };
            var country = new List<string>
            {
                "Andora", "Argentina", "Australia","Austria","Belgium","Botswana","Brazil","Bulgaria","Cameroon","Canada","Central Africa","Chile","China","Chinese Taipei","Colombia","Croatia","Czech Republic","Denmark","Dominican Republic","Ecuador","Egypt","El Salvador","Equatorial Guinea","Esonia","Finland","France","Germany","Greece","Guatemala","Guinea","Guinea-Bissau","Honduras","Hong Kong","Hungary","India","Indonesia","Ireland","Israel","Italy","Ivory Coast","Jamaica","Japan","Jordan","Kenya","Latvia", "Liechtenstein","Lithuania","Luxemburg", "Macau", "Macedonia", "Madagascar", "Malaysia", "Mali", "Malta", "Mauritius", "Mexico", "Moldova", "Monaco", "Montenegro", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Norway", "Panama", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Romania", "Russia", "Saudi Arabia", "Senegal", "Singapore","Slovakia", "South Africa", "South Korea", "Spain", "Sweden", "Switzerland", "Thailand", "Turkey", "Unitied Arab Emirates", "Inited Kingdom", "Uruguay", "USA", "Vatican", "Venezuela", "Vietnam"
            };
            cmb_gender.ItemsSource = gender;
            cmbCountry.ItemsSource = country;
        }

        private void btn_source_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.FilterIndex = 2;
            open.Filter = "jpg|*.jpg| png|*.png";

            if (open.ShowDialog() == true)
            {
                BitmapImage source = new BitmapImage();
                source.BeginInit(); // начало считывания фото
                source.UriSource = new Uri(@"" + open.FileName, UriKind.Relative);
                source.CacheOption = BitmapCacheOption.OnLoad; //Задержка
                source.EndInit();

                imgAvatar.Source = source;
                imgAvatar.Stretch = Stretch.Uniform;
            }
        }

        private void btn_Reg_Click(object sender, RoutedEventArgs e)
        {
            if (txb_email.Text != "" && txb_name.Text != "" && txb_pass.Text != "" && txb_repeatpass.Text != "" && txb_surname.Text != "" && txb_email.Text != "Email" && txb_surname.Text != "Фамилия")
            {
                var check = (from b in db.User
                             where b.Email == txb_email.Text
                             select b).SingleOrDefault();
                if (check == null)
                {
                    if (txb_pass.Text == txb_repeatpass.Text)
                    {
                        if (Validate.IsValidEmail(txb_email.Text))
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
                                            Gender = cmb_gender.SelectedItem.ToString(),
                                            Photo = Img.ImageToByteArray(imgAvatar.Source as BitmapImage),
                                            Country = cmbCountry.Text,
                                            Role = "User",
                                            DateOfBirth = dateBirth.SelectedDate,
                                        };
                                        db.User.Add(user);
                                        db.SaveChanges();
                                        this.NavigationService.Navigate(new Uri("Runner/AuthRunner.xaml", UriKind.Relative));
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Не удалось зарегистрирвоать пользователя","Ошибка");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Нарушена валидация фамилии", "Ошибка");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Нарушена валидация имени", "Ошибка");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Нарушена валидация e-mail", "Ошибка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль не совпадает");
                    }
                }
                else
                {
                    MessageBox.Show("Такой e-mail уже существует","Ошибка");
                }

            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Runner/AuthRegRunner.xaml", UriKind.Relative));
        }

        private void txb_email_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_email.Text = "";
        }

        private void txb_pass_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_pass.Text = "";
        }

        private void txb_repeatpass_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_repeatpass.Text = "";
        }

        private void txb_name_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_name.Text = "";
        }

        private void txb_surname_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_surname.Text = "";
        }

        private void txb_pathphoto_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_pathphoto.Text = "";
        }
    }
}
