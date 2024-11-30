using examen_final.Domain.WeatherForecasts;

namespace examen_final.Domain.Tests;

[TestClass]
public class WeatherForecastServiceTests {

    [TestMethod]
    public void WeatherForecastList_Success() {
        //Arrange

        //Act
        var result = WeatherForecastService.WeatherForecastList();

        //Assert
        Assert.IsNotNull( result );
    }
}
