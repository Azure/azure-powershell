﻿// ----------------------------------------------------------------------------------
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
using System.Management.Automation;

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Insights.DataCollectionRules
{
    /// <summary>
    /// Delete a Data Collection Endpoint
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataCollectionEndpoint", DefaultParameterSetName = ByName, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureRmDataCollectionEndpointCommand : ManagementCmdletBase
    {
        private const string ByName = "ByName";
        private const string ByInputObject = "ByInputObject";
        private const string ByResourceId = "ByResourceId";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the resource group parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the reource name parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the InputObject parameter
        /// </summary>
        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The data collection rule resource from the pipe")]
        [ValidateNotNull]
        public PSDataCollectionEndpointResource InputObject { get; set; }

        /// <summary>
        /// Gets or sets the ResourceId parameter
        /// </summary>
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource identifier")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the PassThru switch parameter to force return an object when removing the resource.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return true upon successful removal.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        /// <summary>
        /// Executes the cmdlet. Remove-AzDataCollectionEndpoint
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

            if (ShouldProcess(
                    target: string.Format("Data collection endpoint '{0}' from resource group '{1}'", this.Name, this.ResourceGroupName),
                    action: "Delete a data collection endpoint"))
            {
                this.MonitorManagementClient.DataCollectionEndpoints.DeleteWithHttpMessagesAsync(
                    resourceGroupName: ResourceGroupName,
                    dataCollectionEndpointName: Name).GetAwaiter().GetResult();

                if (this.PassThru.IsPresent)
                {
                    WriteObject(true);
                }
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