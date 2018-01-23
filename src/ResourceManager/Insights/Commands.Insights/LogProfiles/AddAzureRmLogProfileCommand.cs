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

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;

namespace Microsoft.Azure.Commands.Insights.LogProfiles
{
    /// <summary>
    /// Get the log profiles.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmLogProfile", SupportsShouldProcess = true), OutputType(typeof(PSLogProfile))]
    public class AddAzureRmLogProfileCommand : ManagementCmdletBase
    {
        private static readonly List<string> ValidCategories = new List<string> { "Delete", "Write", "Action" };

        #region Parameters declarations

        /// <summary>
        /// Gets or sets the name of the log profile
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the log profile")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the storage account parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The storage account id")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the service bus rule id parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The service bus authorization rule id")]
        [ValidateNotNullOrEmpty]
        public string ServiceBusRuleId { get; set; }

        /// <summary>
        /// Gets or sets the retention of the logs
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The retention in days")]
        [ValidateNotNullOrEmpty]
        public int? RetentionInDays { get; set; }

        /// <summary>
        /// Gets or sets the locations parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The locations that will be enabled for logging")]
        [ValidateNotNullOrEmpty]
        [Alias("Locations")]
        public List<string> Location { get; set; }

        /// <summary>
        /// Gets or sets the categories parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The categories that will be enabled for logging.  By default all categories will be enabled")]
        [ValidateNotNullOrEmpty]
        [Alias("Categories")]
        public List<string> Category { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            this.WriteIdentifiedWarning(
                cmdletName: "Add-AzureRmLogProfile",
                topic: "Parameter name change", 
                message: "The parameter plural names for the parameters will be deprecated in a future breaking change release in favor of the singular versions of the same names.");
            if (ShouldProcess(
                target: string.Format("Create/update a log profile: {0}", this.Name),
                action: "Create/update a log profile"))
            {
                var putParameters = new LogProfileResource()
                {
                    Location = string.Empty,
                    Locations = this.Location
                };

                if (this.Category == null)
                {
                    this.Category = new List<string>(ValidCategories);
                }

                putParameters.Categories = this.Category;
                putParameters.RetentionPolicy = new RetentionPolicy
                {
                    Days = this.RetentionInDays.HasValue ? this.RetentionInDays.Value : 0,
                    Enabled = this.RetentionInDays.HasValue
                };
                putParameters.ServiceBusRuleId = this.ServiceBusRuleId;
                putParameters.StorageAccountId = this.StorageAccountId;

                LogProfileResource result = this.MonitorManagementClient.LogProfiles.CreateOrUpdateAsync(logProfileName: this.Name, parameters: putParameters, cancellationToken: CancellationToken.None).Result;
                WriteObject(new PSLogProfile(result));
            }
        }
    }
}
