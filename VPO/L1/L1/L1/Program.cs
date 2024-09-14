using System.Text;

namespace L1
{
    public class Task1()
    {
        public static string Func()
        {
            string str = "Hello, world!\n" +
                         "Andhiagain!\n";
            Random rnd = new Random();
            int count = rnd.Next(5, 50);
            StringBuilder sb = new StringBuilder(str);
            for (int i = 0; i < count; i++)
                sb.Append('!');
            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Task1.Func());
        }
    }
}