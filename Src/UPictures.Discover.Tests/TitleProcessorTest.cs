using Xunit;

namespace UPictures.Discover.Tests
{
    public class TitleProcessorTest
    {
        [Theory]
        [InlineData("2015-05-22_my-album")]
        [InlineData("2015-06_another-album")]
        [InlineData("2015-yet another album")]
        public void ProcessWithValidTitleShouldReturnTitleResult(string title)
        {
            // Arrange & Act
            var titleResult = TitleProcessor.Process(title);

            // Assert
            Assert.NotNull(titleResult);
            Assert.Equal("2015", titleResult.Year);
            Assert.Equal(title, titleResult.Title);
        }

        [Theory]
        [InlineData("2015_my-album")]
        [InlineData("Another-album")]
        [InlineData("2015 yet another album")]
        public void ProcessWithInvalidTitleShouldReturnNull(string title)
        {
            // Arrange & Act
            var titleResult = TitleProcessor.Process(title);

            // Assert
            Assert.Null(titleResult);
        }
    }
}