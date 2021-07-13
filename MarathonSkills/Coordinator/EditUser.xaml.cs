using System;
using System.Collections.Generic;
using System.IO;
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

namespace MarathonSkills.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        User u;
        public EditUser(User user)
        {
            InitializeComponent();
            u = user;
            List<StatisticsMarathon> stm = db.StatisticsMarathon.ToList();


            Uri resourceUri = new Uri("/tick-icon.png", UriKind.Relative);
            imgReg.Source = new BitmapImage(resourceUri);
            if (user.Payment == 1)
            {
                Uri resourceUri1 = new Uri("/tick-icon.png", UriKind.Relative);
                imgPayment.Source = new BitmapImage(resourceUri1);
            }
            else
            {
                Uri resourceUri1 = new Uri("/cross-icon.png", UriKind.Relative);
                imgPayment.Source = new BitmapImage(resourceUri1);
            }
            Uri resourceUri2 = new Uri("/cross-icon.png", UriKind.Relative);
            imgInv.Source = new BitmapImage(resourceUri2);
            Uri resourceUri3 = new Uri("/cross-icon.png", UriKind.Relative);
            imgStart.Source = new BitmapImage(resourceUri3);



            txbEmail.Text = user.Email.ToString();
            txbName.Text = user.Name.ToString();
            txbSurName.Text = user.Surname.ToString();
            txbGender.Text = user.Gender.ToString();
            txbDateOf.Text = user.DateOfBirth.ToString();
            txbCountry.Text = user.Country.ToString();
            txbFund.Text = db.Fund.Where(x => x.ID == user.ID_Fund).Select(x => x.Name).SingleOrDefault();
            txbMoney.Text = "$" + db.Fund.Where(x => x.ID == user.ID_Fund).Select(x => x.Money.ToString()).SingleOrDefault();
            txbTypeInv.Text = db.Inventory.Where(x => x.ID == user.ID_Inventory).Select(x => x.Name).SingleOrDefault();

            var Name = from sm in stm
                       from m in db.Marathon
                       where m.ID == sm.ID_Marathon && sm.ID_User == user.ID
                       select m.Name;

            foreach (var v in Name)
            {
                txbDistance.Text += v.ToString() + " ";
            }

            using (var stream = new MemoryStream(user.Photo))
            {
                var decoder = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                imgUser.Source = decoder.Frames[0];
            }



        }

        private void btnShowSerf_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnPrintB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditProf_Click(object sender, RoutedEventArgs e)
        {
            Admin.AdminEditUser aeu = new Admin.AdminEditUser(u);
            NavigationService.Navigate(aeu);
        }
    }
}
