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

            Console.WriteLine("\nTest fit3");
            Console.WriteLine(challenge.fit3(10, 10, 10, 1, 1, 1));
            Console.WriteLine(challenge.fit3(12, 34, 56, 7, 8, 9));
            Console.WriteLine(challenge.fit3(123, 456, 789, 10, 11, 12));
            Console.WriteLine(challenge.fit3(1234567, 89101112, 13141516, 171819, 202122, 232425));

            Console.WriteLine("\nTest fitn");
            int[] container = {123, 456, 789}; //{123, 456, 789, 1011, 1213, 1415};
            int[] box = {10, 11, 12};//{16, 17, 18, 19, 20, 21};
            Console.WriteLine(challenge.fitn(container, box));

            container = new int[] {123, 456, 789, 1011, 1213, 1415};
            box = new int[] {16, 17, 18, 19, 20, 21};
            Console.WriteLine(challenge.fitn(container, box));

            //This test produces a number that is too large
            container = new int[] {180598, 125683, 146932, 158296, 171997, 204683, 193694, 216231, 177673, 169317, 216456, 220003, 165939, 205613, 152779, 177216, 128838, 126894, 210076, 148407};
            box = new int[] {1984, 2122, 1760, 2059, 1278, 2017, 1443, 2223, 2169, 1502, 1274, 1740, 1740, 1768, 1295, 1916, 2249, 2036, 1886, 2010};
            Console.WriteLine(challenge.fitn(container, box));
        }
    }

    class Challenge_377
    {
        public int fit1(int containerX, int containerY, int boxX, int boxY)
        {
            return (containerX/boxX) * (containerY/boxY);
        }

        public int fit2(int containerX, int containerY, int boxX, int boxY)
        {
            int yAxis = fit1(containerX, containerY, boxY, boxX);
            int xAxis = fit1(containerX, containerY, boxX, boxY);
            return xAxis > yAxis ? xAxis : yAxis;
        }

        public int fit3(int containerX, int containerY, int ContainerZ, int boxX, int boxY, int boxZ)
        {
            int flat = fit2(containerX, containerY, boxX, boxY) * (ContainerZ/boxZ);
            int sideways = fit2(containerX, containerY, boxZ, boxY) * (ContainerZ/boxX);
            int standing = fit2(containerX, containerY, boxX, boxZ) * (ContainerZ/boxY);

            int highest = flat > sideways ? flat : sideways;
            highest = highest > standing ? highest : standing;
            return highest;
        }
        public int fitn(int[] container, int[] box)
        {
            int total = 1;
            int highest = 0;

            Array.Sort(container);
            Array.Sort(box);

            int count = 0;
            for(int offset = 0; offset < container.Length; offset++)
            {
                total = 1;
                for(int i = 0; i < container.Length; i++)
                {
                    total *= (container[i]/box[(i + offset) % container.Length]);
                    count++;
                }
                Console.WriteLine("Total: " + total + "Offset: " + offset);
                if(total > highest)
                    highest = total;
            }
            Console.WriteLine("Count: " + count);
            return highest;
        }



    }
}
