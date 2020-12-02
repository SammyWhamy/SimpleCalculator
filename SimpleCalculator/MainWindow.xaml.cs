using System;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow _instance = null;

        private void UpdateText(TextBox textbox)
        {
            if (textbox.Text == "Nothing put in yet" || textbox.Text == "0")
            {
                textbox.Text = "";
            }
        }

        private Double Calc(String expression)
        {
            try
            {
                expression = expression.Replace("×", "*");
                expression = expression.Replace("÷", "/");
                Regex rx = new Regex(@"(?<percentage>[\d.]+)(%)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                MatchCollection matches = rx.Matches(expression);
                Console.WriteLine(matches);
                foreach (Match match in matches)
                {
                    GroupCollection groups = match.Groups;
                    expression = expression.Replace(match.Value, (Double.Parse(groups["percentage"].Value) / 100).ToString()+"*");
                }
                Console.WriteLine(expression);
                System.Data.DataTable table = new System.Data.DataTable();
                return Convert.ToDouble(table.Compute(expression, String.Empty));
            } catch (Exception)
            {
                return Double.NaN;
            }
            
        }
        public MainWindow()
        {
            _instance = this;
            InitializeComponent();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if(_instance.Input.Text != "Nothing put in yet" && _instance.Input.Text.Length > 0)
            {
                double res = Calc(_instance.Input.Text);
                _instance.Result.Text = res.ToString("0.######");
                Clipboard.SetText(res.ToString("0.######"));
                if(!Double.IsNaN(res))
                {
                    _instance.PrevExpression.Text = _instance.Input.Text;
                    _instance.Input.Text = res.ToString("0.######");
                }
            }
        }
        // Number Clicks
        private void NumberZero_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "0";
        }
        private void NumberOne_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "1";
        }
        private void NumberTwo_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "2";
        }
        private void NumberThree_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "3";
        }
        private void NumberFour_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "4";
        }
        private void NumberFive_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "5";
        }
        private void NumberSix_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "6";
        }
        private void NumberSeven_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "7";
        }
        private void NumberEight_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "8";
        }
        private void NumberNine_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "9";
        }

        // Operator Clicks
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "+";
        }
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "-";
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += ".";
        }
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "÷";
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "×";
        }
        private void Percentage_Click(object sender, RoutedEventArgs e)
        {
            UpdateText(_instance.Input);
            _instance.Input.Text += "%";
        }

        // Other Clicks
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if(_instance.Input.Text != "Nothing put in yet" && _instance.Input.Text.Length > 0)
            {
                _instance.Input.Text = _instance.Input.Text.Remove(_instance.Input.Text.Length - 1);
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _instance.Input.Text = "Nothing put in yet";
            _instance.Result.Text = "0";
        }
    }
}
