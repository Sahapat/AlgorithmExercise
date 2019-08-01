using System;
using System.Collections.Generic;

using static System.Console;

namespace Exercise
{
    public class MathExercise
    {
        /* 
            Create the program that can find the Greatest Common Factor and Lowest Common Multiple
         */
         
        public static int GCF(int[] numbers) //Greatest Common Factor
        {
            List<int> primeList = new List<int>();

            foreach(var i in numbers)
            {
                if(CheckPrimeNumber(i))
                {
                    primeList.Add(i);
                }
            }
            if(primeList.Count > 1)
            {
                return 1;
            }
            else if(primeList.Count > 0)
            {
                var minPrime = Min(primeList.ToArray());
                foreach(var i in numbers)
                {
                    if(i % minPrime != 0)
                    {
                        return 1;
                    }
                }
            }
            int resultGCF = 1,Divider = 2,minNumber = Min(numbers);
            while(Divider <= minNumber)
            {
                for(int i =0;i<numbers.Length;i++)
                {
                    if(numbers[i] % Divider != 0)
                    {
                        break;
                    }
                    else
                    {
                        if(i == numbers.Length-1)
                        {
                            for(int j =0;j<numbers.Length;j++)
                            {
                                numbers[j] /= Divider;
                            }
                            minNumber = Min(numbers);
                            resultGCF *= Divider;
                        }
                    }
                }
                Divider++;
            }
            return resultGCF;
        }
        public static int LCM(int[] numbers) //Lowest Common Multiple
        {
            int numOfPrime = 0;
            foreach(var i in numbers)
            {
                if(CheckPrimeNumber(i))
                {
                    numOfPrime++;
                }
            }
            if(numOfPrime == numbers.Length)
            {
                int sum = 1;
                foreach(var i in numbers)
                {
                    sum *= i;
                }
                return sum;
            }

            int minNumber = Min(numbers),Divider =2,resultLCM =1;

            while(Divider <= minNumber)
            {
                int canDivide = 0;
                foreach(var i in numbers)
                {
                    if(i%Divider == 0)
                    {
                        canDivide++;
                    }
                }
                if(canDivide > 1)
                {
                    for(int i = 0;i<numbers.Length;i++)
                    {
                        if(numbers[i] % Divider == 0)
                        {
                            numbers[i] /= Divider;
                        }
                    }
                    minNumber = Min(numbers);
                    resultLCM *= Divider;
                    Divider++;
                }
                else
                {
                    Divider++;
                }
            }
            foreach(var i in numbers)
            {
                resultLCM *= i;
            }
            return resultLCM;
        }
        public static int Abs(int number)
        {
            return (number < 0)?-number:number;
        }
        public static int Min(int[] numbers)
        {
            int currentMin = numbers[0];
            for(int i = 0;i<numbers.Length;i++)
            {
                if(currentMin > numbers[i])
                {
                    currentMin = numbers[i];
                }
            }
            return currentMin;
        }
        public static int Max(int[] numbers)
        {
            int currentMax = numbers[0];
            for(int i=0;i<numbers.Length;i++)
            {
                if(currentMax < numbers[i])
                {
                    currentMax = numbers[i];
                }
            }
            return currentMax;
        }
        public static bool CheckPrimeNumber(int number)
        {
            int absoluteNumber = Abs(number);

            if(absoluteNumber <= 3)
            {
                return absoluteNumber > 1;
            }
            else if(absoluteNumber%2 == 0 || absoluteNumber%3==0)
            {
                return false;
            }
            
            var i = 5;
            while(i*i <= absoluteNumber)
            {
                if(absoluteNumber % i == 0 || absoluteNumber%(i+2) == 0)
                {
                    return false;
                }
                i = i+6;
            }
            return true;
        }
        public static void Run()
        {
            Clear();
            Write("1.Find GCF\n2.Find LCM\nInput the order: ");
            string inputString = ReadLine();
            int orderSelected = 0;
            try
            {
                orderSelected = int.Parse(inputString);
            }
            catch(FormatException)
            {
                WriteLine("Terminate");
                return;
            }

            string[] inputArr = null;
            int[] numbers = null;

            switch(orderSelected)
            {
                case 1:
                    Write("Input the list number to find GCF: ");               
                    inputString = ReadLine();
                    inputArr = inputString.Split(' ');
                    numbers = new int[inputArr.Length];
                    try
                    {
                        for(int i = 0;i<numbers.Length;i++)
                        {
                            numbers[i] = int.Parse(inputArr[i]);
                        }
                    }
                    catch(FormatException)
                    {
                        WriteLine("Error! Please input only number and seperate by one space");
                        goto case 1;
                    }
                    WriteLine("GCF = {0}",GCF(numbers));
                    WriteLine("Terminate");
                break;
                case 2:
                    Write("Input the list number to find LCM: ");               
                    inputString = ReadLine();
                    inputArr = inputString.Split(' ');
                    numbers = new int[inputArr.Length];
                    try
                    {
                        for(int i = 0;i<numbers.Length;i++)
                        {
                            numbers[i] = int.Parse(inputArr[i]);
                        }
                    }
                    catch(FormatException)
                    {
                        WriteLine("Error! Please input only number and seperate by one space");
                        goto case 2;
                    }
                    WriteLine("LCM = {0}",LCM(numbers));
                    WriteLine("Terminate");
                break;
            }
        }
    }
}