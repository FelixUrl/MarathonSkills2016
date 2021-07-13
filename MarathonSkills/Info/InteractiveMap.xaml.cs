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
    /// Логика взаимодействия для InteractiveMap.xaml
    /// </summary>
    public partial class InteractiveMap : Page
    {
        Uri drink = new Uri("/Info/icons/map-icon-drinks.png", UriKind.Relative);
        Uri energy = new Uri("/Info/icons/map-icon-energy-bars.png", UriKind.Relative);
        Uri med = new Uri("/Info/icons/map-icon-medical.png", UriKind.Relative);
        Uri info = new Uri("/Info/icons/map-icon-information.png", UriKind.Relative);
        Uri wc = new Uri("/Info/icons/map-icon-toilets.png", UriKind.Relative);
        public InteractiveMap()
        {
            InitializeComponent();
        }

        private void btnCheck1_Click(object sender, RoutedEventArgs e)
        {
            txtCheckpoint.Text = "Checkpoint 1";
            imgDrink.Source = new BitmapImage(drink);
            imgEnergy.Source = new BitmapImage(energy);
            imgWC.Source = null;
            imgMed.Source = null;
            imgInfo.Source = null;

        }

        private void btnCheck2_Click(object sender, RoutedEventArgs e)
        {
            txtCheckpoint.Text = "Checkpoint 2";
            imgDrink.Source = new BitmapImage(drink);
            imgEnergy.Source = new BitmapImage(energy);
            imgWC.Source = new BitmapImage(wc);
            imgMed.Source = new BitmapImage(med);
            imgInfo.Source = new BitmapImage(info);
        }

        private void btnCheck3_Click(object sender, RoutedEventArgs e)
        {
            txtCheckpoint.Text = "Checkpoint 3";
            imgDrink.Source = new BitmapImage(drink);
            imgEnergy.Source = new BitmapImage(energy);
            imgWC.Source = new BitmapImage(wc);
            imgMed.Source = null;
            imgInfo.Source = null;
        }

        private void btnCheck4_Click(object sender, RoutedEventArgs e)
        {
            txtCheckpoint.Text = "Checkpoint 4";
            imgDrink.Source = new BitmapImage(drink);
            imgEnergy.Source = new BitmapImage(energy);
            imgWC.Source = new BitmapImage(wc);
            imgMed.Source = new BitmapImage(med);
            imgInfo.Source = null;
        }

        private void btnCheck5_Click(object sender, RoutedEventArgs e)
        {
            txtCheckpoint.Text = "Checkpoint 5";
            imgDrink.Source = new BitmapImage(drink);
            imgEnergy.Source = new BitmapImage(energy);
            imgWC.Source = new BitmapImage(wc);
            imgMed.Source = new BitmapImage(med);
            imgInfo.Source = null;
        }

        private void btnCheck6_Click(object sender, RoutedEventArgs e)
        {
            txtCheckpoint.Text = "Checkpoint 6";
            imgDrink.Source = new BitmapImage(drink);
            imgEnergy.Source = new BitmapImage(energy);
            imgWC.Source = new BitmapImage(wc);
            imgMed.Source = new BitmapImage(med);
            imgInfo.Source = new BitmapImage(info);
        }
    }
}
