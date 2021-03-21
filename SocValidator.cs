using System;
using System.Linq;

namespace BatteryManagementSystem
{
    public class SocValidator : IRangeValidator
    {
        private readonly ILogger _logger;
        public SocValidator(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException("ILogger cannot be null");
            this._logger = logger;
        }

        public void RangeValidate(float soc)
        {
            Range socRange = GetSocRange(soc);
            if (socRange != null)
                _logger.Log(BatteryRangeLevels.StateOfCharge[socRange]);
        }

        private Range GetSocRange(float soc)
            => BatteryRangeLevels.StateOfCharge.Keys.FirstOrDefault(x => x.InRange(soc));

    }
}
