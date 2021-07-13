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

namespace MarathonSkills.Sponsor
{
    /// <summary>
    /// Логика взаимодействия для Pay.xaml
    /// </summary>
    public partial class Pay : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        public Pay()
        {
            InitializeComponent();
            cmbRunner.ItemsSource = db.User.Where(x => x.Role == "User").ToList();
        }

        private void btn_pay_Click(object sender, RoutedEventArgs e)
        {
            if(txb_cardholder.Text != null && txb_cardnum.Text != null && txb_mouth.Text != null && txb_name.Text != null && txb_year.Text != null && cmbRunner.SelectedIndex != -1)
            { string sponsor_name = txb_name.Text;
                var check = (from b in db.SponsorRunner
                             where b.Name == sponsor_name
                             select b).SingleOrDefault();
                if(check == null)
                {
                    db.SponsorRunner.Add(new SponsorRunner
                    {
                        Name = sponsor_name
                    });
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже есть","Ошибка");
                }

                try
                {
                    decimal count = Convert.ToDecimal(txt_price.Text);
                    var user = (cmbRunner.SelectedItem as User).ID_Fund;
                    List<Fund> fund = db.Fund.ToList();
                    List<SponsorRunner> sponsor = db.SponsorRunner.ToList();
                    decimal countref = (decimal)fund.Where(x => x.ID == user).Select(x => x.Money).SingleOrDefault();
                    int id_sponsor = sponsor.Where(x => x.Name == sponsor_name).Select(x => x.ID).SingleOrDefault();
                    decimal money = count + countref;
                    int money_int = Convert.ToInt32(money);
                    db.Database.ExecuteSqlCommand($"UPDATE Fund SET Money={money_int}, ID_Sponsor={id_sponsor} WHERE ID={user}");
                    db.SaveChanges();
                    ThanksPay thxForPay = new ThanksPay(txt_price.Text, txt_fund.Text, Convert.ToString(cmbRunner.SelectedValue));
                    NavigationService.Navigate(thxForPay);
                }
                catch
                {
                    MessageBox.Show("Не удалось выполнить операцию", "Ошибка");
                }
                
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка");
            }
            
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btn_pricesum_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt64(Convert.ToInt64(txt_price.Text) + Convert.ToInt64(txb_price_num.Text)) <= 10000)
            {
                txt_price.Text = Convert.ToString(Convert.ToInt32(txt_price.Text) + Convert.ToInt32(txb_price_num.Text));
            }
        }

        private void btn_pricemin_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(Convert.ToInt32(txt_price.Text) - Convert.ToInt32(txb_price_num.Text)) > 0)
            {
                txt_price.Text = Convert.ToString(Convert.ToInt32(txt_price.Text) - Convert.ToInt32(txb_price_num.Text));
            }
        }

        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);

        }


        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }

        private void cmbRunner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var user = cmbRunner.SelectedItem as User;
            List<Fund> fund = db.Fund.ToList();
            txt_fund.Text = fund.Where(x => x.ID == user.ID_Fund).Select(x => x.Name).SingleOrDefault();
        }
        private void txb_cardnum_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_cardnum.Text = "";
        }

        private void txb_name_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_name.Text = "";
        }

        private void txb_cardholder_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_cardholder.Text = "";
        }

        private void txb_mouth_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_mouth.Text = "";
        }

        private void txb_year_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_year.Text = "";
        }

        private void txb_year_Copy_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_year_Copy.Text = "";
        }
    }
}
