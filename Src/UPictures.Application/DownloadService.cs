using System;
using System.Collections.Generic;
using CrossCutting.Core.Logging;
using UPictures.Core;
using UPictures.Data;

namespace UPictures.Application
{
    public class DownloadService : IDownloadService
    {
        private readonly IDownloadRepository _downloadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogService _logService;

        public DownloadService(IUnitOfWork unitOfWork, IDownloadRepository downloadRepository, ILogService logService)
        {
            _unitOfWork = unitOfWork;
            _downloadRepository = downloadRepository;
            _logService = logService;
        }

        public IEnumerable<Download> GetLatestDownloads()
        {
            try
            {
                var latestDownloads = _downloadRepository.GetLatestDownloads(10);
                return latestDownloads;
            }
            catch (Exception e)
            {
                LogError(e);
            }

            return null;
        }

        public void SaveDownload(Download download)
        {
            try
            {
                _downloadRepository.Update(download);
                _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                LogError(e);
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
    }
}