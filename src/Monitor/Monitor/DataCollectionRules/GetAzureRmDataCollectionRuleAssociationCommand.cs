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
    /// Get a Data Collection Rule Association
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataCollectionRuleAssociation", DefaultParameterSetName = ByAssociatedResource)]
    [OutputType(typeof(PSDataCollectionRuleAssociationProxyOnlyResource))]
    public class GetAzureRmDataCollectionRuleAssociationCommand : ManagementCmdletBase
    {
        private const string ByAssociatedResource = "ByAssociatedResource";
        private const string ByRule = "ByRule";
        private const string ByInputObject = "ByInputObject";
        private const string ByName = "ByName";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the associated resource.
        /// </summary>
        [Parameter(ParameterSetName = ByAssociatedResource, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The associated resource id.")]
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The associated resource id.")]
        [Alias("ResourceUri")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource group parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByRule, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule.
        /// </summary>
        [Parameter(ParameterSetName = ByRule, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The data collection rule name.")]
        [Alias("DataCollectionRuleName")]
        [ValidateNotNullOrEmpty]
        public string RuleName { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule object.
        /// </summary>
        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "PSDataCollectionRuleResource Object.")]
        [ValidateNotNull]
        public PSDataCollectionRuleResource InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource name parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string AssociationName { get; set; }

        #endregion

        /// <summary>
        /// Executes the cmdlet. Get-AzDataCollectionRuleAssociation
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            List<DataCollectionRuleAssociationProxyOnlyResource> apiResult = null;

            switch (ParameterSetName)
            {
                case ByAssociatedResource:
                    apiResult = this.MonitorManagementClient.DataCollectionRuleAssociations.ListByResource(
                        resourceUri: TargetResourceId
                    ).ToList();
                    break;
                case ByRule:
                    apiResult = this.MonitorManagementClient.DataCollectionRuleAssociations.ListByRule(
                        resourceGroupName: ResourceGroupName,
                        dataCollectionRuleName: RuleName
                    ).ToList();
                    break;
                case ByInputObject:
                    var dcrResourceIdentifier = new ResourceIdentifier(InputObject.Id);
                    apiResult = this.MonitorManagementClient.DataCollectionRuleAssociations.ListByRule(
                        resourceGroupName: dcrResourceIdentifier.ResourceGroupName,
                        dataCollectionRuleName: InputObject.Name
                    ).ToList();
                    break;
                case ByName:
                    var oneAssoc = this.MonitorManagementClient.DataCollectionRuleAssociations.Get(
                        resourceUri: TargetResourceId,
                        associationName: AssociationName
                    );
                    apiResult = new List<DataCollectionRuleAssociationProxyOnlyResource> { oneAssoc };
                    break;
                default:
                    throw new Exception("Unkown ParameterSetName");
            }

            var output = apiResult.Select(x => new PSDataCollectionRuleAssociationProxyOnlyResource(x)).ToList();
            WriteObject(sendToPipeline: output, enumerateCollection: true);
        }
    }
}