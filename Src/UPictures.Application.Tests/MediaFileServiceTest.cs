using System;
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
    public class MediaFileServiceTest
    {
        //[Fact]
        //public void GetByIdShouldReturnItem()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaFileRepository = Substitute.For<IPictureRepository>();
        //    var fileName = "picture 01";
        //    var fileExtension = ".jpg";
        //    var mediaFile = new Picture(fileName, fileExtension, MediaFileType.Picture);
        //    mediaFileRepository.GetById(Arg.Is(1)).Returns(mediaFile);
        //    var mediaFileService = new PictureService(unitOfWork, mediaFileRepository, logService);
        //    Picture returned;

        //    // Act
        //    returned = mediaFileService.GetById(1);

        //    // Assert
        //    Assert.NotNull(returned);
        //    Assert.Equal(fileName, returned.FileName);
        //    Assert.Equal(fileExtension, returned.FileExtension);
        //}

        //[Fact]
        //public void GetByIdWithInvalidIdShouldReturnNull()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaFileRepository = Substitute.For<IPictureRepository>();
        //    var fileName = "picture 01";
        //    var fileExtension = ".jpg";
        //    var mediaFile = new Picture(fileName, fileExtension, MediaFileType.Picture);
        //    mediaFileRepository.GetById(Arg.Any<int>()).Throws(new Exception());
        //    var mediaFileService = new PictureService(unitOfWork, mediaFileRepository, logService);
        //    Picture returned;

        //    // Act
        //    returned = mediaFileService.GetById(1);

        //    // Assert
        //    Assert.Null(returned);
        //    logService.ReceivedWithAnyArgs().Error(Arg.Any<string>());
        //}

        //[Fact]
        //public void AddTagShouldReturnMediaFile()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaFileRepository = Substitute.For<IPictureRepository>();
        //    var fileName = "picture 01";
        //    var fileExtension = ".jpg";
        //    var mediaFile = new Picture(fileName, fileExtension, MediaFileType.Picture);
        //    mediaFileRepository.GetById(Arg.Is(1)).Returns(mediaFile);
        //    var mediaFileService = new PictureService(unitOfWork, mediaFileRepository, logService);
        //    Picture returned;
        //    var mediaFileId = 1;
        //    var tagName = "tag 01";

        //    // Act
        //    returned = mediaFileService.AddTag(mediaFileId, tagName);

        //    // Assert
        //    Assert.NotNull(returned);
        //    Assert.Equal(fileName, returned.FileName);
        //    Assert.Equal(fileExtension, returned.FileExtension);
        //    mediaFileRepository.ReceivedWithAnyArgs().Update(mediaFile);
        //    unitOfWork.ReceivedWithAnyArgs().SaveChanges();
        //}

        //[Fact]
        //public void AddTagWithExceptionShouldReturnNull()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaFileRepository = Substitute.For<IPictureRepository>();
        //    var fileName = "picture 01";
        //    var fileExtension = ".jpg";
        //    var mediaFile = new Picture(fileName, fileExtension, MediaFileType.Picture);
        //    mediaFileRepository.GetById(Arg.Any<int>()).Throws(new Exception());
        //    var mediaFileService = new PictureService(unitOfWork, mediaFileRepository, logService);
        //    Picture returned;
        //    var mediaFileId = 1;
        //    var tagName = "tag 01";

        //    // Act
        //    returned = mediaFileService.AddTag(mediaFileId, tagName);

        //    // Assert
        //    Assert.Null(returned);
        //    logService.ReceivedWithAnyArgs().Error(Arg.Any<string>());
        //}

        //[Fact]
        //public void AddTagWithNonExistingMediaFileShouldReturnNull()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaFileRepository = Substitute.For<IPictureRepository>();
        //    var fileName = "picture 01";
        //    var fileExtension = ".jpg";
        //    var mediaFileId = 1;
        //    mediaFileRepository.GetById(Arg.Is(mediaFileId)).ReturnsNull();
        //    var mediaFileService = new PictureService(unitOfWork, mediaFileRepository, logService);
        //    Picture returned;
        //    var tagName = "tag 01";

        //    // Act
        //    returned = mediaFileService.AddTag(mediaFileId, tagName);

        //    // Assert
        //    Assert.Null(returned);
        //}

        //[Fact]
        //public void RemoveTagShouldRemoveTag()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaFileRepository = Substitute.For<IPictureRepository>();
        //    var fileName = "picture 01";
        //    var fileExtension = ".jpg";
        //    var mediaFile = new Picture(fileName, fileExtension, MediaFileType.Picture);
        //    mediaFile.AddTag("tag 01");
        //    mediaFile.AddTag("tag 02");
        //    mediaFile.AddTag("tag 03");
        //    var tag = mediaFile.Tags.ToList()[1];
        //    mediaFileRepository.GetById(Arg.Is(1)).Returns(mediaFile);
        //    var mediaFileService = new PictureService(unitOfWork, mediaFileRepository, logService);
        //    Picture returned;
        //    var mediaFileId = 1;
        //    var tagName = "tag 01";

        //    // Act
        //    returned = mediaFileService.RemoveTag(mediaFileId, tag);

        //    // Assert
        //    Assert.NotNull(returned);
        //    Assert.Equal(2, returned.Tags.Count);
        //    mediaFileRepository.ReceivedWithAnyArgs().Update(mediaFile);
        //    unitOfWork.ReceivedWithAnyArgs().SaveChanges();
        //}

        //[Fact]
        //public void RemoveTagWithExceptionShouldReturnNull()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaFileRepository = Substitute.For<IPictureRepository>();
        //    var fileName = "picture 01";
        //    var fileExtension = ".jpg";
        //    var mediaFile = new Picture(fileName, fileExtension, MediaFileType.Picture);
        //    mediaFileRepository.GetById(Arg.Any<int>()).Throws(new Exception());
        //    var mediaFileService = new PictureService(unitOfWork, mediaFileRepository, logService);
        //    Picture returned;
        //    var mediaFileId = 1;
        //    var tag = new Tag("tag 01");

        //    // Act
        //    returned = mediaFileService.RemoveTag(mediaFileId, tag);

        //    // Assert
        //    Assert.Null(returned);
        //    logService.ReceivedWithAnyArgs().Error(Arg.Any<string>());
        //}

        //[Fact]
        //public void RemoveTagWithNonExistingMediaFileShouldReturnNull()
        //{
        //    // Arrange 
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaFileRepository = Substitute.For<IPictureRepository>();
        //    var fileName = "picture 01";
        //    var fileExtension = ".jpg";
        //    var mediaFileId = 1;
        //    mediaFileRepository.GetById(Arg.Is(mediaFileId)).ReturnsNull();
        //    var mediaFileService = new PictureService(unitOfWork, mediaFileRepository, logService);
        //    Picture returned;
        //    var tag = new Tag("tag 01");

        //    // Act
        //    returned = mediaFileService.RemoveTag(mediaFileId, tag);

        //    // Assert
        //    Assert.Null(returned);
        //}

        //[Fact]
        //public void SearchShouldCallRepositorySearch()
        //{
        //    // Arrange
        //    var unitOfWork = Substitute.For<IUnitOfWork>();
        //    var logService = Substitute.For<ILogService>();
        //    var mediaFileRepository = Substitute.For<IPictureRepository>();
        //    var fileName = "picture 01";
        //    var fileExtension = ".jpg";
        //    mediaFileRepository.GetById(Arg.Any<int>()).Throws(new Exception());
        //    var mediaFileService = new PictureService(unitOfWork, mediaFileRepository, logService);
        //    var searchQuery = "mediaFile 01";

        //    // Act
        //    mediaFileService.Search(searchQuery);

        //    // Assert
        //    mediaFileRepository.ReceivedWithAnyArgs().Find(searchQuery);
        //}
    }
}
