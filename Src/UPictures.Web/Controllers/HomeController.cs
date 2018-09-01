using System;
using System.Linq;
using System.Web.Mvc;
using UPictures.Application;
using UPictures.Core;
using UPictures.Web.Models;

namespace UPictures.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IPictureService _pictureService;
        private readonly IDownloadService _downloadService;

        public HomeController(IAlbumService albumService, IPictureService pictureService, IDownloadService downloadService)
        {
            _albumService = albumService;
            _pictureService = pictureService;
            _downloadService = downloadService;
        }

        public ActionResult Index()
        {
            var albums = _albumService.GetLatest(6);
            var homeViewModel = new HomeViewModel
            {
                Albums = albums.Select(a => new AlbumViewModel
                {
                    Name = a.Name,
                    Id = a.Id,
                    Pictures = a.Pictures.Select(
                        p => new PictureViewModel
                        {
                            FileName = p.FileName
                        }).ToList()
                }).ToList(),
                SearchQuery = string.Empty
            };

            return View(homeViewModel);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel homeViewModel)
        {
            return RedirectToAction("Search", "Search", new SearchViewModel { SearchQuery = homeViewModel.SearchQuery });
        }

        public ActionResult Download()
        {
            var download = (Download)Session["download"];

            var lastDownloads = _downloadService.GetLatestDownloads().ToList();
            if (download != null)
            {
                lastDownloads.Add(download);
            }
            else
            {
                download = new Download();
            }

            return View(lastDownloads.Select(d => new DownloadViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Pictures = d.Pictures.Select(p => new PictureViewModel
                {
                    Id = p.Id,
                    FileName = p.FileName,
                    AlbumId = p.Album.Id,
                    AlbumName = p.Album.Name
                }).ToList(),
                Status = d.Status.ToString(),
                CreationDate = d.CreationDate
            }).ToList());
        }

        public ActionResult Select(int id)
        {
            var download = (Download)Session["download"];

            if (download == null)
            {
                download = new Download();
            }

            var picture = _pictureService.GetById(id);
            download.Pictures.Add(picture);

            Session["download"] = download;

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Unselect(int id)
        {
            var download = (Download)Session["download"];

            if (download != null)
            {
                var picture = download.Pictures.FirstOrDefault(p => p.Id == id);
                if (picture != null)
                {
                    download.Pictures.Remove(picture);
                    Session["download"] = download;
                }
            }

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult CloseDownload()
        {
            var download = (Download)Session["download"];

            if (download != null)
            {
                return View(download.Pictures.Select(p => new PictureViewModel
                {
                    Id = p.Id,
                    FileName = p.FileName,
                    AlbumName = p.Album.Name
                }));
            }

            return RedirectToAction("Download");
        }

        public ActionResult DownloadDownload()
        {
            var download = (Download) Session["download"];

            if (download != null)
            {
                return View(new DownloadViewModel
                {
                    Name = $"{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}_{download.Pictures.FirstOrDefault().Album.Name}"
                });
            }

            return RedirectToAction("Download");
        }

        [HttpPost]
        public ActionResult DownloadDownload(DownloadViewModel downloadViewModel)
        {
            var download = (Download)Session["download"];

            if (download != null)
            {
                download.Name = downloadViewModel.Name;
                download.FileName = downloadViewModel.Name + ".zip";
                download.Status = DownloadStatus.Pending;
                _downloadService.SaveDownload(download);
            }

            return RedirectToAction("Download");
        }
    }
}