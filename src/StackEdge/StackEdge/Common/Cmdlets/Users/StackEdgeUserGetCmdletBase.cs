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

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Users
{
    [Cmdlet(VerbsCommon.Get, Constants.User, DefaultParameterSetName = ListParameterSet
     ),
     OutputType(typeof(PSStackEdgeUser))]
    public class StackEdgeUserGetCmdletBase : AzureStackEdgeCmdletBase
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
            HelpMessage = HelpMessageUsers.NameHelpMessage,
            Position = 2)]
        [Parameter(Mandatory = false,
            ParameterSetName = GetByParentObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessageUsers.NameHelpMessage
        )]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageUsers.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
            ParameterSetName = GetByParentObjectParameterSet,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [ValidateNotNull]
        [Alias(Constants.DeviceAlias)]
        public PSStackEdgeDevice DeviceObject;

        private User GetResourceModel()
        {
            return this.StackEdgeManagementClient.Users.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private List<PSStackEdgeUser> GetByResourceName()
        {
            var resourceModel = GetResourceModel();
            return new List<PSStackEdgeUser>() {new PSStackEdgeUser(resourceModel)};
        }

        private IPage<User> ListResourceModel()
        {
            return this.StackEdgeManagementClient.Users.ListByDataBoxEdgeDevice(
                this.DeviceName,
                this.ResourceGroupName);
        }

        private IPage<User> ListResourceModel(string nextPageLink)
        {
            return this.StackEdgeManagementClient.Users.ListByDataBoxEdgeDeviceNext(
                nextPageLink
            );
        }


        private List<PSStackEdgeUser> ListPSResourceModels()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return GetByResourceName();
            }

            var resourceModel = ListResourceModel();
            var paginatedResult = new List<User>(resourceModel);
            while (!string.IsNullOrEmpty(resourceModel.NextPageLink))
            {
                resourceModel = ListResourceModel(resourceModel.NextPageLink);
                paginatedResult.AddRange(resourceModel);
            }

            return paginatedResult.Select(t => new PSStackEdgeUser(t)).ToList();
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

            var results = ListPSResourceModels();
            WriteObject(results, true);
        }
    }
}