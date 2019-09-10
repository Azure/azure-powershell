// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class AfsPath.
    /// </summary>
    public class AfsPath
    {
        /// <summary>
        /// Enum PathKind
        /// </summary>
        private enum PathKind
        {
            /// <summary>
            /// The invalid
            /// </summary>
            Invalid,
            /// <summary>
            /// The simple drive
            /// </summary>
            SimpleDrive,
            /// <summary>
            /// The ext drive
            /// </summary>
            ExtDrive,
            /// <summary>
            /// The unc drive
            /// </summary>
            UncDrive,
            /// <summary>
            /// The unc share
            /// </summary>
            UncShare,
            /// <summary>
            /// The ext unc drive
            /// </summary>
            ExtUncDrive,
            /// <summary>
            /// The ext unc share
            /// </summary>
            ExtUncShare
        }

        #region Fields and Properties
        /// <summary>
        /// The full name
        /// </summary>
        private readonly string _fullName;
        /// <summary>
        /// The path kind
        /// </summary>
        private PathKind _pathKind;
        /// <summary>
        /// The computer name
        /// </summary>
        private string _computerName;
        /// <summary>
        /// The share name
        /// </summary>
        private string _shareName;
        /// <summary>
        /// The drive letter
        /// </summary>
        private char _driveLetter;
        /// <summary>
        /// The length
        /// </summary>
        private int? _length;
        /// <summary>
        /// The depth
        /// </summary>
        private int? _depth;
        /// <summary>
        /// The origin
        /// </summary>
        private string _origin;
        /// <summary>
        /// The path
        /// </summary>
        private string _path;

        /// <summary>
        /// The path patterns
        /// </summary>
        private static readonly Regex PathPatterns = new Regex(
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

        /// <summary>
        /// Gets the drive letter.
        /// </summary>
        /// <value>The drive letter.</value>
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

        /// <summary>
        /// Gets the name of the computer.
        /// </summary>
        /// <value>The name of the computer.</value>
        public string ComputerName => _computerName;

        /// <summary>
        /// Gets the name of the share.
        /// </summary>
        /// <value>The name of the share.</value>
        public string ShareName => _shareName;

        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>The length.</value>
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

        /// <summary>
        /// Gets the depth.
        /// </summary>
        /// <value>The depth.</value>
        public int Depth
        {
            get
            {
                if (!_depth.HasValue)
                {
                    _depth = _path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Length;

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
        /// <summary>
        /// Initializes a new instance of the <see cref="AfsPath" /> class.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <exception cref="ArgumentException">Invalid path - fullName</exception>
        public AfsPath(string fullName)
        {
            _fullName = fullName;

            if (!TryParsePath(
                path: fullName,
                pathKind: out _pathKind,
                origin: out _origin,
                dataPath: out _path,
                computerName: out _computerName,
                shareName: out _shareName,
                driveLetter: out _driveLetter))
            {
                throw new ArgumentException("Invalid path", nameof(fullName));
            }            
        }
        #endregion


        #region Private methods
        /// <summary>
        /// Tries the parse path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="pathKind">Kind of the path.</param>
        /// <param name="origin">The origin.</param>
        /// <param name="dataPath">The data path.</param>
        /// <param name="computerName">Name of the computer.</param>
        /// <param name="shareName">Name of the share.</param>
        /// <param name="driveLetter">The drive letter.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool TryParsePath(string path, out PathKind pathKind, out string origin, out string dataPath, out string computerName, out string shareName, out char driveLetter)
        {
            computerName = null;
            shareName = null;
            driveLetter = '\0';
            origin = null;
            dataPath = null;

            Match match = PathPatterns.Match(path);
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