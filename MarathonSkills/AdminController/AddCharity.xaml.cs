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

namespace MarathonSkills.AdminController
{
    /// <summary>
    /// Логика взаимодействия для AddCharity.xaml
    /// </summary>
    public partial class AddCharity : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        public AddCharity()
        {
            InitializeComponent();
        }
        private void txbName_GotFocus(object sender, RoutedEventArgs e)
        {
            txbName.Text = "";
            txbName.Foreground = Brushes.Black;
        }
        private void txbDisc_GotFocus(object sender, RoutedEventArgs e)
        {
            txbDisc.Text = "";
            txbDisc.Foreground = Brushes.Black;
        }

        private void btn_Reg_Click(object sender, RoutedEventArgs e)
        {
            if (txbName.Text != "" && txbDisc.Text != "" && txbName.Text != "Наименование")
            {
                if (Validate.IsString(txbName.Text))
                {
                    try
                    {
                        Fund fun = new Fund();

                        fun.Name = txbName.Text;
                        fun.Description = txbDisc.Text;
                        if (imgLogo.Source != null)
                        {
                            fun.Logo = Img.ImageToByteArray(imgLogo.Source as BitmapImage);
                        }
                        db.Fund.Add(fun);
                        db.SaveChanges();
                        this.NavigationService.Navigate(new Uri("Admin/ManageCharities.xaml", UriKind.Relative));
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось выполнить операцию", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Не правильно набрано название", "Ошибка валидации");
                }

            }
            else
            {
                MessageBox.Show("Поля не заполнены", "Ошибка");
            }
        }
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Admin/ManageCharities.xaml", UriKind.Relative));
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.FilterIndex = 2;
            open.Filter = "jpg|*.jpg|  png|*.png";

            if (open.ShowDialog() == true)
            {
                BitmapImage source = new BitmapImage();
                source.BeginInit(); // начало считывания фото
                source.UriSource = new Uri(@"" + open.FileName, UriKind.Relative);
                source.CacheOption = BitmapCacheOption.OnLoad; //Задержка
                source.EndInit();

                txbFile.Text = source.ToString();
                imgLogo.Source = source;
            }
        }
    }
}
