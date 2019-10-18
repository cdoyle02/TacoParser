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
            //arrange
            var taco = new TacoParser();
            var str = "34.073638, -84.677017,Taco Bell Acwort...";

            //act
            var actual = taco.Parse(str);

            //assert
            Assert.NotNull(actual);
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

        [Fact]
        public void ShouldFailParse()
        {
            //arrange
            var tester = new TacoParser();
            var str1 = "34.073638, -84.677017,Taco Bell Acwort..., dis is bad data., dis is moar bad data., shallnt work.";
            var bish = new TacoBell();

            bish.Name = "Taco Bell Acwort...";
            var expected = bish.Name; 
            //act
            var actual = tester.Parse(str1);

            //assert
            Assert.Equal(actual.Name, expected);

        }
    }
}