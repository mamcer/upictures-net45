using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UPictures.Web.Models
{
    public class SearchViewModel
    {
        public SearchViewModel()
        {
            AlbumSearchResults = new List<AlbumSearchResult>();
            PictureSearchResults = new List<PictureSearchResult>();
        }

        [Display(Name = "q")]
        public string SearchQuery { get; set; }

        public List<AlbumSearchResult> AlbumSearchResults { get; set; }

        public List<PictureSearchResult> PictureSearchResults { get; set; }

        public int TotalResults
        {
            get
            {
                return AlbumSearchResults.Count + PictureSearchResults.Count;
            }
        }
    }

    public class PictureSearchResult
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public int AlbumId { get; set; }

        public string AlbumName { get; set; }
    }

    public class AlbumSearchResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PicturesCount { get; set; }
    }
}