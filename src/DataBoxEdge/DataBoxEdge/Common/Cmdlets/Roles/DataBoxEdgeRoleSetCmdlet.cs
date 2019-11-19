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
using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;


namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Roles
{
    [Cmdlet(VerbsCommon.Set,
         Constants.Role,
         DefaultParameterSetName = SetByNameParameterSet,
         SupportsShouldProcess = true),
     OutputType(typeof(PSDataBoxEdgeRole))]
    public class DataBoxEdgeRoleSetCmdlet : AzureDataBoxEdgeCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";
        private const string SetByParentObjectParameterSet = "SetByParentObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = SetByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessageRoles.Name
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageRoles.ShareName
        )]
        [ValidateNotNullOrEmpty]
        public string[] ShareName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = SetByParentObjectParameterSet,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [ValidateNotNull]
        public PSDataBoxEdgeDevice DeviceObject;

        private Role GetResource()
        {
            return this.DataBoxEdgeManagementClient.Roles.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private IEnumerable<string> ListShareIdFromShareName()
        {
            return ShareName.Select(shareName => this.DataBoxEdgeManagementClient.Shares.Get(this.DeviceName,
                shareName,
                this.ResourceGroupName)
            ).Select(share => share.Id).ToList();
        }

        private Role SetShares(Role role)
        {
            if (role is IoTRole iotRole)
            {
                foreach (var shareId in ListShareIdFromShareName())
                {
                    iotRole.ShareMappings.Add(new MountPointMap(shareId));
                }
            }
            else
            {
                throw new PSArgumentException(HelpMessageRoles.InvalidRoleType);
            }

            return role;
        }

        private Role SetShareMappings(Role role)
        {
            role = SetShares(role);
            return this.DataBoxEdgeManagementClient.Roles.CreateOrUpdate(DeviceName,
                Name,
                role,
                ResourceGroupName);
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
                var resourceIdentifier = new DataBoxEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
                this.Name = resourceIdentifier.ResourceName;
            }

            var resource = GetResource();

            if (this.IsParameterBound(c => c.ShareName))
            {
                resource = SetShareMappings(resource);
            }

            WriteObject(new PSDataBoxEdgeRole(resource), true);
        }
    }
}