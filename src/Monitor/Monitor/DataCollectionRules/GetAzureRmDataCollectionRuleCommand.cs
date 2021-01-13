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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.DataCollectionRules
{
    /// <summary>
    /// Get a Data Collection Rule
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataCollectionRule", DefaultParameterSetName = BySubscription)]
    [OutputType(typeof(PSDataCollectionRuleResource))]
    public class GetAzureRmDataCollectionRuleCommand : ManagementCmdletBase
    {
        private const string ByName = "ByName";
        private const string ByResourceGroup = "ByResourceGroup";
        private const string BySubscription = "BySubscription";
        private const string ByResourceId = "ByResourceId";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the resource group parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByResourceGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the resource name parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string RuleName { get; set; }

        /// <summary>
        /// Gets or sets the ResourceId parameter
        /// </summary>
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource identifier")]
        [Alias("ResourceId")]
        [ValidateNotNullOrEmpty]
        public string RuleId { get; set; }
        #endregion

        /// <summary>
        /// Executes the cmdlet. Get-AzDataCollectionRule
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            List<DataCollectionRuleResource> apiResult = null;

            switch (ParameterSetName)
            {
                case BySubscription:
                    apiResult = MonitorManagementClient.DataCollectionRules.ListBySubscription().ToList();
                    break;
                case ByResourceGroup:
                    apiResult = MonitorManagementClient.DataCollectionRules.ListByResourceGroup(
                        resourceGroupName: ResourceGroupName).ToList();
                    break;
                case ByName:
                    var oneDcrByName = MonitorManagementClient.DataCollectionRules.Get(
                        resourceGroupName: ResourceGroupName,
                        dataCollectionRuleName: RuleName);
                    apiResult = new List<DataCollectionRuleResource> { oneDcrByName };
                    break;
                case ByResourceId:
                    var resourceIdentifier = new ResourceIdentifier(RuleId);
                    var oneDcrByRuleId = MonitorManagementClient.DataCollectionRules.Get(
                        resourceGroupName: resourceIdentifier.ResourceGroupName,
                        dataCollectionRuleName: resourceIdentifier.ResourceName);
                    apiResult = new List<DataCollectionRuleResource> { oneDcrByRuleId };
                    break;
                default:
                    throw new Exception("Unkown ParameterSetName");
            }

            var output = apiResult.Select(x => new PSDataCollectionRuleResource(x)).ToList();
            WriteObject(sendToPipeline: output, enumerateCollection: true);
        }
    }
}