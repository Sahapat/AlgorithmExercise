using System;
using System.Collections;
using static System.Console;

namespace Exercise
{
    public class FlagPoleProblem
    {
        /* There are flag pole with difference height align from left to right. There have a person who stand on the left side and watch the pole.

        Create the program that show how many and what flag pole person seen.
        #Note
        The Flag pole can intercept the pole behind if their height are equal.
        */
        private ArrayList seenPole = null;
        private ushort eyeLevel = 0;
        private ushort[] polesTall = null;

        internal FlagPoleProblem(ushort[] polesTall)
        {
            this.polesTall = polesTall;
            seenPole = new ArrayList();
            CheckSeeing();
        }
        public static void Run()
        {
            Clear();
            Write("Input number of flagpole: ");
            var inputString = ReadLine();
            int numOfFlagpole = 0;
            try
            {
                numOfFlagpole = ushort.Parse(inputString);
            }
            catch (FormatException)
            {
                numOfFlagpole = 0;
                WriteLine("Terminate");
                return;
            }

            ushort[] temp = new ushort[numOfFlagpole];

            for (int i = numOfFlagpole, j = 0; i > 0;)
            {
                Clear();
                WriteLine("Remain flagpole to assign {0}", i);
                inputString = ReadLine();
                try
                {
                    temp[j] = ushort.Parse(inputString);
                }
                catch (FormatException)
                {
                    continue;
                }
                i--;
                j++;
            }

            FlagPoleProblem flagpoleSolve = new FlagPoleProblem(temp);

            WriteLine("Number of flagpole {0}", numOfFlagpole);
            WriteLine("Seen {0}\nDetail", flagpoleSolve.seenPole.Count);
            for (int i = 0; i < flagpoleSolve.seenPole.Count; i++)
            {
                Write(flagpoleSolve.seenPole[i] + " ");
            }
            WriteLine();
        }
        void CheckSeeing()
        {
            for (int i = 0; i < polesTall.Length; i++)
            {
                if (eyeLevel < polesTall[i])
                {
                    eyeLevel = polesTall[i];
                    seenPole.Add(polesTall[i]);
                }
            }
        }
    }
}