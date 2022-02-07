using CourseWorkSUBD.ActionManager;
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
    /// Логика взаимодействия для MasterRoom.xaml
    /// </summary>
    public partial class MasterRoom : Window
    {
        public MasterRoom()
        {
            InitializeComponent();
            AddToMasterGrid();
        }

        private void AddToMasterGrid()
        {
            var os = from ord in RepOrder.SelectAll() where ord.Master != null select ord;
            var orders = from ord in os where ord.Master.UserLogin == Registration.RegUser.UserLogin select ord;

            var info = orders.Select(i => new
            {
                Id = i.Id,
                Клиент = i.Client.FIO,
                Телефон = i.Client.Phone,
                Дата = i.DateRegistr,
                Госномер = i.Auto.Gosnumber,
                Статус = i.Status,
            }).ToList();

            nameMaster.Text = RepEmployee.SelectAll().Where(a=>a.UserLogin == Registration.RegUser.UserLogin).Select(b => b.FIO).First();

            masterDataGrid.ItemsSource = info;
        }

        private void masterExit_Click(object sender, RoutedEventArgs e)
        {
            string mes = "Вы уверены, что хотите выйти в главное меню?";
            MessageBoxResult res = MessageBox.Show($"{mes}", "Master. Личный кабинет", MessageBoxButton.OKCancel);
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

        private void butGridOrder_Click(object sender, RoutedEventArgs e)
        {
            ManInfoOrder manInfo = new ManInfoOrder();
            manInfo.ShowDialog();
        }

        private void masterDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dg = sender as DataGrid;

            object item = dg.SelectedItem;
            if (item == null)
                return;
            Type type = item.GetType();
            PropertyInfo[] properties = type.GetProperties();
            ManInfoOrder.ManIdOrder = properties[0].GetValue(item).ToString();
        }
    }
}
