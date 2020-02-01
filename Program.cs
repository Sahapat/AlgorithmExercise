using System;
using Exercise;

using static System.Console;

namespace DotnetPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            Clear();
            Write("1.Exercise Flagpole\n2.Exercise Packaging\n3.Exercise Colorful Village\n4.Math exercise\n5.Bouncing ball simulate\n6.Equation Solve\n7.FizzBuzz Problem\nSelect the order: ");
            var inputString = ReadLine();
            int orderSelected = 0;
            try
            {
                orderSelected = int.Parse(inputString);
            }
            catch (FormatException)
            {
                orderSelected = 0;
            }

            switch (orderSelected)
            {
                case 1:
                    FlagPoleProblem.Run();
                    break;
                case 2:
                    PackageProblem.Run();
                    break;
                case 3:
                    ColorfulVillageProblem.Run();
                    break;
                case 4:
                    MathExercise.Run();
                break;
                case 5:
                    BouncingBallSimulate.Run();
                break;
                case 6:
                    EquationSolve.Run();
                break;
                case 7:
                    FizzBuzzProblem.Run();
                break;
            }
            WriteLine("Program Terminate");
            ReadKey();
        }
    }
}
