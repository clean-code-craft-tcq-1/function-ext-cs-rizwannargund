using System.Globalization;
using System.Reflection;
using System.Resources;

namespace BatteryManagementSystem
{
    public class Language
    {
        private static ResourceManager _resourceManager = new ResourceManager(string.Format("checker.{0}.resx", "en-US"),
            Assembly.GetExecutingAssembly());

        private static string _languageCode = "en-US";
        public const string TemperatureUnitInput = "TemperatureUnitInput";
        public const string TemperatureUnitInput1 = "TemperatureUnitInput1";
        public const string TemperatureUnitInput2 = "TemperatureUnitInput2";
        public const string InvalidInputMessage = "InvalidInputMessage";
        public const string TemperatureValue = "TemperatureValue";
        public const string ChargeRateValue = "ChargeRateValue";
        public const string SocValue = "SocValue";
        public const string LowSocBreach = "LOW_SOC_BREACH";
        public const string LowSocWarning = "LOW_SOC_WARNING";
        public const string NormalSoc = "NORMAL_SOC";
        public const string HighSocWarning = "HIGH_TEMP_WARNING";
        public const string HighSocBreach = "HIGH_TEMP_BREACH";
        public const string LowTempBreach = "LOW_TEMP_BREACH";
        public const string LowTempWarning = "LOW_TEMP_WARNING";
        public const string NormalTemp = "NORMAL_TEMP";
        public const string HighTempWarning = "HIGH_TEMP_WARNING";
        public const string HighTempBreach = "HIGH_TEMP_BREACH";
        public const string NormalChargeRate = "NORMAL_CHARGERATE";
        public const string HighChargeRateWarning = "HIGH_CHARGERATE_WARNING";
        public const string HighChargeRateBreach = "HIGH_CHARGERATE_BREACH";

        public static void SetLanguageCode(int languageId)
        {
            switch (languageId)
            {
                case 2:
                    _languageCode = "de-DE";
                    break;
                default:
                    _languageCode = "en-US";
                    break;
            }
        }

        public static void LoadResource()
        {
            _resourceManager = new ResourceManager(string.Format("checker.{0}.resx", _languageCode),
                Assembly.GetExecutingAssembly());
        }

        public static string GetString(string key)
        {
            return _resourceManager.GetString(key, CultureInfo.InvariantCulture);
        }
    }
}
