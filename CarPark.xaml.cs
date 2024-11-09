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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FleetEquipment
{
    /// <summary>
    /// Логика взаимодействия для CarPark.xaml
    /// </summary>
    public partial class CarPark : Page
    {
        public CarPark()
        {
            InitializeComponent();

            RefreshDataGrid();

            using (var db = new FleetEquipment_user32_dbEntities())
            {
                var users = db.CarPark_FleetEquipment.ToList();

                DataGridCarPark.ItemsSource = users;
            }
        }


        private void RefreshDataGrid()
        {
            using (var db = GetDbContext())
            {
                DataGridCarPark.ItemsSource = db.CarPark_FleetEquipment.ToList();
            }
        }

        private FleetEquipment_user32_dbEntities GetDbContext()
        {
            return new FleetEquipment_user32_dbEntities();
        }

        private void But_Update_Click(object sender, RoutedEventArgs e)
        {
            var selectedCarPark = DataGridCarPark.SelectedItem as CarPark_FleetEquipment;
            if (selectedCarPark == null)
            {
                MessageBox.Show("Пожалуйста, выберите автопарк.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var addEditCarPark = new AddEditCarPark(selectedCarPark);
            addEditCarPark.ShowDialog();

            RefreshDataGrid();
        }

        private void But_Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedCarPark = DataGridCarPark.SelectedItem as CarPark_FleetEquipment;
            if (selectedCarPark == null)
            {
                MessageBox.Show("Пожалуйста, выберите автопарк.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить этот автопарк?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (var db = new FleetEquipment_user32_dbEntities())
                {
                    db.CarPark_FleetEquipment.Attach(selectedCarPark);

                    db.CarPark_FleetEquipment.Remove(selectedCarPark);
                    db.SaveChanges();

                    RefreshDataGrid();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEditCarPark newWindow = new AddEditCarPark() { Owner = (Window)this.Parent };
            newWindow.ShowDialog();

            RefreshDataGrid();
        }
    }
}
