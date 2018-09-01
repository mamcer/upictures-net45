using CrossCutting.MainModule.IOC;
using System;
using CrossCutting.Core.IOC;
using UPictures.Core;

namespace UPictures.Data.IntegrationTests
{
    public class DatabaseFixture : IDisposable
    {
        //private IContainer _container;
        //private IUnitOfWork _unitOfWork;

        //public DatabaseFixture()
        //{
        //    // Initialize 
        //    _container = new IocUnityContainer();
        //    _unitOfWork = _container.Resolve<IUnitOfWork>();
        //    _mediaCollectionRepository = _container.Resolve<IMediaCollectionRepository>();

        //    // Media Collections
        //    var mediaCollection01 = new MediaCollection("2010");
        //    var mediaCollection02 = new MediaCollection("2012");

        //    // Albums
        //    var album0101 = new Album("2010-01-15_hello album");
        //    var album0102 = new Album("2010-07-10_another album");
        //    var album0201 = new Album("2012-10-24_yani juli mario");

        //    // Media Files
        //    var mediaFile010101 = new Picture("IMG_0049", ".jpg", MediaFileType.Picture);
        //    var mediaFile010102 = new Picture("IMG_0050", ".JPG", MediaFileType.Picture);
        //    var mediaFile010103 = new Picture("IMG_0051", ".jpg", MediaFileType.Picture);

        //    var mediaFile010201 = new Picture("IMG_0101", ".jpg", MediaFileType.Picture);
        //    var mediaFile010202 = new Picture("IMG_0102", ".jpg", MediaFileType.Picture);
        //    var mediaFile010203 = new Picture("IMG_0103", ".JPG", MediaFileType.Picture);
        //    var mediaFile010204 = new Picture("IMG_0104", ".jpg", MediaFileType.Picture);
        //    var mediaFile010205 = new Picture("IMG_0105", ".AVI", MediaFileType.Video);
        //    var mediaFile010206 = new Picture("IMG_0106", ".jpg", MediaFileType.Picture);
        //    var mediaFile010207 = new Picture("IMG_0107", ".jpg", MediaFileType.Picture);

        //    var mediaFile020101 = new Picture("DSCN6180", ".jpg", MediaFileType.Picture);
        //    var mediaFile020102 = new Picture("DSCN6184", ".MOV", MediaFileType.Video);
        //    var mediaFile020103 = new Picture("DSCN6186", ".jpg", MediaFileType.Picture);
        //    mediaFile020102.AddTag("tag 01");
        //    mediaFile020102.AddTag("tag 02");
        //    mediaFile020103.AddTag("tag 03");

        //    // Save all
        //    album0101.AddPicture(mediaFile010101);
        //    album0101.AddPicture(mediaFile010102);
        //    album0101.AddPicture(mediaFile010103);

        //    album0102.AddPicture(mediaFile010201);
        //    album0102.AddPicture(mediaFile010202);
        //    album0102.AddPicture(mediaFile010203);
        //    album0102.AddPicture(mediaFile010204);
        //    album0102.AddPicture(mediaFile010205);
        //    album0102.AddPicture(mediaFile010206);
        //    album0102.AddPicture(mediaFile010207);

        //    album0201.AddPicture(mediaFile020101);
        //    album0201.AddPicture(mediaFile020102);
        //    album0201.AddPicture(mediaFile020103);

        //    mediaCollection01.AddAlbum(album0101);
        //    mediaCollection01.AddAlbum(album0102);
        //    mediaCollection02.AddAlbum(album0201);

        //    _mediaCollectionRepository.Create(mediaCollection01);
        //    _mediaCollectionRepository.Create(mediaCollection02);

        //    _unitOfWork.SaveChanges();
        //}

        public void Dispose()
        {
            //var mediaCollection02 = _mediaCollectionRepository.GetByName("2012");

            //_mediaCollectionRepository.Delete(mediaCollection01);
            //_mediaCollectionRepository.Delete(mediaCollection02);

            //_unitOfWork.SaveChanges();
        }
    }
}
