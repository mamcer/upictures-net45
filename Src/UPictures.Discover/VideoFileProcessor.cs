using System.Diagnostics;
using System.IO;
using System.Threading;

namespace UPictures.Discover
{
    public class VideoFileProcessor : MediaFileProcessor
    {
        private readonly string _ffmpegBinPath;
        private readonly string _irfanViewBinPath;
        private readonly string _thumbnailsFolderPath;
        private readonly string _searchFolderPath;
        private readonly string _masterFolderPath;
        private readonly string _viewFolderPath;

        public VideoFileProcessor(string ffmpegBinPath, string irfanViewBinPath, string thumbnailsFolderPath, string searchFolderPath, string masterFolderPath, string viewFolderPath)
        {
            _ffmpegBinPath = ffmpegBinPath;
            _irfanViewBinPath = irfanViewBinPath;
            _thumbnailsFolderPath = thumbnailsFolderPath;
            _searchFolderPath = searchFolderPath;
            _masterFolderPath = masterFolderPath;
            _viewFolderPath = viewFolderPath;
        }

        public override void CreateMaster(FileProcess fileProcess)
        {
            // create folder
            var albumName = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(fileProcess.Path));
            var masterFolderPath = Path.Combine(_masterFolderPath, albumName);
            CreateFolder(masterFolderPath);

            File.Copy(fileProcess.Path, Path.Combine(masterFolderPath, Path.GetFileName(fileProcess.Path)), true);
        }

        public override void CreateSearch(FileProcess fileProcess)
        {
            CreateThumbnail(fileProcess, _searchFolderPath, 50, 30);
        }

        public override void CreateThumbnail(FileProcess fileProcess)
        {
            CreateThumbnail(fileProcess, _thumbnailsFolderPath, 100, 70);
        }

        public override void CreateView(FileProcess fileProcess)
        {
            // create folder
            var albumName = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(fileProcess.Path));
            var viewFolderPath = Path.Combine(_viewFolderPath, albumName);
            CreateFolder(viewFolderPath);

            // create mp4 video version
            var mp4Parameters = $@"-i ""{fileProcess.Path}"" -qscale 0 ""{Path.Combine(viewFolderPath, fileProcess.Name + ".mp4")}"" -y";
            var mp4Process = CreateProcess(_ffmpegBinPath, mp4Parameters);
            StartFFmpegProcess(mp4Process);

            //// create webm video version
            //var webmParameters = $@"-i ""{fileProcess.Path}"" -qscale 0 ""{Path.Combine(viewFolderPath, fileProcess.Name + ".webm")}"" -y";
            //var webmProcess = CreateProcess(_ffmpegBinPath, webmParameters);
            //StartFFmpegProcess(webmProcess);
        }

        private void CreateThumbnail(FileProcess fileProcess, string folderPath, int width, int height)
        {
            // create folder
            var albumName = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(fileProcess.Path));
            var thumbnailFolderPath = Path.Combine(folderPath, albumName);
            CreateFolder(thumbnailFolderPath);

            // take video thumbnail
            var tempPath = Path.GetTempPath();
            var thumbnailFilePath = Path.Combine(tempPath, fileProcess.Name) + ".jpg";
            var ffmpegThumbnailParameters = $@"-i ""{fileProcess.Path}"" -ss 00:00:05 -vframes 1 ""{thumbnailFilePath}"" -y";
            var process = CreateProcess(_ffmpegBinPath, ffmpegThumbnailParameters);
            process.Start();
            process.WaitForExit();

            // create thumbail
            var irfanViewThumbnailParameters = $@"""{thumbnailFilePath}"" /resize=({width}, {height}) /aspectratio /resample /silent /convert=""{Path.Combine(thumbnailFolderPath, fileProcess.Name + ".jpg")}""";
            process = CreateProcess(_irfanViewBinPath, irfanViewThumbnailParameters);
            process.Start();
            process.WaitForExit();
        }

        private void StartFFmpegProcess(Process process)
        {
            var tryNumber = 1;
            var ffmpegProcessName = "ffmpeg";
            var maxFFmpegProcessCount = 14;
            while (Process.GetProcessesByName(ffmpegProcessName).Length > maxFFmpegProcessCount)
            {
                Thread.Sleep(3000);
                tryNumber += 1;
            }

            process.Start();
        }
    }
}