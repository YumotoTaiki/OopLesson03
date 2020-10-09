using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class Program{
        static void Main(string[] args)
        {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };
            Console.WriteLine("問題3.1");
            //(1)
            var exist = numbers.Exists(n => n % 8 == 0 || n % 9 == 0);
            if (exist)
                Console.WriteLine("(1)存在しています。");
            else
                Console.WriteLine("(1)存在していません。");

            //(2)
            numbers.ForEach(s => Console.Write($"(2){s / 2},"));

            //(3)
            Console.Write("\n(3)50以上→");
            foreach (var item in numbers.Where(s => s >= 50)) {
                Console.Write($"{item},");
            }

            //(4)
            Console.Write("\n(4)2倍→");
            foreach (var item in numbers.Select(s => s * 2)) {
                Console.Write($"{item},");
            }
            Console.WriteLine();
            Console.WriteLine("問題3.2");

            //問題3.2
            var names = new List<string> {
                "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong Kong"
            };

            //(1)
            Console.WriteLine("(1)都市名を入力,空行で終了");
            var line = Console.ReadLine();
            do {
                if (string.IsNullOrEmpty(line)) {
                    break;
                }
                var indexname = names.FindIndex(s => s == line);
                Console.WriteLine(indexname);
            } while (true);

            //(2)
            int includeO = names.Count(s => s.Contains("o") );
            Console.WriteLine($"(2)oが含まれている都市名は{includeO}個あります。");

            //(3)
            var nameO = names.Where(s => s.Contains("o"));
            Console.Write("(3)oが含まれているのは");
            foreach (var item in nameO) {
                Console.Write($"{item} ,");
            }

            //(4)
            var startB = names.Where(s => s.StartsWith("B"));
            Console.Write("\n(4)Bから始まる都市の文字数は");
            foreach (var item in startB.Select(s => s.Length)) {
                Console.Write($"{item} ,");
            }
        }
    }
}
