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

using Microsoft.Azure.Commands.ApplicationInsights.Models;
using Microsoft.Azure.Management.ApplicationInsights.Management.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ApplicationInsights
{
    [Cmdlet(VerbsCommon.Set, ApplicationInsightsContinuousExportNounStr), OutputType(typeof(PSExportConfiguration))]
    public class SetApplicationInsightsContinuousExportCommand : ApplicationInsightsBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ComponentObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Application Insights Component Object.")]
        [ValidateNotNull]
        public PSApplicationInsightsComponent ApplicationInsightsComponent { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Insights Component Resource Id.")]
        [ValidateNotNull]
        public ResourceIdentifier ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Insights Component Name.")]
        [Alias(ApplicationInsightsComponentNameAlias, ComponentNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Insights Continuous Export Id.")]
        [ValidateNotNullOrEmpty]
        public string ExportId { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Document types that need exported.")]        
        [ValidateSet(ApplicationInsightsBaseCmdlet.DocumentTypes.Requests,
            ApplicationInsightsBaseCmdlet.DocumentTypes.Exceptions,
            ApplicationInsightsBaseCmdlet.DocumentTypes.Event,
            ApplicationInsightsBaseCmdlet.DocumentTypes.Messages,
            ApplicationInsightsBaseCmdlet.DocumentTypes.Metrics,
            ApplicationInsightsBaseCmdlet.DocumentTypes.PageViewPerformance,
            ApplicationInsightsBaseCmdlet.DocumentTypes.PageViews,
            ApplicationInsightsBaseCmdlet.DocumentTypes.RemoteDependency,
            ApplicationInsightsBaseCmdlet.DocumentTypes.Availability,
            ApplicationInsightsBaseCmdlet.DocumentTypes.PerformanceCounters,
            IgnoreCase = true)]
        public string[] DocumentType { get; set; }

        [Parameter(
            Position = 4,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Destination Storage Account Id.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountId { get; set; }

        [Parameter(
            Position = 5,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Destination Storage Location Id.")]
        [ValidateNotNullOrEmpty]
        public string StorageLocationId { get; set; }

        [Parameter(
            Position = 6,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Destination Storage SAS uri.")]
        [ValidateNotNullOrEmpty]
        public string StorageSASUri { get; set; }

        [Parameter(
            Position = 7,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable continuous export or not.")]
        [PSDefaultValue(Value = true)]
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                this.isEnabled = value;
            }
        }
        private bool isEnabled = true;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.ApplicationInsightsComponent != null)
            {
                this.ResourceGroupName = this.ApplicationInsightsComponent.ResourceGroupName;
                this.Name = this.ApplicationInsightsComponent.Name;
            }

            if (this.ResourceId != null)
            {
                this.ResourceGroupName = this.ResourceId.ResourceGroupName;
                this.Name = this.ResourceId.ResourceName;
            }

            ApplicationInsightsComponentExportRequest exportRequest = new ApplicationInsightsComponentExportRequest();
            exportRequest.IsEnabled = this.IsEnabled.ToString().ToLowerInvariant();
            exportRequest.DestinationAccountId = this.StorageAccountId;
            exportRequest.DestinationStorageSubscriptionId = ParseSubscriptionFromId(this.StorageAccountId);
            exportRequest.DestinationAddress = this.StorageSASUri;
            exportRequest.DestinationStorageLocationId = this.StorageLocationId;
            exportRequest.DestinationType = "Blob";
            exportRequest.RecordTypes = string.Join(",", ConvertToRecordType(this.DocumentType));

            var exportResponse = this.AppInsightsManagementClient
                                        .ExportConfigurations
                                        .UpdateWithHttpMessagesAsync(
                                            this.ResourceGroupName,
                                            this.Name,
                                            this.ExportId,
                                            exportRequest)
                                        .GetAwaiter()
                                        .GetResult();

            WriteComponentExportConfiguration(exportResponse.Body);
        }
    }
}
