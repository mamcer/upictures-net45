using System.Diagnostics;
using System.IO;

namespace UPictures.Discover
{
    public abstract class MediaFileProcessor
    {
        public Process CreateProcess(string fileName, string parameters)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = parameters,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };

            return process;
        }

        public void CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public abstract void CreateThumbnail(FileProcess fileProcess);

        public abstract void CreateSearch(FileProcess fileProcess);

        public abstract void CreateView(FileProcess fileProcess);

        public abstract void CreateMaster(FileProcess fileProcess);
    }
}