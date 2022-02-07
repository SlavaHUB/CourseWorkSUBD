using CourseWorkSUBD.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using CourseWorkSUBD.Repository;
using MongoDB.Bson;

namespace CourseWorkSUBD.ActionManager
{
    /// <summary>
    /// Логика взаимодействия для ManInfoOrder.xaml
    /// </summary>
    public partial class ManInfoOrder : Window
    {
        static public string ManIdOrder { get; set; }
        private Order order;
        public ManInfoOrder()
        {
            InitializeComponent();
            order = (from o in Repository.RepOrder.SelectAll() where o.Id.ToString() == ManIdOrder select o).First();
            AddInfoMaster();
            AddInfo();
            CheckStatusOrder();
        }
        private Order GetOrder()
        {
            return null;
        }

        private void NameMasterTextBox()
        {
            nameMasterText.Visibility = Visibility.Visible;
            nameMasterText.Text = order.Master.FIO;
        }
        private void CheckStatusOrder()
        {
            if (order.Status.ToLower() == "wait")
            {
                butAccept.Visibility = Visibility.Visible;
                butRefuse.Visibility = Visibility.Visible;
                nameMaster.Visibility = Visibility.Visible;
            }
            else if (order.Status.ToLower() == "perform")
            {
                butClose.Visibility = Visibility.Visible;
                nameMasterText.Visibility = Visibility.Visible;
                NameMasterTextBox();
            }
            else if (order.Status.ToLower() == "close")
            {
                NameMasterTextBox();
            }
        }
        private void AddInfo()
        {
            infoClient.Text = order.Client.FIO;

            infoAutoMarka.Text = order.Auto.Mark;

            infoAutoGosnom.Text = order.Auto.Gosnumber;
            infoAutoTypeEngine.Text = order.Auto.TypeEngine;

            //infoWork.Text = (from w in RepWorks.SelectAll() where w.Id_work == order.Id_work select w.Description_work).First();
            StringBuilder sb = new StringBuilder();
            foreach(var ws in order.Works)
            {
                sb.Append(ws.Description + "\n");
            }
            infoWork.Text = sb.ToString();
        }

        private void AddInfoMaster()
        {
            var masterFIOs = from m in RepEmployee.SelectAll() where m.Position == "master" select m.FIO;
            foreach (var m in masterFIOs)
            {
                nameMaster.Items.Add(new TextBlock { Text = m, FontSize = 14 });
            }
        }

        private void butAccept_Click(object sender, RoutedEventArgs e)
        {
            if (nameMaster.SelectedItem == null)
                MessageBox.Show("Ошибка: не все поля заполнены");
            else
            {
                var masterLogins = (from m in RepEmployee.SelectAll() where m.Position == "master" select m.UserLogin).ToList();
                Order ord = new Order();
                ord.Status = "perform";
                ord.Id = new ObjectId(ManIdOrder);

                ord.Master = new DocumentInto.Master{ FIO = (from mast in RepEmployee.SelectAll() 
                                                             where mast.UserLogin.ToString() == masterLogins[nameMaster.SelectedIndex] 
                                                             select mast.FIO).First(),
                                                      UserLogin = masterLogins[nameMaster.SelectedIndex] };

                ord.Checker = new DocumentInto.Checker{ FIO = (from c in RepEmployee.SelectAll() 
                                                                where c.UserLogin == Registration.RegUser.UserLogin 
                                                                select c.FIO).First(),
                                                        UserLogin = Registration.RegUser.UserLogin
                };

                RepOrder.UpdateStatusAndMaster(ord);
                MessageBox.Show("Данные сохранены");
            }
        }

        private void butRefuse_Click(object sender, RoutedEventArgs e)
        {
            RepOrder.UpdateOnlyStatus(ManIdOrder, "refused");
            this.Close();
            MessageBox.Show("Успех: статус заказа изменен на ОТКАЗАННО");
        }

        private void butClose_Click(object sender, RoutedEventArgs e)
        {
            RepOrder.UpdateOnlyStatus(ManIdOrder, "close");
            MessageBox.Show("Успех: статус заказа изменен на ЗАКРЫТО");
        }
    }
}
