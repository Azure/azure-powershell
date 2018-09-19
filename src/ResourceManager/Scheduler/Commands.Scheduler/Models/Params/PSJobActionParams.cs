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
    using Microsoft.Azure.Management.Scheduler.Models;

    public class PSJobActionParams
    {
        /// <summary>
        /// Gets or sets job action type.
        /// </summary>
        public JobActionType JobActionType { get; set; }

        /// <summary>
        /// Gets or sets job http action.
        /// </summary>
        public PSHttpJobActionParams HttpJobAction { get; set; }

        /// <summary>
        /// Gets or sets job storage action.
        /// </summary>
        public PSStorageJobActionParams StorageJobAction { get; set; }

        /// <summary>
        /// Gets or sets service bus action.
        /// </summary>
        public PSServiceBusParams ServiceBusAction { get; set; }
    }
}
