using System.Collections.Generic;
using UPictures.Core;

namespace UPictures.Data
{
    public interface IDownloadRepository : IRepository<Download, int>
    {
        IEnumerable<Download> GetLatestDownloads(int count);
    }
}