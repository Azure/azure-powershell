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
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Management.Automation;

    /// <summary>
    /// Updates the integration account batch configuration.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, AzureRMConstants.AzureRMPrefix + "IntegrationAccountBatchConfiguration", DefaultParameterSetName = ParameterSet.ByIntegrationAccountAndParameters)]
    [OutputType(typeof(BatchConfiguration))]
    public class UpdateAzureIntegrationAccountBatchConfigurationCommand : LogicAppBaseCmdlet
    {
        #region Input Parameters

        [Parameter(Mandatory = true, HelpMessage = Constants.ResourceGroupHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndJson)]
        [Parameter(Mandatory = true, HelpMessage = Constants.ResourceGroupHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndFilePath)]
        [Parameter(Mandatory = true, HelpMessage = Constants.ResourceGroupHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndParameters)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountNameHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndJson)]
        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountNameHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndFilePath)]
        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountNameHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndParameters)]
        [ResourceNameCompleter("Microsoft.Logic/integrationAccounts", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName")]
        public string ParentName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationNameHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndJson)]
        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationNameHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndFilePath)]
        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationNameHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndParameters)]
        [ResourceNameCompleter("Microsoft.Logic/integrationAccounts/batchConfigurations", nameof(ResourceGroupName), nameof(ParentName))]
        [ValidateNotNullOrEmpty]
        [Alias("BatchConfigurationName", "ResourceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationFilePathHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndFilePath)]
        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationFilePathHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndFilePath)]
        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationFilePathHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndFilePath)]
        [ValidateNotNullOrEmpty]
        public string BatchConfigurationFilePath { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationDefinitionHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndJson)]
        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationDefinitionHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndJson)]
        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationDefinitionHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndJson)]
        [ValidateNotNullOrEmpty]
        public string BatchConfigurationDefinition { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationBatchGroupNameHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationBatchGroupNameHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationBatchGroupNameHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndParameters)]
        [ValidateNotNullOrEmpty]
        public string BatchGroupName { get; set; } = "DEFAULT";

        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationMessageCountHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationMessageCountHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationMessageCountHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndParameters)]
        [ValidateNotNullOrEmpty]
        public int MessageCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationBatchSizeHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationBatchSizeHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationBatchSizeHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndParameters)]
        [ValidateNotNullOrEmpty]
        public int BatchSize { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationScheduleIntervalHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationScheduleIntervalHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationScheduleIntervalHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndParameters)]
        [ValidateNotNullOrEmpty]
        public int ScheduleInterval { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationScheduleFrequencyHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationScheduleFrequencyHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationScheduleFrequencyHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndParameters)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Month", "Week", "Day", "Hour", "Minute", "Second", IgnoreCase = true)]
        public string ScheduleFrequency { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationScheduleTimeZoneHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationScheduleTimeZoneHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationScheduleTimeZoneHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndParameters)]
        [ValidateNotNullOrEmpty]
        public string ScheduleTimeZone { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationScheduleStartTimeHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationScheduleStartTimeHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndParameters)]
        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationScheduleStartTimeHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndParameters)]
        [ValidateNotNullOrEmpty]
        public DateTime? ScheduleStartTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.BatchConfigurationMetadataHelpMessage)]
        [ValidateNotNullOrEmpty]
        public Hashtable Metadata { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationInputObjectHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndJson, ValueFromPipeline = true)]
        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationInputObjectHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndFilePath, ValueFromPipeline = true)]
        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationInputObjectHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndParameters, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public BatchConfiguration InputObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationResourceIdHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndJson, ValueFromPipelineByPropertyName = true)]
        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationResourceIdHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndFilePath, ValueFromPipelineByPropertyName = true)]
        [Parameter(Mandatory = true, HelpMessage = Constants.BatchConfigurationResourceIdHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndParameters, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account batch configuration update command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case ParameterSet.ByInputObjectAndJson:
                case ParameterSet.ByInputObjectAndFilePath:
                case ParameterSet.ByInputObjectAndParameters:
                {
                    var parsedResourceId = new ResourceIdentifier(this.InputObject.Id);
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                    this.ParentName = parsedResourceId.ResourceName;
                    break;
                }
                case ParameterSet.ByResourceIdAndJson:
                case ParameterSet.ByResourceIdAndFilePath:
                case ParameterSet.ByResourceIdAndParameters:
                {
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                    this.ParentName = parsedResourceId.ResourceName;
                    break;
                }
            }

            var batchConfiguration = new BatchConfiguration();

            switch (this.ParameterSetName)
            {
                case ParameterSet.ByInputObjectAndJson:
                case ParameterSet.ByResourceIdAndJson:
                case ParameterSet.ByIntegrationAccountAndJson:
                {
                    batchConfiguration.Properties = CmdletHelper.ConvertToBatchConfigurationProperties(this.BatchConfigurationDefinition);
                    break;
                }
                case ParameterSet.ByInputObjectAndFilePath:
                case ParameterSet.ByResourceIdAndFilePath:
                case ParameterSet.ByIntegrationAccountAndFilePath:
                {
                    batchConfiguration.Properties = CmdletHelper.ConvertToBatchConfigurationProperties(CmdletHelper.GetStringContentFromFile(this.TryResolvePath(this.BatchConfigurationFilePath)));
                    break;
                }
                case ParameterSet.ByInputObjectAndParameters:
                case ParameterSet.ByResourceIdAndParameters:
                case ParameterSet.ByIntegrationAccountAndParameters:
                {
                    var releaseCriteria = new BatchReleaseCriteria();
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
                            StartTime = this.ScheduleStartTime?.ToShortDateString()
                        };
                    }

                    batchConfiguration.Properties = new BatchConfigurationProperties
                    {
                        BatchGroupName = this.BatchGroupName,
                        ReleaseCriteria = releaseCriteria
                    };

                    if (!this.IsValidReleaseCriteria(releaseCriteria))
                    {
                        throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, Properties.Resource.BatchConfigurationParameterNeedsToBeSpecified));
                    }

                    break;
                }
            }

            batchConfiguration.Properties.Metadata = this.Metadata;

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