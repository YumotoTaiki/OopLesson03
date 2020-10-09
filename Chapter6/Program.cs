using Chapter06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6 {
    class Program {
        static void Main(string[] args) {
            #region 教科書
            //整数の例
            var numbers = new List<int> { 19, 23, 43, 43, 15, 22, 31, 32, 18, 23, 28, 13 };

            var strings = numbers.Select(n => n.ToString("0000")).ToArray();
            foreach (var str in strings) {
                Console.Write(str + " ");
            }

            //numbers.Distinct().Select(n => n.ToString("0000")).ToList().ForEach(s => Console.Write(s + " "));

            //並べ替え
            Console.WriteLine();
            var sortedNumbers = numbers.OrderBy(n => n);
            foreach (var nums in sortedNumbers) {
                Console.Write(nums + " ");
            }

            //文字数の例
            var words = new List<string> {
                "Microsoft","Apple","Google","Oracle","Facebook"};

            var lower = words.Select(name => name.ToLower()).ToArray();

            //オブジェクトの例
            var books = Books.GetBooks();

            //タイトルリスト
            var titles = books.Select(name => name.Title);
            foreach (var title in titles) {
                Console.Write(title + "");
            }

            //ページ数の多い順に並び変え
            Console.WriteLine();
            var sortedPages = books.OrderByDescending(n => n.Pages);
            foreach (var nums in sortedPages) {
                Console.WriteLine(nums.Title + " "+ nums.Pages);
            }
            #endregion

            //練習問題
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };


        }
    }
}
