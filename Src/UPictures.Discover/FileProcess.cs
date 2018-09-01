using System;
using UPictures.Core;

namespace UPictures.Discover
{
    public class FileProcess
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public string Path { get; set; }

        public DateTime DateTaken { get; set; }

        public string CameraMaker { get; set; }

        public string CameraModel { get; set; }

        public double FileSize { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }
    }
}