using System.Collections.Generic;
using System.Data.Entity;
using UPictures.Core;
using System.Linq;

namespace UPictures.Data
{
    public class AlbumRepository : EntityFrameworkRepository<Album, int>, IAlbumRepository
    {
        public AlbumRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Album> Find(string name)
        {
            return _dbContext.Set<Album>()
                .Where(a => a.Name.ToLower()
                .StartsWith(name.ToLower()))
                .ToList();
        }

        public override Album GetById(int id)
        {
            var album = _dbContext.Set<Album>()
                .Where(a => a.Id == id)
                .Include(a => a.Pictures)
                .FirstOrDefault();
            album.Pictures = album.Pictures.OrderBy(p => p.Id).ToList();
            return album;
        }

        public Album GetByName(string name)
        {
            var album = _dbContext.Set<Album>()
                .Where(a => a.Name == name)
                .Include(a => a.Pictures)
                .FirstOrDefault();
            album.Pictures = album.Pictures.OrderBy(p => p.Id).ToList();
            return album;
        }

        public IEnumerable<Album> GetLatest(int top)
        {
            return _dbContext.Set<Album>()
                .OrderByDescending(a => a.Id)
                .Take(top)
                .Include(a => a.Pictures)
                .ToList();
        }
    }
}