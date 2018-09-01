namespace UPictures.Discover
{
    public interface IFolderValidator
    {
        bool Exists(string path);
    }
}