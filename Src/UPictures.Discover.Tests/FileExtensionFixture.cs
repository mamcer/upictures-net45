namespace UPictures.Discover.Tests
{
    public class FileExtensionFixture
    {
        public string[] PictureFileExtensions { get; private set; }

        public string[] VideoFileExtensions { get; private set; }

        public FileExtensionFixture()
        {
            PictureFileExtensions = new[] { ".jpg", ".png" };
            VideoFileExtensions = new[] { ".avi", ".mov", ".3gp", ".mpg", ".mp4", ".mpeg" };
        }
    }
}