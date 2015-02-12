﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// File name resolver class for translating Azure file names to Windows file names.
    /// </summary>
    internal class AzureToFileSystemFileNameResolver
    {
        /// <summary>
        /// These filenames are reserved on windows, regardless of the file extension.
        /// </summary>
        private static readonly string[] reservedBaseFileNames = new string[]
            {
                "CON", "PRN", "AUX", "NUL", 
                "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", 
                "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9",
            };

        /// <summary>
        /// These filenames are reserved on windows, only if the full filenamem matches.
        /// </summary>
        private static readonly string[] reservedFileNames = new string[]
            {
                "CLOCK$",
            };

        /// <summary>
        /// Chars invalid for file name.
        /// </summary>
        private static char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

        /// <summary>
        /// Chars invalid for path name.
        /// </summary>
        private static char[] invalidPathChars = AzureToFileSystemFileNameResolver.GetInvalidPathChars();

        /// <summary>
        /// Regular expression for replacing slashes that we don't consider directory separators:
        /// <para>Translate / to %2F if it is:
        /// - the first character in the file name
        /// - the last character in the file name
        /// - preceeded by another /.</para>
        /// <example>/abc//def/ gets translated to: %2Fabc/%2Fdef%2F</example>.
        /// </summary>
        private static Regex translateSlashesRegex = new Regex("(^/)|(?<=/)/|(/$)", RegexOptions.Compiled);

        private Dictionary<string, string> resolvedFilesCache = new Dictionary<string, string>();

        private Func<int> getMaxFileNameLength;

        public AzureToFileSystemFileNameResolver(Func<int> getMaxFileNameLength)
        {
            this.getMaxFileNameLength = getMaxFileNameLength;
        }

        public string ResolveFileName(string relativePath, DateTimeOffset? snapshotTime)
        {
            // 1) Unescape original string, original string is UrlEncoded.
            // 2) Replace Azure directory separator with Windows File System directory separator.
            // 3) Trim spaces at the end of the file name.
            string destinationRelativePath = TranslateSlashes(relativePath).TrimEnd(new char[] { ' ' });

            // Split into path + filename parts.
            int lastSlash = destinationRelativePath.LastIndexOf('\\');

            string destinationFileName;
            string destinationPath;

            if (-1 == lastSlash)
            {
                destinationPath = string.Empty;
                destinationFileName = destinationRelativePath;
            }
            else
            {
                destinationPath = destinationRelativePath.Substring(0, lastSlash + 1);
                destinationFileName = destinationRelativePath.Substring(lastSlash + 1);
            }

            if (!string.IsNullOrEmpty(destinationPath))
            {
                // Replace invalid path characters with %HH, with HH being the hexadecimal 
                // representation of the invalid characters.
                destinationPath = EscapeInvalidCharacters(destinationPath, invalidPathChars);
            }

            if (!string.IsNullOrEmpty(destinationFileName))
            {
                // Replace invalid file name characters with %HH, with HH being the hexadecimal
                // representation of the invalid character.
                destinationFileName = EscapeInvalidCharacters(destinationFileName, invalidFileNameChars);
            }

            // Append snapshot time to filename.
            destinationFileName = AppendSnapShotToFileName(destinationFileName, snapshotTime);

            // Combine path and filename back together again.
            destinationRelativePath = Path.Combine(destinationPath, destinationFileName);

            // Check if the destination name is 
            // - already used by a previously resolved file.
            // - or represents a reserved filename on the target file system.
            // - or is longer than the allowed path length on the target file system.
            // If this is the case add a numeric prefix to resolve the conflict.
            destinationRelativePath = this.ResolveFileNameConflict(destinationRelativePath);

            // Add the resolved name to the resolved files cache, so additional files
            // will not use the same target name to download to.
            this.resolvedFilesCache.Add(destinationRelativePath.ToLowerInvariant(), destinationRelativePath);

            return destinationRelativePath;
        }

        /// <summary>
        /// Append snapshot time to a file name.
        /// </summary>
        /// <param name="fileName">Original file name.</param>
        /// <param name="snapshotTime">Snapshot time to append.</param>
        /// <returns>A file name with appended snapshot time.</returns>
        private static string AppendSnapShotToFileName(string fileName, DateTimeOffset? snapshotTime)
        {
            string resultName = fileName;

            if (snapshotTime.HasValue)
            {
                string pathAndFileNameNoExt = Path.ChangeExtension(fileName, null);
                string extension = Path.GetExtension(fileName);
                string timeStamp = string.Format("{0:u}", snapshotTime.Value);

                resultName = string.Format(
                    "{0} ({1}){2}",
                    pathAndFileNameNoExt,
                    timeStamp.Replace(":", string.Empty).TrimEnd(new char[] { 'Z' }),
                    extension);
            }

            return resultName;
        }

        /// <summary>
        /// Turns baseFileName into a valid file name by calling Conflict and Construct.
        /// The procedures are enumerating numbers from 1 and trying to append the number to the base file name.
        /// Conflict is used to test whether current generated file name conflicts with others.
        /// Construct is supposed to generate a file name based on the three parameters, file name without extension, extension and the number to append.
        /// </summary>
        /// <param name="baseFileName">Original file name.</param>
        /// <param name="conflict">A delegate takes one file name as parameter and returns true when no confliction is found.</param>
        /// <param name="construct">A delegate takes three parameters, file name without extension, extension and the number to append, and returns
        /// a file name constructed by these three parameters.</param>
        /// <returns>Valid file name by calling Conflict and Construct.</returns>
        private static string ResolveFileNameConflict(string baseFileName, Func<string, bool> conflict, Func<string, string, int, string> construct)
        {
            if (!conflict(baseFileName))
            {
                return baseFileName;
            }

            string pathAndFilename = Path.ChangeExtension(baseFileName, null);
            string extension = Path.GetExtension(baseFileName);

            string resolvedName = string.Empty;
            int postfixCount = 1;

            do
            {
                resolvedName = construct(pathAndFilename, extension, postfixCount);
                postfixCount++;
            }
            while (conflict(resolvedName));

            return resolvedName;
        }

        private static char[] GetInvalidPathChars()
        {
            // Union InvalidFileNameChars and InvalidPathChars together
            // while excluding slash.
            HashSet<char> charSet = new HashSet<char>(Path.GetInvalidPathChars());

            foreach (char c in invalidFileNameChars)
            {
                if ('\\' == c || '/' == c || charSet.Contains(c))
                {
                    continue;
                }

                charSet.Add(c);
            }

            invalidPathChars = new char[charSet.Count];
            charSet.CopyTo(invalidPathChars);

            return invalidPathChars;
        }

        private static string TranslateSlashes(string source)
        {
            // Transform slashes not used for directory separators to %2F.
            string output = translateSlashesRegex.Replace(source, string.Format("%{0:X2}", (int)'/'));

            // Translate remaining slashes to backslashes.
            return output.Replace('/', '\\');
        }

        private static string EscapeInvalidCharacters(string fileName, params char[] invalidChars)
        {
            if (null != invalidChars)
            {
                // Replace invalid characters with %HH, with HH being the hexadecimal
                // representation of the invalid character.
                foreach (char c in invalidChars)
                {
                    fileName = fileName.Replace(c.ToString(), string.Format("%{0:X2}", (int)c));
                }
            }

            return fileName;
        }

        private static bool IsReservedFileName(string fileName)
        {
            string fileNameNoExt = Path.GetFileNameWithoutExtension(fileName);
            string fileNameWithExt = Path.GetFileName(fileName);

            if (Array.Exists<string>(reservedBaseFileNames, delegate(string s) { return fileNameNoExt.Equals(s, StringComparison.OrdinalIgnoreCase); }))
            {
                return true;
            }

            if (Array.Exists<string>(reservedFileNames, delegate(string s) { return fileNameWithExt.Equals(s, StringComparison.OrdinalIgnoreCase); }))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                return true;
            }

            bool allDotsOrWhiteSpace = true;
            for (int i = 0; i < fileName.Length; ++i)
            {
                if (fileName[i] != '.' && !char.IsWhiteSpace(fileName[i]))
                {
                    allDotsOrWhiteSpace = false;
                    break;
                }
            }

            if (allDotsOrWhiteSpace)
            {
                return true;
            }

            return false;
        }

        private string ResolveFileNameConflict(string baseFileName)
        {
            // TODO - MaxFileNameLength could be <= 0.
            int maxFileNameLength = this.getMaxFileNameLength();

            Func<string, bool> conflict = delegate(string fileName)
            {
                return this.resolvedFilesCache.ContainsKey(fileName.ToLowerInvariant()) ||
                       IsReservedFileName(fileName) ||
                       fileName.Length > maxFileNameLength;
            };

            Func<string, string, int, string> construct = delegate(string fileName, string extension, int count)
            {
                string postfixString = string.Format(" ({0})", count);

                // TODO - trimLength could be be larger than pathAndFilename.Length, what do we do in this case?
                int trimLength = (fileName.Length + postfixString.Length + extension.Length) - maxFileNameLength;

                if (trimLength > 0)
                {
                    fileName = fileName.Remove(fileName.Length - trimLength);
                }

                return string.Format("{0}{1}{2}", fileName, postfixString, extension);
            };

            return ResolveFileNameConflict(baseFileName, conflict, construct);
        }
    }
}
