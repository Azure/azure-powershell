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

namespace Microsoft.Azure.Commands.Insights.ActivityLogAlert
{
    /// <summary>
    /// Create an Activity Log Alert condition
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmActivityLogAlertCondition"), OutputType(typeof(ActivityLogAlertLeafCondition))]
    public class NewAzureRmActivityLogAlertConditionCommand : AzureRMCmdlet
    {
        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the Field parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The field of the leaf condition")]
        [ValidateNotNullOrEmpty]
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the Equals parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The equals field of the leaf condition")]
        [ValidateNotNullOrEmpty]
        public string Equal { get; set; }

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteObject(
                new ActivityLogAlertLeafCondition(
                    field: this.Field,
                    equals: this.Equal));
        }
    }
}
