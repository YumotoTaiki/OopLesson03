using Section02;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7 {
    class Program {

        static void Main(string[] args) {

            Console.WriteLine("**********************");
            Console.WriteLine("* 辞書登録プログラム *");
            Console.WriteLine("**********************");

            int num;
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>() { };

            do {
                Console.WriteLine("1. 登録　2. 内容を表示　3. 終了");
                var readnum = Console.ReadLine();
                if (int.TryParse(readnum, out num)) {
                    switch (num) {
                        case 1:
                            Registration(dict);
                            break;
                        case 2:
                            Display(dict);
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
            } while (true);
        }

        static public void Registration(Dictionary<string, List<string>> dict) {
            Console.Write("KEYを入力：");
            var readKey = Console.ReadLine();

            Console.Write("Valueを入力：");
            var readValue = Console.ReadLine();

            if (dict.ContainsKey(readKey)) {
                dict[readKey].Add(readValue);
            } else {
                dict[readKey] = new List<string> { readValue };
            }

            Console.WriteLine("登録しました!");
            Console.WriteLine();
            return;
        }

        static public void Display(Dictionary<string, List<string>> dict) {
            Console.WriteLine();
            foreach (var item in dict) {
                foreach (var term in item.Value) {
                    Console.WriteLine("{0} : {1}", item.Key, term);
                }
            }
            Console.WriteLine();
        }

        //static public void DuplicateKeySample() {
        //    // ディクショナリの初期化
        //    var dict = new Dictionary<string, List<string>>() {
        //       { "PC", new List<string> { "パーソナル コンピュータ", "プログラム カウンタ", } },
        //       { "CD", new List<string> { "コンパクト ディスク", "キャッシュ ディスペンサー", } },
        //    };
        //
        //    // ディクショナリに追加
        //    var key = "EC";
        //    var value = "電子商取引";
        //    if (dict.ContainsKey(key)) {
        //        dict[key].Add(value);
        //    } else {
        //        dict[key] = new List<string> { value };
        //    }
        //
        //    // ディクショナリの内容を列挙
        //    foreach (var item in dict) {
        //        foreach (var term in item.Value) {
        //            Console.WriteLine("{0} : {1}", item.Key, term);
        //        }
        //    }
        //}

    }
}
