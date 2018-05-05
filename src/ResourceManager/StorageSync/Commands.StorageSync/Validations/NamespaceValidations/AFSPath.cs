using System.IO;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    internal class AFSPath
    {
        private readonly string _fullName;

        public AFSPath(string fullName)
        {
            _fullName = fullName;
        }

        public int Length()
        {
            if (IsUNCPath())
            {
                return PathWithoutNetworkComponents().Length;
            }

            return _fullName.Length;
        }

        private string PathWithoutNetworkComponents()
        {
            string pattern = @"^\\\\[^\\]+\\[^\\]+";
            Regex serverShareRegex = new Regex(pattern);

            return serverShareRegex.Replace(_fullName, "");
        }

        private bool IsUNCPath()
        {
            return _fullName.StartsWith(@"\");
        }

        internal int Depth()
        {
            string path = _fullName;
            if (IsUNCPath())
            {
                path = PathWithoutNetworkComponents();
            }
            else
            {
                path = RemoveDriveLetter();
            }

            if (path.StartsWith(@"\"))
            {
                path = path.Substring(1);
            }

            return path.Split(Path.DirectorySeparatorChar).Length;

        }

        private string RemoveDriveLetter()
        {
            return _fullName.Substring(2);
        }
    }
}