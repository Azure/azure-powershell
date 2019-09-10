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

    /// <summary>
    /// Class AfsNamedObjectInfo.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.INamedObjectInfo" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.INamedObjectInfo" />
    class AfsNamedObjectInfo : INamedObjectInfo
    {
        /// <summary>
        /// Gets the separators.
        /// </summary>
        /// <value>The separators.</value>
        private static char[] Separators => new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };

        /// <summary>
        /// Initializes a new instance of the <see cref="AfsNamedObjectInfo" /> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public AfsNamedObjectInfo(string path)
        {
            FullName = path;
            int index = path.LastIndexOfAny(Separators);
            Name = index >= 0 ? path.Substring(index + 1) : path;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName { get; private set; }

        /// <summary>
        /// Combines the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        public static string Combine(string path, string name)
        {
            return $"{path}{Separators[0]}{name}";
        }
    }
}
