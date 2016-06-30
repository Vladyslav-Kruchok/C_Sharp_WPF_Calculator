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

namespace C_Sharp_WPF_Lesson1_Calculator_HW_201603116
{
    /*
    Class to examine to right value
    */
    public class Is
    {
        private string m_str;
        public Is()
        {
            m_str = "";
        }
        public Is(string c_str)
        {
            m_str = c_str;
        }
        public bool IsTruePoint()
        {
            int len = m_str.Length;
            if (len == 0)
                return true;
            if (m_str[len - 1] == '+' | m_str[len - 1] == '-' | m_str[len - 1] == '*' | m_str[len - 1] == '/')
                return true;
            //examine for 123.123.123.123 or 123operator.
            for ( int i = len; i > 0 ; --i)
            {
                if (m_str[i-1]=='+' | m_str[i-1] == '-' | m_str[i-1] == '*' | m_str[i-1] == '/')
                    return false;
                if (m_str[i-1] == ',')
                    return true;
            }
            return false;
        }
        public bool IsTrueOperator()
        {
            int len = m_str.Length;
            if (len == 0)
                return true;
            if (m_str[len - 1] == '+' | m_str[len - 1] == '-' | m_str[len - 1] == '*' | m_str[len - 1] == '/' | m_str[len - 1] == ',')
                return true;
            return false;
        }
        public double Calculate()
        {
            int len = m_str.Length;//25+67\0 len=6
            string figure_str = "";
            string operation_str = "";
            double[] figure = new double[2];
            int count = 0;
            for (int i=0; i < len; ++i)
            {
                if (m_str[i] >= '0' & m_str[i] <= '9' | m_str[i]==',')
                {
                    figure_str += m_str[i];
                }
                if (m_str[i] == '+' | m_str[i] == '-' | m_str[i] == '*' | m_str[i] == '/')
                {
                    operation_str += m_str[i];
                    figure[count] = Convert.ToDouble(figure_str);
                    figure_str = "";
                    count++;
                }
            }
            figure[count] = Convert.ToDouble(figure_str);
            switch(operation_str)
            {
                case "+":return figure[0] + figure[1];
                case "-":return figure[0] - figure[1];
                case "*":return figure[0] * figure[1];
                case "/":return figure[0] / figure[1];
            }
            return 0;
        }
        public string IsOperator(string str)
        {

            return str;
        }

    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const char zero = '0', one = '1', two = '2', 
                   three = '3', four = '4', five = '5',
                   six = '6', seven = '7', eight = '8', nine = '9';
        const char plus = '+', minus = '-', mul = '*', dev = '/', res = '=', 
                   point = ',', pm = '-', priority_open = '(', priority_close = ')';
        const string clear = "";
        double [] buff_figure = new double[20];
        //point done
        private void BtPt_Click(object sender, RoutedEventArgs e)
        {
            Is temp = new Is(Field_of_result.Text);
            if (!temp.IsTruePoint())
            {
                Field_of_result.Text += point;
            }
        }
        //clear done
        private void BtClear_Click(object sender, RoutedEventArgs e)
        {
            Field_of_result.Text = clear;
        }
        //back done
        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            int len = Field_of_result.Text.Length;
            Field_of_result.Text = Field_of_result.Text.Remove((len - 1), 1);
        }

        //(+/-) написати умову вставки мінуса перед значенням
        private void BtPM_Click(object sender, RoutedEventArgs e)
        {
           
        }
        //- done
        private void BtMinus_Click(object sender, RoutedEventArgs e)
        {
            Is temp = new Is(Field_of_result.Text);
            if (!temp.IsTrueOperator())
            {
                Field_of_result.Text += minus;
            }

        }
        //+ done
        private void BtPlus_Click(object sender, RoutedEventArgs e)
        {
            Is temp = new Is(Field_of_result.Text);
            if (!temp.IsTrueOperator())
            {
                Field_of_result.Text += plus;
            }
         }
        //devide done
        private void BtDev_Click(object sender, RoutedEventArgs e)
        {
            Is temp = new Is(Field_of_result.Text);
            if (!temp.IsTrueOperator())
            {
                Field_of_result.Text += dev;
            }
        }
        //* done
        private void BtMul_Click(object sender, RoutedEventArgs e)
        {
            Is temp = new Is(Field_of_result.Text);
            if (!temp.IsTrueOperator())
            {
                Field_of_result.Text += mul;
            }
        }
        // (=) (=) (=) (=) (=) (=) (=) (=) (=) (=) (=) (=) (=) (=)
        private void BtRes_Click(object sender, RoutedEventArgs e)
        {
            int len = Field_of_result.Text.Length;
            //if (first operator) to delete;
            if (Field_of_result.Text[len - 1] == plus 
                | Field_of_result.Text[len - 1] == minus 
                | Field_of_result.Text[len - 1] == mul 
                | Field_of_result.Text[len - 1] == dev 
                | Field_of_result.Text[len - 1] == point)
            {
                Field_of_result.Text = Field_of_result.Text.Remove((len - 1), 1);
                len--; 
            }
            //if (first figure) to define a whole figure
            Is result = new Is(Field_of_result.Text);
            Field_of_result.Text = result.Calculate().ToString();
        }

        private void Bt0_Click(object sender, RoutedEventArgs e)
        {
            Field_of_result.Text += zero;
        }
        private void Bt9_Click(object sender, RoutedEventArgs e)
        {
            Field_of_result.Text += nine;
        }
        private void Bt8_Click(object sender, RoutedEventArgs e)
        {
            Field_of_result.Text += eight;
        }
        private void Bt7_Click(object sender, RoutedEventArgs e)
        {
            Field_of_result.Text += seven;
        }
        private void Bt6_Click(object sender, RoutedEventArgs e)
        {
            Field_of_result.Text += six;
        }
        private void Bt5_Click(object sender, RoutedEventArgs e)
        {
            Field_of_result.Text += five;
        }
        private void Bt4_Click(object sender, RoutedEventArgs e)
        {
            Field_of_result.Text += four;
        }
        private void Bt3_Click(object sender, RoutedEventArgs e)
        {
            Field_of_result.Text += three;
        }
        private void Bt2_Click(object sender, RoutedEventArgs e)
        {
            Field_of_result.Text += two;
        }
        private void Bt1_Click(object sender, RoutedEventArgs e)
        {
            Field_of_result.Text += one;
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
