using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7 {
    class MonthDay {
        public int Day { get; private set; }
        public int Month { get; private set; }
        public MonthDay(int month, int day) {
            this.Month = month;
            this.Day = day;
        }

        //MonthDayどうしの比較をする
        public override bool Equals(object obj) {
            var other = obj as MonthDay;
            if (other == null) {
                throw new ArgumentException();
            }
            return this.Day == other.Day && this.Month == other.Month;
        }
        //ハッシュコードを求める
        public override int GetHashCode() {
            var code = Month.GetHashCode();
            return Month.GetHashCode() * 31 + Day.GetHashCode();
        }
    }
}
