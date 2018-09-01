using System.Collections.Generic;
using UPictures.Core;

namespace UPictures.Application
{
    public interface IAlbumService
    {
        Album GetById(int id);

        Album GetByName(string name);

        IEnumerable<Album> Find(string name);

        void SaveAlbum(Album album);

        IEnumerable<Album> GetLatest(int top);
    }
}