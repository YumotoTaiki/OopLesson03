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
        static public char key;

        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";
            Exercise1_1(text);
            Exercise1_2(text);
        }

        static void Exercise1_1(string text) {
            // ディクショナリの初期化
            var dict = new Dictionary<char, int>() { };

            foreach (var ch in text) {
                if (ch == ' ') {
                    continue;
                } else {
                    if ('a' <= ch && ch <= 'z') {
                        key = Char.ToUpper(ch);
                    } else {
                        key = ch;
                    }
                }

                if (dict.ContainsKey(key)) {
                    dict[key]++;
                } else {
                    dict.Add(key, 1);
                }
            }

            // ディクショナリの内容を列挙
            foreach (var item in dict.OrderBy(x => x.Key)) {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }
        }

        static void Exercise1_2(string text) {
            var chars = new SortedDictionary<char, int> {};
            foreach (var item in text) {
                if (item == ' ') {
                    continue;
                } else {
                    if ('a' <= item && item <= 'z') {
                        key = Char.ToUpper(item);
                    } else {
                        key = item;
                    }
                }

                if (chars.ContainsKey(key)) {
                    chars[key]++;
                } else {
                    chars.Add(key, 1);
                }
            }

            // ディクショナリの内容を列挙
            foreach (var item in chars) {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }
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
