namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    using System.IO;
    using System.Text.RegularExpressions;

    internal class AfsPath
    {
        private readonly string _fullName;

        public AfsPath(string fullName)
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

        public bool TryGetDriveLetterFromPath(out char driveLetter)
        {
            if (!string.IsNullOrEmpty(this._fullName))
            {
                string pattern = @"^([a-zA-Z])\:";
                Regex serverShareRegex = new Regex(pattern);

                Match match = serverShareRegex.Match(this._fullName);
                if (match.Success && match.Groups.Count > 1)
                {
                    driveLetter = match.Groups[1].Value[0];
                    return true;
                }
            }

            driveLetter = default(char);
            return false;
        }

        public bool TryGetComputerNameAndDriveFromPath(out string computerName, out char driveLetter)
        {
            if (!string.IsNullOrEmpty(this._fullName))
            {
                string pattern = @"^\\\\([^\\]+)\\([a-zA-Z])\$(?:|\\.*)$";
                Regex serverShareRegex = new Regex(pattern);

                Match match = serverShareRegex.Match(this._fullName);
                if (match.Success && match.Groups.Count > 2)
                {
                    computerName = match.Groups[1].Value;
                    driveLetter = match.Groups[2].Value[0];
                    return true;
                }
            }

            computerName = null;
            driveLetter = default(char);
            return false;
        }

        public bool TryGetComputerNameAndShareFromPath(out string computerName, out string shareName)
        {
            if (!string.IsNullOrEmpty(this._fullName))
            {
                string pattern = @"^\\\\([^\\]+)\\([^\\]+)(?:|\\.*)$";
                Regex serverShareRegex = new Regex(pattern);

                Match match = serverShareRegex.Match(this._fullName);
                if (match.Success && match.Groups.Count > 2)
                {
                    computerName = match.Groups[1].Value;
                    shareName = match.Groups[2].Value;
                    return true;
                }
            }

            computerName = null;
            shareName = null;
            return false;
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