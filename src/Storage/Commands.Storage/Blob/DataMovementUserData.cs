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
// ---------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Storage.Blob
{
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// User data for data movement library
    /// </summary>
    public class DataMovementUserData
    {
        public object Data;
        public ProgressRecord Record;
        public long TaskId;
        public TaskCompletionSource<bool> taskSource;
        public IStorageBlobManagement Channel;
        public long TotalSize;

        public DataMovementUserData()
        {
            taskSource = new TaskCompletionSource<bool>();
        }
    }
}
