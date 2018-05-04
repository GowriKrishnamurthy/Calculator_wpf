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
        enum Operation { Add, Subtract, Multiply, Divide, Equals, Start };
        Operation currentOperation = Operation.Start;
        double currentValue = 0;

        public MainWindow()
        {
            InitializeComponent();
            txtResult.Text = currentValue.ToString();
        }

        //Number button clicked
        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {

        }

        //Multiplication button clicked
        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
        }


        //Division button clicked
        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
        }


        //Subtraction button clicked
        private void btnSubtract_Click(object sender, RoutedEventArgs e)
        {
        }


        //Addition button clicked
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
        }

        //Equal to button clicked
        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {

        }

        //Clear the current results
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
        }


    }
}
