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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.EdgeStorageContainers
{
    [Cmdlet(VerbsCommon.Get,
         Constants.EdgeStorageContainer,
         DefaultParameterSetName = ListParameterSet),
     OutputType(typeof(PSStackEdgeStorageContainer))]
    public class StackEdgeStorageContainerGetCmdlet : AzureStackEdgeCmdletBase
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessageEdgeStorageContainer.EdgeStorageAccountHelpMessage,
            Position = 2)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessageEdgeStorageContainer.EdgeStorageAccountHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices/storageAccounts", nameof(ResourceGroupName),
            nameof(DeviceName))]
        public string EdgeStorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessageEdgeStorageContainer.NameHelpMessage,
            Position = 3)]
        [Parameter(Mandatory = false,
            ParameterSetName = GetByParentObjectParameterSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessageEdgeStorageContainer.NameHelpMessage
        )]
        [ValidateNotNullOrEmpty]
        [Alias("EdgeStorageContainerName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = GetByParentObjectParameterSet,
            HelpMessage = HelpMessageEdgeStorageContainer.EdgeStorageAccountObjectHelpMessage)]
        [ValidateNotNull]
        [Alias(HelpMessageEdgeStorageContainer.EdgeStorageAccountAlias)]
        public PSStackEdgeStorageAccount EdgeStorageAccountObject;

        private Container GetResource()
        {
            return this.StackEdgeManagementClient.Containers.Get(
                this.DeviceName,
                this.EdgeStorageAccountName,
                this.Name,
                this.ResourceGroupName);
        }

        private List<PSStackEdgeStorageContainer> GetResourceByName()
        {
            var resource = GetResource();
            return new List<PSStackEdgeStorageContainer>()
            {
                new PSStackEdgeStorageContainer(resource)
            };
        }

        private IPage<Container> ListResource()
        {
            return this.StackEdgeManagementClient.Containers.ListByStorageAccount(
                this.DeviceName,
                this.EdgeStorageAccountName,
                this.ResourceGroupName);
        }

        private IPage<Container> ListResource(string nextPageLink)
        {
            return this.StackEdgeManagementClient.Containers.ListByStorageAccountNext(
                nextPageLink
            );
        }

        private List<PSStackEdgeStorageContainer> ListPSResource()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return GetResourceByName();
            }

            var listResource = ListResource();
            var paginatedResult = new List<Container>(listResource);
            while (!string.IsNullOrEmpty(listResource.NextPageLink))
            {
                listResource = ListResource(listResource.NextPageLink);
                paginatedResult.AddRange(listResource);
            }

            return paginatedResult.Select(t => new PSStackEdgeStorageContainer(t)).ToList();
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new StackEdgeStorageResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
                this.EdgeStorageAccountName = resourceIdentifier.EdgeStorageAccountName;
                this.Name = resourceIdentifier.Name;
            }

            if (this.IsParameterBound(c => this.EdgeStorageAccountObject))
            {
                this.ResourceGroupName = this.EdgeStorageAccountObject.ResourceGroupName;
                this.DeviceName = this.EdgeStorageAccountObject.DeviceName;
                this.EdgeStorageAccountName = this.EdgeStorageAccountObject.Name;
            }

            var results = ListPSResource();
            WriteObject(results, true);
        }
    }
}