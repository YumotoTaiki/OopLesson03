using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5 {
    class Program {
        static void Main(string[] args) {
            #region 問題5.1
            Console.Write("文字列1→");
            var str1 = Console.ReadLine().ToUpper();
            Console.Write("文字列2→");
            var str2 = Console.ReadLine().ToUpper();

            if (String.Compare(str1, str2, ignoreCase: true) == 0)
                Console.WriteLine("同じ");
            else
                Console.WriteLine("違う");
            #endregion

            #region 問題5.2
            int num = 0;
            Console.Write("数値文字列1→");
            str1 = Console.ReadLine();
            if (int.TryParse(str1, out num))
                Console.WriteLine(num.ToString("#,#"));
            else
                Console.WriteLine("数字ではない");
            #endregion

            /*#region 5
            //問題5.3
            //1
            var str = "Jackdaws love my big sphinx of quartz";
            string s = "この文字列の中の空白の数は？";
            Console.WriteLine(str.Count(c => c == ' '));

            //2
            Console.WriteLine(str.Replace("big","small"));

            //3
            int count = str.Split(' ').Count();
            Console.WriteLine("単語数:{0}",count);

            //4
            var words = str.Split(' ').Where(s => s.Length <= 4);
            foreach (var word in words) {
                Console.WriteLine(word);
            }

            //5
            var array = str.Split(' ').ToArray();
            if (array.Length > 0) {
                var sb = new StringBuilder(array[0]);
                foreach (var word in array) {
                    //sb.Append
                }
            }

            //問題5.4
            var lines = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var word = lines.Split(',');
            foreach (var item in lines) {
                var w = lines.Split('=');
                Console.WriteLine(Tojapanese(word[0], word[1]);
            }
        }
        static string Tojapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家";
                case "BestWork":
                    return "代表作";
                case "Born":
                    return "誕生年";
                default:
                    return "    ";
            }
        }
        #endregion*/
        }
    }
}
