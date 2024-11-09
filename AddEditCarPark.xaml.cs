using FleetEquipment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для AddEditCarPark.xaml
    /// </summary>
    public partial class AddEditCarPark : Window
    {
        private CarPark_FleetEquipment carPark;
        private readonly int _carParkId;
        public AddEditCarPark(CarPark_FleetEquipment existingCarPark = null)
        {
            InitializeComponent();

            carPark = existingCarPark ?? new CarPark_FleetEquipment();
            _carParkId = existingCarPark?.ID ?? 0;

            NameTextBox.DataContext = carPark;
            NameTextBox.SetBinding(TextBox.TextProperty, new Binding("Name"));

            AddressTextBox.DataContext = carPark;
            AddressTextBox.SetBinding(TextBox.TextProperty, new Binding("Address"));

            PhoneTextBox.DataContext = carPark;
            PhoneTextBox.SetBinding(TextBox.TextProperty, new Binding("Phone"));

            NumberVehicleComboBox.DataContext = carPark;
            NumberVehicleComboBox.SetBinding(ComboBox.SelectedValueProperty, new Binding("ID_Vehicle_FleetEquipment"));

            NumberVehicleComboBox.ItemsSource = GetVehicles();

            if (existingCarPark != null)
            {
                NameTextBox.Text = existingCarPark.Name;
                AddressTextBox.Text = existingCarPark.Adress;
                PhoneTextBox.Text = existingCarPark.Phone;
                NumberVehicleComboBox.SelectedItem = GetVehicles().FirstOrDefault(v => v.ID == existingCarPark.ID_Vehicle_FleetEquipment);
            }
        }

        private IEnumerable<Vehicle_FleetEquipment> GetVehicles()
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                return db.Vehicle_FleetEquipment.ToList();
            }
        }

        private void ExecuteCarPark_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                if (!ValidateFields())
                {
                    return;
                }

                if (_carParkId != 0)
                {
                    var existingCarPark = db.CarPark_FleetEquipment.Find(_carParkId);
                    if (existingCarPark == null)
                    {
                        MessageBox.Show("Автопарк не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    existingCarPark.Name = NameTextBox.Text;
                    existingCarPark.Adress = AddressTextBox.Text;
                    existingCarPark.Phone = PhoneTextBox.Text;
                    existingCarPark.ID_Vehicle_FleetEquipment = ((Vehicle_FleetEquipment)NumberVehicleComboBox.SelectedItem).ID;

                    db.SaveChanges();

                    MessageBox.Show("Автопарк успешно обновлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    var newCarPark = new CarPark_FleetEquipment
                    {
                        Name = NameTextBox.Text,
                        Adress = AddressTextBox.Text,
                        Phone = PhoneTextBox.Text,
                        ID_Vehicle_FleetEquipment = ((Vehicle_FleetEquipment)NumberVehicleComboBox.SelectedItem).ID
                    };

                    db.CarPark_FleetEquipment.Add(newCarPark);
                    db.SaveChanges();

                    MessageBox.Show("Автопарк успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                this.Close();
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя автопарка.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(AddressTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите адрес автопарка.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!IsValidPhone(PhoneTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите телефон в формате 22-02-20.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool IsValidPhone(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{2}-\d{2}-\d{2}$");
        }

        private void BackButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
