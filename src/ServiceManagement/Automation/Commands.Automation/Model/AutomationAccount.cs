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

using Microsoft.Azure.Commands.Automation.Common;

namespace Microsoft.Azure.Commands.Automation.Model
{
    using AutomationManagement = Microsoft.WindowsAzure.Management.Automation;

    /// <summary>
    /// The automation account.
    /// </summary>
    public class AutomationAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutomationAccount"/> class.
        /// </summary>
        /// <param name="cloudService">
        /// The cloud service.
        /// </param>
        /// <param name="resource">
        /// The resource.
        /// </param>
        public AutomationAccount(AutomationManagement.Models.CloudService cloudService, AutomationManagement.Models.AutomationResource resource)
        {
            Requires.Argument("cloudService", cloudService).NotNull();
            Requires.Argument("resource", resource).NotNull();

            this.AutomationAccountName = resource.Name;
            this.Location = cloudService.GeoRegion;
            switch (resource.State)
            {
                case AutomationManagement.Models.AutomationResourceState.Started:
                    this.State = Constants.AutomationAccountState.Ready;
                    break;
                case AutomationManagement.Models.AutomationResourceState.Stopped:
                    this.State = Constants.AutomationAccountState.Suspended;
                    break;
                default:
                    this.State = resource.State;
                    break;
            }

            if (resource.IntrinsicSettings != null) this.Plan = resource.IntrinsicSettings.SubscriptionPlan;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutomationAccount"/> class.
        /// </summary>
        public AutomationAccount()
        {
        }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the plan.
        /// </summary>
        public string Plan { get; set; }
    }
}
