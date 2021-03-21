using System;
using System.Linq;

namespace BatteryManagementSystem
{
    public class TemperatureValidator: IRangeValidator
    {
        private readonly ILogger _logger;
        public TemperatureValidator(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException("ILogger cannot be null");
            this._logger = logger;
        }

        public void RangeValidate(float temperature)
        {
            Range temperatureRange = GetTemperatureRange(temperature);
            if (temperatureRange != null)
                _logger.Log(BatteryRangeLevels.Temperature[temperatureRange]);
        }

        private Range GetTemperatureRange(float temperature)
            => BatteryRangeLevels.Temperature.Keys.FirstOrDefault(x => x.InRange(temperature));
    }
}
