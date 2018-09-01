using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UPictures.Core;

namespace UPictures.Data
{
    public class PictureRepository : EntityFrameworkRepository<Picture, int>, IPictureRepository
    {
        public PictureRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Picture> Find(string query)
        {
            return _dbContext.Set<Picture>()
                .Where(mf => mf.FileName.ToLower().StartsWith(query.ToLower()))
                .Include(mf => mf.Tags)
                .Include(mf => mf.Album)
                .ToList();
        }

        public override Picture GetById(int id)
        {
            return _dbContext.Set<Picture>()
                .Where(mf => mf.Id == id)
                .Include(mf => mf.Tags)
                .Include(mf => mf.Album)
                .FirstOrDefault();
        }
    }
}