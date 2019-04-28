using System;

namespace Challenge_377_Easy_
{
    class Program
    {
        static void Main(string[] args)
        {
            Challenge_377 challenge = new Challenge_377();

            //fit1 tests
            Console.WriteLine(challenge.fit1(25, 18, 6, 5));
            Console.WriteLine(challenge.fit1(10, 10, 1, 1)); 
            Console.WriteLine(challenge.fit1(12, 34, 5, 6));
            Console.WriteLine(challenge.fit1(12345, 678910, 1112, 1314));
            Console.WriteLine(challenge.fit1(5, 100, 6, 1));

            //fit2 tests
            Console.WriteLine("\nTest fit2");
            Console.WriteLine(challenge.fit2(25, 18, 6, 5));
            Console.WriteLine(challenge.fit2(12, 34, 5, 6));
            Console.WriteLine(challenge.fit2(12345, 678910, 1112, 1314));
            Console.WriteLine(challenge.fit2(5, 5, 3, 2));
            Console.WriteLine(challenge.fit2(5, 100, 6, 1));
            Console.WriteLine(challenge.fit2(5, 5, 6, 1));

            challenge.printFit3();



        }
    }

    class Challenge_377
    {
        public int fit1(int containerX, int ContainerY, int boxX, int boxY)
        {
            return (containerX/boxX) * (ContainerY/boxY);
        }

        public int fit2(int containerX, int ContainerY, int boxX, int boxY)
        {
            int yAxis = fit1(containerX, ContainerY, boxY, boxX);
            int xAxis = fit1(containerX, ContainerY, boxX, boxY);
            return xAxis > yAxis ? xAxis : yAxis;
        }

        public int fit3(int containerX, int ContainerY, int ContainerZ, int boxX, int boxY, int boxZ)
        {
            int flat = fit2(containerX, ContainerY, boxX, boxY) * (ContainerZ/boxZ);
            int sideways = fit2(containerX, ContainerY, boxZ, boxY) * (ContainerZ/boxX);
            int standing = fit2(containerX, ContainerY, boxX, boxZ) * (ContainerZ/boxY);

            int highest = flat > sideways ? flat : sideways;
            highest = highest > standing ? highest : standing;
            return highest;
        }
 
        public void printFit3()
        {
            Console.WriteLine("\nTest fit3");
            Console.WriteLine(fit3(10, 10, 10, 1, 1, 1));
            Console.WriteLine(fit3(12, 34, 56, 7, 8, 9));
            Console.WriteLine(fit3(123, 456, 789, 10, 11, 12));
            Console.WriteLine(fit3(1234567, 89101112, 13141516, 171819, 202122, 232425));
        }
    }
}
