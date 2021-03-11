using System.Linq;

namespace BatteryManagementSystem
{
    public class StateOfChargeValidator
    {
        public string FindSocWithinRange(BatteryStateControl batteryStateControl)
        {
            Range range = BatteryRangeLevel.StateOfCharge.Keys.FirstOrDefault(x => x.InRange(batteryStateControl.StateOfCharge));
            if (range != null)
                return Language.GetString(BatteryRangeLevel.StateOfCharge[range]);
            else
            {
                return "No message found!";
            }
        }
    }
}