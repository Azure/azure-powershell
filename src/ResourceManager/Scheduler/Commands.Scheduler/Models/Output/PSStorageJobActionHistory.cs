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

namespace Microsoft.Azure.Commands.Scheduler.Models
{
    public class PSStorageJobActionHistory : PSJobActionHistory
    {
        /// <summary>
        /// Gets or sets storage account name.
        /// </summary>
        public string StorageAccountName { get; internal set; }

        /// <summary>
        /// Gets or sets storage queue name.
        /// </summary>
        public string StorageQueueName { get; internal set; }
    }
}
