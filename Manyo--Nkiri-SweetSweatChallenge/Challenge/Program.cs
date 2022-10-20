// See https://aka.ms/new-console-template for more information
while (true)
{
    Console.WriteLine("Enter min");
    int min = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter max");
    int max = int.Parse(Console.ReadLine());
    int SweetCount = 0;
    int Sweatcount = 0;
    int SweetandSweatcount = 0;

    if (min < max && max - min <= 1000)
    {
        for (int i = min; i <= max; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("Sweet'nSalty");
                SweetandSweatcount++;
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Sweet");
                SweetCount++;
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Salty");
                Sweatcount++;
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
    Console.WriteLine($"Sweat Count: {Sweatcount}");
    Console.WriteLine($"SweetandSweat Count: {SweetandSweatcount}");
    Console.WriteLine($"SweetCount: {SweetCount}");


}
