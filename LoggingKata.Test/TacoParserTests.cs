using System;
using LoggingKata;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }
     
       

        [Fact]
        public void ShouldParseFact()
        {
            var taco = new TacoParser();
            var str = "34.073638, -84.677017,Taco Bell Acwort...";
            var tacoBell = new TacoBell();

            tacoBell.Name = "Taco Bell Acwort...";
            var expected = tacoBell.Name;

            var actual = taco.Parse(str);


            Assert.Equal(actual.Name, expected); 
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            
        }
    }
}