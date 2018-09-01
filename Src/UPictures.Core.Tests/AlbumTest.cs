using System;
using System.Linq;
using Xunit;

namespace UPictures.Core.Tests
{
    public class AlbumTest
    {
        [Fact]
        public void ConstructorShouldSetName()
        {
            // Arrange
            Album album;
            var albumName = "Album Name";

            // Act
            album = new Album(albumName);

            // Assert
            Assert.Equal(albumName, album.Name);
        }

        public void ConstructorShouldInitializeMediaFiles()
        {
            // Arrange
            Album album;
            var albumName = "Album Name";

            // Act
            album = new Album(albumName);

            // Assert
            Assert.NotNull(album.Pictures);
            Assert.Equal(0, album.Pictures.Count);
        }

        [Fact]
        public void AddPictureWithNullShouldThrowArgumentNullException()
        {
            //Arrange
            Picture picture = null;
            var album = new Album("album01");

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => album.AddPicture(picture));
        }

        [Fact]
        public void AddValidPictureShouldAddPicture()
        {
            //Arrange
            string fileName = "fileName01";
            string folderName = "Vacaciones";
            double fileSize = 2.0;
            int width = 1024;
            int height = 768;

            Picture picture = new Picture(fileName, fileSize, width, height, folderName);
            var album = new Album("album01");

            //Act
            album.AddPicture(picture);

            //Assert
            Assert.Equal(1, album.Pictures.Count);
            Assert.Equal(fileName, album.Pictures.First().FileName);
        }

        [Fact]
        public void AddExistingPictureShouldNotAddPicture()
        {
            //Arrange
            var fileName01 = "fileName01";
            var fileName02 = "fileName02";
            var fileName03 = "fileName01";
            string folderName = "Vacaciones";
            double fileSize = 2.0;
            int width = 1024;
            int height = 768;
            var picture01 = new Picture(fileName01, fileSize, width, height, folderName);
            var picture02 = new Picture(fileName02, fileSize, width, height, folderName);
            var picture03 = new Picture(fileName03, fileSize, width, height, folderName);
            var album = new Album("album01");

            //Act
            album.AddPicture(picture01);
            album.AddPicture(picture02);
            album.AddPicture(picture03);

            //Assert
            Assert.Equal(2, album.Pictures.Count);
        }

        [Fact]
        public void EqualsShouldCompareByNameToLower()
        {

            // Arrange
            var album01 = new Album("album 01");
            var album02 = new Album("alBuM 01");
            bool areEqual;

            // Act
            areEqual = album01.Equals(album02);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void EqualsWithNullShouldReturnFalse()
        {

            // Arrange
            var album01 = new Album("album 01");
            Album album02 = null;
            bool areEqual;

            // Act
            areEqual = album01.Equals(album02);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void EqualsWithDifferentNamesShouldReturnFalse()
        {

            // Arrange
            var album01 = new Album("album 01");
            var album02 = new Album("album 02");
            bool areEqual;

            // Act
            areEqual = album01.Equals(album02);

            // Assert
            Assert.False(areEqual);
        }
    }
}