using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Проверка на наличие необходимых параметров
        if (args.Length < 2)
        {
            Console.WriteLine("Использование: <папка> <расширение>");
            return;
        }

        string directoryPath = args[0]; // Путь к папке
        string fileExtension = args[1]; // Расширение файла

        // Проверка на существование директории
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Указанная папка не существует.");
            return;
        }

        // Поиск файлов с указанным расширением
        try
        {
            var files = Directory.GetFiles(directoryPath, $"*{fileExtension}", SearchOption.AllDirectories);

            // Вывод результатов на консоль
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}