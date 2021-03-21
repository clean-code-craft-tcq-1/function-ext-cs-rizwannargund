using System;
using System.Diagnostics;

namespace BatteryManagementSystem
{
    public class BatteryStateChecker
    {
        static ILogger _logger = new MockConsoleLogger();
        static ResourceHelper _userLanguage = new ResourceHelper();
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
            _userLanguage.SetLanguageCode(result);
            _userLanguage.LoadResource();
        }


        #region Inputs
        static float GetTemperatureUnitWithValue()
        {
            _logger.Log(_userLanguage.GetString(ResourceHelper.TemperatureUnitInput));
            _logger.Log(_userLanguage.GetString(ResourceHelper.TemperatureUnitInput1));
            _logger.Log(_userLanguage.GetString(ResourceHelper.TemperatureUnitInput2));
            int.TryParse(Console.ReadLine(), out int result);
            if (result == 0)
            {
                _logger.Log(_userLanguage.GetString(ResourceHelper.InvalidInputMessage));
                Environment.Exit(0);
            }

            return GetTemperatureValue(result);
        }

        static float GetTemperatureValue(int unitType)
        {
            _logger.Log(_userLanguage.GetString(ResourceHelper.TemperatureValue));
            float.TryParse(Console.ReadLine(), out float result);
            if (result == 0)
            {
                _logger.Log(_userLanguage.GetString(ResourceHelper.InvalidInputMessage));
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
            _logger.Log(_userLanguage.GetString(ResourceHelper.SocValue));
            float.TryParse(Console.ReadLine(), out float result);
            if (result == 0)
            {
                _logger.Log(_userLanguage.GetString(ResourceHelper.InvalidInputMessage));
                Environment.Exit(0);
            }

            return result;
        }
        static float GetChargeRateValue()
        {
            _logger.Log(_userLanguage.GetString(ResourceHelper.ChargeRateValue));
            float.TryParse(Console.ReadLine(), out float result);
            if (result == 0)
            {
                _logger.Log(_userLanguage.GetString(ResourceHelper.InvalidInputMessage));
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

            Debug.Assert(!temperature.Equals(null), "Invalid temperature input");
            Debug.Assert(!soc.Equals(null), "Invalid state of charge input");
            Debug.Assert(!chargeRate.Equals(null), "Invalid charge rate input");

            BatteryStateControl batteryStateControl = new BatteryStateControl(temperature, soc, chargeRate);
            batteryStateControl.GetBatteryState(new MockConsoleLogger());
            Debug.Assert(!batteryStateControl.Temperature.Equals(null), "Temperature is not set.");
            Debug.Assert(!batteryStateControl.StateOfCharge.Equals(null), "State of charge is not set.");
            Debug.Assert(!batteryStateControl.ChargeRate.Equals(null), "Charge rate is not set");
            try
            {
                batteryStateControl?.GetBatteryState(new MockConsoleLogger());
            }
            catch (Exception e)
            {
                Debug.Assert(false, "Failed to get battery state." + e.Message);
            }

            Console.WriteLine("All ok");
            return 0;
        }
    }
}