using System.Collections.Generic;
using UPictures.Core;

namespace UPictures.Application
{
    public interface IDownloadService
    {
        IEnumerable<Download> GetLatestDownloads();

        void SaveDownload(Download download);
    }
}