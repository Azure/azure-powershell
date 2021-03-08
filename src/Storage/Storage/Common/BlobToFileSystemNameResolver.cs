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

using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    /// <summary>
    /// File name resolver class for translating blob names to Windows file names.
    /// </summary>
    internal class BlobToFileSystemNameResolver : BlobToFileNameResolver
    {
        /// <summary>
        /// Chars invalid for file name.
        /// </summary>
        private static char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

        /// <summary>
        /// Chars invalid for path name.
        /// </summary>
        private static char[] invalidPathChars = BlobToFileSystemNameResolver.GetInvalidPathChars();

        protected override string DirSeparator
        {
            get
            {
                return "\\";
            }
        }

        protected override char[] InvalidPathChars
        {
            get
            {
                return BlobToFileSystemNameResolver.invalidPathChars;
            }
        }

        public BlobToFileSystemNameResolver(Func<int> getMaxFileNameLength)
            : base(getMaxFileNameLength)
        {
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
    }
}
