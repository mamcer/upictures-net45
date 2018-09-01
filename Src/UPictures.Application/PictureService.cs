using CrossCutting.Core.Logging;
using UPictures.Core;
using UPictures.Data;
using System;
using System.Collections.Generic;

namespace UPictures.Application
{
    public class PictureService : IPictureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogService _logService;
        private readonly IPictureRepository _mediaFileRepository;

        public PictureService(IUnitOfWork unitOfWork, IPictureRepository mediaFileRepository, ILogService logService)
        {
            _unitOfWork = unitOfWork;
            _logService = logService;
            _mediaFileRepository = mediaFileRepository;
        }

        public Picture GetById(int id)
        {
            try
            {
                return _mediaFileRepository.GetById(id);
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message);
                return null;
            }
        }

        public Picture AddTag(int id, string tag)
        {
            try
            {
                var mediaFile = _mediaFileRepository.GetById(id);
                if (mediaFile == null)
                {
                    return null;
                }

                mediaFile.AddTag(tag);
                _mediaFileRepository.Update(mediaFile);
                _unitOfWork.SaveChanges();

                return mediaFile;
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message);
                return null;
            }
        }

        public Picture RemoveTag(int pictureId, Tag tag)
        {
            try
            {
                var mediaFile = _mediaFileRepository.GetById(pictureId);
                if (mediaFile == null)
                {
                    return null;
                }

                mediaFile.RemoveTag(tag);
                _mediaFileRepository.Update(mediaFile);
                _unitOfWork.SaveChanges();

                return mediaFile;
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<Picture> Search(string query)
        {
            return _mediaFileRepository.Find(query);
        }
    }
}