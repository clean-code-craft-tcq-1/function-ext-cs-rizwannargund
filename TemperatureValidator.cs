using System.Linq;

namespace BatteryManagementSystem
{
    public class TemperatureValidator
    {
        public string FindTemperatureWithinRange(BatteryStateControl batteryStateControl)
        {
            Range range = BatteryRangeLevel.Temperature.Keys.FirstOrDefault(x => x.InRange(batteryStateControl.Temperature));
            if(range != null)
                return BatteryRangeLevel.Temperature[range];
            else
            {
                return "No message found!";
            }
        }

    }
}
