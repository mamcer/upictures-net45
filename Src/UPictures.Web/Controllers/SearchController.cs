using System.Linq;
using System.Web.Mvc;
using UPictures.Application;
using UPictures.Web.Models;

namespace UPictures.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IPictureService _pictureService;

        public SearchController(IAlbumService albumService, IPictureService pictureService)
        {
            _albumService = albumService;
            _pictureService = pictureService;
        }

        public ActionResult Search(SearchViewModel searchViewModel)
        {
            if (!string.IsNullOrEmpty(searchViewModel.SearchQuery))
            {
                var albumResults = _albumService.Find(searchViewModel.SearchQuery);
                searchViewModel.AlbumSearchResults = albumResults.Select(r => new AlbumSearchResult
                {
                    Id = r.Id,
                    Name = r.Name,
                    PicturesCount = r.Pictures.Count
                }).ToList();

                var pictureResults = _pictureService.Search(searchViewModel.SearchQuery);
                searchViewModel.PictureSearchResults = pictureResults.Select(r => new PictureSearchResult
                {
                    Id = r.Id,
                    FileName = r.FileName,
                    AlbumId = r.Album.Id,
                    AlbumName = r.Album.Name
                }).ToList();
            }

            return View(searchViewModel);
        }
    }
}