using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatteryManagementSystem
{
    interface IValidator
    {
        void ValidateTemperatureState(float temperature);
        void ValidateSocState(float soc);
        void ValidateChargeRateState(float chargeRate);
    }
}
