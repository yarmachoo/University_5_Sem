using System.Threading.Channels;

class Program
{
    static void Main(string[] args)
    {
        string[]? lNames;
        string[]? fNames;
        int[]? ages;
        int count = 0;
        Console.Write("Input amount of people: ");
        try
        {
            count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(count);
        }
        catch (FormatException fe) { Console.WriteLine(fe.Message); }
        catch(OverflowException ofe) { Console.WriteLine(ofe.Message); }


        lNames = new string[count];
        fNames = new string[count];
        ages = new int[count];
         
        for(int i = 0; i<count; i++)
        {
            lNames[i] = Console.ReadLine();
            fNames[i] = Console.ReadLine();

            try
            {
                ages[i] = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException fe) { Console.WriteLine(fe.Message); }
            catch (OverflowException ofe) { Console.WriteLine(ofe.Message); }

        }

        for(int i = 0; i<count;i++)
        {
            Console.WriteLine($"{lNames[i]} {fNames[i]} {ages[i]}");
        }

        Console.WriteLine(ages.Min());
        Console.WriteLine(ages.Max());
        Console.WriteLine(ages.Average());
    }
}