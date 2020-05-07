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

namespace Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models
{
    /// <summary>
    /// PSNamespaceJunction.
    /// </summary>
    public class PSNamespaceJunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSNamespaceJunction"/> class.
        /// </summary>
        /// <param name="nameSpacePath">nameSpacePath.</param>
        /// <param name="targetPath">targetPath.</param>
        /// <param name="nfsExport">nfsExport.</param>
        public PSNamespaceJunction(string nameSpacePath, string targetPath, string nfsExport)
        {
            this.NameSpacePath = nameSpacePath;
            this.TargetPath = targetPath;
            this.NfsExport = nfsExport;
        }

        /// <summary>
        /// Gets or sets namespace path on a Cache for a Storage Target.
        /// </summary>
        public string NameSpacePath { get; set; }

        /// <summary>
        /// Gets or sets path in Storage Target to which namespacePath points.
        /// </summary>
        public string TargetPath { get; set; }

        /// <summary>
        /// Gets or sets NFS export where targetPath exists.
        /// </summary>
        public string NfsExport { get; set; }
    }
}