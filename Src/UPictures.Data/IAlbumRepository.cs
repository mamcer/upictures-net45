using System.Collections.Generic;
using UPictures.Core;

namespace UPictures.Data
{
    public interface IAlbumRepository : IRepository<Album, int>
    {
        IEnumerable<Album> Find(string name);

        Album GetByName(string name);

        IEnumerable<Album> GetLatest(int top);
    }
}