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

using Microsoft.Azure.Batch;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class ListVMFileOptions : VMOperationParameters
    {
        public ListVMFileOptions(BatchAccountContext context, string poolName, string vmName, PSVM vm, IEnumerable<BatchClientBehavior> additionalBehaviors = null) 
            : base(context, poolName, vmName, vm, additionalBehaviors)
        { }

        /// <summary>
        /// If specified, the single vm file with this name will be returned
        /// </summary>
        public string VMFileName { get; set; }

        /// <summary>
        /// The OData filter to use when querying for vm files
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// The maximum number of vm files to return
        /// </summary>
        public int MaxCount { get; set; }

        /// <summary>
        /// If true, performs a recursive list of all files of the vm. If false, returns only the files at the vm directory root.
        /// </summary>
        public bool Recursive { get; set; }
    }
}
