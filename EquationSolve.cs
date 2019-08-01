using System.Collections;
using System.Text;

using static System.Console;

namespace Exercise
{
    public class EquationSolve
    {
        private const char separateCharacter = ',';
        public static void Run()
        {
            Write("Input X: ");
            int x = int.Parse(ReadLine());
            Write("Input Y: ");
            int y = int.Parse(ReadLine());
            Write("Input Equation string: ");
            var inputString = ReadLine();

            WriteLine("Result is " + Solve2VariableEquation(x, y, inputString).ToString());
        }
        public static int Solve2VariableEquation(int X, int Y, string equationString)
        {
            return CalculatePostfix(X, Y, ToStackPostfixString(equationString));
        }
        static string ToStackPostfixString(string equationString)
        {
            Stack operationStack = new Stack();
            StringBuilder postfixExpression = new StringBuilder();
            bool focusExpression = true;
            foreach (var ch in equationString)
            {
                if (ch == ' ') continue;
                if (ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '(')
                {
                    if (operationStack.Count == 0) operationStack.Push(ch);
                    else
                    {
                        char topStack = char.Parse(operationStack.Peek().ToString());
                        if (GetPriolityByCharacter(topStack) >= GetPriolityByCharacter(ch))
                        {
                            if (ch != '(') postfixExpression.Append(operationStack.Pop().ToString());
                            operationStack.Push(ch);
                        }
                        else { operationStack.Push(ch); }
                    }
                    if (focusExpression)
                    {
                        postfixExpression.Append(separateCharacter);
                        focusExpression = false;
                    }
                }
                else if (ch == ')')
                {
                    while (operationStack.Count > 0)
                    {
                        var operation = operationStack.Pop().ToString();
                        if (operation == "(") break;
                        postfixExpression.Append(operation);
                    }
                }
                else
                {
                    focusExpression = true;
                    postfixExpression.Append(ch);
                }
            }
            while (operationStack.Count > 0)
            {
                var operation = operationStack.Pop().ToString();
                postfixExpression.Append(operation);
            }
            return postfixExpression.ToString();
        }
        static int CalculatePostfix(int x, int y, string postfixString)
        {
            Stack numberStack = new Stack();
            StringBuilder numberBuilderTemp = new StringBuilder();

            foreach (var ch in postfixString)
            {
                if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                {
                    int expression1 = 0;
                    int expression2 = 0;
                    if (numberBuilderTemp.Length != 0)
                    {
                        expression1 = int.Parse(numberStack.Pop().ToString());
                        expression2 = getNumberFromExpression(x, y, numberBuilderTemp.ToString());
                        numberBuilderTemp.Clear();
                    }
                    else
                    {
                        expression2 = int.Parse(numberStack.Pop().ToString());
                        expression1 = int.Parse(numberStack.Pop().ToString());
                    }
                    if (ch == '+') numberStack.Push(expression1 + expression2);
                    else if (ch == '-') numberStack.Push(expression1 - expression2);
                    else if (ch == '*') numberStack.Push(expression1 * expression2);
                    else if (ch == '/') numberStack.Push(expression1 / expression2);
                }
                else if (ch == separateCharacter)
                {
                    if (numberBuilderTemp.Length != 0)
                    {
                        numberStack.Push(getNumberFromExpression(x, y, numberBuilderTemp.ToString()));
                        numberBuilderTemp.Clear();
                    }
                }
                else
                {
                    numberBuilderTemp.Append(ch);
                }
            }
            return int.Parse(numberStack.Pop().ToString());
        }
        static int getNumberFromExpression(int x, int y, string expression)
        {
            if (expression.Contains('x'))
            {
                var number = int.Parse(expression.Remove(expression.IndexOf('x')));
                number *= x;
                return number;
            }
            else if (expression.Contains('y'))
            {
                var number = int.Parse(expression.Remove(expression.IndexOf('y')));
                number *= y;
                return number;
            }
            else
            {
                return int.Parse(expression);
            }
        }
        static byte GetPriolityByCharacter(char ch)
        {
            if (ch == '(') return 1;
            else if (ch == '+' || ch == '-') return 2;
            else if (ch == '*' || ch == '/') return 3;
            else return 0;
        }
    }

}