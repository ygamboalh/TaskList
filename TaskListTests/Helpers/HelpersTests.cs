using System;
using System.Collections.Generic;
using TaskListWebApi.Helpers;
using Xunit;

namespace TaskListTests.Helpers
{
    public class HelpersTests
    {
        [Theory]
        [InlineData("email@gmail.com")]
        public void IsValidEmail_StateUnderTest_ExpectedBehavior(string email)
        {
            // Arrange
            var helpers = new Helper();

            // Act
            var sut = helpers.IsValidEmail(email);

            // Assert
            Assert.True(sut);
        }
        [Fact]
        public void SplitString_StateUnderTest_ExpectedBehavior() 
        {
            // Arrange
            string stringToSplit = "string1, string2? string3 string4;string5";
            List<string> stringList = new List<string>();
            stringList.Add("string1");
            stringList.Add("string2");
            stringList.Add("string3");
            stringList.Add("string4");
            stringList.Add("string5");
            var helpers = new Helper();

            // Act
            var sut = helpers.SplitString(stringToSplit);

            // Assert
            Assert.NotNull(sut);
            Assert.Contains<String>("string4",sut);
        }
        [Fact]
        public void SplitChar_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string wordList = "@word";
            var helpers = new Helper();

            // Act
            var sut = helpers.SplitChar(wordList);

            // Assert
            Assert.NotNull(sut);
            Assert.Equal("word", sut);
        }
        [Theory]
        [InlineData("#important")]
        [InlineData("@user")]
        [InlineData("email@email.com")]
        [InlineData("http://www.google.com")]
        [InlineData("Just text")]
        public void FinalCheck_StateUnderTest_ExpectedBehavior(string text)
        {
            // Arrange
            var helpers = new Helper();
            List<string> possibleString = new List<string>();
            possibleString.Add("IsValidEmail");
            possibleString.Add("HasAt");
            possibleString.Add("HasHashtag");
            possibleString.Add("IsValidUrl");
            possibleString.Add("JustText");

            // Act
            var sut = helpers.FinalCheck(text);

            // Assert
            
            Assert.NotNull(sut);
            Assert.Contains<string>(sut,possibleString);
        }
        [Theory]
        [InlineData("http://www.youtube.com")]
        public void IsValidUrl_StateUnderTest_ExpectedBehavior(string url)
        {
            // Arrange
            var helpers = new Helper();

            // Act
            var sut = helpers.IsValidUrl(url);

            // Assert
            Assert.True(sut);
        }

        [Theory]
        [InlineData("#important")]
        public void HasHastag_StateUnderTest_ExpectedBehavior(string hastagString)
        {
            // Arrange
            var helpers = new Helper();

            // Act
            var sut = helpers.HasHashtag(hastagString);

            // Assert
            Assert.True(sut);
        }

        [Theory]
        [InlineData("@myuser")]
        public void HasAt_StateUnderTest_ExpectedBehavior(string atString)
        {
            // Arrange
            var helpers = new Helper();

            // Act
            var sut = helpers.HasAt(atString);

            // Assert
            Assert.True(sut);
        }

        
    }
}
