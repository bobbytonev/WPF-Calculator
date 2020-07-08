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

namespace CalculatorWPF
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

       

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Calcualtor c = new Calcualtor(equals);



           // string s = "(8-9)";
            //String[] s1 =s.matches("\\s*(?:(?<![\\d-])-\\d|[-+\\/*()])|\\d+\\s*");

            //  List<String> test = c.regexBuilder(s, "\\s*(?:(?<![\\d-])-\\d|[+-\\/*()])|\\d+?[.]\\d|\\d\\s*");
            // MessageBox.Show(c.infixToPostFix(test));
           //MessageBox.Show(c.validate("((5-9"));
            
           double result =c.eval(equals.Text);
           hystory.Text += equals.Text+"="+result+"\n";

            equals.Text = result + "";

          

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (equals.Text.Length - 1 >= 0)
            {
                equals.Text = equals.Text.Remove(equals.Text.Length - 1);
            }
            
        }

      

        private void command(object sender, RoutedEventArgs e)
        {
            Button command = sender as Button;

            if (command == null)

                return;


            if (int.TryParse(command.Content.ToString(), out int number)|| command.Content.ToString().Equals("("))
            {
                if (equals.Text.Equals("0"))
                {
                    equals.Text = "";
                }
                
            }
                equals.Text += command.Content.ToString();
                
               
            
           
           
           
          



        }
    }
}
