using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CalculatorWPF
{
    class Calcualtor
    {

       public TextBox box;
      public  Calcualtor(TextBox box)
        {
            this.box = box;
        }

        private bool flag = false;
        
        public double eval(String equation)
        {

           equation = validate(equation);
            if (equation.Equals(""))
            {
                box.Text = "Validation error";
                return 0;
            }
            
            List<String> splitedEquation = regexBuilder(equation, "\\s*(?:(?<![\\d-])-\\d[.]{0,1}\\d+|[+-\\/*()])|\\d+?[.]\\d|\\d\\s*");

            

            String[] tokens = Regex.Split(infixToPostFix(splitedEquation)," +");
            Stack<Double> stack = new Stack<Double>();

            for (int i = 0; i < tokens.Length; i++)
            {
                double number;

                if (double.TryParse(tokens[i], out  number))
                {

                    stack.Push(number);

                } else
                {
                    if (stack.Count < 2)
                    {
                        box.Text = "Expression error";
                        return 0;
                        
                    }
                    double a = stack.Pop();
                    double b = stack.Pop();
                    switch (tokens[i])
                    {
                        case "+":
                          
                            stack.Push(a + b);
                            break;
                        case "-":
                          
                            stack.Push(b - a);
                            break;
                        case "*":
                          
                            stack.Push(a * b);
                            break;
                        case "/":
                             if (a != 0) {
                                stack.Push(b / a);
                              
                            }
                            else
                            {
                                return 0;
                            }
                                
                           

                            break;
                    }
                }
            }

            return stack.Pop();

        }


        public  List<String> regexBuilder(String rawData, String regex)
        {

            MatchCollection matchList = Regex.Matches(rawData, regex);


            return matchList.Cast<Match>().Select(match => match.Value).ToList();
        }



        public String validate(String equation)
        {
            int brOpenBrakets=0;
            int brCloseBrakets = 0;
            
            for (int i = 0; i < equation.Length; i++) { 
                if(equation[i]=='(')
                {
                    brOpenBrakets++;
                }
                if (equation[i] == ')')
                {
                    brCloseBrakets++;
                }
            }
            String newEquation = equation;
            if (!Char.IsDigit(newEquation[newEquation.Length - 1])&&!newEquation[newEquation.Length - 1].Equals(')'))
            {
                newEquation=newEquation.Remove(newEquation.Length - 1); 
            }
           
            int sum = brOpenBrakets - brCloseBrakets;
            if (sum < 0)
            {
                return "";
            }
           
            for (int i = 0; i < sum; i++)
            {
                newEquation += ")";
            }


            return newEquation;


        }

        public String infixToPostFix(List<String> token)
        {
            
            StringBuilder postfix = new StringBuilder();

            Stack<String> stack = new Stack<String>();

            String operators = "+-*/";
            int[] p = { 1, 1, 2, 2 };

            for (int i = 0; i < token.Count; i++)
            {

                if (double.TryParse(token[i],out double param))
               {
                    postfix.Append(token[i]);
                   
               }
                else
                {
                    
                    if (token[i].Equals(")"))
                    {
                        while (stack.Any())
                        {
                            string sign = stack.Pop();
                            flag = true;
                            if (sign.Equals("("))
                            {
                                
                                break;
                            }
                            postfix.Append(" "+sign);

                        }
                    }
                    else
                    {
                        while (stack.Any())
                        {

                            string sign = stack.Pop();
                            if (sign.Equals("(") || token[i].Equals("(")
                               || p[operators.IndexOf(sign.ToCharArray()[0])] < p[operators.IndexOf(token[i])])
                            {

                                flag = true;
                                stack.Push(sign);
                                break;
                            }
                            postfix.Append(" "+sign);



                        }
                        if (!postfix.ToString().Equals(""))
                        {
                           
                            postfix.Append(" ");
                        }
                        stack.Push(token[i]);
                       

                  }

                }

            }
            while (stack.Any())
            {
                postfix.Append(" "+stack.Pop());
            }

            return postfix.ToString();

        }
    }


}
