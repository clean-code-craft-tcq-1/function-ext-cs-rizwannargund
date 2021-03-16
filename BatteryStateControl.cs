using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatteryManagementSystem
{
    public class BatteryStateControl
    {
        public float Temperature { get; set; }
        public float StateOfCharge { get; set; }
        public float ChargeRate { get; set; }

        public BatteryStateControl(float temperature, float stateOfCharge, float chargeRate)
        {
            Temperature = temperature;
            StateOfCharge = stateOfCharge;
            ChargeRate = chargeRate;
        }

        public void GetBatteryState()
        {
            ILogger logger = new Logger();
            BatteryRangeValidator batteryRangeValidator = new BatteryRangeValidator(logger);
            batteryRangeValidator.ValidateTemperatureState(this.Temperature);
            batteryRangeValidator.ValidateSocState(this.StateOfCharge);
            batteryRangeValidator.ValidateChargeRateState(this.ChargeRate);
        }
    }
}
