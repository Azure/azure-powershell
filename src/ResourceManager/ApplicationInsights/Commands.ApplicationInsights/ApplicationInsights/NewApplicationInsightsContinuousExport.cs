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
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ApplicationInsights
{
    [Cmdlet(VerbsCommon.New, ApplicationInsightsContinuousExportNounStr), OutputType(typeof(PSExportConfiguration))]
    public class NewAzureApplicationInsightsContinuousExportCommand : ApplicationInsightsBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Component Name.")]
        [Alias(ApplicationInsightsComponentNameAlias, ComponentNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Document types that need exported.")]
        [Alias(ApplicationKindAlias)]
        [ValidateSet(DocumentType.Requests,
            DocumentType.Exceptions,
            DocumentType.Event,
            DocumentType.Messages,
            DocumentType.Metrics,
            DocumentType.PageViewPerformance,
            DocumentType.PageViews,
            DocumentType.RemoteDependency,
            DocumentType.Availability,
            DocumentType.PerformanceCounters,
            IgnoreCase = true)]
        public string[] DocumentTypes { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Destination Storage Account Id.")]
        [ValidateNotNullOrEmpty]
        public string DestinationStorageAccountId { get; set; }

        [Parameter(
            Position = 4,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Destination Storage Location Id.")]
        [ValidateNotNullOrEmpty]
        public string DestinationStorageLocationId { get; set; }

        [Parameter(
            Position = 5,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Destination Storage SAS token.")]
        [ValidateNotNullOrEmpty]
        public string DestinationStorageSASToken { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ApplicationInsightsComponentExportRequest exportRequest = new ApplicationInsightsComponentExportRequest();
            exportRequest.IsEnabled = "true";
            exportRequest.DestinationAccountId = this.DestinationStorageAccountId;
            exportRequest.DestinationStorageSubscriptionId = ParseSubscriptionFromId(this.DestinationStorageAccountId);
            exportRequest.DestinationAddress = this.DestinationStorageSASToken;
            exportRequest.DestinationStorageLocationId = this.DestinationStorageLocationId;
            exportRequest.DestinationType = "Blob";
            exportRequest.RecordTypes = string.Join(",", this.DocumentTypes);

            var exportConfigurationsResponse = this.AppInsightsManagementClient
                                                    .ExportConfigurations
                                                    .CreateWithHttpMessagesAsync(
                                                        this.ResourceGroupName,
                                                        this.Name, 
                                                        exportRequest)
                                                    .GetAwaiter()
                                                    .GetResult();

            WriteComponentExportConfiguration(exportConfigurationsResponse.Body);
        }
    }
}
