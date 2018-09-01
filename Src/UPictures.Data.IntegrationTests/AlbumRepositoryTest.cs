using System.Linq;
using CrossCutting.MainModule.IOC;
using UPictures.Core;
using Xunit;
using System.Collections.Generic;

namespace UPictures.Data.IntegrationTests
{
    [Collection("DatabaseCollection")]
    public class AlbumRepositoryTest
    {
        //private IAlbumRepository _albumRepository;

        //public AlbumRepositoryTest()
        //{
        //    var container = new IocUnityContainer();
        //    _albumRepository = container.Resolve<IAlbumRepository>();
        //}

        //[Fact]
        //public void FindShouldCompareByName()
        //{
        //    // Arrange
        //    List<Album> result;
        //    var query = "2010-07-10_AnoThEr";

        //    // Act
        //    result = _albumRepository.Find(query).ToList();

        //    // Assert
        //    Assert.Equal(1, result.Count);
        //}

        //[Fact]
        //public void FindShouldMoreThanOneMatchingElement()
        //{
        //    // Arrange
        //    List<Album> result;
        //    var query = "2010";

        //    // Act
        //    result = _albumRepository.Find(query).ToList();

        //    // Assert
        //    Assert.Equal(2, result.Count);
        //}

        //[Fact]
        //public void FindShouldEmptyOnNoMatch()
        //{
        //    // Arrange
        //    List<Album> result;
        //    var query = "hello album";

        //    // Act
        //    result = _albumRepository.Find(query).ToList();

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(0, result.Count);
        //}

        //[Fact]
        //public void GetByIdShouldReturnExistingItem()
        //{
        //    // Arrange
        //    var name = "2012-10-24_yani juli mario";
        //    var album = _albumRepository.Find(name).FirstOrDefault();
        //    Album result;

        //    // Act
        //    result = _albumRepository.GetById(album.Id);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(album.Id, result.Id);
        //    Assert.Equal(name, result.Name);
        //    Assert.NotNull(result.Pictures);
        //    Assert.Equal(3, result.Pictures.Count);
        //}

        //[Fact]
        //public void GetByIdNonExistingItemShouldReturnNull()
        //{
        //    // Arrange
        //    var id = -1;
        //    Album result;

        //    // Act
        //    result = _albumRepository.GetById(id);

        //    // Assert
        //    Assert.Null(result);
        //}
    }
}