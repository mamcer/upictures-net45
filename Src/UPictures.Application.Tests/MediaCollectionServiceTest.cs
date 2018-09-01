using System;
using System.Collections.Generic;
using System.Linq;
using CrossCutting.Core.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using UPictures.Core;
using UPictures.Data;
using Xunit;

namespace UPictures.Application.Tests
{
    public class MediaCollectionServiceTest
    {
        //[Fact]
        //public void GetByIdShouldReturnItem()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaCollectionRepository = Substitute.For<IMediaCollectionRepository>();
        //    var mediaCollection = new MediaCollection("My Collection");
        //    mediaCollectionRepository.GetById(Arg.Is(1)).Returns(mediaCollection);
        //    var mediaCollectionService = new MediaCollectionService(unitOfWork, mediaCollectionRepository, logService);
        //    MediaCollection returned;

        //    // Act
        //    returned = mediaCollectionService.GetById(1);

        //    // Assert
        //    Assert.NotNull(returned);
        //    Assert.Equal("My Collection", returned.Name);
        //}

        //[Fact]
        //public void GetByIdWithInvalidIdShouldReturnNull()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaCollectionRepository = Substitute.For<IMediaCollectionRepository>();
        //    var mediaCollection = new MediaCollection("My Collection");
        //    mediaCollectionRepository.GetById(Arg.Is(1)).Returns(mediaCollection);
        //    var mediaCollectionService = new MediaCollectionService(unitOfWork, mediaCollectionRepository, logService);
        //    MediaCollection returned;

        //    // Act
        //    returned = mediaCollectionService.GetById(2);

        //    // Assert
        //    Assert.Null(returned);
        //}

        //[Fact]
        //public void GetByIdWithInvalidIdShouldLogError()
        //{
        //    // Arrange
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaCollectionRepository = Substitute.For<IMediaCollectionRepository>();
        //    mediaCollectionRepository.GetById(Arg.Any<int>()).Throws(new Exception());
        //    var mediaCollectionService = new MediaCollectionService(unitOfWork, mediaCollectionRepository, logService);
        //    // Act
        //    mediaCollectionService.GetById(1);

        //    // Assert
        //    logService.ReceivedWithAnyArgs().Error(Arg.Any<string>());
        //}

        //[Fact]
        //public void GetByNameShouldReturnItem()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaCollectionRepository = Substitute.For<IMediaCollectionRepository>();
        //    var mediaCollection = new MediaCollection("My Collection");
        //    mediaCollectionRepository.GetByName(Arg.Is("2005")).Returns(mediaCollection);
        //    var mediaCollectionService = new MediaCollectionService(unitOfWork, mediaCollectionRepository, logService);
        //    MediaCollection returned;

        //    // Act
        //    returned = mediaCollectionService.GetByName("2005");

        //    // Assert
        //    Assert.NotNull(returned);
        //    Assert.Equal("My Collection", returned.Name);
        //}

        //[Fact]
        //public void GetByNameWithExceptionShouldReturnNull()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaCollectionRepository = Substitute.For<IMediaCollectionRepository>();
        //    mediaCollectionRepository.GetByName(Arg.Any<string>()).Throws(new Exception());
        //    var mediaCollectionService = new MediaCollectionService(unitOfWork, mediaCollectionRepository, logService);
        //    MediaCollection returned;

        //    // Act & Assert
        //    returned = mediaCollectionService.GetByName("2005");

        //    // Assert
        //    Assert.Null(returned);
        //}

        //[Fact]
        //public void GetByIdWithInvalidNameShouldReturnNull()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaCollectionRepository = Substitute.For<IMediaCollectionRepository>();
        //    var mediaCollection = new MediaCollection("My Collection");
        //    mediaCollectionRepository.GetByName(Arg.Is("2006")).Returns(mediaCollection);
        //    var mediaCollectionService = new MediaCollectionService(unitOfWork, mediaCollectionRepository, logService);
        //    MediaCollection returned;

        //    // Act
        //    returned = mediaCollectionService.GetByName("2005");

        //    // Assert
        //    Assert.Null(returned);
        //}

        //[Fact]
        //public void GetByIdWithInvalidNameShouldLogError()
        //{
        //    // Arrange
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaCollectionRepository = Substitute.For<IMediaCollectionRepository>();
        //    mediaCollectionRepository.GetByName(Arg.Any<string>()).Throws(new Exception());
        //    var mediaCollectionService = new MediaCollectionService(unitOfWork, mediaCollectionRepository, logService);
            
        //    // Act
        //    mediaCollectionService.GetByName("2007");

        //    // Assert
        //    logService.ReceivedWithAnyArgs().Error(Arg.Any<string>());
        //}

        //[Fact]
        //public void GetAllShouldReturnAllItems()
        //{
        //    // Arrange
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaCollectionRepository = Substitute.For<IMediaCollectionRepository>();
        //    var mediaCollection = new List<MediaCollection> {new MediaCollection("2005"), new MediaCollection("2006"), new MediaCollection("2007")};
        //    mediaCollectionRepository.GetAll().Returns(mediaCollection);
        //    var mediaCollectionService = new MediaCollectionService(unitOfWork, mediaCollectionRepository, logService);
        //    IEnumerable<MediaCollection> collections;

        //    // Act
        //    collections = mediaCollectionService.GetAll();

        //    // Assert
        //    Assert.Equal(3, collections.Count());
        //}

        //[Fact]
        //public void GetAllWithExceptionShouldReturnNull()
        //{
        //    // Arrange
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaCollectionRepository = Substitute.For<IMediaCollectionRepository>();
        //    mediaCollectionRepository.GetAll().Throws(new Exception());
        //    var mediaCollectionService = new MediaCollectionService(unitOfWork, mediaCollectionRepository, logService);
        //    IEnumerable<MediaCollection> collections;

        //    // Act
        //    collections = mediaCollectionService.GetAll();

        //    // Assert
        //    logService.ReceivedWithAnyArgs().Error(Arg.Any<string>());
        //    Assert.Null(collections);
        //}

        //[Fact]
        //public void SaveMediaCollectionWithExistingCollectionShouldUpdate()
        //{
        //    // Arrange
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaCollectionRepository = Substitute.For<IMediaCollectionRepository>();
        //    var mediaCollection = new MediaCollection("2005");
        //    mediaCollectionRepository.GetByName("2005").Returns(mediaCollection);
        //    var mediaCollectionService = new MediaCollectionService(unitOfWork, mediaCollectionRepository, logService);

        //    // Act
        //    mediaCollectionService.SaveMediaCollection(mediaCollection);

        //    // Assert
        //    mediaCollectionRepository.Received().Update(mediaCollection);
        //    unitOfWork.ReceivedWithAnyArgs().SaveChanges();
        //}

        //[Fact]
        //public void SaveMediaCollectionWithNonExistingCollectionShouldInsert()
        //{
        //    // Arrange
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaCollectionRepository = Substitute.For<IMediaCollectionRepository>();
        //    var mediaCollection = new MediaCollection("2005");
        //    mediaCollectionRepository.GetByName("2005").ReturnsNull();
        //    var mediaCollectionService = new MediaCollectionService(unitOfWork, mediaCollectionRepository, logService);

        //    // Act
        //    mediaCollectionService.SaveMediaCollection(mediaCollection);

        //    // Assert
        //    mediaCollectionRepository.Received().Create(mediaCollection);
        //    unitOfWork.ReceivedWithAnyArgs().SaveChanges();
        //}
    }
}