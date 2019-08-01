using System;
using System.Collections;

using static System.Console;

namespace Exercise
{
    /* 
    At the village, have a houses align as horizontal line with an assign's number 1 to N. You're the mayer of village want to paint the house with lowest price and condition, Can't have save color more than 2 closed house.

    Ex Input          |        Output
       3 2
       1 1 10                  15
       1 2 4
       2 1 7
       2 2 4
       3 1 8
       3 2 4

    Select
       House 1 Color 2 Price 4
       House 2 Color 1 Price 7
       House 3 Color 2 Price 4

       Sum price >> 15 Lowest price
     */
    public class ColorfulVillageProblem
    {
        public static void Run()
        {
            Write("Input nHouse and kColor: ");
            var inputsString = ReadLine().Split(' ');

            ushort nHouse = ushort.Parse(inputsString[0]);
            ushort kColor = ushort.Parse(inputsString[1]);

            ushort[,,] houseDatas = new ushort[nHouse,kColor,1];

            for(ushort i=1;i<=nHouse;i++)
            {
                for(ushort j=1;j<=kColor;j++)
                {
                    Write($"House {i} Color {j}: ");
                    houseDatas[i-1,j-1,0] = ushort.Parse(ReadLine());
                }
            }
            WriteLine("Lowest price is "+LowestPriceCalculate(houseDatas));
            Clear();
        }
        static ushort LowestPriceCalculate(ushort[,,] houseDatas)
        {
            ushort lowestPrice = ushort.MaxValue;
            ushort[] colorsSelectedTemp = new ushort[2];
            return 0;
        }
    }
}