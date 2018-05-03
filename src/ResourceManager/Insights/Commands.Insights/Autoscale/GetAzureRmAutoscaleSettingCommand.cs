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
using System.Linq;
using System.Management.Automation;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Insights.Autoscale
{
    /// <summary>
    /// Get an Alert rule
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutoscaleSetting"), OutputType(typeof(List<PSAutoscaleSetting>))]
    public class GetAzureRmAutoscaleSettingCommand : ManagementCmdletBase
    {
        internal const string GetAzureRmAutoscaleSettingParamGroup = "GetAutoscaleSetting";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the ResourceGroupName parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetAzureRmAutoscaleSettingParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

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
            this.WriteIdentifiedWarning(
                cmdletName: "Get-AzureRmAutoscaleSetting",
                topic: "Parameter deprecation", 
                message: "The DetailedOutput parameter will be deprecated in a future breaking change release.");
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                // Retrieve all the Autoscale settings for a resource group
                IPage<AutoscaleSettingResource> result = this.MonitorManagementClient.AutoscaleSettings.ListByResourceGroupAsync(resourceGroupName: this.ResourceGroupName).Result;

                var records = result.Select(e => this.DetailedOutput.IsPresent ? new PSAutoscaleSetting(e) : new PSAutoscaleSettingNoDetails(e));
                WriteObject(sendToPipeline: records, enumerateCollection: true);
            }
            else
            {
                // Retrieve a single Autoscale setting determined by the resource group and the rule name
                AutoscaleSettingResource result = this.MonitorManagementClient.AutoscaleSettings.GetAsync(resourceGroupName: this.ResourceGroupName, autoscaleSettingName: this.Name).Result;

                WriteObject(sendToPipeline: this.DetailedOutput.IsPresent ? new PSAutoscaleSetting(result) : new PSAutoscaleSettingNoDetails(result));
            }
        }
    }
}
