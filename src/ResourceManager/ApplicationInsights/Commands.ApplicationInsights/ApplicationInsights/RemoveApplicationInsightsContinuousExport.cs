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

using System.Management.Automation;

namespace Microsoft.Azure.Commands.ApplicationInsights
{
    [Cmdlet(VerbsCommon.Remove, ApplicationInsightsContinuousExportNounStr, SupportsShouldProcess = true)]
    public class RemoveApplicationInsightsComponentContinuousExport : ApplicationInsightsBaseCmdlet
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
            HelpMessage = "Application Insights Component Name.")]
        [Alias(ApplicationInsightsComponentNameAlias, ComponentNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Insights Continuous Export ID.")]
        [ValidateNotNullOrEmpty]
        public string ExportId { get; set; }

        [Parameter(HelpMessage = "Force to Delete the Application Insights Component continuous export configuration")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }
        private bool force = false;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Remove Application Insights Continuous Export"))
            {
                if (this.force || ShouldContinue(string.Format("Remove Application Insights Continuous Export '{0}'", this.ExportId), ""))
                {
                    this.AppInsightsManagementClient
                        .ExportConfigurations
                        .DeleteWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name, 
                            this.ExportId)
                        .GetAwaiter()
                        .GetResult();
                }
            }
        }
    }
}
