
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

        public void GetBatteryState(ILogger logger)
        {
            TemperatureValidator temperatureValidator = new TemperatureValidator(logger);
            temperatureValidator.RangeValidate(this.Temperature);

            SocValidator socValidator = new SocValidator(logger);
            socValidator.RangeValidate(this.StateOfCharge);

            ChargeRateValidator chargeRateValidator = new ChargeRateValidator(logger);
            chargeRateValidator.RangeValidate(this.ChargeRate);
        }
    }
}
