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
using Excel = Microsoft.Office.Interop.Excel;

namespace MarathonSkills.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для ManagRunner.xaml
    /// </summary>
    public partial class ManagRunner : Page
    {
        class SortUser : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                return x.Name == y.Name && x.Surname == y.Surname && x.Email == y.Email;
            }
            public int GetHashCode(User x)
            {
                return (x.Name + "_" + x.Surname + "_" + x.Email).GetHashCode();
            }
        }

        MarathonSkillsEntities db = new MarathonSkillsEntities();
        List<string> pay = new List<string>() {
            "Оплата подтвержена",
            "Оплата не подтвержена",
        };
        List<string> sort = new List<string>()
        {
            "Имени",
            "Фамилии",
            "Email",
        };

        public ManagRunner()
        {
            InitializeComponent();
            UserInCoord.ItemsSource = db.User.Where(x => x.Role == "User").ToList();
            cmbPayment.ItemsSource = pay;
            cmbSortBy.ItemsSource = sort;
            cmbDistance.ItemsSource = db.Marathon.ToList();
        }
        private void btnUserUpdate_Click(object sender, RoutedEventArgs e)
        {
            int pay = 0;

            List<User> bdList = db.User.ToList();
            List<StatisticsMarathon> stm = db.StatisticsMarathon.ToList();
            List<Marathon> sm = db.Marathon.ToList();

            if (cmbPayment.SelectedItem != null)
            {
                if (cmbPayment.SelectedItem == "Оплата подтвержена")
                {
                    pay = 1;
                }

                if (cmbDistance.SelectedItem != null)
                {
                    if (cmbSortBy.SelectedItem == "Имени")
                    {
                        var sortByName = from n in bdList
                                         from b in stm
                                         from m in sm
                                         where pay == n.Payment && n.ID == b.ID_User && m.ID == b.ID_Marathon
                                         orderby n.Name
                                         select n;
                        var distinctsort = sortByName.Distinct(new SortUser());
                        UserInCoord.ItemsSource = distinctsort;
                    }
                    else if (cmbSortBy.SelectedItem == "Фамилии")
                    {
                        var sortBySurName = from n in bdList
                                            from b in stm
                                            from m in sm
                                            where pay == n.Payment && n.ID == b.ID_User && m.ID == b.ID_Marathon
                                            orderby n.Surname
                                            select n;
                        var distinctsort = sortBySurName.Distinct(new SortUser());
                        UserInCoord.ItemsSource = distinctsort;
                    }
                    else if (cmbSortBy.SelectedItem == "Email")
                    {
                        var sortByEmail = from n in bdList
                                          from b in stm
                                          from m in sm
                                          where pay == n.Payment && n.ID == b.ID_User && m.ID == b.ID_Marathon
                                          orderby n.Email
                                          select n;
                        var distinctsort = sortByEmail.Distinct(new SortUser());
                        UserInCoord.ItemsSource = distinctsort;
                    }
                    else if (cmbSortBy.SelectedItem == null)
                    {
                        var sortByNot = from n in bdList
                                        from b in stm
                                        from m in sm
                                        where pay == n.Payment && n.ID == b.ID_User && m.ID == b.ID_Marathon
                                        select n;
                        var distinctsort = sortByNot.Distinct(new SortUser());
                        UserInCoord.ItemsSource = distinctsort;
                    }
                    else
                    {
                        UserInCoord.ItemsSource = db.User.ToList();
                    }
                }
                else
                {
                    if (cmbSortBy.SelectedItem == "Имени")
                    {
                        var sortByName = from b in bdList
                                         where pay == b.Payment
                                         orderby b.Name
                                         select b;
                        UserInCoord.ItemsSource = sortByName;
                    }
                    else if (cmbSortBy.SelectedItem == "Фамилии")
                    {
                        var sortBySurName = from b in bdList
                                            where pay == b.Payment
                                            orderby b.Surname
                                            select b;
                        UserInCoord.ItemsSource = sortBySurName;
                    }
                    else if (cmbSortBy.SelectedItem == "Email")
                    {
                        var sortByEmail = from b in bdList
                                          where pay == b.Payment
                                          orderby b.Email
                                          select b;
                        UserInCoord.ItemsSource = sortByEmail;
                    }
                    else if (cmbSortBy.SelectedItem == null)
                    {
                        var sortByNot = from b in bdList
                                        where pay == b.Payment
                                        select b;
                        UserInCoord.ItemsSource = sortByNot;
                    }
                    else
                    {
                        UserInCoord.ItemsSource = db.User.ToList();
                    }
                }
            }
            else
            {
                if (cmbDistance.SelectedItem != null)
                {

                    if (cmbSortBy.SelectedItem == "Имени")
                    {
                        var SortByName = from b in stm
                                         from n in bdList
                                         from m in sm
                                         where n.ID == b.ID_User && m.ID == b.ID_Marathon
                                         orderby n.Name
                                         select n;
                        var distinctsort = SortByName.Distinct(new SortUser());

                        UserInCoord.ItemsSource = distinctsort;
                    }
                    else if (cmbSortBy.SelectedItem == "Фамилии")
                    {
                        var SortBySurName = from b in stm
                                            from n in bdList
                                            from m in sm
                                            where n.ID == b.ID_User && m.ID == b.ID_Marathon
                                            orderby n.Surname
                                            select n;
                        var distinctsort = SortBySurName.Distinct(new SortUser());

                        UserInCoord.ItemsSource = distinctsort;
                    }
                    else if (cmbSortBy.SelectedItem == "Email")
                    {
                        var SortByEmail = from b in stm
                                          from n in bdList
                                          from m in sm
                                          where n.ID == b.ID_User && m.ID == b.ID_Marathon
                                          orderby n.Email
                                          select n;
                        var distinctsort = SortByEmail.Distinct(new SortUser());

                        UserInCoord.ItemsSource = distinctsort;
                    }
                    else if (cmbSortBy.SelectedItem == null)
                    {
                        var SortByNot = from b in stm
                                        from n in bdList
                                        from m in sm
                                        where n.ID == b.ID_User && m.ID == b.ID_Marathon
                                        select n;

                        UserInCoord.ItemsSource = SortByNot.Distinct();
                    }
                    else
                    {
                        UserInCoord.ItemsSource = db.User.ToList();
                    }
                }
                else
                {
                    if (cmbSortBy.SelectedItem == "Имени")
                    {
                        var sortByName = from b in bdList
                                         orderby b.Name
                                         select b;
                        UserInCoord.ItemsSource = sortByName;
                    }
                    else if (cmbSortBy.SelectedItem == "Фамилии")
                    {
                        var sortBySurName = from b in bdList
                                            orderby b.Surname
                                            select b;
                        UserInCoord.ItemsSource = sortBySurName;
                    }
                    else if (cmbSortBy.SelectedItem == "Email")
                    {
                        var sortByEmail = from b in bdList
                                          orderby b.Email
                                          select b;
                        UserInCoord.ItemsSource = sortByEmail;
                    }
                    else if (cmbSortBy.SelectedItem == null)
                    {
                        var sortByNot = from b in bdList
                                        select b;
                        UserInCoord.ItemsSource = sortByNot;

                    }
                    else
                    {
                        UserInCoord.ItemsSource = db.User.ToList();
                    }
                }
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            UserInCoord.ItemsSource = db.User.ToList();
            cmbDistance.SelectedIndex = -1;
            cmbPayment.SelectedIndex = -1;
            cmbPayment.SelectedIndex = -1;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = UserInCoord.SelectedValue as User;
            EditUser aed = new EditUser(user);
            this.NavigationService.Navigate(aed);
        }
        private void btnInExecel_Click(object sender, RoutedEventArgs e)
        {
            //Объявляем приложение
            Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();
            //Количество листов в рабочей книге
            ex.SheetsInNewWorkbook = 2;
            ex.Visible = true;
            //Добавить рабочую книгу
            Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);
            //Отключить отображение окон с сообщениями
            ex.DisplayAlerts = false;
            //Получаем первый лист документа (счет начинается с 1)
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
            //Название листа (вкладки снизу)
            sheet.Name = $"Отчет";
            //Пример заполнения ячеек
            sheet.Cells[1, 1] = String.Format("Имя");
            sheet.Cells[1, 2] = String.Format("Фамилия");
            sheet.Cells[1, 3] = String.Format("E-mail");
            sheet.Cells[1, 4] = String.Format("Статус");
            int i = 2;
            foreach (User b in UserInCoord.Items)
            {
                sheet.Cells[i, 1] = String.Format($"{b.Name}");
                sheet.Cells[i, 2] = String.Format($"{b.Surname}");
                sheet.Cells[i, 3] = String.Format($"{b.Email}");
                if (b.Payment == 0)
                {
                    sheet.Cells[i, 4] = String.Format($"Оплата не подтверждена");
                }
                else
                {
                    sheet.Cells[i, 4] = String.Format($"Оплата подтверждена");
                }
                i++;
            }

            ex.Application.ActiveWorkbook.SaveAs("otchet.csv");
            //Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
            //Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        }

        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            string writePath = @"emails.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (User b in UserInCoord.Items)
                {
                    sw.WriteLine(b.Email);
                }
            }

            MessageBox.Show("Фаил в директории\nMarathonSkills/MarathonSkills/bin/emails", "Успешно");
        }
    }
}
