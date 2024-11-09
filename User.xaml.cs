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
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Page
    {
        public User()
        {
            InitializeComponent();

            RefreshDataGrid();
        }

        private FleetEquipment_user32_dbEntities GetDbContext()
        {
            return new FleetEquipment_user32_dbEntities();
        }

        private void RefreshDataGrid()
        {
            using (var db = GetDbContext())
            {
                DataGridUser.ItemsSource = db.User_FleetEquipment.ToList();
            }
        }

        private void But_Update_Click(object sender, RoutedEventArgs e)
        {
            var userId = (int)((Button)sender).CommandParameter;

            using (var db = GetDbContext())
            {
                var userToUpdate = db.User_FleetEquipment.FirstOrDefault(u => u.ID == userId);

                if (userToUpdate != null)
                {
                    AddEditUser editWindow = new AddEditUser(userToUpdate) { Owner = (Window)this.Parent };
                    editWindow.ShowDialog();

                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.");
                }
            }
        }

        private void But_Delete_Click(object sender, RoutedEventArgs e)
        {
            var userId = (int)((Button)sender).CommandParameter;

            if (MessageBox.Show("Вы действительно хотите уволить этого пользователя?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                using (var db = GetDbContext())
                {
                    var userToDelete = db.User_FleetEquipment.FirstOrDefault(u => u.ID == userId);

                    if (userToDelete != null)
                    {
                        db.User_FleetEquipment.Remove(userToDelete);
                        db.SaveChanges();

                        RefreshDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден.");
                    }
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditUser newWindow = new AddEditUser() { Owner = (Window)this.Parent };
            newWindow.ShowDialog();

            RefreshDataGrid();
        }
    }
}
