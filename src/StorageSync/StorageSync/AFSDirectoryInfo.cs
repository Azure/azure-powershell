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
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class AfsDirectoryInfo.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.AfsNamedObjectInfo" />
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IDirectoryInfo" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.AfsNamedObjectInfo" />
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IDirectoryInfo" />
    class AfsDirectoryInfo : AfsNamedObjectInfo, IDirectoryInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AfsDirectoryInfo" /> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public AfsDirectoryInfo(string path) : base(path)
        {
        }

        /// <summary>
        /// Enumerates the directories.
        /// </summary>
        /// <returns>IEnumerable&lt;IDirectoryInfo&gt;.</returns>
        public IEnumerable<IDirectoryInfo> EnumerateDirectories()
        {
            List<string> subDirectories = ListFiles.GetDirectories(ListFiles.EnsureUncPrefixPresent(FullName));
            return subDirectories.Select(subDirectoryName => new AfsDirectoryInfo(Combine(FullName, subDirectoryName)));
        }

        /// <summary>
        /// Enumerates the files.
        /// </summary>
        /// <returns>IEnumerable&lt;IFileInfo&gt;.</returns>
        public IEnumerable<IFileInfo> EnumerateFiles()
        {
            List<Tuple<string, long>> subDirectories = ListFiles.GetFiles(ListFiles.EnsureUncPrefixPresent(FullName));
            return subDirectories.Select(tuple => new AfsFileInfo(Combine(FullName, tuple.Item1), tuple.Item2));
        }

        /// <summary>
        /// Existses this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Exists()
        {
            return System.IO.Directory.Exists(FullName);
        }
    }
}
