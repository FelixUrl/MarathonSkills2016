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

namespace MarathonSkills.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для ShowFund.xaml
    /// </summary>
    public partial class ShowFund : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        public ShowFund()
        {
            InitializeComponent();
            FundDb.ItemsSource = db.Fund.ToList();
            var totalCount = db.Fund.Count();
            var totaMoney = db.Fund.Select(x=> x.Money).Sum();

           txbCount.Text = totalCount.ToString();
           txbMoney.Text = "$"+totaMoney.ToString();

        }
    }
}
