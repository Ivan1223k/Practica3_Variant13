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

namespace Variant13
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

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!double.TryParse(HeightBox.Text, out double x))
                {
                    MessageBox.Show("Введена некорректная высота!", "Ошибка");
                }
                if (!double.TryParse(WidthBox.Text, out double y))
                {
                    MessageBox.Show("Введена некорректная ширина!", "Ошибка");
                }
                if (!double.TryParse(LenghtBox.Text, out double z))
                {
                    MessageBox.Show("Введена некорректная длина!", "Ошибка");
                }

                double selectedMaterial = SelectMaterial();

                if (selectedMaterial == 0)
                {
                    MessageBox.Show("Пожалуйста, выберите материал.");
                    return;
                }

                double result = Mass(x, y, z, selectedMaterial);
                ResultBox.Text = result.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private double SelectMaterial()
        {
            double P;
            if (Olovo.IsChecked == true) return 7300.0;
            if (Svinec.IsChecked == true) return  11340.0;
            if (Steel.IsChecked == true) return  7800.0;
            if (Ice.IsChecked == true) return 900.0;
            return 0;
        }

        private double Mass(double x, double y, double z, double selectedMaterial) {
            return x*y*z * selectedMaterial;
        }
    }
}
