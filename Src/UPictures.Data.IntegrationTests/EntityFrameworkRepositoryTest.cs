using System;
using UPictures.Core;
using Xunit;

namespace UPictures.Data.IntegrationTests
{
    public class EntityFrameworkRepositoryTest
    {
        //[Fact]
        //public void ConstructorWithNullContextShouldThrowException()
        //{
        //    // Arrange
        //    EntityFrameworkRepository<Album, int> entityFrameworkRepository;

        //    // Act & Assert
        //    Assert.Throws<ArgumentNullException>(() => entityFrameworkRepository =  new EntityFrameworkRepository<Album, int>(null));
        //}

        //[Fact]
        //public void CreateShouldAddEntity()
        //{
        //    // This case also test GetById and Delete
        //    // Arrange
        //    var dbcontext = new UPicturesEntities();
        //    var unitOfWork = new EntityFrameworkUnitOfWork(dbcontext);
        //    EntityFrameworkRepository<MediaCollection, int> entityFrameworkRepository = new EntityFrameworkRepository<MediaCollection, int>(dbcontext);
        //    var name = "My Collection";
        //    var mediaCollection = new MediaCollection(name);
        //    MediaCollection result;            

        //    // Act 
        //    entityFrameworkRepository.Create(mediaCollection);
        //    unitOfWork.SaveChanges();
        //    result = entityFrameworkRepository.GetById(mediaCollection.Id);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(name, result.Name);
        //    entityFrameworkRepository.Delete(mediaCollection);
        //    unitOfWork.SaveChanges();
        //}

        //[Fact]
        //public void CreateWithNullEntityShouldThrowException()
        //{
        //    // Arrange
        //    var dbcontext = new UPicturesEntities();
        //    EntityFrameworkRepository<MediaCollection, int> entityFrameworkRepository = new EntityFrameworkRepository<MediaCollection, int>(dbcontext);
        //    MediaCollection mediaCollection = null;

        //    // Act & Assert
        //    Assert.Throws<ArgumentNullException>(() => entityFrameworkRepository.Create(mediaCollection));
        //}

        //[Fact]
        //public void DeleteWithNullEntityShouldThrowException()
        //{
        //    // Arrange
        //    var dbcontext = new UPicturesEntities();
        //    EntityFrameworkRepository<MediaCollection, int> entityFrameworkRepository = new EntityFrameworkRepository<MediaCollection, int>(dbcontext);
        //    MediaCollection mediaCollection = null;

        //    // Act & Assert
        //    Assert.Throws<ArgumentNullException>(() => entityFrameworkRepository.Delete(mediaCollection));
        //}

        //[Fact]
        //public void UpdateWithNullEntityShouldThrowException()
        //{
        //    // Arrange
        //    var dbcontext = new UPicturesEntities();
        //    EntityFrameworkRepository<MediaCollection, int> entityFrameworkRepository = new EntityFrameworkRepository<MediaCollection, int>(dbcontext);
        //    MediaCollection mediaCollection = null;

        //    // Act & Assert
        //    Assert.Throws<ArgumentNullException>(() => entityFrameworkRepository.Update(mediaCollection));
        //}

        //[Fact]
        //public void UpdateShouldUpdateEntity()
        //{
        //    // Arrange
        //    var dbcontext = new UPicturesEntities();
        //    var unitOfWork = new EntityFrameworkUnitOfWork(dbcontext);
        //    EntityFrameworkRepository<MediaCollection, int> entityFrameworkRepository = new EntityFrameworkRepository<MediaCollection, int>(dbcontext);
        //    var name = "My Collection";
        //    var updatedName = "My Updated Collection";
        //    var mediaCollection = new MediaCollection(name);
        //    MediaCollection result;

        //    // Act 
        //    entityFrameworkRepository.Create(mediaCollection);
        //    unitOfWork.SaveChanges();
        //    mediaCollection.Name = updatedName;
        //    entityFrameworkRepository.Update(mediaCollection);
        //    unitOfWork.SaveChanges();
        //    result = entityFrameworkRepository.GetById(mediaCollection.Id);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(updatedName, result.Name);
        //    entityFrameworkRepository.Delete(mediaCollection);
        //    unitOfWork.SaveChanges();
        //}
    }
}