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

        public char? DriveLetter
        {
            get
            {
                if (this._driveLetter != default(char))
                {
                    return this._driveLetter;
                }

                return null;
            }
        }

        public string ComputerName => this._computerName;

        public string ShareName => this._shareName;

        public int Length
        {
            get
            {
                if (!this._length.HasValue)
                {
                    switch (this._pathKind)
                    {
                        case PathKind.SimpleDrive:
                        case PathKind.ExtDrive:
                        case PathKind.UncDrive:
                        case PathKind.ExtUncDrive:
                            {
                                this._length = this._path.Length + 2; // adding two chars for drive and colon
                                break;
                            }
                        default:
                            {
                                this._length = this._path.Length;
                                break;
                            }
                    }
                }

                return this._length.Value;
            }
        }

        public int Depth
        {
            get
            {
                if (!this._depth.HasValue)
                {
                    this._depth = this._path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Length;

                    if (this._path.StartsWith(@"\"))
                    {
                        this._depth--;
                    }
                }

                return this._depth.Value;
            }
        }

        #endregion

        #region Constructors
        public AfsPath(string fullName)
        {
            this._fullName = fullName;

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