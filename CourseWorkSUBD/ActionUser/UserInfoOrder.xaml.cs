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

namespace CourseWorkSUBD.ActionUser
{
    /// <summary>
    /// Логика взаимодействия для UserInfoOrder.xaml
    /// </summary>
    public partial class UserInfoOrder : Window
    {
        public string CurIdOrder { get; set; }
        public UserInfoOrder()
        {
            InitializeComponent();
        }

        private void butClientPay_Click(object sender, RoutedEventArgs e)
        {
            Repository.RepOrder.UpdatePayment(CurIdOrder);
            MessageBox.Show("Заказ оплачен!");
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clientIdOrder.Text = CurIdOrder.ToString();
            clientIdOrder.Text = CurIdOrder.ToString();
        }

        private void clientCard_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("Неправильно введены данные");
            }
        }
    }
}
