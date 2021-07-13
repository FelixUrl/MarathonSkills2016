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
    /// Логика взаимодействия для PerviousResult.xaml
    /// </summary>
    public partial class PerviousResult : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        public PerviousResult()
        {
            InitializeComponent();
            List<string> gender = new List<string> { "Male", "Female" };
            List<string> age = new List<string> { "18-27", "27-36", "36-49" };
            cmbMarathon.ItemsSource = db.Marathon.ToList();
            cmbDistance.ItemsSource = db.Marathon.ToList();
            cmbGender.ItemsSource = gender;
            cmbAge.ItemsSource = age;
            gridResult.ItemsSource = db.Marathon.ToList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {           
            if (cmbDistance.SelectedIndex != -1 && cmbMarathon.SelectedIndex != -1)
            {
                double distance = (double)(cmbDistance.SelectedValue as Marathon).Distance;
                string marathon = (cmbMarathon.SelectedValue as Marathon).Name;
                gridResult.ItemsSource = db.Marathon.Where(x => x.Distance == distance).Where(y=>y.Name == marathon).ToList();
            }
            if(cmbDistance.SelectedIndex != -1 && cmbMarathon.SelectedIndex == -1)
            {
                double distance = (double)(cmbDistance.SelectedValue as Marathon).Distance;
                gridResult.ItemsSource = db.Marathon.Where(x => x.Distance == distance).ToList();
            }
            if (cmbDistance.SelectedIndex == -1 && cmbMarathon.SelectedIndex != -1)
            {
                string marathon = (cmbMarathon.SelectedValue as Marathon).Name;
                gridResult.ItemsSource = db.Marathon.Where(y => y.Name == marathon).ToList();
            }
        }
    }
}
