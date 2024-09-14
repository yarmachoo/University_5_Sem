using System.Buffers;

class Program 
{
    static void Main(string[] args)
    {
        int a= 0, b = 0;
        try
        {
            a = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException fe) { Console.WriteLine(fe.Message); }
        catch (OverflowException ofe) { Console.WriteLine(ofe.Message); }

        try
        {
            b = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException fe) { Console.WriteLine(fe.Message); }
        catch (OverflowException ofe) { Console.WriteLine(ofe.Message); }

        Console.WriteLine(a*b);
    }
}
