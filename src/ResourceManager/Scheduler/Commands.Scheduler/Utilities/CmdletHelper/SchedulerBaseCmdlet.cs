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

namespace Microsoft.Azure.Commands.Scheduler.Utilities
{
    using Microsoft.Azure.Commands.ResourceManager.Common;

    /// <summary>
    /// Scheduler base commandlet class.
    /// </summary>
    public class SchedulerBaseCmdlet : AzureRMCmdlet
    {
        /// <summary>
        /// The Scheduler client.
        /// </summary>
        private SchedulerClient _schedulerClient = null;

        /// <summary>
        /// Gets or sets the Scheduler client used in the powershell commands.
        /// </summary>
        public SchedulerClient SchedulerClient
        {
            get
            {
                this._schedulerClient = new SchedulerClient(this.DefaultProfile.Context);

                return this._schedulerClient;
            }
            set
            {
                this._schedulerClient = value;
            }
        }
    }
}
