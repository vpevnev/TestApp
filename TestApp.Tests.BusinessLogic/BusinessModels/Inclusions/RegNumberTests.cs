using TestApp.BusinessLogic.BusinessModels.Inclusions;
using Xunit;

namespace TestApp.Tests.BusinessLogic.BusinessModels.Inclusions
{
    public class RegNumberTests
    {
        [Theory]
        [InlineData("032-013-000637-7", 32, 13, 637)]
        [InlineData("032-013-000637", 32, 13, 637)]
        [InlineData("032-013-", 32, 13, 0)]
        [InlineData("032--000637", 32, 0, 637)]
        [InlineData("032--1-000637", 32, 0, 1)]
        [InlineData("-1-000637", 0, 1, 637)]
        [InlineData("---", 0, 0, 0)]
        [InlineData("", 0, 0, 0)]
        public void SetFullRegNumberCorrectly(string full, short region, short district, int number)
        {
            // Arrange
            RegNumber regNumber = new();

            // Act
            regNumber.FullRegNumber = full;

            // Assert
            Assert.Equal(region, regNumber.RegnCode);
            Assert.Equal(district, regNumber.DistCode);
            Assert.Equal(number, regNumber.InsrNumber);
        }
    }
}
