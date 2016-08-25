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
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Autoscale
{
    /// <summary>
    /// Get an Alert rule
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutoscaleSetting"), OutputType(typeof(List<AutoscaleSettingResource>))]
    public class GetAzureRmAutoscaleSettingCommand : ManagementCmdletBase
    {
        internal const string GetAzureRmAutoscaleSettingParamGroup = "Parameters for Get-AzureRmAustoscaleSetting cmdlet";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the ResourceGroupName parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAutoscaleSettingParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the rule name parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAutoscaleSettingParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The autoscale setting name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the detailedoutput parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAutoscaleSettingParamGroup, ValueFromPipelineByPropertyName = true, HelpMessage = "Return object with all the details of the records (the default is to return only some attributes, i.e. no detail)")]
        public SwitchParameter DetailedOutput { get; set; }

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                // Retrieve all the Autoscale settings for a resource group
                AutoscaleSettingListResponse result = this.InsightsManagementClient.AutoscaleOperations.ListSettingsAsync(resourceGroupName: this.ResourceGroup, targetResourceUri: null).Result;

                var records = result.AutoscaleSettingResourceCollection.Value.Select(e => this.DetailedOutput.IsPresent ? new PSAutoscaleSetting(e) : e);
                WriteObject(sendToPipeline: records, enumerateCollection: true);
            }
            else
            {
                // Retrieve a single Autoscale setting determined by the resource group and the rule name
                AutoscaleSettingGetResponse result = this.InsightsManagementClient.AutoscaleOperations.GetSettingAsync(resourceGroupName: this.ResourceGroup, autoscaleSettingName: this.Name).Result;

                WriteObject(sendToPipeline: this.DetailedOutput.IsPresent ? new PSAutoscaleSetting(result) : result.ToAutoscaleSettingGetResponse());
            }
        }
    }
}
