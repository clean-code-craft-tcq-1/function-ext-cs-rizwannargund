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
    }
}
