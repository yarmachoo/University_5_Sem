class Program
{
    static void Main(string[] args)
    {
        // Параметры таблицы
        int rows = 100; // количество строк
        string filePath = "gradient_table.html";

        // Создание HTML файла
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html lang=\"en\">");
            writer.WriteLine("<head>");
            writer.WriteLine("<meta charset=\"UTF-8\">");
            writer.WriteLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            writer.WriteLine("<title>Gradient Table</title>");
            writer.WriteLine("<style>");
            writer.WriteLine("table { width: 100%; border-collapse: collapse; }");
            writer.WriteLine("td { height: 20px; text-align: center; }");
            writer.WriteLine("</style>");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");
            writer.WriteLine("<table>");

            for (int i = 0; i < rows; i++)
            {
                // Вычисление цвета фона (от белого к черному)
                int colorValue = (int)(255 - (255.0 / rows) * i);
                string color = $"rgb({colorValue}, {colorValue}, {colorValue})";

                writer.WriteLine($"<tr style=\"background-color: {color};\"><td></td></tr>");
            }

            writer.WriteLine("</table>");
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }

        Console.WriteLine("HTML файл успешно создан: " + filePath);
    }
}