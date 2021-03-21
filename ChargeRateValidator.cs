using System;
using System.Linq;

namespace BatteryManagementSystem
{
    public class ChargeRateValidator
    {
        private readonly ILogger _logger;
        public ChargeRateValidator(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException("ILogger cannot be null");
            this._logger = logger;
        }

        public void RangeValidate(float chargeRate)
        {
            Range chargeRateRange = GetChargeRateRange(chargeRate);
            if (chargeRateRange != null)
                _logger.Log(BatteryRangeLevels.ChargeRate[chargeRateRange]);
        }

        private Range GetChargeRateRange(float chargeRate)
            => BatteryRangeLevels.ChargeRate.Keys.FirstOrDefault(x => x.InRange(chargeRate));
    }
}
