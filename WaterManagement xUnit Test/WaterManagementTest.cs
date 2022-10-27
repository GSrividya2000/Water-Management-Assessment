using Microsoft.VisualStudio.TestPlatform.TestHost;
using FluentAssertions;
using Program = WaterManagement.Program;

namespace WaterManagement_xUnit_Test
{
    public class WaterManagementTest
    {
        [Fact]
        public void Task_Bill()
        {
            //Arrange
            Program program = new Program();
            int appartmentType = 2;
            int CorporationWaterRatio = 2;
            int borewellRatio = 1;
            int totalGuests = 6;
            var expectedResult = "2700 8050"; 

            //Act
            string actualResult=program.Bill(appartmentType,CorporationWaterRatio,borewellRatio,totalGuests);

            //Assert
            actualResult.Should().Be(expectedResult);
        }
    }
}