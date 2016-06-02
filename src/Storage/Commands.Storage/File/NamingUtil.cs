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

namespace Microsoft.WindowsAzure.Commands.Storage.File
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides utilities to determining whether the given string is a valid
    /// name of some component.
    /// </summary>
    internal static class NamingUtil
    {
        private const int MinShareNameLength = 3;

        private const string ShareNameValidationPattern = @"^[a-z0-9][a-z0-9\-]{0,62}$";

        private const string FileNameValidationPattern = @"^[^\x00-\x1f""\\/:|<>?*\uE000-\uF8FF]{1,255}$";

        private const string InvalidFileNamePattern = @"^((LPT\d)|(COM\d)|(PRN)|(AUX)|(NUL)|(CON)|(CLOCK\$))$";

        private const int MaxPathLength = 2048;

        private static readonly char[] PathSeparators = new char[] { '/', '\\' };

        private static readonly string[] DirectoryIndicators = new string[] { ".", ".." };

        /// <summary>
        /// Validates the given path. Provides an overload which does not
        /// output the isDirectory parameter for callers who don't care if
        /// it is a directory.
        /// </summary>
        /// <param name="path">Indicating the path.</param>
        /// <param name="isFileName">
        /// Provides an optional hint whether this path is expected to be a
        /// path to a file. If this option is given and the given path can only
        /// be treated as a directory (isDirectory output value would be set to
        /// true). An argument exception would throw.
        /// </param>
        /// <returns>
        /// Returns a collection of strings which contains all sub folders of
        /// the given path if validated successfully.
        /// </returns>
        public static string[] ValidatePath(string path, bool isFileName = false)
        {
            bool isDirectory;
            return ValidatePath(path, out isDirectory, isFileName);
        }

        /// <summary>
        /// Validates the given path. Returns the validated path in the form
        /// of a collection of strings which represents all sub folders
        /// </summary>
        /// <param name="path">Indicating the path.</param>
        /// <param name="isDirectory">
        /// Outputs a value indicating whether the given path can only be
        /// treated as an directory. Returning false for isDirectory means
        /// we could not tell from the given string whether the path is a
        /// directory or a file.
        /// </param>
        /// <param name="isFileName">
        /// Provides an optional hint whether this path is expected to be a
        /// path to a file. If this option is given and the given path can only
        /// be treated as a directory (isDirectory output value would be set to
        /// true), an argument exception would throw.
        /// </param>
        /// <returns>
        /// Returns a collection of strings which contains all parent folders of
        /// the given path if validated successfully.
        /// </returns>
        public static string[] ValidatePath(string path, out bool isDirectory, bool isFileName = false)
        {
            if (string.IsNullOrEmpty(path))
            {
                isDirectory = false;
                return new string[0];
            }

            isDirectory = PathSeparators.Contains(path.Last());
            if (isFileName && isDirectory)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.FileNameShouldNotEndWithSlash, path));
            }

            if (path.Length > MaxPathLength)
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.PathTooLong, path, MaxPathLength));
            }

            string[] result = path.Split(PathSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var fileName in result)
            {
                if (!Regex.Match(fileName, FileNameValidationPattern, RegexOptions.Singleline).Success ||
                    Regex.Match(fileName.ToUpperInvariant(), InvalidFileNamePattern, RegexOptions.Singleline).Success)
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.PathInvalid, fileName));
                }
            }

            if (result.Length == 0 || DirectoryIndicators.Contains(result.Last(), StringComparer.Ordinal))
            {
                isDirectory = true;
            }

            return result;
        }

        public static void ValidateShareName(string shareName, bool validatingPrefix)
        {
            if (string.IsNullOrEmpty(shareName) && validatingPrefix)
            {
                return;
            }

            if (Regex.Match(shareName, ShareNameValidationPattern).Success &&
                !shareName.Contains("--"))
            {
                if (validatingPrefix)
                {
                    return;
                }

                // When validating exact share name (not a prefix), we must
                // ensure the minimum length and make sure the last character
                // is not dash.
                else if (shareName.Length >= MinShareNameLength &&
                         shareName.Last() != '-')
                {
                    return;
                }
            }

            throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ShareNameInvalid, shareName));
        }
    }
}
