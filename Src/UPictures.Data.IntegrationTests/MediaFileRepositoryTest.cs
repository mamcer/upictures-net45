using System.Collections.Generic;
using System.Linq;
using CrossCutting.MainModule.IOC;
using UPictures.Core;
using Xunit;

namespace UPictures.Data.IntegrationTests
{
    [Collection("DatabaseCollection")]
    public class MediaFileRepositoryTest
    {
        //private IPictureRepository _mediaFileRepository;

        //public MediaFileRepositoryTest()
        //{
        //    var container = new IocUnityContainer();
        //    _mediaFileRepository = container.Resolve<IPictureRepository>();
        //}

        //[Fact]
        //public void FindShouldCompareCaseInsensitiveAndIncludeAlbum()
        //{
        //    // Arrange
        //    List<Picture> result;
        //    var query = "DscN";


        //    // Act
        //    result = _mediaFileRepository.Find(query).ToList();

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(3, result.Count);
        //    Assert.NotNull(result[1].Tags);
        //    Assert.NotNull(result[1].Album);
        //}

        //[Fact]
        //public void FindNonExistingItemShouldReturnEmptyList()
        //{
        //    // Arrange
        //    List<Picture> result;
        //    var query = "Non Existing Media File";


        //    // Act
        //    result = _mediaFileRepository.Find(query).ToList();

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(0, result.Count);
        //}

        //[Fact]
        //public void GetByIdExistingItemShouldReturnItem()
        //{
        //    // Arrange
        //    Picture result;
        //    Picture mediaFile;
        //    var mediaFileName = "DSCN6186";

        //    // Act
        //    mediaFile = _mediaFileRepository.Find(mediaFileName).FirstOrDefault();
        //    result = _mediaFileRepository.GetById(mediaFile.Id);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.NotNull(result.Tags);
        //    Assert.NotNull(result.Album);
        //}

        //[Fact]
        //public void GetByIdNonExistingItemShouldReturnNull()
        //{
        //    // Arrange
        //    Picture result;
        //    var id = -1;

        //    // Act
        //    result = _mediaFileRepository.GetById(id);

        //    // Assert
        //    Assert.Null(result);
        //}
    }
}
