using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4 {
    class Program {
        static void Main(string[] args) {
            List<YearMonth> yearMonths = new List<YearMonth>();
            for (int i = 0; i < 5; i++) {
                YearMonth yearMonth = new YearMonth(0, 0);
                yearMonths.Add(yearMonth);
            }

            foreach (var item in yearMonths) {
                Console.WriteLine(item);
            }
        }
    }
}
