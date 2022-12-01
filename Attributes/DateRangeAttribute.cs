using System.ComponentModel.DataAnnotations;

namespace CarRentCalculator.Attributes
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute()
          : base(typeof(DateTime),
                  DateTime.Now.ToShortDateString(),
                  DateTime.Now.AddYears(1).ToShortDateString())
        { }
    }
}
