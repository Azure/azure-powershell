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
using System.Globalization;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    class BlobToAzureFileNameResolver : BlobToFileNameResolver
    {
        private static char[] invalidPathChars = new char[] { '"', '\\', ':', '|', '<', '>', '*', '?' };

        public BlobToAzureFileNameResolver(Func<int> getMaxFileNameLength)
            : base(getMaxFileNameLength)
        {
        }

        protected override string DirSeparator
        {
            get
            {
                return "/";
            }
        }

        protected override char[] InvalidPathChars
        {
            get
            {
                return BlobToAzureFileNameResolver.invalidPathChars;
            }
        }

        protected override string EscapeInvalidCharacters(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            char separator = this.DirSeparator.ToCharArray()[0];
            string escapedSeparator = string.Format(CultureInfo.InvariantCulture, "%{0:X2}", (int)separator);

            bool followSeparator = false;
            char[] fileNameChars = fileName.ToCharArray();
            int lastIndex = fileNameChars.Length - 1;

            for (int i = 0; i < fileNameChars.Length; ++i)
            {
                if (fileNameChars[i] == separator)
                {
                    if (followSeparator || (0 == i) || (lastIndex == i))
                    {
                        sb.Append(escapedSeparator);
                    }
                    else
                    {
                        sb.Append(fileNameChars[i]);
                    }

                    followSeparator = true;
                }
                else
                {
                    followSeparator = false;
                    sb.Append(fileNameChars[i]);
                }
            }

            fileName = sb.ToString();

            return base.EscapeInvalidCharacters(fileName);
        }
    }
}
