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

namespace Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models
{
    using Microsoft.Azure.Commands.DataShare.Models;
    using System;

    /// <summary>
    /// Azure Data Share Synchronization Settings
    /// </summary>
    public class PSDataShareSynchronizationSetting : PSResource
    {
        /// <summary>
        /// The time between scheduled synchronizations
        /// </summary>
        public string RecurrenceInterval { get; set; }

        /// <summary>
        /// The start time for the first synchronization
        /// </summary>
        public DateTime? SynchronizationTime { get; set; }

        /// <summary>
        /// The provisioning state for this synchronization setting
        /// </summary>
        public PSProvisioningState ProvisioningState { get; set; }

        /// <summary>
        /// The date-time the settings were created
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// The person that created the settings
        /// </summary>
        public string CreatedBy { get; set; }
    }
}
