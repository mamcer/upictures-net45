using System;
using System.Globalization;
using System.IO;
using System.Linq;
using ExifLib;

namespace UPictures.Discover
{
    public class FileProcessor
    {
        public string[] PictureFileExtensions { get; private set; }

        public FileProcessor(string[] pictureFileExtensions)
        {
            PictureFileExtensions = pictureFileExtensions;
        }

        public FileProcess Process(string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            var fileExtension = Path.GetExtension(filePath).ToLower(CultureInfo.InvariantCulture);

            if (PictureFileExtensions.Contains(fileExtension))
            {
                DateTime datePictureTaken;
                string cameraMaker, cameraModel;
                uint height, width;
                double fileSize;

                using (ExifReader reader = new ExifReader(filePath))
                {
                    reader.GetTagValue(ExifTags.DateTimeDigitized, out datePictureTaken);
                    reader.GetTagValue(ExifTags.Make, out cameraMaker);
                    reader.GetTagValue(ExifTags.Model, out cameraModel);
                    reader.GetTagValue(ExifTags.PixelXDimension, out width);
                    reader.GetTagValue(ExifTags.PixelYDimension, out height);
                }

                using (var file = File.OpenRead(filePath))
                {
                    fileSize = file.Length;
                }

                var mediaFile = new FileProcess
                {
                    Name = fileName,
                    Extension = fileExtension,
                    Path = filePath,
                    DateTaken = datePictureTaken,
                    CameraMaker = cameraMaker,
                    CameraModel = cameraModel,
                    FileSize = fileSize,
                    Height = Convert.ToInt32(height),
                    Width = Convert.ToInt32(width)
                };

                return mediaFile;
            }

            return null;
        }
    }
}