namespace UPictures.Discover
{
    public interface IConfigurationManager
    {
        bool StartupCheck();

        string RootFolder { get; }

        string Errors { get; }
    }
}