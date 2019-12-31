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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ResourceModel = Microsoft.Azure.Management.DataBoxEdge.Models.Role;
using PSResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeRole;


namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Roles
{
    [Cmdlet(VerbsCommon.Set,
         Constants.Role,
         DefaultParameterSetName = SetByNameParameterSet,
         SupportsShouldProcess = true),
     OutputType(typeof(PSResourceModel))]
    public class DataBoxEdgeRoleSetCmdletBase : AzureDataBoxEdgeCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";

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
            HelpMessage = HelpMessageRoles.Name,
            Position = 2
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageRoles.ShareName
        )]
        [AllowEmptyCollection]
        [ValidateNotNull]
        public string[] ShareName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = SetByInputObjectParameterSet,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [ValidateNotNull]
        [Alias("Role")]
        public PSResourceModel InputObject;

        private ResourceModel GetResourceModel()
        {
            return this.DataBoxEdgeManagementClient.Roles.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private string GetShareIdFromShareName(string shareName)
        {
            return this.DataBoxEdgeManagementClient.Shares.Get(this.DeviceName,
                shareName,
                this.ResourceGroupName).Id;
        }

        private ResourceModel SetShareMountPoint(ResourceModel resourceModel)
        {
            if (resourceModel is IoTRole iotRole)
            {
                iotRole.ShareMappings = new List<MountPointMap>();
                foreach (var shareName in ShareName)
                {
                    var shareId = GetShareIdFromShareName(shareName);
                    iotRole.ShareMappings.Add(new MountPointMap(shareId));
                }

                return resourceModel;
            }

            throw new PSArgumentException(HelpMessageRoles.InvalidRoleType);
        }

        private ResourceModel UpdateResourceModel(ResourceModel resourceModel)
        {
            return this.DataBoxEdgeManagementClient.Roles.CreateOrUpdate(DeviceName,
                Name,
                resourceModel,
                ResourceGroupName);
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => this.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.DeviceName = this.InputObject.DeviceName;
                this.Name = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new DataBoxEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
                this.Name = resourceIdentifier.ResourceName;
            }

            var resourceModel = GetResourceModel();

            if (this.IsParameterBound(c => c.ShareName))
            {
                resourceModel = SetShareMountPoint(resourceModel);
            }

            resourceModel = UpdateResourceModel(resourceModel);

            WriteObject(new PSResourceModel(resourceModel), true);
        }
    }
}