using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;

namespace UPictures.Core
{
    [Table("Picture")]
    public class Picture
    {
        private Picture() : this("DefaultFileName", 1, 1, 1, @"C:\")
        {
        }

        public Picture(string fileName, double fileSize, int width, int height, string folderName)
        {
            Tags = new List<Tag>();
            FileName = fileName;
            FileSize = fileSize;
            Width = width;
            Height = height;
            FolderName = folderName;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(255)]
        public string FolderName { get; set; }

        [Required]
        public double FileSize { get; set; }

        public DateTime DateTaken { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public int Height { get; set; }

        [MaxLength(255)]
        public string CameraMaker { get; set; }

        [MaxLength(255)]
        public string CameraModel { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual Album Album { get; set;  }

        public override bool Equals(object obj)
        {
            Picture mediaMediaFile = obj as Picture;

            if (mediaMediaFile != null)
            {
                return FileName.ToLower(CultureInfo.InvariantCulture).Equals(mediaMediaFile.FileName.ToLower(CultureInfo.InvariantCulture));
            }

            return base.Equals(obj);
        }

        public void AddTag(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
            {
                throw new ArgumentNullException("tagName");
            }

            var newTag = new Tag(tagName);

            if (!Tags.Contains(newTag))
            {
                Tags.Add(newTag);
            }
        }

        public void RemoveTag(Tag tag)
        {
            var existingTag = Tags.FirstOrDefault(t => t.Equals(tag));
            if (existingTag != null)
            {
                Tags.Remove(existingTag);
            }
        }
    }
}