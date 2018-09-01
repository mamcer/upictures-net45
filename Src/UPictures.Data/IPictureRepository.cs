using System.Collections.Generic;
using UPictures.Core;

namespace UPictures.Data
{
    public interface IPictureRepository : IRepository<Picture, int>
    {
        IEnumerable<Picture> Find(string query);
    }
}