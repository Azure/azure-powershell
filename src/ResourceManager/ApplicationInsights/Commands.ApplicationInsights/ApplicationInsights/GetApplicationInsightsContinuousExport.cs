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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ApplicationInsights
{
    [Cmdlet(VerbsCommon.Get, ApplicationInsightsContinuousExportNounStr, DefaultParameterSetName = ComponentNameParameterSet), OutputType(typeof(PSExportConfiguration))]
    public class GetApplicationInsightsContinuousExportCommand : ApplicationInsightsBaseCmdlet
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
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "Application Insights Component Name.")]
        [Alias(ApplicationInsightsComponentNameAlias, ComponentNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = false,
            HelpMessage = "Application Insights Continuous Export Id.")]
        [ValidateNotNullOrEmpty]
        public string ExportId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.ApplicationInsightsComponent != null)
            {
                this.ResourceGroupName = this.ApplicationInsightsComponent.ResourceGroupName;
                this.Name = this.ApplicationInsightsComponent.Name;
            }

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                ResourceIdentifier identifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = identifier.ResourceGroupName;
                this.Name = identifier.ResourceName;
            }

            if (string.IsNullOrEmpty(this.ExportId))
            {
                var exportConfigurationsResponse = this.AppInsightsManagementClient
                                                        .ExportConfigurations
                                                        .ListWithHttpMessagesAsync(
                                                            this.ResourceGroupName,
                                                            this.Name)
                                                        .GetAwaiter()
                                                        .GetResult();

                WriteComponentExportConfiguration(exportConfigurationsResponse.Body);
            }
            else
            {
                var exportConfigurationResponse = this.AppInsightsManagementClient
                                                        .ExportConfigurations
                                                        .GetWithHttpMessagesAsync(
                                                            this.ResourceGroupName,
                                                            this.Name,
                                                            this.ExportId)
                                                        .GetAwaiter()
                                                        .GetResult();

                WriteComponentExportConfiguration(exportConfigurationResponse.Body);
            }
        }
    }
}
