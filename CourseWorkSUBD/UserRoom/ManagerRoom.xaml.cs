using CourseWorkSUBD.ActionManager;
using CourseWorkSUBD.Collections;
using CourseWorkSUBD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseWorkSUBD.UserRoom
{
    /// <summary>
    /// Логика взаимодействия для ManagerRoom.xaml
    /// </summary>
    public partial class ManagerRoom : Window
    {
        private string OrderOrWork;
        private List<Order> orders;
        public ManagerRoom()
        {
            InitializeComponent();
            orders = RepOrder.SelectAll();
            AddInfoStat();
            AddFioManager();
        }

        private void butManClients_Click(object sender, RoutedEventArgs e)
        {
            manGrid.Visibility = Visibility.Visible;
            manGridOrder.Visibility = Visibility.Collapsed;
            infoStack.Visibility = Visibility.Collapsed;
            stackInfoMonth.Visibility = Visibility.Collapsed;

            var clients = orders.Select(c => new
            {
               Телефон = c.Client.Phone,
                ФИО = c.Client.FIO,
            }).ToList();

            manGrid.ItemsSource = clients;
        }

        private void AddFioManager()
        {
            fioManager.Text = (from empl in RepEmployee.SelectAll()
                               where empl.UserLogin == Registration.RegUser.UserLogin
                               select empl).First().FIO;
        }

        private void butManOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderOrWork = "order";
            manGridOrder.Visibility = Visibility.Visible;
            manGrid.Visibility = Visibility.Collapsed;
            infoStack.Visibility = Visibility.Collapsed;
            stackInfoMonth.Visibility = Visibility.Collapsed;

            var payments = from p in RepOrder.SelectAll() select p.Payment;

            var ords = orders.Select(order => new
            {
                Id = order.Id,
                Услуги = order.Works.Count,
                Статус = order.Status,
                Дата = order.DateRegistr,
            }).ToList();

            manGridOrder.ItemsSource = ords;
        }

        private void butManEmpl_Click(object sender, RoutedEventArgs e)
        {
            manGrid.Visibility = Visibility.Visible;
            manGridOrder.Visibility = Visibility.Collapsed;
            infoStack.Visibility = Visibility.Collapsed;
            stackInfoMonth.Visibility = Visibility.Collapsed;

            var employee = RepEmployee.SelectAll().Select(emps => new
            {
                ФИО = emps.FIO,
                Зарплата = emps.Salary,
                Логин = emps.UserLogin,
                Должность = emps.Position,
                Данные = emps.PrivateData,
            }).ToList();

            manGrid.ItemsSource = employee;
        }

        private void butManWorks_Click(object sender, RoutedEventArgs e)
        {
            OrderOrWork = "work";
            manGrid.Visibility = Visibility.Collapsed;
            manGridOrder.Visibility = Visibility.Visible;
            infoStack.Visibility = Visibility.Collapsed;
            stackInfoMonth.Visibility = Visibility.Collapsed;

            var works = from w in RepWorks.SelectAll() select w;

            manGridOrder.ItemsSource = works;
        }

        private void butManStat_Click(object sender, RoutedEventArgs e)
        {
            AddInfoStat();
        }

        private void AddInfoStat()
        {
            infoStack.Visibility = Visibility.Visible;
            manGrid.Visibility = Visibility.Collapsed;
            manGridOrder.Visibility = Visibility.Collapsed;
            stackInfoMonth.Visibility = Visibility.Collapsed;

            infoOrder.Text = (from order in RepOrder.SelectAll() select order.Id).Count().ToString();

            infoClient.Text = (from c in RepClients.SelectAll() select c.Id).Count().ToString();

            infoEmpl.Text = (from epml in RepEmployee.SelectAll() select epml.Id).Count().ToString();

            var works = from w in RepWorks.SelectAll() select w;
            infoWorks.Text = (from w in works select w.Id).Count().ToString();
            List<double> lst = new List<double>();
            var wks = from os in orders select os.Works;
            foreach(var w in wks)
            {
                foreach(var a in w)
                {
                    lst.Add(a.Cost);
                }
            }
            infoCostWorks.Text = Math.Round(lst.Average(), 2).ToString();
        }

        private void butGridOrder_Click(object sender, RoutedEventArgs e)
        {
            ManInfoWork.CheckAdd = false;
            if (OrderOrWork == "order")
            {
                ManInfoOrder manInfo = new ManInfoOrder();
                manInfo.ShowDialog();
            }
            else if (OrderOrWork == "work")
            {
                ManInfoWork infoWork = new ManInfoWork();
                ManInfoWork.CheckAdd = true;
                infoWork.ShowDialog();
            }
        }

        private void manGridOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dg = sender as DataGrid;

            object item = dg.SelectedItem;
            if (item == null)
                return;
            Type type = item.GetType();
            PropertyInfo[] properties = type.GetProperties();
            if (OrderOrWork == "order")
            {
                ManInfoOrder.ManIdOrder = properties[0].GetValue(item).ToString();
            }
            else if (OrderOrWork == "work")
            {
                ManInfoWork.ManIdWork = (properties[0].GetValue(item)).ToString();
            }
        }

        private void manExit_Click(object sender, RoutedEventArgs e)
        {
            string mes = "Вы уверены, что хотите выйти в главное меню?";
            MessageBoxResult res = MessageBox.Show($"{mes}", "Manager. Личный кабинет", MessageBoxButton.OKCancel);
            switch (res)
            {
                case MessageBoxResult.OK:
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void butManInfoMonth_Click(object sender, RoutedEventArgs e)
        {
            stackInfoMonth.Visibility = Visibility.Visible;

            manGrid.Visibility = Visibility.Collapsed;
            manGridOrder.Visibility = Visibility.Collapsed;
            infoStack.Visibility = Visibility.Collapsed;

            string curMonth = DateTime.Now.Month.ToString();

            if (curMonth.Length == 1)
                curMonth = "0" + curMonth;

            curMonthInfo.Text = curMonth;

            var rightOrders = orders.Where(d => d.DateRegistr.Split('.')[1] == curMonth).Select(o => o);
            double sum = 0.0;

            foreach(var o in rightOrders)
                foreach(var c in o.Works)
                    sum += c.Cost;

            infoColOrdersMonth.Text = rightOrders.Count().ToString();
            infoCostOrdersMonth.Text = sum.ToString();
        }

        private void butManAddWork_Click(object sender, RoutedEventArgs e)
        {
            ManInfoWork.CheckAdd = true;
            ManInfoWork infoWork = new ManInfoWork();
            infoWork.ShowDialog();
        }

        private void butGridDel_Click(object sender, RoutedEventArgs e)
        {
            if (OrderOrWork == "order")
                MessageBox.Show("Вы не можете удалить заказ");
            else
            {
                string mes = "Вы действительно хотите удалить эту услугу?";
                MessageBoxResult res = MessageBox.Show($"{mes}", "Удаление услуги", MessageBoxButton.OKCancel);
                switch (res)
                {
                    case MessageBoxResult.OK:
                        RepWorks.Delete(ManInfoWork.ManIdWork);
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
        }
    }
}
