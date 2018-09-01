using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UPictures.Web.Models
{
    public class PictureViewModel
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public int AlbumId { get; set; }

        public string AlbumName { get; set; }

        [Display(Name = "New Tag")]
        [MinLength(3)]
        [MaxLength(255)]
        public string NewTag { get; set; }

        public List<TagViewModel> Tags { get; set; }

        public bool IsSelected { get; set; }
    }
}