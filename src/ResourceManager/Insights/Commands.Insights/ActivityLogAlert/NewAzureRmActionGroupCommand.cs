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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Monitor.Management.Models;
using System.Management.Automation;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Insights.ActivityLogAlert
{
    /// <summary>
    /// Create an Activity Log Alert Action Group
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmActionGroup"), OutputType(typeof(ActivityLogAlertActionGroup))]
    public class NewAzureRmActionGroupCommand : AzureRMCmdlet
    {
        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the ActionGroupId parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The action group Id")]
        [ValidateNotNullOrEmpty]
        public string ActionGroupId { get; set; }

        /// <summary>
        /// Gets or sets the WebhookProperty parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The webhook properties of the action group")]
        [ValidateNotNullOrEmpty]
        public Dictionary<string, string> WebhookProperty { get; set; }

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteObject(
                new ActivityLogAlertActionGroup(
                    actionGroupId: this.ActionGroupId,
                    webhookProperties: this.WebhookProperty));
        }
    }
}
