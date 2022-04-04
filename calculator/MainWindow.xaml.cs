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

namespace calculator
{
    public partial class MainWindow : Window
    {
        double x;
        char oper;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            if(textBox.Text == "0")
                textBox.Text = (sender as Button)?.Content.ToString();
            else
                if(textBox.Text.Length < 25)
            textBox.Text += (sender as Button)?.Content;
        }

        private void ButtonPoint_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.IndexOf(',') < 0)
                textBox.Text += ",";

        }
        private void ButtonOper_Click(object sender, RoutedEventArgs e)
        {
            x = Convert.ToDouble(textBox.Text);
            oper = (sender as Button).Content.ToString()[0];
            textBox.Text = "0";
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            double y = Convert.ToDouble(textBox.Text);
            double result = 0;
            switch (oper)
            {
                case '+': result = x + y; break;
                case '-': result = x - y; break;
                case '*': result = x * y; break;
                case '/': result = x / y; break;
                case 'i': break;
            }
            textBox.Text = result.ToString();
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "0";
            oper = 'i';
            x = 0;
        }
        private void ButtonClearLast_Click(object sender, RoutedEventArgs e) {
            textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
        }
        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            var theKeyAsAString = e.Key.ToString();
            var theKeyAsAChar = Convert.ToChar(theKeyAsAString[theKeyAsAString.Length - 1]);
            if (!Char.IsNumber(theKeyAsAChar))
                e.Handled = true;
        }
    }
}
