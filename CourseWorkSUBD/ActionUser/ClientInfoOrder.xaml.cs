using CourseWorkSUBD.Collections;
using CourseWorkSUBD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseWorkSUBD.ActionUser
{
    /// <summary>
    /// Логика взаимодействия для ClientInfoOrder.xaml
    /// </summary>
    public partial class ClientInfoOrder : Window
    {
        private Order order;
        public ClientInfoOrder()
        {
            InitializeComponent();

            order = new Order();
            order = (from o in RepOrder.SelectAll()
                     where o.Id.ToString() == UserRoom.UserPrivateRoom.SelectIdOrder
                     select o).First();

            AddInfoMaster();
            AddInfoAuto();
            AddInfoDateRegistr();
            AddInfoOrder();
        }

        private void AddInfoMaster()
        {
            if (order.Master == null)
            {
                clientNameMaster.Text = "не назначен";
            }
            else clientNameMaster.Text = order.Master.FIO;
        }

        private void AddInfoAuto()
        {
            clientInfoAutoMarka.Text = order.Auto.Mark;
            clientInfoAutoGosnom.Text = order.Auto.Gosnumber;
            clientInfoAutoTypeEngine.Text = order.Auto.TypeEngine;
        }
        private void AddInfoDateRegistr()
        {
            clientDataOrder.Text = order.DateRegistr;
        }
        private void AddInfoOrder()
        {
            //var works = (from w in RepWorks.SelectAll() where w.Id_work == order.Id_work select w).First();
            //clientInfoWork.Text += works.Description_work + "\n" + "Стоимость: " + works.Cost_work;
            StringBuilder sb = new StringBuilder();
            foreach (var ws in order.Works)
            {
                sb.Append(ws.Description + "\n");
            }
            clientInfoWork.Text = sb.ToString();
        }

        private void butPayment_Click(object sender, RoutedEventArgs e)
        {
            if (order.Payment == 0)
            {
                UserInfoOrder userInfo = new UserInfoOrder();
                userInfo.CurIdOrder = order.Id.ToString();
                userInfo.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Ваш заказ уже оплачен.");
        }

        private void butClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
