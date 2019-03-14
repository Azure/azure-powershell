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

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Class PSStorageSyncValidation.
    /// </summary>
    public class PSStorageSyncValidation
    {
        #region Fields and Properties
        /// <summary>
        /// The computer name
        /// </summary>
        public string ComputerName;
        /// <summary>
        /// The namespace path
        /// </summary>
        public string NamespacePath;
        /// <summary>
        /// The namespace file count
        /// </summary>
        public long NamespaceFileCount;
        /// <summary>
        /// The namespace directory count
        /// </summary>
        public long NamespaceDirectoryCount;
        /// <summary>
        /// The results
        /// </summary>
        public List<PSValidationResult> Results;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PSStorageSyncValidation" /> class.
        /// </summary>
        public PSStorageSyncValidation()
        {
            Results = new List<PSValidationResult>();
        }
        #endregion
    }
}
