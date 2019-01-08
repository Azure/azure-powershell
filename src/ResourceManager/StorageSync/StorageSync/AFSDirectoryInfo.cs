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

    class AfsDirectoryInfo : AfsNamedObjectInfo, IDirectoryInfo
    {
        public AfsDirectoryInfo(string path) : base(path)
        {
        }

        public IEnumerable<IDirectoryInfo> EnumerateDirectories()
        {
            List<string> subDirectories = ListFiles.GetDirectories(ListFiles.EnsureUncPrefixPresent(this.FullName));
            return subDirectories.Select(subDirectoryName => new AfsDirectoryInfo(Combine(this.FullName, subDirectoryName)));
        }

        public IEnumerable<IFileInfo> EnumerateFiles()
        {
            List<Tuple<string, long>> subDirectories = ListFiles.GetFiles(ListFiles.EnsureUncPrefixPresent(this.FullName));
            return subDirectories.Select(tuple => new AfsFileInfo(Combine(this.FullName, tuple.Item1), tuple.Item2));
        }

        public bool Exists()
        {
            return System.IO.Directory.Exists(this.FullName);
        }
    }
}
