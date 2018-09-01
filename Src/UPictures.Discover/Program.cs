using CrossCutting.Core.Logging;
using CrossCutting.MainModule.IOC;
using System;
using System.IO;
using System.Linq;
using System.Text;
using UPictures.Application;
using UPictures.Core;

namespace UPictures.Discover
{
    class Program
    {
        private static ILogService _logService;

        static void Main(string[] args)
        {
            var container = new IocUnityContainer();
            _logService = container.Resolve<ILogService>();
            DateTime scanTime = DateTime.Now;
            ConsoleLog("scan started");

            try
            {
                // Startup check
                var mediaConfigurationManager = new MediaConfigurationManager(args, new FolderValidator());
                ConsoleLog("startup checking...");
                if (!mediaConfigurationManager.StartupCheck())
                {
                    ConsoleLog("startup check failed, please see log for more details");
                    ConsoleLog("usage: UPictures.Discover.exe [MediaFolderPath]");
                    _logService.Error(mediaConfigurationManager.Errors);
                    return;
                }
                ConsoleLog("all ok!");

                var mediaProcessorFactory = new MediaProcessorFactory(mediaConfigurationManager.IrfanViewBinPath, mediaConfigurationManager.ThumbnailFolderPath, mediaConfigurationManager.SearchFolderPath, mediaConfigurationManager.MasterFolderPath, mediaConfigurationManager.ViewFolderPath);
                var fileProcessor = new FileProcessor(mediaConfigurationManager.PictureFileExtensions);
                var totalFiles = 0;
                var errorCount = 0;
                var folderPaths = Directory.GetDirectories(mediaConfigurationManager.RootFolder);
                var folderIndex = 0;
                var folderCount = folderPaths.Length;
                ConsoleLog($"{folderCount} subfolders discovered at {mediaConfigurationManager.RootFolder}");
                foreach (var folderPath in folderPaths)
                {
                    folderIndex += 1;
                    var folderName = Path.GetFileName(folderPath);
                    ConsoleLog($"start processing of '{folderName}' [{folderIndex} of {folderCount}]");
                    var titleResult = TitleProcessor.Process(folderName);
                    if (titleResult != null)
                    {
                        var albumService = container.Resolve<IAlbumService>();
                        var existingAlbum = albumService.GetByName(titleResult.Title);
                        if (existingAlbum != null)
                        {
                            ConsoleLog($"album '{titleResult.Title}' already exists, skipping folder");
                            continue;
                        }

                        ConsoleLog($"creating album '{titleResult.Title}'");
                        var album = new Album(titleResult.Title);
                        var files = Directory.GetFiles(folderPath);
                        var fileIndex = 0;
                        var fileCount = files.Count();

                        foreach (var filePath in files)
                        {
                            fileIndex += 1;
                            var fileProcess = fileProcessor.Process(filePath);

                            if (fileProcess == null)
                            {
                                ConsoleLog($"ERROR: Unknown file type for: {filePath}");
                                errorCount += 1;
                                continue;
                            }

                            ConsoleLog($"[{folderIndex}/{folderCount}]:[{fileIndex}/{fileCount:00}] processing '{fileProcess.Name}{fileProcess.Extension}' of type '{fileProcess.Extension}'");
                            var mediaProcessor = mediaProcessorFactory.GetFileProcessor();

                            ConsoleLog($"[{folderIndex}/{folderCount}]:[{fileIndex}/{fileCount}] creating thumbnails for '{fileProcess.Name}{fileProcess.Extension}'");
                            mediaProcessor.CreateThumbnail(fileProcess);

                            ConsoleLog($"[{folderIndex}/{folderCount}]:[{fileIndex}/{fileCount}] creating search for '{fileProcess.Name}{fileProcess.Extension}'");
                            mediaProcessor.CreateSearch(fileProcess);

                            ConsoleLog($"[{folderIndex}/{folderCount}]:[{fileIndex}/{fileCount}] creating view for '{fileProcess.Name}{fileProcess.Extension}'");
                            mediaProcessor.CreateView(fileProcess);

                            ConsoleLog($"[{folderIndex}/{folderCount}]:[{fileIndex}/{fileCount}] creating master for '{fileProcess.Name}{fileProcess.Extension}'");
                            mediaProcessor.CreateMaster(fileProcess);

                            var mediaFile = new Picture(fileProcess.Name, fileProcess.FileSize, fileProcess.Width, fileProcess.Height, album.Name)
                            {
                                DateTaken = fileProcess.DateTaken,
                                CameraModel = fileProcess.CameraModel,
                                CameraMaker = fileProcess.CameraMaker
                            };

                            album.AddPicture(mediaFile);
                            totalFiles += 1;
                        }

                        ConsoleLog($"saving album '{album.Name}'");
                        albumService.SaveAlbum(album);
                    }
                    else
                    {
                        ConsoleLog($"ERROR: failed to process folder title for: {folderPath}");
                        errorCount += 1;
                    }
                }

                ConsoleLog("scan finished");
                ConsoleLog($"total time: {DateTime.Now.Subtract(scanTime).ToString("hh\\:mm\\:ss")}");
                ConsoleLog($"total folders scanned: {folderCount}");
                ConsoleLog($"total files scanned: {totalFiles}");
                ConsoleLog($"total errors: {errorCount} (see application file log for more details)");
            }
            catch (Exception ex)
            {
                ConsoleLog("ERROR: an unhandled error has occurred. Please see log for more details.");

                var errorMessage = new StringBuilder();
                errorMessage.AppendLine(ex.Message);
                errorMessage.AppendLine(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    errorMessage.AppendLine(ex.InnerException.Message);
                    errorMessage.AppendLine(ex.InnerException.StackTrace);
                }

                _logService.Error(errorMessage.ToString());
            }
        }

        private static void ConsoleLog(string msg)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy.dd.MM-HH:mm:ss") + " - " + msg);
            _logService.Info(msg);
        }
    }
}