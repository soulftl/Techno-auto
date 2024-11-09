using FleetEquipment.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Vehicle.xaml
    /// </summary>
    public partial class Vehicle : Page
    {
        private FleetEquipment_user32_dbEntities dbContext;
        public Vehicle()
        {
            InitializeComponent();
            dbContext = new FleetEquipment_user32_dbEntities();
            RefreshDataGrid();

            using (var db = new FleetEquipment_user32_dbEntities())
            {
                var vehicles = db.Vehicle_FleetEquipment.Select(v => new
                {
                    v.ID,
                    TransmissionText = v.Transmission.HasValue && v.Transmission.Value ? "Автомат" : "Механика",
                    v.Body_type,
                    v.InStock,
                    v.ID_Type_FleetEquipment,
                    Type = v.Type_FleetEquipment.Name, 
                    v.ID_Manufacturer_FleetEquipment,
                    Manufacturer = v.Manufacturer_FleetEquipment.Name, 
                    v.ID_Color_FleetEquipment,
                    Color = v.Color_FleetEquipment.Name, 
                    v.ID_User_FleetEquipment,
                    User = v.User_FleetEquipment.First_name + " " + v.User_FleetEquipment.Last_name 
                }).ToList();

                DataGridVehicle.ItemsSource = vehicles;
            }
        }

        private FleetEquipment_user32_dbEntities GetDbContext()
        {
            return new FleetEquipment_user32_dbEntities();
        }

        private void RefreshDataGrid()
        {
            using (var db = GetDbContext())
            {
                DataGridVehicle.ItemsSource = db.User_FleetEquipment.ToList();
            }
        }

        private void But_Update_Click(object sender, RoutedEventArgs e)
        {
            var vehicleId = (int)((Button)sender).CommandParameter;

            var vehicleToUpdate = dbContext.Vehicle_FleetEquipment.Find(vehicleId);

            if (vehicleToUpdate != null)
            {
                AddEditVehicle editWindow = new AddEditVehicle(vehicleToUpdate) { Owner = (Window)this.Parent };
                editWindow.ShowDialog();

                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Транспорт не найден.");
            }
        }

        private void But_Delete_Click(object sender, RoutedEventArgs e)
        {
            var vehicleId = (int)((Button)sender).CommandParameter;

            if (MessageBox.Show("Вы действительно хотите удалить этот транспорт?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var vehicleToDelete = dbContext.Vehicle_FleetEquipment.Find(vehicleId);

                if (vehicleToDelete != null)
                {
                    dbContext.Vehicle_FleetEquipment.Remove(vehicleToDelete);
                    dbContext.SaveChanges();

                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("Транспорт не найден.");
                }
            }
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            AddEditVehicle newWindow = new AddEditVehicle() { Owner = (Window)this.Parent };
            newWindow.ShowDialog();

            RefreshDataGrid();
        }
    }
}
