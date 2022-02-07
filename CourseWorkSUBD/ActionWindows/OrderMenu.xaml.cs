using CourseWorkSUBD.Collections;
using CourseWorkSUBD.DocumentInto;
using CourseWorkSUBD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseWorkSUBD.ActionWindows
{
    /// <summary>
    /// Логика взаимодействия для OrderMenu.xaml
    /// </summary>
    public partial class OrderMenu : Window
    {
        List<Work> works;
        List<Work> selectWork;
        public OrderMenu()
        {
            InitializeComponent();

            works = (from w in RepWorks.SelectAll() select w).ToList();
            selectWork = new List<Work>();

            AddToComBoxProblem();
            AddToComBoxAuto();
            AddToComBoxYear();
            AddToComBoxTypeEngine();
        }

        private void orderProblem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private bool CheckLoginClient()
        {
            var client = RepClients.SelectByLogin(Registration.RegUser.UserLogin);
            if (client == null)
                return false;
            else return true;
        }

        private void orderReg_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputTextBox() && CheckSelectComboBox())
            {
                //проверяем, есть ли клиент в коллекции клиент
                Client c = new Client
                {
                    Phone = orderTelNom.Text,
                    FIO = orderUserSurname.Text,
                    UserLogin = Registration.RegUser.UserLogin
                };
                if (CheckLoginClient() == false)
                    RepClients.Insert(c);
                else
                    RepClients.UpdatePrivateData(c);

                //добавляем в таблицу заказы
                Order order = new Order();
                order.DateRegistr = DateTime.Now.ToString();
                order.Payment = 0;
                order.Auto = new DocumentInto.Auto
                {
                    Gosnumber = orderNomer.Text,
                    TypeEngine = orderTypeEngine.Text,
                    YearRelese = Convert.ToInt32(orderYear.Text),
                    Mark = orderMarka.Text
                };
                order.Client = new ClientInto 
                { 
                    FIO = orderUserSurname.Text,
                    Phone = orderTelNom.Text,
                    UserLogin = Registration.RegUser.UserLogin
                };

                order.Status = "wait";
                order.Works = new List<WorkInto>();
                foreach (var w in selectWork)
                    order.Works.Add(new WorkInto { Description = w.Description, Cost = w.Cost });

                RepOrder.Insert(order);

                string mes = "Регистрация заказа прошла успешно.\nСостояние и подробности заказа Вы можете узнать в личном кабинете.";
                MessageBox.Show(mes);
                this.Close();
            }
        }

        private void butListWorks_Click(object sender, RoutedEventArgs e)
        {
            selectWork.Add(works[orderProblem.SelectedIndex]);
            countListWorks.Content = selectWork.Count.ToString();
            if (orderProblem.SelectedItem != null)
                OrderCost();
        }

        //---------------

        private void AddToComBoxProblem()
        {
            var works = from w in RepWorks.SelectAll() select w.Description;
            int c = 0;
            foreach (var w in works)
            {
                if (c % 2 == 0)
                    orderProblem.Items.Add(new TextBlock { FontSize = 14, Text = w });
                else
                    orderProblem.Items.Add(new TextBlock { FontSize = 14, Text = w, Foreground = Brushes.Orange });

                c++;
            }
        }

        private void AddToComBoxAuto()
        {
            var marks = from m in RepMarks.SelectAll() select m.Name;
            int c = 0;
            foreach (var m in marks)
            {
                if (c % 2 == 0)
                    orderMarka.Items.Add(new TextBlock { FontSize = 14, Text = m });
                else
                    orderMarka.Items.Add(new TextBlock { FontSize = 14, Text = m, Foreground = Brushes.Orange });

                c++;
            }
        }

        private void AddToComBoxYear()
        {
            int curYear = int.Parse(DateTime.Now.Year.ToString());

            while (curYear > 1950)
            {
                if (curYear % 2 == 0)
                    orderYear.Items.Add(new TextBlock { FontSize = 14, Text = curYear.ToString() });
                else
                    orderYear.Items.Add(new TextBlock { FontSize = 14, Text = curYear.ToString(), Foreground = Brushes.Orange });
                curYear--;
            }
        }

        private void AddToComBoxTypeEngine()
        {
            orderTypeEngine.Items.Add(new TextBlock { FontSize = 14, Text = "Бензин" });
            orderTypeEngine.Items.Add(new TextBlock { FontSize = 14, Text = "Дизель", Foreground = Brushes.Orange });
            orderTypeEngine.Items.Add(new TextBlock { FontSize = 14, Text = "Гибрид" });
        }

        private bool CheckInputTextBox()
        {
            Regex regPhone = new Regex(@"^(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$");
            Regex regGosnomer = new Regex("[0-9]{4}[A-Z]{2}");
            bool flag = true;

            if (orderUserSurname.Text.Length > 30 || orderUserSurname.Text.Length < 2)
            {
                orderUserSurname.Background = Brushes.Red;
                flag = false;
            }
            else
                orderUserSurname.Background = Brushes.White;

            if (!regPhone.IsMatch(orderTelNom.Text))
            {
                orderTelNom.Background = Brushes.Red;
                flag = false;
            }
            else
                orderTelNom.Background = Brushes.White;

            if (!regGosnomer.IsMatch(orderNomer.Text))
            {
                orderNomer.Background = Brushes.Red;
                flag = false;
            }
            else
                orderNomer.Background = Brushes.White;

            if (flag == false)
            {
                MessageBox.Show("Неправильно введены данные");
                return flag;
            }
            else
                return flag;

        }
        private bool CheckSelectComboBox()
        {
            bool flag = true;
            if (orderProblem.SelectedItem == null)
            {
                orderProblem.Background = Brushes.Red;
                flag = false;
            }
            if (orderMarka.SelectedItem == null)
            {
                orderMarka.Background = Brushes.Red;
                flag = false;
            }
            if (orderYear.SelectedItem == null)
            {
                orderYear.Background = Brushes.Red;
                flag = false;
            }
            if (orderTypeEngine.SelectedItem == null)
            {
                orderTypeEngine.Background = Brushes.Red;
                flag = false;
            }
            if (flag == false)
            {
                MessageBox.Show("Выбраны не все элементы");
                return flag;
            }
            else
                return flag;
        }
        private void OrderCost()
        {
            orderCost.Text = (from w in selectWork select w.Cost).Sum().ToString();
        }

    }
}
