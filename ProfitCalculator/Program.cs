using System;

namespace ProfitCalculator
{

    class Calculator
    {
        public static double DoOperation(double result, double cleanNum1, double cleanNum2, string op)
        {

            switch(op)
            {
                case "i":
                    result = cleanNum1 + cleanNum2;
                    break;
                case "e":
                    result =cleanNum1 - cleanNum2;
                    break;
            }

            return result;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Welcome to this profit calculator");

            while (!endApp)
            {
                string num1 = "";
                string num2 = "";
                double result = 0;

                Console.WriteLine("Do you want to add an Income or an Expense?");
                Console.WriteLine("\ti - Income");
                Console.WriteLine("\te - Expense");
                Console.WriteLine("Choose your option and press Enter: ");

                string op = Console.ReadLine();

                Console.WriteLine("Please enter the value of your change: ");
                num1 = Console.ReadLine();


                double cleanNum1 = 0;
                while (!double.TryParse(num1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter a valid number: ");
                    num1 = Console.ReadLine();
                }

                Console.WriteLine("Please enter the next value of your change: ");
                num2 = Console.ReadLine();


                double cleanNum2 = 0;
                while (!double.TryParse(num2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter a valid number: ");
                    num2 = Console.ReadLine();
                }

                while (string.IsNullOrEmpty(op))
                {
                    Console.WriteLine("This can't be empty, please choose i or e: ");
                    op = Console.ReadLine();
                }

                int n;
                bool parsetrue = Int32.TryParse(op, out n);
                while (parsetrue)
                {
                Console.WriteLine("This can't be a number, please choose i or e: ");
                op = Console.ReadLine();
                }
                while (op == "i")
                {
                Calculator.DoOperation(result, cleanNum1, cleanNum2, op);
                }
                while (op == "e")
                {
                    Calculator.DoOperation(result, cleanNum1, cleanNum2, op);
                }
               

                try
                {
                    result = Calculator.DoOperation(result, cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error");
                    }else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch(Exception e)
                {
                    Console.WriteLine("An exception occurred: " + e.Message);
                }

                Console.WriteLine("---------------------------\n");

                Console.WriteLine("Press x to close the application or any other key to continue: ");
                if (Console.ReadLine() == "x") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}
