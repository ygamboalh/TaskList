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
        [InlineData("#underground")]
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

        [Theory]
        [InlineData("This is a text")]
        public void DivideString_StateUnderTest_ExpectedBehavior(string stringToSplit)
        {
            // Arrange
            var helpers = new Helper();

            // Act
            var sut = helpers.SplitString(stringToSplit);

            // 
            Assert.IsType<List<string>>(sut);
        }
    }
}
