using UPictures.Core;
using Xunit;

namespace UPictures.Discover.Tests
{
    public class FileProcessorTest : IClassFixture<FileExtensionFixture>
    {
        //private readonly FileExtensionFixture _fixture;

        //public FileProcessorTest(FileExtensionFixture fixture)
        //{
        //    _fixture = fixture;
        //}

        //[Fact]
        //public void ProcessWithUnknownFileExtensionShouldReturnUnknownMediaFile()
        //{
        //    // Arrange
        //    var filePath = @"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG587.dat";
        //    FileProcess fileProcess;
        //    var fileProcessor = new FileProcessor(_fixture.PictureFileExtensions, _fixture.VideoFileExtensions);

        //    // Act
        //    fileProcess = fileProcessor.Process(filePath);

        //    // Assert
        //    Assert.NotNull(fileProcess);
        //    Assert.Equal(MediaFileType.Unknown, fileProcess.MediaType);
        //}

        //[Fact]
        //public void ProcessWithValidPathShouldReturnANotNullFileProcess()
        //{
        //    // Arrange
        //    var filePath = @"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG587.jpg";
        //    FileProcess fileProcess;
        //    var fileProcessor = new FileProcessor(_fixture.PictureFileExtensions, _fixture.VideoFileExtensions);

        //    // Act
        //    fileProcess = fileProcessor.Process(filePath);

        //    // Assert
        //    Assert.NotNull(fileProcess);
        //}

        //[Theory]
        //[InlineData(@"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG587.jpg")]
        //[InlineData(@"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG587.png")]
        //public void ProcessWithValidImageFilePathShouldReturnFileProcess(string filePath)
        //{
        //    // Arrange
        //    FileProcess fileProcess;
        //    var fileProcessor = new FileProcessor(_fixture.PictureFileExtensions, _fixture.VideoFileExtensions);

        //    // Act
        //    fileProcess = fileProcessor.Process(filePath);

        //    // Assert
        //    Assert.NotNull(fileProcess);
        //    Assert.Equal("IMG587", fileProcess.Name);
        //    Assert.Equal(MediaFileType.Picture, fileProcess.MediaType);
        //}

        //[Theory]
        //[InlineData(@"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG587.jpg")]
        //[InlineData(@"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG587.jpg")]
        //[InlineData(@"C:\IMG587.jpg")]
        //public void ProcessWithValidJpgPathShouldReturnFileProcess(string filePath)
        //{
        //    // Arrange
        //    FileProcess fileProcess;
        //    var fileProcessor = new FileProcessor(_fixture.PictureFileExtensions, _fixture.VideoFileExtensions);

        //    // Act
        //    fileProcess = fileProcessor.Process(filePath);

        //    // Assert
        //    Assert.NotNull(fileProcess);
        //    Assert.Equal("IMG587", fileProcess.Name);
        //    Assert.Equal(".jpg", fileProcess.Extension);
        //    Assert.Equal(MediaFileType.Picture, fileProcess.MediaType);
        //}

        //[Theory]
        //[InlineData(@"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG588.avi")]
        //[InlineData(@"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG588.mov")]
        //[InlineData(@"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG588.3gp")]
        //[InlineData(@"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG588.mpg")]
        //[InlineData(@"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG588.mp4")]
        //[InlineData(@"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG588.mpeg")]
        //public void ProcessWithValidVideoFilePathShouldReturnFileProcess(string filePath)
        //{
        //    // Arrange
        //    FileProcess fileProcess;
        //    var fileProcessor = new FileProcessor(_fixture.PictureFileExtensions, _fixture.VideoFileExtensions);

        //    // Act
        //    fileProcess = fileProcessor.Process(filePath);

        //    // Assert
        //    Assert.NotNull(fileProcess);
        //    Assert.Equal("IMG588", fileProcess.Name);
        //    Assert.Equal(MediaFileType.Video, fileProcess.MediaType);
        //}

        //[Theory]
        //[InlineData(@"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG589.mov")]
        //[InlineData(@"C:\Users\dummy.user\My Pictures\2015-05-09_Vacaciones\IMG589.mov")]
        //[InlineData(@"C:\IMG589.mov")]
        //public void ProcessWithValidMovFilePathShouldReturnFileProcess(string filePath)
        //{
        //    // Arrange
        //    FileProcess fileProcess;
        //    var fileProcessor = new FileProcessor(_fixture.PictureFileExtensions, _fixture.VideoFileExtensions);

        //    // Act
        //    fileProcess = fileProcessor.Process(filePath);

        //    // Assert
        //    Assert.NotNull(fileProcess);
        //    Assert.Equal("IMG589", fileProcess.Name);
        //    Assert.Equal(".mov", fileProcess.Extension);
        //    Assert.Equal(MediaFileType.Video, fileProcess.MediaType);
        //}
    }
}