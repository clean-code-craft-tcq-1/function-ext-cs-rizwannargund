using System.Collections.Generic;

namespace BatteryManagementSystem
{
    public class BatteryRangeLevels
    {
        public static readonly IDictionary<Range, string> StateOfCharge = new Dictionary<Range, string>()
        {
            { new Range(0,20), ResourceHelper.LowSocBreach},
            { new Range(21,24), ResourceHelper.LowSocWarning},
            { new Range(25,75), ResourceHelper.NormalSoc},
            { new Range(76,80), ResourceHelper.HighSocWarning},
            { new Range(81,100), ResourceHelper.HighSocBreach}
        };

        public static readonly IDictionary<Range, string> Temperature = new Dictionary<Range, string>()
        {
            { new Range(-45, -0.01f), ResourceHelper.LowTempBreach},
            { new Range(0, 2.25f), ResourceHelper.LowTempWarning},
            { new Range(2.26f, 42.75f), ResourceHelper.NormalTemp},
            { new Range(42.76f, 45), ResourceHelper.HighTempWarning},
            { new Range(46, 100), ResourceHelper.HighTempBreach}
        };

        public static readonly IDictionary<Range, string> ChargeRate = new Dictionary<Range, string>()
        {
            { new Range(0, 0.75f), ResourceHelper.NormalChargeRate},
            { new Range(0.76f, 0.8f), ResourceHelper.HighChargeRateWarning},
            { new Range(0.81f, 100), ResourceHelper.HighChargeRateBreach}
        };
    }
}
