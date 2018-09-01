using System;
using System.Linq;
using Xunit;

namespace UPictures.Core.Tests
{
    public class PictureTest
    {
        [Fact]
        public void ConstructorShouldSetProperties()
        {
            // Arrange
            Picture mediaFile;
            var fileName = "picture";
            string folderName = "Vacaciones";
            double fileSize = 2.5;
            int width = 1024;
            int height = 768;

            // Act
            mediaFile = new Picture(fileName, fileSize, width, height, folderName);

            // Assert
            Assert.Equal(fileName, mediaFile.FileName);
            Assert.Equal(fileSize, mediaFile.FileSize);
            Assert.Equal(width, mediaFile.Width);
            Assert.Equal(height, mediaFile.Height);
            Assert.NotNull(mediaFile.Tags);
            Assert.Equal(0, mediaFile.Tags.Count);
        }

        [Fact]
        public void EqualsShouldCompareByNameToLower()
        {
            // Arrange
            double fileSize = 2500;
            string folderName = "Vacaciones";
            int width = 1024;
            int height = 768;
            var mediaFile01 = new Picture("filename", fileSize, width, height, folderName);
            var mediaFile02 = new Picture("FileName", fileSize, width, height, folderName);
            bool areEqual;

            // Act
            areEqual = mediaFile01.Equals(mediaFile02);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void EqualsWithNullShouldReturnFalse()
        {
            // Arrange
            double fileSize = 2500;
            string folderName = "Vacaciones";
            int width = 1024;
            int height = 768;
            var mediaFile01 = new Picture("filename", fileSize, width, height, folderName);
            Picture mediaFile02 = null;
            bool areEqual;

            // Act
            areEqual = mediaFile01.Equals(mediaFile02);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void EqualsWithDifferentNamesShouldReturnFalse()
        {
            // Arrange
            double fileSize = 2500;
            string folderName = "Vacaciones";
            int width = 1024;
            int height = 768;
            var mediaFile01 = new Picture("filename", fileSize, width, height, folderName);
            var mediaFile02 = new Picture("filename02", fileSize, width, height, folderName);
            bool areEqual;

            // Act
            areEqual = mediaFile01.Equals(mediaFile02);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void AddTagWithNullShouldThrowArgumentNullException()
        {
            // Arrange
            var fileName = "picture";
            string folderName = "Vacaciones";
            double fileSize = 2500;
            int width = 1024;
            int height = 768;
            var mediaFile = new Picture(fileName, fileSize, width, height, folderName);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => mediaFile.AddTag(null));
        }

        [Fact]
        public void AddNonExistingTagShouldAddTag()
        {
            // Arrange
            var fileName = "picture";
            string folderName = "Vacaciones";
            double fileSize = 2500;
            int width = 1024;
            int height = 768;
            var mediaFile = new Picture(fileName, fileSize, width, height, folderName);
            mediaFile.AddTag("tag 01");
            mediaFile.AddTag("tag 02");
            var tagName = "tag 03";

            // Act
            mediaFile.AddTag(tagName);

            // Assert
            Assert.Equal(3, mediaFile.Tags.Count);
            Assert.Equal(tagName, mediaFile.Tags.ToList()[2].Name);
        }

        [Fact]
        public void AddWithExistingTagShouldNotAddTag()
        {
            // Arrange
            var fileName = "picture";
            string folderName = "Vacaciones";
            double fileSize = 2500;
            int width = 1024;
            int height = 768;
            var mediaFile = new Picture(fileName, fileSize, width, height, folderName);
            mediaFile.AddTag("tag 01");
            mediaFile.AddTag("tag 02");
            var tagName = "tag 01";

            // Act
            mediaFile.AddTag(tagName);

            // Assert
            Assert.Equal(2, mediaFile.Tags.Count);
        }

        [Fact]
        public void RemoveExistingTagShouldRemoveTag()
        {
            // Arrange
            var fileName = "picture";
            string folderName = "Vacaciones";
            double fileSize = 2500;
            int width = 1024;
            int height = 768;
            var mediaFile = new Picture(fileName, fileSize, width, height, folderName);
            mediaFile.AddTag("tag 01");
            mediaFile.AddTag("tag 02");
            var tag = mediaFile.Tags.ToList()[1];

            // Act
            mediaFile.RemoveTag(tag);

            // Assert
            Assert.Equal(1, mediaFile.Tags.Count);
            Assert.Equal("tag 01", mediaFile.Tags.ToList()[0].Name);
        }

        [Fact]
        public void RemoveNonExistingTagShouldDoNothing()
        {
            // Arrange
            var fileName = "picture";
            string folderName = "Vacaciones";
            double fileSize = 2500;
            int width = 1024;
            int height = 768;
            var mediaFile = new Picture(fileName, fileSize, width, height, folderName);
            mediaFile.AddTag("tag 01");
            mediaFile.AddTag("tag 02");
            var tag = new Tag("tag 03");

            // Act
            mediaFile.RemoveTag(tag);

            // Assert
            Assert.Equal(2, mediaFile.Tags.Count);
        }
    }
}