using System.Linq;
using System.Web.Mvc;
using UPictures.Application;
using UPictures.Web.Models;

namespace UPictures.Web.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public ActionResult View(int id)
        {
            var album = _albumService.GetById(id);
            var albumViewModel = new AlbumViewModel
            {
                Id = album.Id,
                Name = album.Name,
                Pictures = album.Pictures.Select(p => new PictureViewModel
                {
                    Id = p.Id,
                    FileName = p.FileName,
                    Tags = p.Tags.Select(t => new TagViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    }).ToList()
                }).ToList()
            };

            return View(albumViewModel);
        }
    }
}