using System;
using System.Collections;
using CrossCutting.Core.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using UPictures.Core;
using UPictures.Data;
using Xunit;
using System.Collections.Generic;

namespace UPictures.Application.Tests
{
    public class AlbumServiceTest
    {
        [Fact]
        public void GetByIdWithValidIdShouldReturnAlbum()
        {
            // Arrange
            var albumRepository = Substitute.For<IAlbumRepository>();
            var album = new Album("hello");
            albumRepository.GetById(Arg.Is(2)).Returns(album);
            var logService = Substitute.For<ILogService>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var albumService = new AlbumService(unitOfWork, albumRepository, logService);

            // Act
            var returned = albumService.GetById(2);

            // Assert
            Assert.NotNull(returned);
        }

        [Fact]
        public void GetByIdWithInvalidIdShouldReturnNull()
        {
            // Arrange
            var albumRepository = Substitute.For<IAlbumRepository>();
            albumRepository.GetById(Arg.Any<int>()).Throws(new Exception());
            var logService = Substitute.For<ILogService>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var albumService = new AlbumService(unitOfWork, albumRepository, logService);

            // Act
            var returned = albumService.GetById(2);

            // Assert
            Assert.Null(returned);
        }

        [Fact]
        public void GetByIdWithInvalidIdShouldLogError()
        {
            // Arrange
            var albumRepository = Substitute.For<IAlbumRepository>();
            albumRepository.GetById(Arg.Any<int>()).Throws(new Exception());
            var logService = Substitute.For<ILogService>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var albumService = new AlbumService(unitOfWork, albumRepository, logService);

            // Act
            albumService.GetById(2);

            // Assert
            logService.Received().Error(Arg.Any<string>());
        }

        [Fact]
        public void FindWithRepositoryExceptionShouldLogError()
        {
            // Arrange
            var albumRepository = Substitute.For<IAlbumRepository>();
            albumRepository.Find(Arg.Any<string>()).Throws(new Exception());
            var logService = Substitute.For<ILogService>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var albumService = new AlbumService(unitOfWork, albumRepository, logService);

            // Act
            albumService.Find("mario");

            // Assert
            logService.Received().Error(Arg.Any<string>());
        }

        [Fact]
        public void FindWithRepositoryExceptionShouldReturnNull()
        {
            // Arrange
            var albumRepository = Substitute.For<IAlbumRepository>();
            albumRepository.Find(Arg.Any<string>()).Throws(new Exception());
            var logService = Substitute.For<ILogService>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var albumService = new AlbumService(unitOfWork, albumRepository, logService);
            IEnumerable<Album> albums;

            // Act
            albums = albumService.Find("mario");

            // Assert
            Assert.Null(albums);
        }

        [Fact]
        public void FindShouldCallRepositoryFind()
        {
            // Arrange
            var albumRepository = Substitute.For<IAlbumRepository>();
            albumRepository.Find(Arg.Any<string>()).Returns(new List<Album>());
            var logService = Substitute.For<ILogService>();
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var albumService = new AlbumService(unitOfWork, albumRepository, logService);
            IEnumerable<Album> albums;

            // Act
            albums = albumService.Find("mario");

            // Assert
            Assert.NotNull(albums);
            albumRepository.ReceivedWithAnyArgs().Find(Arg.Any<string>());
        }
    }
}
