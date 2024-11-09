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
    /// Логика взаимодействия для AddEditVehicle.xaml
    /// </summary>
    public partial class AddEditVehicle : Window
    {
        private Vehicle_FleetEquipment vehicle;
        private readonly int _vehicleId;

        public AddEditVehicle(Vehicle_FleetEquipment existingVehicle = null)
        {
            InitializeComponent();

            vehicle = existingVehicle ?? new Vehicle_FleetEquipment();
            _vehicleId = existingVehicle?.ID ?? 0;

            TypeComboBox.ItemsSource = GetTypes();
            ManufacturerComboBox.ItemsSource = GetManufacturers();
            ColorComboBox.ItemsSource = GetColors();
            TechnicComboBox.ItemsSource = GetUsers();

            BodyType.DataContext = vehicle;
            BodyType.SetBinding(TextBox.TextProperty, new Binding("Body_type"));

            InStock.DataContext = vehicle;
            InStock.SetBinding(TextBox.TextProperty, new Binding("InStock"));

            Transmission.DataContext = vehicle;
            Transmission.SetBinding(CheckBox.IsCheckedProperty, new Binding("Transmission"));

            TypeComboBox.DataContext = vehicle;
            TypeComboBox.SetBinding(ComboBox.SelectedValueProperty, new Binding("ID_Type_FleetEquipment"));

            ManufacturerComboBox.DataContext = vehicle;
            ManufacturerComboBox.SetBinding(ComboBox.SelectedValueProperty, new Binding("ID_Manufacturer_FleetEquipment"));

            ColorComboBox.DataContext = vehicle;
            ColorComboBox.SetBinding(ComboBox.SelectedValueProperty, new Binding("ID_Color_FleetEquipment"));

            TechnicComboBox.DataContext = vehicle;
            TechnicComboBox.SetBinding(ComboBox.SelectedValueProperty, new Binding("ID_User_FleetEquipment"));

            Transmission.IsChecked = false;

            if (existingVehicle != null)
            {
                Transmission.IsChecked = existingVehicle.Transmission;
                BodyType.Text = existingVehicle.Body_type;
                InStock.Text = existingVehicle.InStock.ToString();
                TypeComboBox.SelectedItem = GetTypes().FirstOrDefault(t => t.ID == existingVehicle.ID_Type_FleetEquipment);
                ManufacturerComboBox.SelectedItem = GetManufacturers().FirstOrDefault(m => m.ID == existingVehicle.ID_Manufacturer_FleetEquipment);
                ColorComboBox.SelectedItem = GetColors().FirstOrDefault(c => c.ID == existingVehicle.ID_Color_FleetEquipment);
                TechnicComboBox.SelectedItem = GetUsers().FirstOrDefault(u => u.ID == existingVehicle.ID_User_FleetEquipment);
            }
        }

        private IEnumerable<Type_FleetEquipment> GetTypes()
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                return db.Type_FleetEquipment.ToList();
            }
        }

        private IEnumerable<Manufacturer_FleetEquipment> GetManufacturers()
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                return db.Manufacturer_FleetEquipment.ToList(); 
            }
        }

        private IEnumerable<Color_FleetEquipment> GetColors()
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                return db.Color_FleetEquipment.ToList(); 
            }
        }

        private IEnumerable<User_FleetEquipment> GetUsers()
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                return db.User_FleetEquipment.ToList(); 
            }
        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                if (!ValidateFields())
                {
                    return;
                }

                if (_vehicleId != 0)
                {
                    var existingVehicle = db.Vehicle_FleetEquipment.Find(_vehicleId);
                    if (existingVehicle == null)
                    {
                        MessageBox.Show("Транспорт не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    existingVehicle.Transmission = Transmission.IsChecked.Value;
                    existingVehicle.Body_type = BodyType.Text;
                    existingVehicle.InStock = int.Parse(InStock.Text);

                    var selectedTypeId = ((Type_FleetEquipment)TypeComboBox.SelectedItem).ID;
                    var selectedManufacturerId = ((Manufacturer_FleetEquipment)ManufacturerComboBox.SelectedItem).ID;
                    var selectedColorId = ((Color_FleetEquipment)ColorComboBox.SelectedItem).ID;
                    var selectedUserId = ((User_FleetEquipment)TechnicComboBox.SelectedItem).ID;

                    existingVehicle.ID_Type_FleetEquipment = selectedTypeId;
                    existingVehicle.ID_Manufacturer_FleetEquipment = selectedManufacturerId;
                    existingVehicle.ID_Color_FleetEquipment = selectedColorId;
                    existingVehicle.ID_User_FleetEquipment = selectedUserId;

                    db.SaveChanges();

                    MessageBox.Show("Транспорт успешно обновлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    var newVehicle = new Vehicle_FleetEquipment
                    {
                        Transmission = Transmission.IsChecked.Value,
                        Body_type = BodyType.Text,
                        InStock = int.Parse(InStock.Text),
                        ID_Type_FleetEquipment = ((Type_FleetEquipment)TypeComboBox.SelectedItem).ID,
                        ID_Manufacturer_FleetEquipment = ((Manufacturer_FleetEquipment)ManufacturerComboBox.SelectedItem).ID,
                        ID_Color_FleetEquipment = ((Color_FleetEquipment)ColorComboBox.SelectedItem).ID,
                        ID_User_FleetEquipment = ((User_FleetEquipment)TechnicComboBox.SelectedItem).ID
                    };

                    db.Vehicle_FleetEquipment.Add(newVehicle);
                    db.SaveChanges();

                    MessageBox.Show("Транспорт успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                this.Close();
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(BodyType.Text))
            {
                MessageBox.Show("Пожалуйста, введите тип кузова.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!int.TryParse(InStock.Text, out _))
            {
                MessageBox.Show("Пожалуйста, введите цифру или число для поля 'В наличии'.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void BackButtonVehicle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
