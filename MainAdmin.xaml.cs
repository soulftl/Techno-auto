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
    /// Логика взаимодействия для MainAdmin.xaml
    /// </summary>
    public partial class MainAdmin : Window
    {
        private Button lastClickedButton;

        public MainAdmin()
        {
            InitializeComponent();
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            WelcomeTextBlock.Visibility = Visibility.Collapsed;

            MainFrame.Navigate(new User());

            Button clickedButton = (Button)sender;

            clickedButton.Background = (Brush)new BrushConverter().ConvertFromString("#FFBD7900");

            if (lastClickedButton != null)
            {
                lastClickedButton.Background = GetOriginalColor(lastClickedButton);
            }

            lastClickedButton = clickedButton;

        }

        private void Vehicle_Click(object sender, RoutedEventArgs e)
        {
            WelcomeTextBlock.Visibility = Visibility.Collapsed;

            MainFrame.Navigate(new Vehicle());

            Button clickedButton = (Button)sender;

            clickedButton.Background = (Brush)new BrushConverter().ConvertFromString("#FFBD7900");

            if (lastClickedButton != null)
            {
                lastClickedButton.Background = GetOriginalColor(lastClickedButton);
            }

            lastClickedButton = clickedButton;
        }

        private void CarPark_Click(object sender, RoutedEventArgs e)
        {
            WelcomeTextBlock.Visibility = Visibility.Collapsed;

            MainFrame.Navigate(new CarPark());

            Button clickedButton = (Button)sender;

            clickedButton.Background = (Brush)new BrushConverter().ConvertFromString("#FFBD7900");

            if (lastClickedButton != null)
            {
                lastClickedButton.Background = GetOriginalColor(lastClickedButton);
            }

            lastClickedButton = clickedButton;
        }

        private Brush GetOriginalColor(Button button)
        {
            switch (button.Name)
            {
                case "User":
                    return (Brush)new BrushConverter().ConvertFromString("#FFFFA608");
                case "Vehicle":
                    return (Brush)new BrushConverter().ConvertFromString("#FFFFA608");
                case "CarPark":
                    return (Brush)new BrushConverter().ConvertFromString("#FFFFA608");
                default:
                    return Brushes.Black;
            }
        }
    }
}
