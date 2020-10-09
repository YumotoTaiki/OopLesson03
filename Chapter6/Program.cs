using Chapter06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6 {
    class Program {
        static void Main(string[] args) {

            //練習問題
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            //問題6.1
            //(1)
            var max = numbers.Where(n => n > 0).Max();
            Console.WriteLine($"最大は{max}");

            //(2)
            var last2 = numbers.Select(n => numbers[numbers.Length-1]);

            //Console.WriteLine($"最後から2番目は{numbers[numbers.Length - 2]}");

            int pos = numbers.Length - 2;
            foreach (var number in numbers.Skip(pos)) {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            //(3)
            var strNums = numbers.Select(name => name.ToString("000")).ToArray();
            foreach (var item in strNums) {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            //(4)
            var min3 = numbers.OrderBy(n => n).Take(3);
            foreach (var item in min3) {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            //(5)
            var over10 = numbers.Distinct().Count(n => n > 10);
            Console.WriteLine($"10よりおおきいのは{over10}");
        }
    }
}
