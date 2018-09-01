using System;
using System.Collections.Generic;

namespace UPictures.Web.Models
{
    public class AlbumViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ThumbnailFileName
        {
            get
            {
                if (Pictures.Count > 0)
                {
                    var random = new Random(DateTime.Now.Millisecond);
                    var index = random.Next(0, Pictures.Count);
                    return Pictures[index].FileName;
                }

                return string.Empty;
            }
        }

        public List<PictureViewModel> Pictures { get; set; }
    }
}