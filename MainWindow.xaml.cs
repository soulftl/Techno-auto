using FleetEquipment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace FleetEquipment
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Entrance_Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Login_TextBox.Text;
            string password = Password_TextBox.Password;

            using (FleetEquipment_user32_dbEntities db = new FleetEquipment_user32_dbEntities())
            {
                var user = db.User_FleetEquipment.FirstOrDefault(u => u.Login == login && u.Password == password);

                if (user != null)
                {
                    string fullName = $"{user.First_name} {user.Patronymic} {user.Last_name}";

                    var role = db.Role_FleetEquipment.FirstOrDefault(r => r.ID == user.ID_Role_FleetEquipment);

                    if (role != null)
                    {
                        if (role.Name == "Администратор")
                        {
                            MainAdmin mainAdmin = new MainAdmin(); 
                            mainAdmin.Show();
                            this.Close();
                            MessageBox.Show($"Добро пожаловать, {user.First_name} {user.Patronymic}!");
                        }
                        else if (role.Name == "Техник")
                        {
                            MainTechnician mainTechnician = new MainTechnician(fullName, user.ID);
                            mainTechnician.Show();
                            this.Close();
                            MessageBox.Show($"Добро пожаловать, {user.First_name} {user.Patronymic}!");
                        }
                        else
                        {
                            MessageBox.Show("Неверная роль пользователя.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка получения роли пользователя.");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                }
            }
        }
    }
}
