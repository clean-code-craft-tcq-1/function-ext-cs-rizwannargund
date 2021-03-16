using System;
using System.Diagnostics;

namespace BatteryManagementSystem
{
    public class BatteryStateChecker
    {
        static ILogger _logger = new Logger();

        static void SetLanguage()
        {
            _logger.Log("Please choose one of the language");
            _logger.Log("1. English");
            _logger.Log("2. German");
            int.TryParse(Console.ReadLine(), out int result);
            if (result == 0)
            {
                _logger.Log("Please enter valid input");
                Environment.Exit(0);
            }
            Language.SetLanguageCode(result);
            Language.LoadResource();
        }


        #region Inputs
        static float GetTemperatureUnitWithValue()
        {
            _logger.Log(Language.GetString(Language.TemperatureUnitInput));
            _logger.Log(Language.GetString(Language.TemperatureUnitInput1));
            _logger.Log(Language.GetString(Language.TemperatureUnitInput2));
            int.TryParse(Console.ReadLine(), out int result);
            if (result == 0)
            {
                _logger.Log(Language.GetString(Language.InvalidInputMessage));
                Environment.Exit(0);
            }

            return GetTemperatureValue(result);
        }

        static float GetTemperatureValue(int unitType)
        {
            _logger.Log(Language.GetString(Language.TemperatureValue));
            float.TryParse(Console.ReadLine(), out float result);
            if (result == 0)
            {
                _logger.Log(Language.GetString(Language.InvalidInputMessage));
                Environment.Exit(0);
            }
            if (unitType == 2)
            {
                result = ((5 / 9) * (result - 32));
            }

            return result;
        }
        static float GetSocValue()
        {
            _logger.Log(Language.GetString(Language.SocValue));
            float.TryParse(Console.ReadLine(), out float result);
            if (result == 0)
            {
                _logger.Log(Language.GetString(Language.InvalidInputMessage));
                Environment.Exit(0);
            }

            return result;
        }
        static float GetChargeRateValue()
        {
            _logger.Log(Language.GetString(Language.ChargeRateValue));
            float.TryParse(Console.ReadLine(), out float result);
            if (result == 0)
            {
                _logger.Log(Language.GetString(Language.InvalidInputMessage));
                Environment.Exit(0);
            }

            return result;
        }
        #endregion

        static int Main()
        {
            SetLanguage();
            float temperature = GetTemperatureUnitWithValue();
            float soc = GetSocValue();
            float chargeRate = GetChargeRateValue();

            BatteryStateControl batteryStateControl = new BatteryStateControl(temperature, soc, chargeRate);
            batteryStateControl.GetBatteryState();
            Console.WriteLine("All ok");
            return 0;
        }
    }
}