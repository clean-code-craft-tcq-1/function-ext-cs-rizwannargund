using System.Linq;

namespace BatteryManagementSystem
{
    public class ChargeRateValidator
    {
        
        public string FindChargeRateWithinRange(BatteryStateControl batteryStateControl)
        {
            Range range = BatteryRangeLevel.ChargeRate.Keys.FirstOrDefault(x => x.InRange(batteryStateControl.ChargeRate));
            if (range != null)
                return Language.GetString(BatteryRangeLevel.ChargeRate[range]);
            else
            {
                return "No message found!";
            }
        }
    }
}
