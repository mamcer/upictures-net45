using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPictures.Core
{
    public enum DownloadStatus
    {
        New = 0,
        Pending = 2,
        InProgress = 4,
        Done = 8,
        Error = 16
    }

    [Table("Download")]
    public class Download
    {
        public Download()
        {
            Status = DownloadStatus.New;
            CreationDate = DateTime.Now;
            Pictures = new List<Picture>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string FileName { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public DownloadStatus Status { get; set; }
    }
}