using System.Collections.Generic;
using UPictures.Core;

namespace UPictures.Application
{
    public interface IPictureService
    {
        Picture GetById(int id);

        Picture AddTag(int id, string tag);

        Picture RemoveTag(int pictureid, Tag tag);

        IEnumerable<Picture> Search(string query);
    }
}