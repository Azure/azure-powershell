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
using Microsoft.Azure.Management.Insights.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;

namespace Microsoft.Azure.Commands.Insights.LogProfiles
{
    /// <summary>
    /// Get the log profiles.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmLogProfile"), OutputType(typeof(PSLogProfile))]
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
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The storage account id")]
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
        public List<string> Locations { get; set; }

        /// <summary>
        /// Gets or sets the categories parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The categories that will be enabled for logging.  By default all categories will be enabled")]
        [ValidateNotNullOrEmpty]
        public List<string> Categories { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            var putParameters = new LogProfileCreatOrUpdateParameters();

            if (this.Categories == null)
            {
                this.Categories = new List<string>(ValidCategories);
            }

            putParameters.Properties = new LogProfile
            {
                Categories = this.Categories,
                Locations = this.Locations,
                RetentionPolicy = new RetentionPolicy
                {
                    Days = this.RetentionInDays.HasValue ? this.RetentionInDays.Value : 0,
                    Enabled = this.RetentionInDays.HasValue
                },
                ServiceBusRuleId = this.ServiceBusRuleId,
                StorageAccountId = this.StorageAccountId
            };

            this.InsightsManagementClient.LogProfilesOperations.CreateOrUpdateAsync(
                this.Name,
                putParameters,
                CancellationToken.None).Wait();

            PSLogProfile psResult = new PSLogProfile(
                "/subscriptions/{0}/providers/microsoft.insights/logprofiles/{1}"
                    .FormatInvariant(DefaultContext.Subscription.Id.ToString(), this.Name), 
                this.Name,
                putParameters.Properties);
            WriteObject(psResult);
        }
    }
}
