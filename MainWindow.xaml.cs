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

namespace Calculator_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isNewEntry = true;
        double currentValue = 0;
        enum Operation { Add, Subtract, Multiply, Divide, Equals};
        Operation currentOperation;
        public MainWindow()
        {
            InitializeComponent();
            txtResult.Text = currentValue.ToString();
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            //dummy result value for trying to parse the entry string
            int result;

            //Get the value from the button label
            Button btn = (Button)sender;
            string value = btn.Content.ToString();

            //special handling for decimal point
            if (value.Equals("."))
            {
                if (isNewEntry)
                {
                    return;
                }
                if (!txtResult.Text.Contains("."))
                {
                    txtResult.Text += value;
                    isNewEntry = false;
                }
                return;
            }

            //try to parse entry as int; 
            //if successful, append to current entry
            if (Int32.TryParse(value, out result))
            {
                if (isNewEntry || txtResult.Text.Equals("0"))
                {
                    txtResult.Text = "";
                }
                txtResult.Text += value;
                isNewEntry = false;
            }
        }

        private void Calculate(Operation op)
        {
            double newValue = Double.Parse(txtResult.Text);
            double result;

            if (op != Operation.Equals)
            {
                currentOperation = op;
            }

            switch (currentOperation)
            {
                case Operation.Subtract:
                    if (currentValue == 0)
                    {
                        result = newValue;
                    }
                    else
                    {
                        result = currentValue - newValue;
                    }
                    break;
                case Operation.Add:
                    result = currentValue + newValue;
                    break;
                case Operation.Multiply:
                    if (currentValue == 0)
                    {
                        result = newValue;
                    }
                    else
                    {
                        result = currentValue * newValue;
                    }
                    break;
                case Operation.Divide:
                    if (newValue == 0)
                    {
                        txtResult.Text = currentValue.ToString();
                        return;
                    }
                    else if (currentValue == 0)
                    {
                        currentValue = newValue;
                        txtResult.Text = "0";
                        return;
                    }
                    else
                    {
                        result = currentValue / newValue;
                    }
                    break;
                default:
                    return;
            }

            currentValue = result;
            txtResult.Text = result.ToString();
            isNewEntry = true;
        }

        // Event handlers for operations.
        //Multiplication button clicked
        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Operation.Multiply);
        }

        //Division button clicked
        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Operation.Divide);
        }

        //Subtraction button clicked
        private void btnSubtract_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Operation.Subtract);
        }
        
        //Addition button clicked
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Operation.Add);
        }

        //Equal to button clicked. Last operation
        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Operation.Equals);
        }

        //Clear the current results
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "0";
            currentValue = 0;
            isNewEntry = true;
        }


    }
}
