using System.Collections.Generic;
using System.Linq;
using CrossCutting.MainModule.IOC;
using UPictures.Core;
using Xunit;

namespace UPictures.Data.IntegrationTests
{
    //[Collection("DatabaseCollection")]
    //public class MediaCollectionRepositoryTest
    //{
    //    private IMediaCollectionRepository _mediaCollectionRepository;

    //    public MediaCollectionRepositoryTest()
    //    {
    //        var container = new IocUnityContainer();
    //        _mediaCollectionRepository = container.Resolve<IMediaCollectionRepository>();
    //    }

    //    [Fact]
    //    public void GetByNameShouldMatchName()
    //    {
    //        // Arrange
    //        MediaCollection result;
    //        var name = "2012";

    //        // Act
    //        result = _mediaCollectionRepository.GetByName(name);

    //        // Assert
    //        Assert.NotNull(result);
    //        Assert.Equal(name, result.Name);
    //        Assert.NotNull(result.Albums);
    //        Assert.Equal(1, result.Albums.Count);
    //    }

    //    [Fact]
    //    public void GetByNameNonExistingItemShouldReturnNull()
    //    {
    //        // Arrange
    //        MediaCollection result;
    //        var name = "Non Existing Collection";

    //        // Act
    //        result = _mediaCollectionRepository.GetByName(name);

    //        // Assert
    //        Assert.Null(result);
    //    }

    //    [Fact]
    //    public void GetAllShouldReturnAllCollections()
    //    {
    //        // Arrange
    //        List<MediaCollection> result;

    //        // Act
    //        result = _mediaCollectionRepository.GetAll().ToList();

    //        // Assert
    //        Assert.NotNull(result);
    //        Assert.Equal(2, result.Count);
    //        Assert.Equal("2010", result[0].Name);
    //        Assert.NotNull(result[0].Albums);
    //    }

    //    [Fact]
    //    public void GetByIdShouldReturnExistingItemWithAlbums()
    //    {
    //        // Arrange
    //        MediaCollection mediaCollection;
    //        var collectionName = "2010";
    //        MediaCollection result;

    //        // Act
    //        mediaCollection = _mediaCollectionRepository.GetByName(collectionName);
    //        result = _mediaCollectionRepository.GetById(mediaCollection.Id);

    //        // Assert
    //        Assert.NotNull(result);
    //        Assert.NotNull(result.Albums);
    //        Assert.Equal(collectionName, result.Name);
    //    }

    //    [Fact]
    //    public void GetByIdNonExistingItemShouldReturnNull()
    //    {
    //        // Arrange
    //        int id = -1;
    //        MediaCollection result;

    //        // Act
    //        result = _mediaCollectionRepository.GetById(id);

    //        // Assert
    //        Assert.Null(result);
    //    }
    //}
}
