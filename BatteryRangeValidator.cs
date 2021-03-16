
using System;
using System.Linq;

namespace BatteryManagementSystem
{
    public class BatteryRangeValidator : IValidator
    {
        private ILogger _logger;
        public BatteryRangeValidator(ILogger logger)
        {
            if(logger == null)
                throw new ArgumentNullException("ILogger cannot be null");
            this._logger = logger;
        }

        public void ValidateTemperatureState(float temperature)
        {
            Range temperatureRange = GetTemperatureRange(temperature);
            if (temperatureRange != null)
                _logger.Log(BatteryRangeLevels.Temperature[temperatureRange]);
        }

        public void ValidateSocState(float soc)
        {
            Range socRange = GetSocRange(soc);
            if (socRange != null)
                _logger.Log(BatteryRangeLevels.Temperature[socRange]);
        }

        public void ValidateChargeRateState(float chargeRate)
        {
            Range chargeRateRange = GetChargeRateRange(chargeRate);
            if (chargeRateRange != null)
                _logger.Log(BatteryRangeLevels.Temperature[chargeRateRange]);
        }

        public Range GetTemperatureRange(float temperature)
            => BatteryRangeLevels.Temperature.Keys.FirstOrDefault(x => x.InRange(temperature));
        
        public Range GetSocRange(float soc)
            => BatteryRangeLevels.StateOfCharge.Keys.FirstOrDefault(x => x.InRange(soc));

        public Range GetChargeRateRange(float chargeRate)
            => BatteryRangeLevels.ChargeRate.Keys.FirstOrDefault(x => x.InRange(chargeRate));
    }
}
