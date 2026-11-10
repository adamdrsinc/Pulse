namespace PulseCore;

public enum ValveState
{
    Closed,
    Open,
    Opening,
    CLosing,
    Fault
}

public class TelemetryReading
{
    public double         Altitude      { get; set; }
    public DateTimeOffset Timestamp     { get; set; }
    public double         Velocity      { get; set; }
    public float          Temperature   { get; set; }
    public ValveState     VState        { get; set; }
    public Int32          VIN           { get; set; }


    public override string ToString()
    {
        return $"""
            -- Telemetry Reading : {Timestamp:0} : VIN {VIN} --
            
            Altitude:        {Altitude}
            Velocity:        {Velocity}
            Temperature:     {Temperature}
            Valve State:     {VState}
            Sequence Number: {SequenceNumber}
            """;
    }
}
