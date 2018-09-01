using System.IO;

namespace UPictures.Discover
{
    public class FolderValidator : IFolderValidator
    {
        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }
    }
}