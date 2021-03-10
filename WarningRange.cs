using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace BatteryManagementSystem
{
    public class WarningRange
    {
        private float WarningTolerance { get; }
        public float LowLimit { get; private set; }
        public float PeakLimit { get; private set; }
        private readonly float _min,_max;
        private const string LowWarningMessage = "LowWarningMessage";
        private const string PeakWarningMessage = "PeakWarningMessage";

        public WarningRange(float minimum, float maximum)
        {
            WarningTolerance = ((maximum / 5) * 100);
            LowLimit = minimum + WarningTolerance;
            PeakLimit = maximum - WarningTolerance;
            _min = minimum;_max = maximum;
        }

        public WarningLevel CheckWarningRange(float value)
        {
            if (_min <= value && LowLimit >= value)
                return WarningLevel.Low;
            else if (PeakLimit <= value && _max >= value)
                return WarningLevel.High;
            return WarningLevel.Normal;
        }

        public string WarningMessage(string languageCode, WarningLevel warningLevel)
        {
            ResourceManager resourceManager = new ResourceManager(string.Format("checker.{0}.resx", languageCode),
                Assembly.GetExecutingAssembly());
            switch (warningLevel)
            {
                case WarningLevel.Low:
                    return resourceManager.GetString(LowWarningMessage, CultureInfo.InvariantCulture);
                case WarningLevel.High:
                    return resourceManager.GetString(PeakWarningMessage, CultureInfo.InvariantCulture);
                default:
                    return "";
            }
        }
    }
}
