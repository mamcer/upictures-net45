using System;
using System.Collections.Generic;

namespace UPictures.Web.Models
{
    public class DownloadViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<PictureViewModel> Pictures { get; set; }

        public string Status { get; set; }
    }
}