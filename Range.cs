namespace BatteryManagementSystem
{
    public class Range
    {
        public float From { get; set; }
        public float To { get; set; }

        public Range(float from, float to)
        {
            From = from;
            To = to;
        }

        public bool InRange(float value)
            => (value >= From && value <= To);

    }
}