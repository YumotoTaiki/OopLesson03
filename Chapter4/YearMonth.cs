using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4 {

    public static class YearMonth {
        //プロパティ
        public int Year { get; private set; }
        public int Month { get; private set; }
        public bool Is21Century { get; set; }

        //コンストラクタ
        YearMonth(int year,int month) {
            Year = year;
            Month = month;
        }

        public void AddOnMonth() {
            YearMonth yearMonth = new YearMonth(Year, Month);
            if (Month == 12) {
                yearMonth.Year++;
                yearMonth.Month = 1;
            } else {
                yearMonth.Month++;
            }
        }

        public override string ToString() {
            return $"{Year}年{Month}月";
        }
    }
}
