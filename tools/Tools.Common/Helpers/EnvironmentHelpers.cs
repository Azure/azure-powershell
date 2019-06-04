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
using System.IO;

namespace Tools.Common.Helpers
{
    public static class EnvironmentHelpers
    {
        /// <summary>
        /// Get the name of the directory from a directory path
        /// </summary>
        /// <param name="path">A directory path</param>
        /// <returns>The name of the directory</returns>
        public static string GetDirectoryName(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            var result = path.TrimEnd(Path.DirectorySeparatorChar);
            var lastSlash = result.LastIndexOf(Path.DirectorySeparatorChar);
            if (lastSlash > 0)
            {
                result = result.Substring(lastSlash + 1);
            }

            return result;
        }
    }
}
