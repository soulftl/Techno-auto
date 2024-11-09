using FleetEquipment.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FleetEquipment
{
    /// <summary>
    /// Логика взаимодействия для MainTechnician.xaml
    /// </summary>
    public partial class MainTechnician : Window
    {
        private int _currentUserId;
        public MainTechnician(string fullName, int currentUserId)
        {
            InitializeComponent();

            _currentUserId = currentUserId;

            RefreshDataGrid();

            Welcome_TextBlock.Text = $"{fullName}";
        }

        private void RefreshDataGrid()
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                DataGridFix.ItemsSource = db.Fix_FleetEquipment
                    .Where(f => f.ID_Technician == _currentUserId)
                    .Include(f => f.Status_FleetEquipment)
                    .ToList();
            }
        }

        private void DataGridFix_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var fix = e.Row.DataContext as Fix_FleetEquipment;

            if (fix != null)
            {
                var statusComboBox = new ComboBox
                {
                    ItemsSource = GetStatusOptions(),
                    DisplayMemberPath = "Name",
                    SelectedValuePath = "ID",
                    SelectedValue = fix.Status_FleetEquipment?.ID
                };

                var statusCell = GetCell(e.Row, 2);
                if (statusCell != null)
                {
                    statusCell.Content = statusComboBox;
                }
            }
        }

        private List<Status_FleetEquipment> GetStatusOptions()
        {
            using (var db = new FleetEquipment_user32_dbEntities())
            {
                var statusOptions = db.Status_FleetEquipment.ToList();
                return statusOptions;
            }
        }

        private void DataGridFix_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var row = e.Row.DataContext as Fix_FleetEquipment;

                using (var db = new FleetEquipment_user32_dbEntities())
                {
                    db.Fix_FleetEquipment.Attach(row);
                    db.Entry(row).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void But_Update_Click(object sender, RoutedEventArgs e)
        {
            var fixId = (int)((Button)sender).CommandParameter;

            var editStatusWindow = new EditStatus(fixId);
            editStatusWindow.ShowDialog();

            RefreshDataGrid();
        }

        private DataGridCell GetCell(DataGridRow row, int columnIndex)
        {
            var presenter = FindVisualChild<DataGridCellsPresenter>(row);
            if (presenter != null)
            {
                return (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
            }
            return null;
        }

        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typedChild)
                {
                    return typedChild;
                }

                var childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
            return null;
        }
    }
}
