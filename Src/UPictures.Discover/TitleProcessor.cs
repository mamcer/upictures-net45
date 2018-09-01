using System.Text.RegularExpressions;

namespace UPictures.Discover
{
    public class TitleProcessor
    {
        public static TitleResult Process(string title)
        {
            var titleResult = new TitleResult();

            Regex regex = new Regex("(\\d+)-.+");
            var match = regex.Match(title);

            if (match.Success)
            {
                titleResult.Year = match.Groups[1].Value;
                titleResult.Title = title;
                return titleResult;
            }

            return null;
        }
    }
}