using Chapter06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6 {
    class Program {
        static void Main(string[] args) {

            //練習問題
            var books = new List<Book> {
                new Book { Title = "C#プログラミングの新常識「C#」", Price = 3800, Pages = 378 },
                new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
                new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
                new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
                new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
                new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
                new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            int countC = 0;
            foreach (var book in books.Where(b=> b.Title.Contains("C#"))) {
                for (int i = 0; i < book.Title.Length-1; i++) {
                    if ((book.Title[i] == 'C') && (book.Title[i + 1] == '#')){
                        countC++;
                    }
                }
            }
            Console.WriteLine($"文字列「C#」の個数は{countC}です。");

            //問題6.2
            //(1)
            var book1 = books.FirstOrDefault(b => b.Title == "ワンダフル・C#ライフ");
            if (book1 != null) {
                Console.WriteLine($"{book1.Price} {book1.Pages}");
            }

            //(2)
            int count = books.Count(b => b.Title.Contains("C#"));
            Console.WriteLine(count);

            //(3)
            var average = books.Where(b => b.Title.Contains("C#")).Average(b => b.Pages);
            Console.WriteLine(average);

            //(4)
            var book4 = books.FirstOrDefault(b => b.Price >= 4000);
            if (book4 != null) {
                Console.WriteLine(book4.Title);
            }

            //(5)
            var pages = books.Where(b => b.Price < 4000).Max(b => b.Pages);
            Console.WriteLine(pages);

            //(6)
            var selected = books.Where(b => b.Pages >= 4000).OrderByDescending(b => b.Price);
            foreach (var book in selected) {
                Console.WriteLine("{0} {1}",book.Title,book.Price);
            }

            //(7)
            var selected7 = books.Where(b => b.Title.Contains("C#") && b.Pages <= 500);
            foreach (var book in books) {
                Console.WriteLine(book.Title);
            }
        }
    }
}
