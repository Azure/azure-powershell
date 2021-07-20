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
using System.Collections.Generic;
using System.Management.Automation;

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor;

namespace Microsoft.Azure.Commands.Insights.DataCollectionRules
{
    /// <summary>
    /// Update a Data Collection Endpoint
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataCollectionEndpoint", DefaultParameterSetName = ByName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSDataCollectionEndpointResource))]
    public class UpdateAzureRmDataCollectionEndpointCommand : ManagementCmdletBase
    {
        private const string ByName = "ByName";
        private const string ByInputObject = "ByInputObject";
        private const string ByResourceId = "ByResourceId";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the resource group parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the data collection endpoint name.
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
        /// Gets or sets the InputObject parameter
        /// </summary>
        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The data collection endpoint resource from the pipe")]
        [ValidateNotNull]
        public PSDataCollectionEndpointResource InputObject { get; set; }

        /// <summary>
        /// Gets or sets the data collection endpoint tags.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource tags.")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource tags.")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource tags.")]
        public Hashtable Tag { get; set; }
        #endregion

        /// <summary>
        /// Executes the cmdlet. Update-AzDataCollectionEndpoint
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            switch (ParameterSetName)
            {
                case ByName:
                    break;
                case ByInputObject:
                    ResourceId = InputObject.Id;
                    SetNameAndResourceFromResourceId();
                    break;
                case ByResourceId:
                    SetNameAndResourceFromResourceId();
                    break;
                default:
                    throw new Exception("Unkown ParameterSetName");
            }

            var resourceForUpdate = new Dictionary<string, string>();

            if (Tag != null)
                resourceForUpdate = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            if (ShouldProcess(
                        target: string.Format("Data collection endpoint '{0}' in resource group '{1}'", Name, ResourceGroupName),
                        action: "Update a data collection endpoint"))
            {
                var dceResponse = this.MonitorManagementClient.DataCollectionEndpoints.Update(
                    resourceGroupName: ResourceGroupName,
                    dataCollectionEndpointName: Name,
                    tags: resourceForUpdate
                );

                var output = new PSDataCollectionEndpointResource(dceResponse);
                WriteObject(sendToPipeline: output);
            }
        }

        private void SetNameAndResourceFromResourceId()
        {
            var resourceIdentifier = new ResourceIdentifier(ResourceId);
            Name = resourceIdentifier.ResourceName;
            ResourceGroupName = resourceIdentifier.ResourceGroupName;
        }
    }
}