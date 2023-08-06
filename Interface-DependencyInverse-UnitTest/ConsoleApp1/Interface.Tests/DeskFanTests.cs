using System;
using Xunit;
using Moq;

namespace Interface.Tests
{
    public class DeskFanTests
    {
        [Fact]
        public void PowerLowerThanZero_OK()
        {
            var mock = new Mock<IPowerSupply>();
            mock.Setup(ps => ps.GetPower()).Returns(() => 0);
            var fan = new DeskFan(mock.Object);



            //var fan = new DeskFan(new PowerSupplyLowerThanZero());
            //var expected = "Won't work.";
            //var actual = fan.Work();
            //Assert.Equal(expected, actual);
        }

        [Fact]
        public void PowerHigherThan200_Warning()
        {
            var mock = new Mock<IPowerSupply>();
            mock.Setup(ps => ps.GetPower()).Returns(() => 220);
            var fan = new DeskFan(mock.Object);

            //var fan = new DeskFan(new PowerSupplyHigherThan200());
            //var expected = "Warning!";
            //var actual = fan.Work();
            //Assert.Equal(expected, actual);
        }
    }

    // 引入Moq后弃用
    class PowerSupplyLowerThanZero : IPowerSupply
    {
        public int GetPower()
        {
            return 0;
        }
    }

    // 引入Moq后弃用
    class PowerSupplyHigherThan200 : IPowerSupply
    {
        public int GetPower()
        {
            return 220;
        }
    }
}
