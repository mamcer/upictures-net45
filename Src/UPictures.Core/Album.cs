using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace UPictures.Core
{
    [Table("Album")]
    public class Album
    {
        private Album() : this("Default Name")
        {
        }

        public Album(string name)
        {
            Pictures = new List<Picture>();
            Name = name;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public void AddPicture(Picture picture)
        {
            if (picture == null)
            {
                throw new ArgumentNullException(nameof(picture));
            }

            if (!Pictures.Contains(picture))
            {
                picture.Album = this;
                Pictures.Add(picture);
            }
        }

        public override bool Equals(object obj)
        {
            Album album = obj as Album;

            if (album != null)
            {
                return Name.ToLower(CultureInfo.InvariantCulture).Equals(album.Name.ToLower(CultureInfo.InvariantCulture));
            }

            return base.Equals(obj);
        }
    }
}