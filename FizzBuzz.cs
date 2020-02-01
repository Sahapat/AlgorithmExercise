using System.Collections;
using System.Collections.Generic;

using static System.Console;

//Solve with factory pattern
namespace Exercise
{
    interface IFizzBuzz
    {
        bool checkRule(int num);
        void PrintOut();
    }
    class Fizz : IFizzBuzz
    {
        public bool checkRule(int num)
        {
            return num % 3 == 0;
        }

        public void PrintOut()
        {
            WriteLine("Fizz");
        }
    }
    class Buzz : IFizzBuzz
    {
        public bool checkRule(int num)
        {
            return num % 5 == 0;
        }

        public void PrintOut()
        {
            WriteLine("Buzz");
        }
    }
    class FizzBuzzDefualt : IFizzBuzz
    {
        int num = 0;
        public bool checkRule(int num)
        {
            this.num =num; 
            return true;
        }

        public void PrintOut()
        {
            WriteLine(num);
        }
    }
    class FizzBuzzFactory
    {
        List<IFizzBuzz> factoryItem = new List<IFizzBuzz>(){
            new Fizz(),
            new Buzz(),
            new FizzBuzzDefualt()
        };
        public IFizzBuzz GetFizzBuzz(int num)
        {
            return factoryItem.Find(item => item.checkRule(num));
        }
    }
    public class FizzBuzzProblem
    {
        public static void Run()
        {
            FizzBuzzFactory fizzBuzzFactory = new FizzBuzzFactory();
            while (true)
            {
                Write("Input num: ");
                var num = 0;
                try
                {
                    num = int.Parse(ReadLine());
                }
                catch (System.FormatException)
                {
                    WriteLine("Please input num");
                }
                var fizzItem = fizzBuzzFactory.GetFizzBuzz(num);
                fizzItem.PrintOut();
                Write("Stop? Y/N: ");
                var inputString = ReadLine();
                if(inputString.ToLower() == "y")return;
            }
        }
    }
}