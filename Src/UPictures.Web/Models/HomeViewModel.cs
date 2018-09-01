using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UPictures.Web.Models
{
    public class HomeViewModel
    {
        [Display(Name = "Search")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        [MinLength(3)]
        public string SearchQuery { get; set; }

        public List<AlbumViewModel> Albums { get; set; }
    }
}