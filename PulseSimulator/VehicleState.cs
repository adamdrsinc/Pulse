using PulseCore;

namespace PulseSimulator
{
    public static class SimulatorOptions
    {
        public static double MAX_VELOCITY = double.MaxValue;
        public static double ACCELERATION = 120.35;
    }

    public sealed class VehicleState
    {
        public double Altitude { get; private set; } = 0;
        public DateTimeOffset Timestamp { get; private set;} = DateTimeOffset.Now;
        public double Velocity { get; private set;} = 0;
        public float Temperature { get; private set; } = 0;
        public PulseCore.ValveState VState { get; private set; } = PulseCore.ValveState.CLOSED;
        public UInt32 VIN { get; private set; } = 101010;
        public UInt32 Sequence { get; private set; } = 0;

        public void Advance(TimeSpan elapsed)
        {
            double distanceTravelled = (Velocity * elapsed.TotalSeconds) + (0.5 * SimulatorOptions.ACCELERATION * Math.Pow(elapsed.TotalSeconds, 2));
            double newVelocity = Math.Sqrt(Math.Pow(Velocity, 2) + 2 * SimulatorOptions.ACCELERATION * distanceTravelled);

            Altitude += distanceTravelled;
            Velocity = newVelocity;

            Timestamp = DateTimeOffset.UtcNow;
            Sequence++;
        }

        public TelemetryReading GetReading()
        {
            return new TelemetryReading
            {
                Altitude = this.Altitude, 
                Timestamp = this.Timestamp, 
                Velocity = this.Velocity, 
                Temperature = this.Temperature,
                VState = this.VState,
                VIN = this.VIN,
                Sequence = this.Sequence
            };
        }

    }
}
