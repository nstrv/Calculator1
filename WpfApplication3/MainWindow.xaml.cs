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
        public string operation2;
        public string left;
        public bool boolright;
        public string ms;
        public int bl = 0;
        public int del = 0; // нажатие /
        public bool num = false; //нажатие 0-9
        public bool sq = false; //нажатие sqrt
        public bool delx = false; // нажатие 1\х
        public bool kv = false; // нажатие sqr
        public string pez = ""; //копирует textBox1.Text после нажатия =
        public bool rav = false; // нажатие =
        public bool proc; // нажатие %

        public MainWindow()
        
        {
            boolright = false;
            InitializeComponent();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //кнопки от 0 до 9
        {
            if (textBox1.Text == "∞") 
                textBox1.Text = "";

            if (textBox1.Text == "бесконечность")
                textBox1.Text = "";
            if (boolright == true)
            {
                boolright = false;
                textBox1.Text = "";
            }
            Button B = (Button)sender;
            if (textBox1.Text == "0")
                textBox1.Text = B.Content.ToString();
            else
                textBox1.Text += B.Content.ToString();
            
            if (boolright == true)
            {
                boolright = false;
                textBox2.Text = "";
            }
            Button B1 = (Button)sender;
            if ((textBox2.Text == "0") && (sq == false) && (kv == false) && (delx == false))
                textBox2.Text = B1.Content.ToString();
            if ((textBox2.Text != "0") && (sq == false) && (kv == false) && (delx == false))
                textBox2.Text += B1.Content.ToString();
            num = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //очистка
        {
                textBox1.Text = "0";
                textBox2.Text = "";
                bl = 0;
                pez = "";
                sq = false;
                kv = false;
                delx = false;
                proc = false;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //операции
        {
            if ((textBox2.Text == "") && (textBox1.Text == "0"))
                textBox2.Text = "0";
            if ((textBox2.Text == "") && (textBox1.Text != "0"))
                textBox2.Text = textBox1.Text;

            if ((sq == false) && (kv == false) && (delx == false))
            {
                Button B = (Button)sender;
                operation = B.Content.ToString();
                left = textBox1.Text;
                boolright = true;

                if (bl == 0)
                {
                    bl++;
                    textBox2.Text += operation;
                }
            }
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //результат
        {
            
            double db1, db2, result;
            result = 0;
            db1 = Convert.ToDouble(left);
            db2 = Convert.ToDouble(textBox1.Text);
           
            if (operation == "+")
            {
               textBox2.Text = "";
               result = db1 + db2;

               if (proc == true)
               {
                 textBox2.Text = "";
                 result = db1 + (db1 * db2/100);
               }
            }
            if (operation == "-")
            {
                textBox2.Text = "";
                result = db1 - db2;
                if (proc == true)
                {
                    textBox2.Text = "";
                    result = db1 - (db1 * db2 / 100);
                }
            }
            if (operation == "*")
            {
                textBox2.Text = "";
                result = db1 * db2;
                if (proc == true)
                {
                    textBox2.Text = "";
                    result = db1 * db2/100;
                }
            }
            if (operation == "/")
            {
                textBox2.Text = "";
                result = db1 / db2;
                if (proc == true)
                {
                    textBox2.Text = "";
                    result = db1 / (db1 * db2 / 100);
                }
            }
            operation = "=";
            boolright = true;
            bl = 0;
            textBox1.Text = result.ToString();
            pez = textBox1.Text;
            rav = true;

        }

        private void Button_Click_5(object sender, RoutedEventArgs e) //извлечение квадратного корня
        {
            textBox2.Text = "";
            double db, result;
            textBox2.Text = textBox2.Text.Insert(0, "sqrt(");
            textBox2.Text += textBox1.Text;
            textBox2.Text += ")";
            db = Convert.ToDouble(textBox1.Text);
            result = Math.Sqrt(db);
            textBox1.Text = result.ToString();
            pez = textBox1.Text;
            sq = true;
           
        }

        private void Button_Click_6(object sender, RoutedEventArgs e) //возведение в квадрат
        {
            textBox2.Text = "";
            double db, result;
            textBox2.Text = textBox2.Text.Insert(0, "sqr(");
            textBox2.Text += textBox1.Text;
            textBox2.Text += ")";
            db = Convert.ToDouble(textBox1.Text);
            result = Math.Pow(db, 2);
            textBox1.Text = result.ToString();
            kv = true;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e) // 1\х
        {
            textBox2.Text = "";
            if (textBox1.Text == "∞")
                textBox1.Text = "0";
            if (textBox1.Text == "бесконечность")
                textBox1.Text = "0";
            double db, result;
            textBox2.Text = textBox2.Text.Insert(0, "reciproc(");
            textBox2.Text += textBox1.Text;
            textBox2.Text += ")";
            db = Convert.ToDouble(textBox1.Text);
            result = 1 / db;
            textBox1.Text = result.ToString();
            delx = true;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e) //изменение знака
        {
            
            double db, result;
            db = Convert.ToDouble(textBox1.Text);
            result = -db;
            textBox1.Text = result.ToString();
            textBox2.Text = result.ToString();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e) //запятая
        {
            
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
                textBox2.Text += ",";
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e) //удаление последней цифры
        {

            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            if ((sq == false) && (kv == false) && (delx == false) && (textBox2.Text.Length >= 0))
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
            if (textBox1.Text == "")
                textBox1.Text = "0";
            if (textBox2.Text == "")
                textBox2.Text = "0";
        }

        private void Button_Click_11(object sender, RoutedEventArgs e) //MS
        {
            ms = textBox1.Text;
        }

        private void Button_Click_12(object sender, RoutedEventArgs e) //MR
        {
            textBox1.Text = ms;
        }

        private void Button_Click_13(object sender, RoutedEventArgs e) //MC
        {
            ms = "0";
            textBox1.Text = "0";
            textBox2.Text = "";
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

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            proc = true;
            if  ((sq == false) && (kv == false) && (delx == false) && (rav = false))
                textBox2.Text += "%";
        }
    }
}
