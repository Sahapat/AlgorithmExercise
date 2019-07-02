using System;
using static System.Console;

namespace Exercise
{
    class BouncingBallSimulate
    {
        /*Proposition
        The ball fall from the high place with n height
        When it touch the floor will bounce back with 90% height
        If height < 10 cm will not bounce anymore.

        Create the program that show every height point of ball when it fall from the high place till it not bounce.
         */

        //For this simulate i use the meter scale.

        static void Simulate(float startPoint)
        {
            int jumpCount = 0;

            if (startPoint < 0.1f)
            {
                WriteLine("{0}. Highest point: {1}", jumpCount + 1, startPoint);
                WriteLine("Jump count: {0}", jumpCount);
                return;
            }
            while (startPoint > 0.1f)
            {
                WriteLine("{0}. Highest point: {1}", jumpCount + 1, startPoint);
                startPoint = startPoint * 0.9f;
                jumpCount++;
                WriteLine("Jump count: {0}", jumpCount);
            }
        }
        public static void Run()
        {
            Clear();
            Write("Input start height point of falling ball<Meter>: ");
            string inputString = ReadLine();
            float startPoint = 0f;
            try
            {
                startPoint = float.Parse(inputString);
            }
            catch(FormatException)
            {
                WriteLine("Terminate");
                return;
            }
            BouncingBallSimulate.Simulate(startPoint);
        }
    }
}