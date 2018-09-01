using System.IO;

namespace UPictures.Discover
{
    public class PictureFileProcessor : MediaFileProcessor
    {
        private readonly string _thumbnailsFolderPath;
        private readonly string _searchFolderPath;
        private readonly string _masterFolderPath;
        private readonly string _viewFolderPath;
        private readonly string _irfanViewBinPath;

        public PictureFileProcessor(string irfanViewBinPath, string thumbnailsFolderPath, string searchFolderPath, string masterFolderPath, string viewFolderPath)
        {
            _irfanViewBinPath = irfanViewBinPath;
            _thumbnailsFolderPath = thumbnailsFolderPath;
            _searchFolderPath = searchFolderPath;
            _masterFolderPath = masterFolderPath;
            _viewFolderPath = viewFolderPath;
        }

        public override void CreateMaster(FileProcess fileProcess)
        {
            // create folder
            var albumName = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(fileProcess.Path));
            var masterFolderPath = Path.Combine(_masterFolderPath, albumName);
            CreateFolder(masterFolderPath);

            File.Copy(fileProcess.Path, Path.Combine(masterFolderPath, Path.GetFileName(fileProcess.Path)), true);
        }

        public override void CreateSearch(FileProcess fileProcess)
        {
            var width = 50;
            var height = 30;

            // create folder
            var albumName = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(fileProcess.Path));
            var searchFolderPath = Path.Combine(_searchFolderPath, albumName);
            CreateFolder(searchFolderPath);

            // create thumbail
            var irfanViewThumbnailParameters = $@"""{fileProcess.Path}"" /resize=({width}, {height}) /aspectratio /resample /convert=""{Path.Combine(searchFolderPath, fileProcess.Name)}""";
            CreateProcess(_irfanViewBinPath, irfanViewThumbnailParameters).Start();
        }

        public override void CreateThumbnail(FileProcess fileProcess)
        {
            var width = 200;
            var height = 140;

            // create folder
            var albumName = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(fileProcess.Path));
            var thumbnailsFolderPath = Path.Combine(_thumbnailsFolderPath, albumName);
            CreateFolder(thumbnailsFolderPath);

            // create thumbail
            var irfanViewThumbnailParameters = $@"""{fileProcess.Path}"" /resize=({width}, {height}) /aspectratio /resample /convert=""{Path.Combine(thumbnailsFolderPath, fileProcess.Name)}""";
            CreateProcess(_irfanViewBinPath, irfanViewThumbnailParameters).Start();
        }

        public override void CreateView(FileProcess fileProcess)
        {
            var width = 1024;
            var height = 768;

            // create folder
            var albumName = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(fileProcess.Path));
            var viewFolderPath = Path.Combine(_viewFolderPath, albumName);
            CreateFolder(viewFolderPath);

            // create thumbail
            var irfanViewThumbnailParameters = $@"""{fileProcess.Path}"" /resize=({width}, {height}) /aspectratio /resample /convert=""{Path.Combine(viewFolderPath, fileProcess.Name)}""";
            CreateProcess(_irfanViewBinPath, irfanViewThumbnailParameters).Start();
        }
    }
}