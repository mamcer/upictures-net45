using CrossCutting.Core.Logging;
using System;
using System.Collections.Generic;
using UPictures.Core;
using UPictures.Data;

namespace UPictures.Application
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogService _logService;

        public AlbumService(IUnitOfWork unitOfWork, IAlbumRepository albumRepository, ILogService logService)
        {
            _unitOfWork = unitOfWork;
            _logService = logService;
            _albumRepository = albumRepository;
        }

        public Album GetById(int id)
        {
            try
            {
                return _albumRepository.GetById(id);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public Album GetByName(string name)
        {
            try
            {
                return _albumRepository.GetByName(name);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public IEnumerable<Album> Find(string name)
        {
            try
            {
                return _albumRepository.Find(name);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public void SaveAlbum(Album album)
        {
            try
            {
                _albumRepository.Create(album);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private void LogError(Exception ex)
        {
            if (ex != null)
            {
                _logService.Error(ex.Message);
            }

            if (ex.InnerException != null)
            {
                _logService.Error(ex.InnerException.Message);
            }
        }

        public IEnumerable<Album> GetLatest(int top)
        {
            try
            {
                return _albumRepository.GetLatest(top);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }
    }
}