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
    /// Логика взаимодействия для AdmissionInventory.xaml
    /// </summary>
    public partial class AdmissionInventory : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        public AdmissionInventory()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(txbNumber.Text != "" || txbBase.Text != "" || txbPolo.Text != "")
            {
                if(txbNumber.Text != "")
                {
                    int count = Convert.ToInt32(txbNumber.Text);
                    int countref = (int)db.Inventory.Where(x => x.ID == 1).Select(x => x.Count).SingleOrDefault();
                    db.Database.ExecuteSqlCommand($"UPDATE Inventory SET Count={countref + count} WHERE ID=1");
                }
                if(txbBase.Text != "")
                {
                    int count = Convert.ToInt32(txbBase.Text);
                    int countref = (int)db.Inventory.Where(x => x.ID == 2).Select(x => x.Count).SingleOrDefault();
                    db.Database.ExecuteSqlCommand($"UPDATE Inventory SET Count={countref + count} WHERE ID=2");
                }
                if (txbPolo.Text != "")
                {
                    int count = Convert.ToInt32(txbPolo.Text);
                    int countref = (int)db.Inventory.Where(x => x.ID == 3).Select(x => x.Count).SingleOrDefault();
                    db.Database.ExecuteSqlCommand($"UPDATE Inventory SET Count={countref + count} WHERE ID=3");
                }
            }
            else 
            {
                MessageBox.Show("Заполните хотябы 1 поле","Ошибка");
            }

            db.SaveChanges();
            this.NavigationService.Navigate(new Uri("Admin/InventoryMarathon.xaml", UriKind.Relative));
        }

        private void txbNumber_TextChanged(object sender, TextChangedEventArgs e)
        { 
            txbRFID.Text = txbNumber.Text;
        }

        private void txbRFID_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbNumber.Text = txbRFID.Text;
        }

        private void txbBase_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbBottle.Text = txbBase.Text;
        }

        private void txbBottle_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbBase.Text = txbBottle.Text;
        }

        private void txbSuvenir_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbPolo.Text = txbSuvenir.Text;
        }

        private void txbPolo_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbSuvenir.Text = txbPolo.Text;
        }
    }
}
