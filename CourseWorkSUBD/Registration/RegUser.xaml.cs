using CourseWorkSUBD.Collections;
using CourseWorkSUBD.Repository;
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

namespace CourseWorkSUBD.Registration
{
    /// <summary>
    /// Логика взаимодействия для RegUser.xaml
    /// </summary>
    public partial class RegUser : Window
    {
        public RegUser()
        {
            InitializeComponent();
        }

        //свойсто, которое показывает, зарегистрирован ли пользователь//
        static public bool Autorisation { get; set; }
        //свойство, которое возвращает логин текущего пользователя
        static public string UserLogin { get; set; }

        private void ButRegistr_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputUser())
            {
                if (RepUsers.SelectByLogin(userLogin.Text) == null)
                {
                    userLogin.Background = Brushes.Green;
                    userPass.Background = Brushes.Green;
                    User user = new User();
                    user.UserLogin = userLogin.Text;
                    user.UserPassword = userPass.Password;
                    user.Rank = "user";
                    RepUsers.Insert(user);
                    UserLogin = userLogin.Text;
                    Autorisation = true;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    userLogin.Background = Brushes.Red;
                    userPass.Background = Brushes.Red;
                    MessageBox.Show("Пользователь с таким логином уже есть.\nПопробуйте другой.");
                }
            }
        }

        private void ButInputUser_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputUser())
            {
                User user = RepUsers.SelectByLogPass(userLogin.Text, userPass.Password);

                if (user == null)
                    MessageBox.Show("Пользователя с таким логином и паролем нет");
                else
                {
                    if (user.Rank == "user")
                    {
                        Autorisation = true;
                        UserLogin = user.UserLogin;
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else if (user.Rank == "manager")
                    {
                        InputManager();
                    }
                    else if (user.Rank == "master")
                    {
                        InputMaster();
                    }
                }
            }
        }

        private void InputManager()
        {
            string mes = "Вы вошли как manager. Если вы не хотели входить\nпод таким " +
              "уровнем доступа, пожалуйста, нажмите Отмена.";
            MessageBoxResult res = MessageBox.Show($"{mes}", "Автосервис. Вход", MessageBoxButton.OKCancel);
            switch (res)
            {
                case MessageBoxResult.OK:
                    UserLogin = RepUsers.SelectByLogPass(userLogin.Text, userPass.Password).UserLogin;
                    UserRoom.ManagerRoom mr = new UserRoom.ManagerRoom();
                    mr.Show();
                    this.Close();
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Пожалуйста, повторите ввод");
                    break;
            }
        }

        private void InputMaster()
        {
            string mes = "Вы вошли как master. Если вы не хотели входить\nпод таким " +
              "уровнем доступа, пожалуйста, нажмите Отмена.";
            MessageBoxResult res = MessageBox.Show($"{mes}", "Автосервис. Вход", MessageBoxButton.OKCancel);
            switch (res)
            {
                case MessageBoxResult.OK:
                    UserLogin = RepUsers.SelectByLogPass(userLogin.Text, userPass.Password).UserLogin;
                    UserRoom.MasterRoom master = new UserRoom.MasterRoom();
                    master.Show();
                    this.Close();
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Пожалуйста, повторите ввод");
                    break;
            }
        }

        //проверяем правильность введенных данных
        private bool CheckInputUser()
        {
            bool flag = true;
            if (userLogin.Text.Length < 3 || userLogin.Text.Length > 15)
            {
                userLogin.Background = Brushes.Red;
                flag = false;
            }
            if (userPass.Password.Length < 5 || userPass.Password.Length > 25)
            {
                userPass.Background = Brushes.Red;
                flag = false;
            }
            if (flag == false)
            {
                MessageBox.Show("Введенные данные не соотвествуют нужной длине.\nПовторите ввод");
                return false;
            }
            else
                return true;
            //проверка закончилась
        }
    }
}
