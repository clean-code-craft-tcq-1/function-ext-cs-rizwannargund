using System;
using System.Diagnostics;

namespace BatteryManagementSystem
{
    public class BatteryStateChecker
    {
        public static string IsTemperatureValid(BatteryStateControl batteryStateControl)
        {
            return new TemperatureValidator().FindTemperatureWithinRange(batteryStateControl);
        }
        public static string IsStateOfChargeValid(BatteryStateControl batteryStateControl)
        {
            return new StateOfChargeValidator().FindSocWithinRange(batteryStateControl);
        }
        public static string IsChargeRateValid(BatteryStateControl batteryStateControl)
        {
            return new ChargeRateValidator().FindChargeRateWithinRange(batteryStateControl);
        }
        
        static void SetLanguage()
        {
            PrintMessage("Please choose one of the language");
            PrintMessage("1. English");
            PrintMessage("2. German");
            int.TryParse(Console.ReadLine(), out int result);
            if (result == 0)
            {
                PrintMessage("Please enter valid input");
                Environment.Exit(0);
            }
            Language.SetLanguageCode(result);
            Language.LoadResource();
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        #region Inputs
        static float GetTemperatureUnitWithValue()
        {
            PrintMessage(Language.GetString(Language.TemperatureUnitInput));
            PrintMessage(Language.GetString(Language.TemperatureUnitInput1));
            PrintMessage(Language.GetString(Language.TemperatureUnitInput2));
            int.TryParse(Console.ReadLine(), out int result);
            if (result == 0)
            {
                PrintMessage(Language.GetString(Language.InvalidInputMessage));
                Environment.Exit(0);
            }

            return GetTemperatureValue(result);
        }

        static float GetTemperatureValue(int unitType)
        {
            PrintMessage(Language.GetString(Language.TemperatureValue));
            float.TryParse(Console.ReadLine(), out float result);
            if (result == 0)
            {
                PrintMessage(Language.GetString(Language.InvalidInputMessage));
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
            PrintMessage(Language.GetString(Language.SocValue));
            float.TryParse(Console.ReadLine(), out float result);
            if (result == 0)
            {
                PrintMessage(Language.GetString(Language.InvalidInputMessage));
                Environment.Exit(0);
            }

            return result;
        }
        static float GetChargeRateValue()
        {
            PrintMessage(Language.GetString(Language.ChargeRateValue));
            float.TryParse(Console.ReadLine(), out float result);
            if (result == 0)
            {
                PrintMessage(Language.GetString(Language.InvalidInputMessage));
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
            PrintMessage(IsTemperatureValid(new BatteryStateControl(temperature, soc, chargeRate)));
            PrintMessage(IsStateOfChargeValid(new BatteryStateControl(temperature, soc, chargeRate)));
            PrintMessage(IsChargeRateValid(new BatteryStateControl(temperature, soc, chargeRate)));

            return 0;
        }
    }
}