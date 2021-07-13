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

namespace MarathonSkills.Runner
{
    /// <summary>
    /// Логика взаимодействия для EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        public EditProfile(List<User> user)
        {
            InitializeComponent();
            string urgender = user.Select(x => x.Gender).SingleOrDefault();
            string urcountry = user.Select(x => x.Country).SingleOrDefault();
            txt_email.Text = user.Select(x => x.Email).SingleOrDefault();
            txb_name.Text = user.Select(x => x.Name).SingleOrDefault();
            txb_surname.Text = user.Select(x => x.Surname).SingleOrDefault();
            List<string> gender = new List<string> { "Male", "Female" };
            cmb_gender.ItemsSource = gender;
            cmb_gender.SelectedValue = gender.Find(x => x.Length == urgender.Length);
            dateBirth.SelectedDate = user.Select(x => x.DateOfBirth).SingleOrDefault();
            var country = new List<string> { "Andora", "Argentina", "Australia", "Austria", "Belgium", "Botswana", "Brazil", "Bulgaria", "Cameroon", "Canada", "Central Africa", "Chile", "China", "Chinese Taipei", "Colombia", "Croatia", "Czech Republic", "Denmark", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Esonia", "Finland", "France", "Germany", "Greece", "Guatemala", "Guinea", "Guinea-Bissau", "Honduras", "Hong Kong", "Hungary", "India", "Indonesia", "Ireland", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan", "Jordan", "Kenya", "Latvia", "Liechtenstein", "Lithuania", "Luxemburg", "Macau", "Macedonia", "Madagascar", "Malaysia", "Mali", "Malta", "Mauritius", "Mexico", "Moldova", "Monaco", "Montenegro", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Norway", "Panama", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Romania", "Russia", "Saudi Arabia", "Senegal", "Singapore", "Slovakia", "South Africa", "South Korea", "Spain", "Sweden", "Switzerland", "Thailand", "Turkey", "Unitied Arab Emirates", "Inited Kingdom", "Uruguay", "USA", "Vatican", "Venezuela", "Vietnam" };
            cmbCountry.ItemsSource = country;
            cmbCountry.SelectedValue = country.Find(x => x == urcountry);
            imgAvatar.Source = Img.ToBitmapImage(user.Select(x => x.Photo).SingleOrDefault());
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (txb_name.Text != "" && txb_pass.Password != "" && txb_repeatpass.Password != "" && txb_surname.Text != "")
            {
                if (txb_pass.Password == txb_repeatpass.Password)
                {
                    if (Validate.IsString(txb_name.Text))
                    {
                        if (Validate.IsString(txb_surname.Text))
                        {
                            User user = new User
                            {
                                Password = txb_pass.Password,
                                Name = txb_name.Text,
                                Surname = txb_surname.Text,
                                Gender = cmb_gender.SelectedItem.ToString(),
                                Photo = Img.ImageToByteArray(imgAvatar.Source as BitmapImage),
                                Country = cmbCountry.Text,
                                DateOfBirth = dateBirth.SelectedDate,
                            };
                            db.User.Add(user);
                            db.SaveChanges();
                            this.NavigationService.Navigate(new Uri("Runner/AuthRunner.xaml", UriKind.Relative));
                        }
                        else
                        {
                            MessageBox.Show("Нарушена валидация e-mail", "Ошибка");
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
                MessageBox.Show("Не все поля заполнены");
            }

        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
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

        private void txb_pass_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_pass.Password = "";
        }

        private void txb_repeatpass_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_repeatpass.Password = "";
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
