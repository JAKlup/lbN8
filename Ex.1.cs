using System;
using System.Text.Encodings;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace lbN8_Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"text.txt";
            string pathDir = @"C:\Users\JOKlup.DESKTOP-NDKP1MJ\source\repos\lbN8\lbN8\text.txt";
            FileInfo info = new FileInfo(pathDir);
            Console.WriteLine("Полное имя:");
            Console.WriteLine(info.FullName);
            Console.WriteLine("Имя:");
            Console.WriteLine(info.Name);
            Console.WriteLine("Разширение:");
            Console.WriteLine(info.Extension);
            Console.WriteLine("Время создания:");
            Console.WriteLine(info.CreationTime);
            Console.WriteLine("Размер:");
            Console.WriteLine(info.Length);
            Console.WriteLine("Количество строк:");
            Console.WriteLine(File.ReadAllLines(pathDir).Length);
            string text = File.ReadAllText(pathDir);
            string[] textMass;
            textMass = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Количество слов:");
            Console.WriteLine(textMass.Length);
            Console.WriteLine($"Есть ли кириллица?");
            Console.WriteLine(Regex.IsMatch(text, @"[А-яеё]"));
            Console.WriteLine($"Есть ли латиница?");
            Console.WriteLine(Regex.IsMatch(text, @"[A-z]"));
            Console.WriteLine($"Есть ли цифры?");
            Console.WriteLine(Regex.IsMatch(text, @"[0-9]"));
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{info.FullName}\n{info.Name}\n{info.CreationTime}\n{info.Length} байт\nВсего строк: {textMass}\nВсего слов: {textMass.Length}");
            File.WriteAllText("result1.txt", sb.ToString());
        }
    }
}
