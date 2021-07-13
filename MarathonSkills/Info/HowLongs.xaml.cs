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
    /// Логика взаимодействия для HowLong.xaml
    /// </summary>
    public partial class HowLongs : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        public HowLongs()
        {
            InitializeComponent();
            gridDistance.ItemsSource = db.HowLong.Where(x => x.Speed == null).ToList();
            gridSpeed.ItemsSource = db.HowLong.Where(x => x.Length == null).ToList();
        }

        private void gridDistance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            HowLong element = gridDistance.SelectedValue as HowLong;
            if (element != null)
            {
                txtInfo.Text = Convert.ToString(element.Length);
                txtName.Text = element.Name;
                imgInfo.Source = Img.ToBitmapImage(element.Image);
            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали", "Ошибка");
            }
        }

        private void gridSpeed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HowLong element = gridSpeed.SelectedValue as HowLong;
            if (element != null)
            {
                txtInfo.Text = Convert.ToString(element.Speed);
                txtName.Text = element.Name;
                imgInfo.Source = Img.ToBitmapImage(element.Image);
            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали", "Ошибка");
            }
        }
    }
}
