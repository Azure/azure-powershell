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
using System.Collections;
using System.Management.Automation;

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.DataCollectionRules
{
    /// <summary>
    /// Create a Data Collection Rule Association
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataCollectionRuleAssociation", DefaultParameterSetName = ByDataCollectionRuleId, SupportsShouldProcess = true)]
    [OutputType(typeof(PSDataCollectionRuleAssociationProxyOnlyResource))]
    public class NewAzureRmDataCollectionRuleAssociationCommand : ManagementCmdletBase
    {
        private const string ByDataCollectionRuleId = "ByDataCollectionRuleId";
        private const string ByInputObject = "ByInputObject";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the associated resource.
        /// </summary>
        [Parameter(ParameterSetName = ByDataCollectionRuleId, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource id to associate.")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource id to associate.")]
        [ValidateNotNullOrEmpty]
        public string ResourceUri { get; set; }

        /// <summary>
        /// Gets or sets the association name.
        /// </summary>
        [Parameter(ParameterSetName = ByDataCollectionRuleId, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource name.")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule.
        /// </summary>
        [Parameter(ParameterSetName = ByDataCollectionRuleId, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The data collection rule id.")]
        [ValidateNotNullOrEmpty]
        public string DataCollectionRuleId { get; set; }

        /// <summary>
        /// Gets or sets the association description.
        /// </summary>
        [Parameter(ParameterSetName = ByDataCollectionRuleId, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource description.")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource description.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule object.
        /// </summary>
        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "PSDataCollectionRuleResource Object.")]
        [ValidateNotNull]
        public PSDataCollectionRuleResource InputObject { get; set; }

        #endregion

        /// <summary>
        /// Executes the cmdlet. New-AzDataCollectionRuleAssociation
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            switch (ParameterSetName)
            {
                case ByDataCollectionRuleId:
                    ProcessRecordInternalByDataCollectionRuleId();
                    break;
                case ByInputObject:
                    DataCollectionRuleId = InputObject.Id;
                    ProcessRecordInternalByDataCollectionRuleId();
                    break;
                default:
                    throw new Exception("Unkown ParameterSetName");
            }
        }

        private void ProcessRecordInternalByDataCollectionRuleId()
        {
            var dcrResourceId = new ResourceIdentifier(DataCollectionRuleId);

            if (ShouldProcess(
                    target: string.Format("Name '{0}' in data collection rule '{1}' in resource group '{2}'", 
                                          Name, dcrResourceId.ResourceName, dcrResourceId.ResourceGroupName),
                    action: "Create a data collection rule association"))
            {
                var dcraResponse = MonitorManagementClient.DataCollectionRuleAssociations.Create(
                                    resourceUri: ResourceUri,
                                    associationName: Name,
                                    body: new DataCollectionRuleAssociationProxyOnlyResource(
                                        dataCollectionRuleId: DataCollectionRuleId,
                                        description: Description
                                    )
                                );

                var output = new PSDataCollectionRuleAssociationProxyOnlyResource(dcraResponse);
                WriteObject(sendToPipeline: output);
            }
        }
    }
}