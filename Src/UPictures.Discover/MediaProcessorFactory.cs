using UPictures.Core;

namespace UPictures.Discover
{
    public class MediaProcessorFactory
    {
        private readonly string _irfanViewBinPath;
        private readonly string _thumbnailsFolderPath;
        private readonly string _searchFolderPath;
        private readonly string _masterFolderPath;
        private readonly string _viewFolderPath;
        private PictureFileProcessor _pictureFileProcessor;

        public MediaProcessorFactory(string irfanViewBinPath, string thumbnailsFolderPath, string searchFolderPath, string masterFolderPath, string viewFolderPath)
        {
            _irfanViewBinPath = irfanViewBinPath;
            _thumbnailsFolderPath = thumbnailsFolderPath;
            _searchFolderPath = searchFolderPath;
            _masterFolderPath = masterFolderPath;
            _viewFolderPath = viewFolderPath;
        }

        private PictureFileProcessor PictureProcessor
        {
            get
            {
                if (_pictureFileProcessor == null)
                {
                    _pictureFileProcessor = new PictureFileProcessor(_irfanViewBinPath, _thumbnailsFolderPath, _searchFolderPath, _masterFolderPath, _viewFolderPath);
                }

                return _pictureFileProcessor;
            }
        }

        public MediaFileProcessor GetFileProcessor()
        {
            return PictureProcessor;
        }
    }
}