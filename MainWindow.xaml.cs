using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

namespace WpfAppStatusbar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void CalculateFactorialClick(object sender, RoutedEventArgs e)
        {
            // Очистка статуса и прогресса
            statusText.Text = string.Empty;
            progressBar.Value = 0;

            // Получение числа для вычисления факториала из TextBox
            if (int.TryParse(inputTextBox.Text, out int number))
            {
                // Асинхронное выполнение операции
                BigInteger result = await Task.Run(() => CalculateFactorial(number));

                // Вывод результата
                statusText.Text = $"Факториал {number} равен: {result}";
            }
            else
            {
                statusText.Text = "Введите корректное число.";
            }
        }

        private BigInteger CalculateFactorial(int number)
        {
            BigInteger result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;

                // Обновление прогресса
                int progressPercentage = (int)(((double)i / number) * 100);
                Application.Current.Dispatcher.Invoke(() => UpdateProgress(progressPercentage));
            }

            return result;
        }

        private void UpdateProgress(int progressPercentage)
        {
            // Обновление прогресса в ProgressBar
            progressBar.Value = progressPercentage;
        }
    }
}

