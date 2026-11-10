using PulseCore;

namespace PulseTests
{
    public class TelemetryReadingTests
    {
        private readonly TelemetryReading _sut;
        private readonly TelemetryResultValidator _val;

        public TelemetryReadingTests()
        {
            _sut = new TelemetryReading();
            _val = new TelemetryResultValidator();
        }

        [Fact]
        public void PositiveAltitudeShouldReturnValid()
        {
            _sut.Altitude = 0.0;
            Assert.True(_val.Validate(_sut).isValid);
        }

        [Fact]
        public void NegativeAltitudeShouldReturnInvalid()
        {
            _sut.Altitude -= 1.0;
            Assert.False(_val.Validate(_sut).isValid);
        }

        [Fact]
        public void PositiveVelocityShouldReturnValid()
        {
            _sut.Velocity = 0.0;
            Assert.True(_val.Validate(_sut).isValid);
        }

        [Fact]
        public void NegativeVelocityShouldReturnInvalid()
        {
            _sut.Velocity = -1.0;
            Assert.False(_val.Validate(_sut).isValid);
        }
    }
}
