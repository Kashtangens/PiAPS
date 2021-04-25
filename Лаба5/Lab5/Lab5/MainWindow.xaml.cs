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

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculatorService.CalculatorSoap calcServiceClient;

        public MainWindow()
        {
            InitializeComponent();
            calcServiceClient = new CalculatorService.CalculatorSoapClient();
        }

        // Событие нажатия кнопки сложения
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int firstArg, secondArg;
            try
            {
                if (int.TryParse(tbFirstArg.Text, out firstArg) && int.TryParse(tbSecondArg.Text, out secondArg))
                {
                    lblResult.Content = calcServiceClient.Add(firstArg, secondArg);
                }
                else
                {
                    MessageBox.Show("Введите целые числа в поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Сервис вернул сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Событие нажатия кнопки сложения
        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            int firstArg, secondArg;
            try
            {
                if (int.TryParse(tbFirstArg.Text, out firstArg) && int.TryParse(tbSecondArg.Text, out secondArg))
                {
                    lblResult.Content = calcServiceClient.Divide(firstArg, secondArg);
                }
                else
                {
                    MessageBox.Show("Введите целые числа в поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Сервис вернул сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Событие нажатия кнопки сложения
        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            int firstArg, secondArg;
            try
            {
                if (int.TryParse(tbFirstArg.Text, out firstArg) && int.TryParse(tbSecondArg.Text, out secondArg))
                {
                    lblResult.Content = calcServiceClient.Subtract(firstArg, secondArg);
                }
                else
                {
                    MessageBox.Show("Введите целые числа в поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Сервис вернул сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Событие нажатия кнопки умножения
        private void btnMul_Click(object sender, RoutedEventArgs e)
        {
            int firstArg, secondArg;
            try
            {
                if (int.TryParse(tbFirstArg.Text, out firstArg) && int.TryParse(tbSecondArg.Text, out secondArg))
                {
                    lblResult.Content = calcServiceClient.Multiply(firstArg, secondArg);
                }
                else
                {
                    MessageBox.Show("Введите целые числа в поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Сервис вернул сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
