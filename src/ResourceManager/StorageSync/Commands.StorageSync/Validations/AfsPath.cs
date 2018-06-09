namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text.RegularExpressions;

    public class AfsPath
    {
        private enum PathKind
        {
            Invalid,
            SimpleDrive,
            ExtDrive,
            UncDrive,
            UncShare,
            ExtUncDrive,
            ExtUncShare
        }

        #region Fields and Properties
        private readonly string _fullName;
        private PathKind _pathKind;
        private string _computerName;
        private string _shareName;
        private char _driveLetter;
        private int? _length;
        private int? _depth;
        private string _origin;
        private string _path;

        private static Regex _pathPatterns = new Regex(
            @"^(?:" +
            @"([a-zA-Z])\:|" +                                          // simpleDrive
            @"\\\\\?\\([a-zA-Z])\:|" +                                  // extDrive
            @"\\\\([^\$\?\\]+)\\([a-zA-Z])\$|" +                        // uncServerDrive
            @"\\\\([^\$\?\\]+)\\([^\$\?\\]+\$?)|" +                     // uncServerShare
            @"\\\\\?\\[Uu][Nn][Cc]\\([^\$\?\\]+)\\([a-zA-Z])\$|" +      // extUncServerDrive
            @"\\\\\?\\[Uu][Nn][Cc]\\([^\$\?\\]+)\\([^\$\?\\]+\$?)" +    // extUncServerShare
            @")");
        /*  Examples:
            group 1     simpleDrive             c:
            group 2     extDrive                \\?\c:
            group 3,4   uncServerDrive          \\server\c$
            group 5,6   uncServerShare          \\server\share
            group 7,8   extuncServerDrive       \\?\unc\server\c$
            group 9,10  extuncServerShare       \\?\unc\server\share
         */

        public char? DriveLetter
        {
            get
            {
                if (_driveLetter != default(char))
                {
                    return _driveLetter;
                }

                return null;
            }
        }

        public string ComputerName => _computerName;

        public string ShareName => _shareName;

        public int Length
        {
            get
            {
                if (!_length.HasValue)
                {
                    switch (_pathKind)
                    {
                        case PathKind.SimpleDrive:
                        case PathKind.ExtDrive:
                        case PathKind.UncDrive:
                        case PathKind.ExtUncDrive:
                            {
                                _length = _path.Length + 2; // adding two chars for drive and colon
                                break;
                            }
                        default:
                            {
                                _length = _path.Length;
                                break;
                            }
                    }
                }

                return _length.Value;
            }
        }

        public int Depth
        {
            get
            {
                if (!_depth.HasValue)
                {
                    _depth = _path.Split(Path.DirectorySeparatorChar).Length;

                    if (_path.StartsWith(@"\"))
                    {
                        _depth--;
                    }
                }

                return _depth.Value;
            }
        }

        #endregion

        #region Constructors
        public AfsPath(string fullName)
        {
            _fullName = fullName;

            if (!TryParsePath(
                path: fullName,
                pathKind: out this._pathKind,
                origin: out this._origin,
                dataPath: out this._path,
                computerName: out this._computerName,
                shareName: out this._shareName,
                driveLetter: out this._driveLetter))
            {
                throw new ArgumentException("Invalid path", nameof(fullName));
            }            
        }
        #endregion


        #region Private methods
        private static bool TryParsePath(string path, out PathKind pathKind, out string origin, out string dataPath, out string computerName, out string shareName, out char driveLetter)
        {
            computerName = null;
            shareName = null;
            driveLetter = '\0';
            origin = null;
            dataPath = null;

            Match match = _pathPatterns.Match(path);
            if (!match.Success)
            {
                pathKind = PathKind.Invalid;
                return false;
            }

            origin = match.Value;
            dataPath = path.Substring(origin.Length);

            if (match.Groups.Count != 11)
            {
                pathKind = PathKind.Invalid;
                return false;
            }

            var groupSimpleDrive = match.Groups[1];
            var groupExtDrive = match.Groups[2];
            var groupUncDrive_Server = match.Groups[3];
            var groupUncDrive_Drive = match.Groups[4];
            var groupUncServerShare_Server = match.Groups[5];
            var groupUncServerShare_Share = match.Groups[6];
            var groupExtUncDrive_Server = match.Groups[7];
            var groupExtUncDrive_Drive = match.Groups[8];
            var groupExtUncShare_Server = match.Groups[9];
            var groupExtUncShare_Share = match.Groups[10];

            if (groupSimpleDrive.Success)
            {
                pathKind = PathKind.SimpleDrive;
                driveLetter = groupSimpleDrive.Value[0];
                return true;
            }

            if (groupExtDrive.Success)
            {
                pathKind = PathKind.ExtDrive;
                driveLetter = groupExtDrive.Value[0];
                return true;
            }

            if (groupUncDrive_Server.Success && groupUncDrive_Drive.Success)
            {
                pathKind = PathKind.UncDrive;
                computerName = groupUncDrive_Server.Value;
                driveLetter = groupUncDrive_Drive.Value[0];
                return true;
            }

            if (groupUncServerShare_Server.Success && groupUncServerShare_Share.Success)
            {
                pathKind = PathKind.UncShare;
                computerName = groupUncServerShare_Server.Value;
                shareName = groupUncServerShare_Share.Value;
                return true;
            }

            if (groupExtUncDrive_Server.Success && groupExtUncDrive_Drive.Success)
            {
                pathKind = PathKind.ExtUncDrive;
                computerName = groupExtUncDrive_Server.Value;
                driveLetter = groupExtUncDrive_Drive.Value[0];
                return true;
            }

            if (groupExtUncShare_Server.Success && groupExtUncShare_Share.Success)
            {
                pathKind = PathKind.ExtUncShare;
                computerName = groupExtUncShare_Server.Value;
                shareName = groupExtUncShare_Share.Value;
                return true;
            }

            pathKind = PathKind.Invalid;
            return false;
        }
        #endregion
    }
}