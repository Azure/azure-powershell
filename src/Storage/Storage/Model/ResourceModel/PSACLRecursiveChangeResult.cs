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

using System.Collections.Generic;
using System.Linq;
using Azure.Storage.Files.DataLake.Models;

namespace Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel
{
    /// <summary>
    /// Wrapper class of AccessControlRecursiveChanges
    /// </summary>
    public class PSACLRecursiveChangeResult
    {
        public AccessControlChangeFailure[] FailedEntries;
        public long TotalDirectoriesSuccessfulCount = 0;
        public long TotalFilesSuccessfulCount = 0;
        public long TotalFailureCount = 0;
        public string ContinuationToken = null;

        public PSACLRecursiveChangeResult(long totalDirectoriesSuccessfulCount,
            long totalFilesSuccessfulCount,
            long totalFailureCount,
            string continuationToken = null,
            List<AccessControlChangeFailure> failedEntries = null)
        {
            this.FailedEntries = (failedEntries == null || failedEntries.Count == 0) ? null : failedEntries.ToArray();
            this.TotalDirectoriesSuccessfulCount = totalDirectoriesSuccessfulCount;
            this.TotalFilesSuccessfulCount = totalFilesSuccessfulCount;
            this.TotalFailureCount = totalFailureCount;
            this.ContinuationToken = continuationToken;
        }
    }
}