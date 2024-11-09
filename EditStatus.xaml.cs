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
    /// Логика взаимодействия для EditStatus.xaml
    /// </summary>
    public partial class EditStatus : Window
    {
        private readonly int _fixId;
        public EditStatus(int fixId)
        {
            InitializeComponent();

            _fixId = fixId;

            StatusComboBox.ItemsSource = GetStatusOptions();

            StatusComboBox.DisplayMemberPath = "Name";

            StatusComboBox.SelectedValuePath = "ID";

            LoadCurrentStatus();
        }

        private List<Status_FleetEquipment> GetStatusOptions()
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                return db.Status_FleetEquipment.ToList();
            }
        }

        private void LoadCurrentStatus()
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                var fix = db.Fix_FleetEquipment.Find(_fixId);
                if (fix != null)
                {
                    StatusComboBox.SelectedValue = fix.ID_Status; 
                }
                else
                {
                    MessageBox.Show("Запись не найдена", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    Close();
                }
            }
        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                var fix = db.Fix_FleetEquipment.Find(_fixId);
                if (fix == null)
                {
                    MessageBox.Show("Заказ не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                fix.ID_Status = ((Status_FleetEquipment)StatusComboBox.SelectedItem).ID;

                db.SaveChanges();

                MessageBox.Show("Статус заказа успешно изменен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void BackButtonVehicle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
