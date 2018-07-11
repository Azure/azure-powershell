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
    using Interfaces;
    using System.IO;

    class AfsNamedObjectInfo : INamedObjectInfo
    {
        private static char[] Separators => new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };

        public AfsNamedObjectInfo(string path)
        {
            this.FullName = path;
            int index = path.LastIndexOfAny(Separators);
            this.Name = index >= 0 ? path.Substring(index + 1) : path;
        }

        public string Name { get; private set; }

        public string FullName { get; private set; }

        public static string Combine(string path, string name)
        {
            return $"{path}{Separators[0]}{name}";
        }
    }
}
