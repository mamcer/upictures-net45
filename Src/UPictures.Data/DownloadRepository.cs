using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UPictures.Core;

namespace UPictures.Data
{
    public class DownloadRepository : EntityFrameworkRepository<Download, int>, IDownloadRepository
    {
        public DownloadRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override Download GetById(int id)
        {
            return _dbContext.Set<Download>()
                .Where(mf => mf.Id == id)
                .Include(mf => mf.Pictures)
                .FirstOrDefault();
        }

        public IEnumerable<Download> GetLatestDownloads(int count)
        {
            var downloads = _dbContext
                .Set<Download>()
                .OrderByDescending(d => d.CreationDate)
                .Take(count)
                .ToList();
            return downloads;
        }
    }
}