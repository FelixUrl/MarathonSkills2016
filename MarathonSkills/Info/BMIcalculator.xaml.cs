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

namespace MarathonSkills.Info
{
    /// <summary>
    /// Логика взаимодействия для BMIcalculator.xaml
    /// </summary>
    public partial class BMIcalculator : Page
    {
        public BMIcalculator()
        {
            InitializeComponent();
            triangle.Opacity = 0;
            triangle1.Opacity = 0;
            triangle2.Opacity = 0;
            triangle3.Opacity = 0;
        }
        private void btnFemale_Click(object sender, RoutedEventArgs e)
        {
            btnMale.IsEnabled = true;
            check_male.IsChecked = false;
            check_female.IsChecked = true;
            btnFemale.IsEnabled = false;
            imgfemale.Visibility = Visibility.Visible;
            imgmale.Visibility = Visibility.Hidden;
        }

        private void btnMale_Click(object sender, RoutedEventArgs e)
        {
            btnFemale.IsEnabled = true;
            check_female.IsChecked = false;
            check_male.IsChecked = true;
            btnMale.IsEnabled = false;
            imgmale.Visibility = Visibility.Visible;
            imgfemale.Visibility = Visibility.Hidden;
        }

        private void btn_calc_Click(object sender, RoutedEventArgs e)
        {
            if(txbWeight.Text != "" && txbHeight.Text != "")
            {
                if (check_female.IsChecked == false && check_male.IsChecked == false)
                {
                    MessageBox.Show("Вы не выбрали пол");
                }
                else
                {
                    if (Validate.IsNumber(txbHeight.Text))
                    {
                        if (Validate.IsNumber(txbWeight.Text))
                        {
                            double h = Convert.ToInt32(txbHeight.Text);
                            double w = Convert.ToInt32(txbWeight.Text); //вес
                            double hc = 0;
                            hc = h * 0.01;
                            double BMI = w / (hc * hc);
                            if (BMI < 18.5)
                            {
                                triangle1.Opacity = 0;
                                triangle2.Opacity = 0;
                                triangle3.Opacity = 0;
                                triangle.Opacity = 0;
                                triangle.Opacity = 1;
                                Uri resourceUri = new Uri("/Info/icons/bmi-underweight-icon.png", UriKind.Relative);
                                imgStat.Source = new BitmapImage(resourceUri);
                            }
                            if (BMI >= 18.5 && BMI < 24.9)
                            {
                                triangle.Opacity = 0;
                                triangle1.Opacity = 0;
                                triangle2.Opacity = 0;
                                triangle3.Opacity = 0;
                                triangle1.Opacity = 1;
                                Uri resourceUri = new Uri("/Info/icons/bmi-healthy-icon.png", UriKind.Relative);
                                imgStat.Source = new BitmapImage(resourceUri);
                            }
                            if (BMI >= 25 && BMI < 29.9)
                            {
                                triangle.Opacity = 0;
                                triangle1.Opacity = 0;
                                triangle2.Opacity = 0;
                                triangle3.Opacity = 0;
                                triangle2.Opacity = 1; 
                                Uri resourceUri = new Uri("/Info/icons/bmi-overweight-icon.png", UriKind.Relative);
                                imgStat.Source = new BitmapImage(resourceUri);
                            }
                            if (BMI > 30)
                            {
                                triangle.Opacity = 0;
                                triangle1.Opacity = 0;
                                triangle2.Opacity = 0;
                                triangle3.Opacity = 0;
                                triangle3.Opacity = 1;
                                Uri resourceUri = new Uri("/Info/icons/bmi-obese-icon.png", UriKind.Relative);
                                imgStat.Source = new BitmapImage(resourceUri);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Это не значение", "Ошибка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Это не значение", "Ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
            
             
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Info/InfoMenu.xaml", UriKind.Relative));
        }

     

        private void txbHeight_GotFocus(object sender, RoutedEventArgs e)
        {
            txbHeight.Text = "";
        }

        private void txbWeight_GotFocus(object sender, RoutedEventArgs e)
        {
            txbWeight.Text = "";
        }

    }
}
