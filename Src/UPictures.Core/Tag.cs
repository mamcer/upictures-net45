using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace UPictures.Core
{
    [Table("Tag")]
    public class Tag
    {
        private Tag() : this("Default Name")
        {
        }

        public Tag(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            Tag tag = obj as Tag;

            if (tag != null)
            {
                return Name.ToLower(CultureInfo.InvariantCulture).Equals(tag.Name.ToLower(CultureInfo.InvariantCulture));
            }

            return base.Equals(obj);
        }
    }
}