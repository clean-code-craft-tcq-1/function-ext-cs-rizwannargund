using System.Collections.Generic;

namespace BatteryManagementSystem
{
    public class BatteryRangeLevels
    {
        public static readonly IDictionary<Range, string> StateOfCharge = new Dictionary<Range, string>()
        {
            { new Range(0,20), Language.LowSocBreach},
            { new Range(21,24), Language.LowSocWarning},
            { new Range(25,75), Language.NormalSoc},
            { new Range(76,80), Language.HighSocWarning},
            { new Range(81,100), Language.HighSocBreach}
        };

        public static readonly IDictionary<Range, string> Temperature = new Dictionary<Range, string>()
        {
            { new Range(-45, -0.01f), Language.LowTempBreach},
            { new Range(0, 2.25f), Language.LowTempWarning},
            { new Range(2.26f, 42.75f), Language.NormalTemp},
            { new Range(42.76f, 45), Language.HighTempWarning},
            { new Range(46, 100), Language.HighTempBreach}
        };

        public static readonly IDictionary<Range, string> ChargeRate = new Dictionary<Range, string>()
        {
            { new Range(0, 0.75f), Language.NormalChargeRate},
            { new Range(0.76f, 0.8f), Language.HighChargeRateWarning},
            { new Range(0.81f, 100), Language.HighChargeRateBreach}
        };
    }
}
