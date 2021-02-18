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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;


namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.EdgeStorageAccounts
{
    [Cmdlet(VerbsCommon.Get, Constants.EdgeStorageAccount, DefaultParameterSetName = ListParameterSet),
     OutputType(typeof(PSStackEdgeStorageAccount))]
    public class StackEdgeStorageAccountGetCmdlet : AzureStackEdgeCmdletBase
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = GetByParentObjectParameterSet,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [ValidateNotNull]
        [Alias(Constants.DeviceAlias)]
        public PSStackEdgeDevice DeviceObject;

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
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [Parameter(Mandatory = false,
            ParameterSetName = GetByParentObjectParameterSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessageEdgeStorageAccount.NameHelpMessage
        )]
        [Alias(HelpMessageEdgeStorageAccount.EdgeStorageAccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        private StorageAccount GetResource()
        {
            return this.StackEdgeManagementClient.StorageAccounts.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private List<PSStackEdgeStorageAccount> GetResourceByName()
        {
            var resource = GetResource();
            return new List<PSStackEdgeStorageAccount>() {new PSStackEdgeStorageAccount(resource)};
        }

        private IPage<StorageAccount> ListResource()
        {
            return this.StackEdgeManagementClient.StorageAccounts.ListByDataBoxEdgeDevice(
                this.DeviceName,
                this.ResourceGroupName);
        }

        private IPage<StorageAccount> ListResource(string nextPageLink)
        {
            return this.StackEdgeManagementClient.StorageAccounts.ListByDataBoxEdgeDeviceNext(
                nextPageLink
            );
        }

        private List<PSStackEdgeStorageAccount> ListPSResource()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return GetResourceByName();
            }

            var listResource = ListResource();
            var paginatedResult = new List<StorageAccount>(listResource);
            while (!string.IsNullOrEmpty(listResource.NextPageLink))
            {
                listResource = ListResource(listResource.NextPageLink);
                paginatedResult.AddRange(listResource);
            }

            return paginatedResult.Select(t => new PSStackEdgeStorageAccount(t)).ToList();
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => this.DeviceObject))
            {
                this.ResourceGroupName = this.DeviceObject.ResourceGroupName;
                this.DeviceName = this.DeviceObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new StackEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
                this.Name = resourceIdentifier.ResourceName;
            }

            var results = ListPSResource();
            WriteObject(results, true);
        }
    }
}