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

namespace MarathonSkills.Admin
{
    /// <summary>
    /// Логика взаимодействия для Inventory.xaml
    /// </summary>
    public partial class InventoryMarathon : Page
    {
        MarathonSkillsEntities db = new MarathonSkillsEntities();
        string item;
        string[] splited_item;
        public InventoryMarathon()
        {
            InitializeComponent();
            List<Elements> inf = new List<Elements>();
            List<User> users = db.User.ToList();

            int cnt = 0;
            int cnt2 = 0;
            int cnt3 = 0;
            foreach(var us in users)
            {
                if (us.ID_Inventory == 1)
                {
                    cnt++; 
                }
                if (us.ID_Inventory == 2)
                {
                    cnt2++;
                }
                if (us.ID_Inventory == 3)
                {
                    cnt3++;
                }
            }
            foreach (var b in db.Inventory)
            {
                
                item = b.Name.Replace("(","");
                item = item.Replace(")","");
                splited_item = item.Split('+');
                foreach(var s in splited_item)
                {
                    if (s == "Номер бегуна")
                    {
                        inf.Add(new Elements
                        {
                            Name = "Номер бегуна",
                            TypeA = cnt,
                            TypeB = cnt2,
                            TypeC = cnt3,
                            Need = cnt + cnt2 + cnt3,
                            ostatok = (int)(b.Count - (cnt + cnt2 + cnt3)),
                        });
                    }
                    if (s == "RFID браслет")
                    {
                        inf.Add(new Elements
                        {
                            Name = "RFID браслет",
                            TypeA = cnt,
                            TypeB = cnt2,
                            TypeC = cnt3,
                            Need = cnt + cnt2 + cnt3,
                            ostatok = (int)(b.Count - (cnt + cnt2 + cnt3)),
                        });
                    }
                    if (s == "Бейсболка")
                    {
                        inf.Add(new Elements
                        {
                            Name = "Бейсболка",
                            TypeB = cnt2,
                            TypeC = cnt3,
                            Need = cnt2 + cnt3,
                            ostatok = (int)(b.Count - (cnt2 + cnt3)),
                        });
                    }
                    if (s == "Бутылка воды")
                    {
                        inf.Add(new Elements
                        {
                            Name = "Бутылка воды",
                            TypeB = cnt2,
                            TypeC = cnt3,
                            Need = cnt2 + cnt3,
                            ostatok = (int)(b.Count - (cnt2 + cnt3)),
                        });
                    }
                    if (s == "Футболка")
                    {
                        inf.Add(new Elements
                        {
                            Name = "Футболка",
                            TypeC = cnt3,
                            Need = cnt3,
                            ostatok = (int)(b.Count - (cnt3)),
                        });
                    }
                    if (s == "Сувенирный буклет")
                    {
                        inf.Add(new Elements
                        {
                            Name = "Сувенирный буклет",
                            TypeC = cnt3,
                            Need = cnt3,
                            ostatok = (int)(b.Count - (cnt3)),
                        });
                    }
                }
            }

            gridInventory.ItemsSource = inf;
        }

        private void btnAdmission_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AdminController/AdmissionInventory.xaml", UriKind.Relative));
        }
    }
}
