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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.DataCollectionRules
{
    /// <summary>
    /// Update a Data Collection Endpoint
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataCollectionEndpoint", DefaultParameterSetName = ByName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSDataCollectionRuleResource))]
    public class SetAzureRmDataCollectionEndpointCommand : ManagementCmdletBase
    {
        private const string ByName = "ByName";
        private const string ByResourceId = "ByResourceId";
        private const string ByInputObject = "ByInputObject";

        #region Cmdlet parameters
        /// <summary>
        /// Gets or sets the data collection rule location.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource location.")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the resource group parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule name.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ResourceId parameter
        /// </summary>
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource identifier")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        
        /// <summary>
        /// Gets or sets the data collection rule object.
        /// </summary>
        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "PSDataCollectionEndpointResource Object.")]
        [ValidateNotNull]
        public PSDataCollectionEndpointResource InputObject { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule description.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource description.")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource description.")]
        public string Description { get; set; }

        //PublicNetworkAccess
        /// <summary>
        /// Gets or sets the configuration to set whether network access from public internet to the endpoints are allowed. Possible values include: 'Enabled', 'Disabled'
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "Gets or sets the configuration to set whether network access from public internet to the endpoints are allowed. Possible values include: 'Enabled', 'Disabled'")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource description.")]
        public string PublicNetworkAccess { get; set; }

        /// <summary>
        /// Gets or sets the data collection rule tags.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource tags.")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource tags.")]
        public Hashtable Tag { get; set; }
        #endregion

        /// <summary>
        /// Executes the cmdlet. Set-AzDataCollectionEndpoint
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            ResourceIdentifier resourceIdentifier;
            switch (ParameterSetName)
            {
                case ByName:
                    break;
                case ByResourceId:
                    resourceIdentifier = new ResourceIdentifier(ResourceId);
                    Name = resourceIdentifier.ResourceName;
                    ResourceGroupName = resourceIdentifier.ResourceGroupName;
                    break;
                case ByInputObject:
                    resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                    Name = resourceIdentifier.ResourceName;
                    ResourceGroupName = resourceIdentifier.ResourceGroupName;
                    PublicNetworkAccess = InputObject.NetworkAcls?.PublicNetworkAccess;
                    Location = InputObject.Location;
                    Description = InputObject.Description;
                    Tag = InputObject.Tags.ToHashtable();
                    break;
                default:
                    throw new Exception("Unknown ParameterSetName");
            }

            ReplaceDataCollectionRule();
        }

        private void ReplaceDataCollectionRule()
        {
            if (ShouldProcess(
                        target: string.Format("Data collection endpoint '{0}' in resource group '{1}'", Name, ResourceGroupName),
                        action: "Update a data collection endpoint"))
            {
                var dceResponse = MonitorManagementClient.DataCollectionEndpoints.Create(resourceGroupName: ResourceGroupName, dataCollectionEndpointName: Name, body: new DataCollectionEndpointResource(
                    location: Location,
                    description: Description,
                    immutableId: null,
                    configurationAccess: null,
                    logsIngestion: null,
                    networkAcls: new DataCollectionEndpointNetworkAcls(PublicNetworkAccess),
                    provisioningState: null,
                    tags: Tag != null ? TagsConversionHelper.CreateTagDictionary(Tag, validate: true) : null,
                    name: Name));

                var output = new PSDataCollectionEndpointResource(dceResponse);
                WriteObject(sendToPipeline: output);
            }
        }
    }
}