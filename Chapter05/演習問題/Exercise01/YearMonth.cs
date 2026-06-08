using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public record YearMonth {

        public int Year { get; init; }
        public int Month { get; init; }



        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }


        public bool Is21Century => Year >= 2001 && Year <= 2100;

        public YearMonth AddOneMonth() {
            if (Month == 12) {
                return new YearMonth(Year + 1, 1);
            }

            return new YearMonth(Year, Month + 1);
        }

        public override string ToString() => $"{Year}年{Month}月";

    }

    

}
