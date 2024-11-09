using FleetEquipment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FleetEquipment
{
    /// <summary>
    /// Логика взаимодействия для AddEditUser.xaml
    /// </summary>
    public partial class AddEditUser : Window
    {
        private User_FleetEquipment user;
        private readonly int _userId;

        public AddEditUser(User_FleetEquipment existingUser = null)
        {
            InitializeComponent();

            user = existingUser ?? new User_FleetEquipment();
            _userId = existingUser?.ID ?? 0;

            if (existingUser != null)
            {
                LastName.Text = existingUser.Last_name;
                FirstName.Text = existingUser.First_name;
                Patronymic.Text = existingUser.Patronymic;
                DateOfBirth.Text = existingUser.Date_of_birth?.ToString("dd/MM/yyyy");
                Phone.Text = existingUser.Phone;
                Login.Text = existingUser.Login;
                Password.Text = existingUser.Password;
                Role.Text = GetRoleName(existingUser.ID_Role_FleetEquipment);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                // Validate fields before proceeding
                if (!ValidateFields())
                    return;

                if (_userId != 0) // Обновление пользователя
                {
                    var existingUser = db.User_FleetEquipment.Find(_userId);
                    if (existingUser == null)
                    {
                        MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Обновление свойств пользователя
                    existingUser.Last_name = LastName.Text;
                    existingUser.First_name = FirstName.Text;
                    existingUser.Patronymic = Patronymic.Text;
                    existingUser.Date_of_birth = DateTime.ParseExact(DateOfBirth.Text, "dd/MM/yyyy", null);
                    existingUser.Phone = Phone.Text;

                    // Проверка на дубликат логина, если логин изменился
                    if (existingUser.Login != Login.Text && db.User_FleetEquipment.Any(u => u.Login == Login.Text))
                    {
                        MessageBox.Show("Уже существует пользователь с таким логином", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Установка ID роли
                    int roleId = GetRoleID(Role.Text.Trim());
                    if (roleId == 0)
                    {
                        MessageBox.Show("Некорректное название роли.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Проверка на существование ID роли
                    var roleExists = db.Role_FleetEquipment.Any(r => r.ID == roleId);
                    if (!roleExists)
                    {
                        MessageBox.Show("Роль не найдена", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Обновление свойств логина и пароля
                    existingUser.Login = Login.Text;
                    existingUser.Password = Password.Text;
                    existingUser.ID_Role_FleetEquipment = roleId; // Update the role ID

                    // Сохранение изменений
                    db.SaveChanges();
                    MessageBox.Show("Пользователь успешно обновлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else // Добавление нового пользователя
                {
                    // Проверка на дубликат логина перед добавлением
                    if (db.User_FleetEquipment.Any(u => u.Login == Login.Text))
                    {
                        MessageBox.Show("Уже существует пользователь с таким логином", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Создание нового пользователя
                    var newUser = new User_FleetEquipment
                    {
                        Last_name = LastName.Text,
                        First_name = FirstName.Text,
                        Patronymic = Patronymic.Text,
                        Date_of_birth = DateTime.ParseExact(DateOfBirth.Text, "dd/MM/yyyy", null),
                        Phone = Phone.Text,
                        Login = Login.Text,
                        Password = Password.Text,
                        ID_Role_FleetEquipment = GetRoleID(Role.Text.Trim()) // Set role ID for new user
                    };

                    // Проверка на существование ID роли
                    var roleExists = db.Role_FleetEquipment.Any(r => r.ID == newUser.ID_Role_FleetEquipment);
                    if (!roleExists)
                    {
                        MessageBox.Show("Роль не найдена", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Добавление нового пользователя в базу данных
                    db.User_FleetEquipment.Add(newUser);
                    db.SaveChanges();

                    MessageBox.Show("Пользователь успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                this.Close();
            }
        }

        private int GetRoleID(string roleName)
        {
            switch (roleName.ToLower())
            {
                case "администратор":
                case "administrator":
                case "admin":
                case "админ":
                case "администраторы":
                    return 1; 
                case "техник":
                case "technician":
                    return 2; 
                default:
                    return 0; 
            }
        }

        private string GetRoleName(int roleId)
        {
            switch (roleId)
            {
                case 1: return "Администратор";
                case 2: return "Техник";
                default: return "";
            }
        }


        private bool ValidateFields()
        {
            if (!Regex.IsMatch(LastName.Text, @"^[А-Яа-я]+$"))
            {
                MessageBox.Show("Фамилия должна содержать только русские буквы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(FirstName.Text, @"^[А-Яа-я]+$"))
            {
                MessageBox.Show("Имя должно содержать только русские буквы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(Patronymic.Text, @"^[А-Яа-я]+$"))
            {
                MessageBox.Show("Отчество должно содержать только русские буквы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!DateTime.TryParseExact(DateOfBirth.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("Неправильный формат даты рождения. Должен быть формат dd/MM/yyyy.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(Phone.Text, @"^\+7\d{10}$"))
            {
                MessageBox.Show("Неправильный формат телефона. Должен начинаться с +7 и содержать 12 цифр.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(Login.Text, @"^[A-Za-z]+$"))
            {
                MessageBox.Show("Логин должен содержать только латинские буквы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(Password.Text, @"^[A-Za-z]+$"))
            {
                MessageBox.Show("Пароль должен содержать только латинские буквы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(Role.Text, @"^[А-Яа-я]+$"))
            {
                MessageBox.Show("Роль должна содержать только буквы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void BackButton_Click(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
