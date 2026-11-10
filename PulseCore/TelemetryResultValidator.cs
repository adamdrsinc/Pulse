using System;
using System.Collections.Generic;
using System.Text;

namespace PulseCore
{
    public record TelemetryValidation(bool isValid, string? reason);

    public class TelemetryResultValidator
    {
        //public double Altitude { get; set; }
        //public DateTimeOffset Timestamp { get; set; }
        //public double Velocity { get; set; }
        //public float Temperature { get; set; }
        //public ValveState VState { get; set; }
        //public UInt32 VIN { get; set; }
        //public UInt32 Sequence { get; set; }

        public TelemetryValidation Validate(TelemetryReading r)
        {
            if (r.Altitude < 0)
            {
                return new TelemetryValidation(false, "Bad Altitude: Negative altitude.");
            } else if (r.Velocity < 0)
            {
                return new TelemetryValidation(false, "Bad Velocity: Negative velocity.");
            } 

            return new TelemetryValidation(true, null);
        }
    }
}
