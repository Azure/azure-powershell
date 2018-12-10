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

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using System.Globalization;
    using System.Management.Automation;

    /// <summary>
    /// Updates the integration account batch configuration.
    /// </summary>
    [Cmdlet(VerbsCommon.Set,
        AzureRMConstants.AzureRMPrefix + "IntegrationAccountBatchConfiguration",
        DefaultParameterSetName = ParameterSet.ByIntegrationAccount)]
    [OutputType(typeof(BatchConfiguration))]
    public class UpdateAzureIntegrationAccountBatchConfigurationCommand : LogicAppBaseCmdlet
    {
        #region Input Parameters

        [Parameter(Mandatory = false, HelpMessage = "The integration account resource group name.", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account name.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Logic/integrationAccounts", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName")]
        public string ParentName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account batch configuration name.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Logic/integrationAccounts/batchConfigurations", nameof(ResourceGroupName), nameof(ParentName))]
        [ValidateNotNullOrEmpty]
        [Alias("BatchConfigurationName", "ResourceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account batch configuration file path.", ParameterSetName = ParameterSet.ByFilePath)]
        [ValidateNotNullOrEmpty]
        public string BatchConfigurationFilePath { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account batch configuration definition.", ParameterSetName = ParameterSet.ByJson)]
        [ValidateNotNullOrEmpty]
        public string BatchConfigurationDefinition { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account batch configuration group name.")]
        [ValidateNotNullOrEmpty]
        public string BatchGroupName { get; set; } = "DEFAULT";

        [Parameter(Mandatory = false, HelpMessage = "The integration account batch configuration message count.")]
        [ValidateNotNullOrEmpty]
        public int MessageCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account batch configuration batch size.")]
        [ValidateNotNullOrEmpty]
        public int BatchSize { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account batch configuration schedule interval.")]
        [ValidateNotNullOrEmpty]
        public int ScheduleInterval { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account batch configuration schedule frequency.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Month", "Week", "Day", "Hour", "Minute", "Second", IgnoreCase = true)]
        public string ScheduleFrequency { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account batch configuration schedule time zone.")]
        [ValidateNotNullOrEmpty]
        public string ScheduleTimeZone { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account batch configuration schedule start time.")]
        [ValidateNotNullOrEmpty]
        public string ScheduleStartTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account batch configuration metadata.", ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public JObject Metadata { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "An integration account batch configuration.", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public BatchConfiguration InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account batch configuration resource id.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account batch configuration update command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var batchConfiguration = new BatchConfiguration();

            // If we have been given an object to work with, use that to prepopulate data so that we can override it later
            if (this.InputObject != null)
            {
                var parsedResourceId = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentName = parsedResourceId.ParentResource.Split('/')[1];

                batchConfiguration.Properties = this.InputObject.Properties;
            }
            else if (this.ResourceId != null)
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentName = parsedResourceId.ParentResource.Split('/')[1];

                batchConfiguration.Properties = this.IntegrationAccountClient.GetIntegrationAccountBatchConfiguration(this.ResourceGroupName, this.ParentName, parsedResourceId.ResourceName).Properties;
            }

            if (ParameterSetName == ParameterSet.ByJson)
            {
                batchConfiguration.Properties = CmdletHelper.ConvertToBatchConfigurationProperties(this.BatchConfigurationDefinition);
            }
            else if (ParameterSetName == ParameterSet.ByFilePath)
            {
                batchConfiguration.Properties = CmdletHelper.ConvertToBatchConfigurationProperties(CmdletHelper.GetStringContentFromFile(this.TryResolvePath(this.BatchConfigurationFilePath)));
            }
            else
            {
                var releaseCriteria = batchConfiguration.Properties?.ReleaseCriteria ?? new BatchReleaseCriteria();
                if (this.MessageCount > 0)
                {
                    releaseCriteria.MessageCount = this.MessageCount;
                }

                if (this.BatchSize > 0)
                {
                    releaseCriteria.BatchSize = this.BatchSize;
                }

                if (this.ScheduleInterval > 0)
                {
                    releaseCriteria.Recurrence = new WorkflowTriggerRecurrence
                    {
                        Interval = this.ScheduleInterval,
                        Frequency = this.ScheduleFrequency,
                        TimeZone = !string.IsNullOrWhiteSpace(this.ScheduleTimeZone) ? this.ScheduleTimeZone : null,
                        StartTime = !string.IsNullOrWhiteSpace(this.ScheduleStartTime) ? this.ScheduleStartTime : null
                    };
                }

                batchConfiguration.Properties = new BatchConfigurationProperties
                {
                    BatchGroupName = this.BatchGroupName,
                    ReleaseCriteria = releaseCriteria
                };

                if (!IsValidReleaseCriteria(releaseCriteria))
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, Properties.Resource.BatchConfigurationParameterNeedsToBeSpecified));
                }
            }

            this.ConfirmAction(
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceMessage, "Microsoft.Logic/integrationAccounts/batchConfigurations", this.Name),
                this.Name,
                () =>
                {
                    this.WriteObject(this.IntegrationAccountClient.UpdateIntegrationAccountBatchConfiguration(this.ResourceGroupName, this.ParentName, this.Name, batchConfiguration));
                });
        }
        private bool IsValidReleaseCriteria(BatchReleaseCriteria releaseCriteria)
        {
            return releaseCriteria.MessageCount > 0 ||
                   releaseCriteria.BatchSize > 0 ||
                   (releaseCriteria.Recurrence?.Interval > 0 && !string.IsNullOrWhiteSpace(releaseCriteria.Recurrence?.Frequency));
        }
    }
}