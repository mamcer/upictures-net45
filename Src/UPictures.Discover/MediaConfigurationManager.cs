using System.Configuration;
using System.Text;

namespace UPictures.Discover
{
    public class MediaConfigurationManager : IConfigurationManager
    {
        private readonly string[] _args;
        private readonly StringBuilder _errors;
        private readonly IFolderValidator _folderValidator;

        public MediaConfigurationManager(string[] args, IFolderValidator folderValidator)
        {
            _args = args;
            _folderValidator = folderValidator;
            _errors = new StringBuilder();
        }

        public string Errors => _errors.ToString();

        public string RootFolder
        {
            get;
            private set;
        }

        public string[] PictureFileExtensions { get; private set; }

        public string IrfanViewBinPath { get; private set; }

        public string ThumbnailFolderPath { get; private set; }

        public string SearchFolderPath { get; private set; }

        public string MasterFolderPath { get; private set; }

        public string ViewFolderPath { get; private set; }

        public bool StartupCheck()
        {
            bool allOk = true;
            _errors.Clear();

            // Argument list cannot be empty
            if (_args == null || _args.Length == 0)
            {
                _errors.AppendLine("Argument list cannot be empty");
                allOk = false;
            }
            else
            {
                RootFolder = _args[0];

                if (!_folderValidator.Exists(RootFolder))
                {
                    allOk = false;
                    _errors.AppendLine($"Folder '{RootFolder}' does not exist or don't have access");
                }
            }

            // Config Picture File Extensions
            if (ConfigurationManager.AppSettings["PictureFileExtensions"] == null)
            {
                _errors.AppendLine("Error:: The required PictureFileExtensions configuration key is missing");
                allOk = false;
            }
            else
            {
                PictureFileExtensions = ConfigurationManager.AppSettings["PictureFileExtensions"].Split(',');
            }

            // Config IrfanViewBinPath
            if (ConfigurationManager.AppSettings["IrfanViewBinPath"] == null)
            {
                _errors.AppendLine("Error:: The required IrfanViewBinPath configuration key is missing");
                allOk = false;
            }
            else
            {
                IrfanViewBinPath = ConfigurationManager.AppSettings["IrfanViewBinPath"];
            }

            // Config ThumbnailFolderPath
            if (ConfigurationManager.AppSettings["ThumbnailFolderPath"] == null)
            {
                _errors.AppendLine("Error:: The required ThumbnailFolderPath configuration key is missing");
                allOk = false;
            }
            else
            {
                ThumbnailFolderPath = ConfigurationManager.AppSettings["ThumbnailFolderPath"];
            }

            // Config SearchFolderPath
            if (ConfigurationManager.AppSettings["SearchFolderPath"] == null)
            {
                _errors.AppendLine("Error:: The required SearchFolderPath configuration key is missing");
                allOk = false;
            }
            else
            {
                SearchFolderPath = ConfigurationManager.AppSettings["SearchFolderPath"];
            }

            // Config MasterFolderPath
            if (ConfigurationManager.AppSettings["MasterFolderPath"] == null)
            {
                _errors.AppendLine("Error:: The required MasterFolderPath configuration key is missing");
                allOk = false;
            }
            else
            {
                MasterFolderPath = ConfigurationManager.AppSettings["MasterFolderPath"];
            }

            // Config ViewFolderPath
            if (ConfigurationManager.AppSettings["ViewFolderPath"] == null)
            {
                _errors.AppendLine("Error:: The required ViewFolderPath configuration key is missing");
                allOk = false;
            }
            else
            {
                ViewFolderPath = ConfigurationManager.AppSettings["ViewFolderPath"];
            }

            return allOk;
        }
    }
}