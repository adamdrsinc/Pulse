namespace PulseCore;


public enum ValveState
{
    CLOSED,
    OPEN,
    OPENING,
    CLOSING,
    FAULT
}

public class TelemetryReading
{
    public double         Altitude      { get; set; }
    public DateTimeOffset Timestamp     { get; set; }
    public double         Velocity      { get; set; }
    public float          Temperature   { get; set; }
    public ValveState     VState        { get; set; }
    public UInt32         VIN           { get; set; }
    public UInt32         Sequence      { get; set; }   

    public override string ToString()
    {
        return $"""
            -- Telemetry Reading : {Timestamp:0} : VIN {VIN} --
            
            Altitude:        {Altitude}
            Velocity:        {Velocity}
            Temperature:     {Temperature}
            Valve State:     {nameof(VState)}
            Sequence Number: {Sequence}

            -- End Reading --
            """;
    }
}



