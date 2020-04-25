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

namespace Калькулятор
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string operation;
        public string right;
        public bool boolleft;
        public string ms;

        public MainWindow()
        
        {
            boolleft = false;
            InitializeComponent();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //кнопки от 0 до 9
        {
            if (textBox1.Text == "M")
                textBox1.Text = "";
            if (boolleft == true)
            {
                boolleft = false;
                textBox1.Text = "";
            }
            Button B = (Button)sender;
            if (textBox1.Text == "0")
                textBox1.Text = B.Content.ToString();
            else
                textBox1.Text += B.Content.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //очистка
        {
                textBox1.Text = "0";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //операции
        {
            if (textBox1.Text == "M")
                textBox1.Text = "0";
            Button B = (Button)sender;
            operation = B.Content.ToString();
            right = textBox1.Text;
            boolleft = true;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //результат
        {
            if (textBox1.Text == "M")
                textBox1.Text = "0";
            double db1, db2, result;
            result = 0;
            db1 = Convert.ToDouble(right);
            db2 = Convert.ToDouble(textBox1.Text);
            if (operation == "+")
            {
                result = db1 + db2;
            }
            if (operation == "-")
            {
                result = db1 - db2;
            }
            if (operation == "*")
            {
                result = db1 * db2;
            }
            if (operation == "/")
            {
                result = db1 / db2;
            }
            if (operation == "%")
            {
                result = db1 * db2/ 100;
            }
            operation = "=";
            boolleft = true;
            textBox1.Text = result.ToString();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) //извлечение квадратного корня
        {
            double db, result;

            db = Convert.ToDouble(textBox1.Text);
            result = Math.Sqrt(db);
            textBox1.Text = result.ToString();
           
        }

        private void Button_Click_6(object sender, RoutedEventArgs e) //возведение в квадрат
        {
            if (textBox1.Text == "M")
                textBox1.Text = "0";
            double db, result;

            db = Convert.ToDouble(textBox1.Text);
            result = Math.Pow(db, 2);
            textBox1.Text = result.ToString();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e) // 1\х
        {
            if (textBox1.Text == "M")
                textBox1.Text = "0";
            double db, result;

            db = Convert.ToDouble(textBox1.Text);
            result = 1 / db;
            textBox1.Text = result.ToString();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e) //изменение знака
        {
            if (textBox1.Text == "M")
                textBox1.Text = "0";
            double db, result;

            db = Convert.ToDouble(textBox1.Text);
            result = -db;
            textBox1.Text = result.ToString();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e) //запятая
        {
            if (textBox1.Text == "M")
                textBox1.Text = "0";
            if (!textBox1.Text.Contains(","))
                textBox1.Text += ",";
        }

        private void Button_Click_10(object sender, RoutedEventArgs e) //удаление последней цифры
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            if (textBox1.Text == "")
                textBox1.Text = "0";
        }

        private void Button_Click_11(object sender, RoutedEventArgs e) //MS
        {
            ms = textBox1.Text;
            textBox1.Text = "M";
        }

        private void Button_Click_12(object sender, RoutedEventArgs e) //MR
        {
            
            textBox1.Text = ms;
        }

        private void Button_Click_13(object sender, RoutedEventArgs e) //MC
        {
            ms = "0";
            textBox1.Text = "0";
        }

        private void Button_Click_14(object sender, RoutedEventArgs e) //M+
        {
            double a1;
            Button B = (Button)sender;
            a1 = Convert.ToDouble(ms) + Convert.ToDouble(textBox1.Text);
            ms = Convert.ToString(a1);
        }

        private void Button_Click_15(object sender, RoutedEventArgs e) //M-
        {
            double a2;
            Button B = (Button)sender;
            a2 = Convert.ToDouble(ms) - Convert.ToDouble(textBox1.Text);
            ms = Convert.ToString(a2);
        }

        
    }
}
