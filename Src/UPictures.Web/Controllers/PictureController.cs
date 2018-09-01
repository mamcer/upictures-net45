using System.Linq;
using System.Web.Mvc;
using UPictures.Application;
using UPictures.Core;
using UPictures.Web.Models;

namespace UPictures.Web.Controllers
{
    public class PictureController : Controller
    {
        private readonly IPictureService _pictureService;
        private readonly IAlbumService _albumService;

        public PictureController(IAlbumService albumService, IPictureService pictureService)
        {
            _pictureService = pictureService;
            _albumService = albumService;
        }

        public ActionResult View(int id)
        {
            var picture = _pictureService.GetById(id);
            var download = (Download)Session["download"];
            var isSelected = false;
            if (download != null)
            {
                if (download.Pictures.Any(p => p.Id == id))
                {
                    isSelected = true;
                }
            }

            var pictureViewModel = new PictureViewModel
            {
                Id = picture.Id,
                FileName = picture.FileName,
                AlbumId = picture.Album.Id,
                AlbumName = picture.Album.Name,
                Tags = picture.Tags.Select(t => new TagViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList(),
                IsSelected = isSelected
            };

            return View(pictureViewModel);
        }

        [HttpPost]
        public ActionResult AddTag(PictureViewModel pictureViewModel)
        {
            if(pictureViewModel.NewTag == null)
            {
                return base.View(pictureViewModel);
            }

            var picture = _pictureService.AddTag(pictureViewModel.Id, pictureViewModel.NewTag);
            var newPictureViewModel = new PictureViewModel
            {
                Id = picture.Id,
                FileName = picture.FileName,
                AlbumId = pictureViewModel.AlbumId,
                AlbumName = pictureViewModel.AlbumName,
                NewTag = string.Empty,
                Tags = picture.Tags.Select(t => new TagViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList()
            };

            return View("View", newPictureViewModel);
        }

        public ActionResult RemoveTag(int pictureId, Tag tag)
        {
            var picture = _pictureService.RemoveTag(pictureId, tag);
            var newPictureViewModel = new PictureViewModel
            {
                Id = picture.Id,
                FileName = picture.FileName,
                AlbumId = picture.Album.Id,
                AlbumName = picture.Album.Name,
                NewTag = string.Empty,
                Tags = picture.Tags.Select(t => new TagViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList()
            };

            return View("View", newPictureViewModel);
        }


        public ActionResult Next(int id)
        {
            var picture = _pictureService.GetById(id);
            var album = _albumService.GetById(picture.Album.Id);
            var pictures = album.Pictures.ToList();
            var index = pictures.FindIndex(p => p.Id == id);
            var nextPictureId = pictures[index].Id;

            if (pictures.Count > index + 1)
            {
                nextPictureId = pictures[index + 1].Id;
            }

            return RedirectToAction("View", new { id = nextPictureId });
        }

        public ActionResult Previous(int id)
        {
            var picture = _pictureService.GetById(id);
            var album = _albumService.GetById(picture.Album.Id);
            var pictures = album.Pictures.ToList();
            var index = pictures.FindIndex(p => p.Id == id);
            var previousPictureId = pictures[index].Id;

            if (index > 0)
            {
                previousPictureId = pictures[index - 1].Id;
            }

            return RedirectToAction("View", new { id = previousPictureId });
        }
    }
}