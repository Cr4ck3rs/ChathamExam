using Xunit;
using WeatherServices.Models;

namespace WeatherServices.Tests
{
    public class WeaherApiOptionTests
    {
        // Test data
        private const string Name = "Name";
        private const string Key = "Key";

        [Fact]
        public void WhenInitializingWeaherApiOptionItsPropertiesShouldHaveCorrectValues()
        {
            var weaherApiOption = new WeaherApiOption
                            {
                                Name = Name,
                                Key = Key
                            };

            Assert.Equal(Name, weaherApiOption.Name);
            Assert.Equal(Key, weaherApiOption.Key);
        }
    }
}
