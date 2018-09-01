using NSubstitute;
using Xunit;

namespace UPictures.Discover.Tests
{
    public class MediaConfigurationManagerTest
    {
        [Fact]
        public void ConstructorShouldSetEmptyErrors()
        {
            // Arrange
            var folderValidator = Substitute.For<IFolderValidator>();
            MediaConfigurationManager mediaConfigurationManager;
            var args = new string[0];

            // Act
            mediaConfigurationManager = new MediaConfigurationManager(args, folderValidator);

            // Assert
            Assert.Equal(string.Empty, mediaConfigurationManager.Errors);
        }

        [Fact]
        public void StartupWithNullArgsShouldReturnFalse()
        {
            // Arrange
            var folderValidator = Substitute.For<IFolderValidator>();
            string[] args = null;
            var mediaConfigurationManager = new MediaConfigurationManager(args, folderValidator);
            bool startupResult;

            // Act
            startupResult = mediaConfigurationManager.StartupCheck();

            // Assert
            Assert.Equal(false, startupResult);
        }

        [Fact]
        public void StartupWithEmptyArgsShouldReturnFalse()
        {
            // Arrange
            var folderValidator = Substitute.For<IFolderValidator>();
            string[] args = new string[0];
            var mediaConfigurationManager = new MediaConfigurationManager(args, folderValidator);
            bool startupResult;

            // Act
            startupResult = mediaConfigurationManager.StartupCheck();

            // Assert
            Assert.Equal(false, startupResult);
        }

        [Fact]
        public void StartupWithValidArgsShouldSetRootFolder()
        {
            // Arrange
            var folderValidator = Substitute.For<IFolderValidator>();
            var rootFolder = @"C:\upictures\pictures";
            string[] args = { rootFolder };
            var mediaConfigurationManager = new MediaConfigurationManager(args, folderValidator);

            // Act
            mediaConfigurationManager.StartupCheck();

            // Assert
            Assert.Equal(rootFolder, mediaConfigurationManager.RootFolder);
        }

        [Fact]
        public void StartupWithNonExistingRootFolderShouldReturnError()
        {
            // Arrange
            var folderValidator = Substitute.For<IFolderValidator>();
            folderValidator.Exists(Arg.Any<string>()).Returns(false);
            var rootFolder = @"C:\upictures\pictures";
            string[] args = { rootFolder };
            var mediaConfigurationManager = new MediaConfigurationManager(args, folderValidator);
            bool startupResult;

            // Act
            startupResult = mediaConfigurationManager.StartupCheck();

            // Assert
            Assert.False(startupResult);
        }
    }
}
