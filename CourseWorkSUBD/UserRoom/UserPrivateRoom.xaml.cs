using CourseWorkSUBD.ActionUser;
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
    /// Логика взаимодействия для UserPrivateRoom.xaml
    /// </summary>
    public partial class UserPrivateRoom : Window
    {
        public static string SelectIdOrder { get; set; }
        Client client;
        public UserPrivateRoom()
        {
            InitializeComponent();
            client = RepClients.SelectByLogin(Registration.RegUser.UserLogin);
            AddDataToGrid();
        }
        private void AddDataToGrid()
        {
            if (client == null)
            {
                return;
            }

            var data = from d in RepOrder.SelectAll() where d.Client.UserLogin == client.UserLogin select d;

            var dataend = data.Select(d => new
            {
                ID = d.Id,
                Мастер = d.Master == null ? "не назначен" : "назначен",
                Услуги = d.Works.Count,
                Дата = d.DateRegistr,
                Оплата = d.Payment == 0 ? "не оплачен" : "оплачено"
            }).ToList();

            userDataGrid.ItemsSource = dataend;
        }

        private void saveUserRoom_Click(object sender, RoutedEventArgs e)
        {
            if (client != null)
            {
                client.Feedback = textFeedback.Text;
                RepClients.Update(client.UserLogin, client.Feedback);
                MessageBox.Show("Данные сохранены");
            }
            else
            {
                MessageBox.Show("Вы не сделали еще ни одного заказа.\nПожалуйста, сначала сделайте заказ,\nа потом оставьте отзыв о проделанной работе");
            }
        }

        private void exitUserRoom_Click(object sender, RoutedEventArgs e)
        {
            string mes = "Вы уверены, что хотите выйти в главное меню?";
            MessageBoxResult res = MessageBox.Show($"{mes}", "Client. Личный кабинет", MessageBoxButton.OKCancel);
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

        private void userDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dg = sender as DataGrid;

            object item = dg.SelectedItem;
            Type type = item.GetType();
            PropertyInfo[] properties = type.GetProperties();

            SelectIdOrder = properties[0].GetValue(item).ToString();
        }

        private void userInfoOrder_Click(object sender, RoutedEventArgs e)
        {
            ClientInfoOrder infoOrder = new ClientInfoOrder();
            infoOrder.Show();
        }

        private void butUpdateDataGrid_Click(object sender, RoutedEventArgs e)
        {
            UserPrivateRoom u = new UserPrivateRoom();
            u.Show();
            this.Close();
        }
    }
}
