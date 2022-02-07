using CourseWorkSUBD.Collections;
using CourseWorkSUBD.Repository;
using MongoDB.Bson;
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

namespace CourseWorkSUBD.ActionManager
{
    /// <summary>
    /// Логика взаимодействия для ManInfoWork.xaml
    /// </summary>
    public partial class ManInfoWork : Window
    {
        public static string ManIdWork;
        public static bool CheckAdd { get; set; }
        public ManInfoWork()
        {
            InitializeComponent();
            AddInfo();
        }

        private void butAddInfoWork_Click(object sender, RoutedEventArgs e)
        {
            if (newDes.Text == "" && newCost.Text == "")
                MessageBox.Show("Все поля должны быть заполнены");
            else
            {
                if (int.TryParse(newCost.Text, out int n))
                {
                    Work work = new Work();
                    work.Description = newDes.Text;
                    work.Cost = Convert.ToInt32(newCost.Text);
                    if (CheckAdd == true)
                    {
                        RepWorks.Insert(work);
                        MessageBox.Show("Данные добавлены!");
                    }
                    else
                    {
                        work.Id = new ObjectId(ManIdWork);
                        RepWorks.Update(work);
                        MessageBox.Show("Данные успешно сохранены");
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверно введены данные");
                    newCost.Text = "";
                }
            }
        }

        private void AddInfo()
        {
            if (CheckAdd == true)
                return;
            else
            {
                var work = (from w in RepWorks.SelectAll() where w.Id.ToString() == ManIdWork select w).First();
                newDes.Text = work.Description;
                newCost.Text = work.Cost.ToString();
            }
        }
    }
}
