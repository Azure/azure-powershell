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

using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Shares
{
    [Cmdlet(VerbsCommon.Set, Constants.Share, DefaultParameterSetName = SmbParameterSet,
         SupportsShouldProcess = true),
     OutputType(typeof(PSStackEdgeShare))]
    public class StackEdgeShareSetCmdletBase : AzureStackEdgeCmdletBase
    {
        private const string SmbParameterSet = "SmbParameterSet";
        private const string NfsParameterSet = "NfsParameterSet";

        private const string UpdateByResourceIdSmbParameterSet = "UpdateByResourceIdSmbParameterSet";
        private const string UpdateByResourceIdNfsParameterSet = "UpdateByResourceIdNfsParameterSet";

        private const string UpdateByInputObjectSmbParameterSet = "UpdateByInputObjectSmbParameterSet";
        private const string UpdateByInputObjectNfsParameterSet = "UpdateByInputObjectNfsParameterSet";

        [Parameter(
            Mandatory = true,
            ParameterSetName = UpdateByResourceIdSmbParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [Parameter(
            Mandatory = true,
            ParameterSetName = UpdateByResourceIdNfsParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = UpdateByInputObjectSmbParameterSet,
            HelpMessage = Constants.InputObjectHelpMessage
        )]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = UpdateByInputObjectNfsParameterSet,
            HelpMessage = Constants.InputObjectHelpMessage
        )]
        [ValidateNotNull]
        [Alias(HelpMessageShare.InputObjectAlias)]
        public PSStackEdgeShare InputObject { get; set; }


        [Parameter(Mandatory = true,
            ParameterSetName = NfsParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true,
            ParameterSetName = SmbParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = NfsParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = SmbParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = NfsParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [Parameter(Mandatory = true,
            ParameterSetName = SmbParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageShare.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = SmbParameterSet,
            HelpMessage = HelpMessageShare.SetUserAccessRightsHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = UpdateByResourceIdSmbParameterSet,
            HelpMessage = HelpMessageShare.SetUserAccessRightsHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = UpdateByInputObjectSmbParameterSet,
            HelpMessage = HelpMessageShare.SetUserAccessRightsHelpMessage)]
        [ValidateNotNullOrEmpty]
        public Hashtable[] UserAccessRight { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = NfsParameterSet,
            HelpMessage = HelpMessageShare.SetClientAccessRightsHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = UpdateByResourceIdNfsParameterSet,
            HelpMessage = HelpMessageShare.SetClientAccessRightsHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = UpdateByInputObjectNfsParameterSet,
            HelpMessage = HelpMessageShare.SetClientAccessRightsHelpMessage)]
        [ValidateNotNullOrEmpty]
        public Hashtable[] ClientAccessRight { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private string GetUserId(string username)
        {
            var user = this.StackEdgeManagementClient.Users.Get(
                this.DeviceName,
                username,
                this.ResourceGroupName
            );
            return user.Id;
        }

        private Share GetResourceModel()
        {
            return this.StackEdgeManagementClient.Shares.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.DeviceName = this.InputObject.DeviceName;
                this.Name = this.InputObject.Name;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resource = new StackEdgeResourceIdentifier(this.ResourceId);
                this.DeviceName = resource.DeviceName;
                this.ResourceGroupName = resource.ResourceGroupName;
                this.Name = resource.Name;
            }

            var share = this.GetResourceModel();

            if (this.IsParameterBound(c => c.ClientAccessRight))
            {
                share.ClientAccessRights = new List<ClientAccessRight>();
                foreach (var clientAccessRight in this.ClientAccessRight)
                {
                    var accessRightPolicy = HashtableToDictionary<string, string>(clientAccessRight);
                    share.ClientAccessRights.Add(
                        new ClientAccessRight(
                            accessRightPolicy.GetOrNull("ClientId"),
                            accessRightPolicy.GetOrNull("AccessRight")
                        )
                    );
                }
            }

            if (this.IsParameterBound(c => c.UserAccessRight))
            {
                share.UserAccessRights = new List<UserAccessRight>();
                foreach (var userAccessRight in this.UserAccessRight)
                {
                    var accessRightPolicy = HashtableToDictionary<string, string>(userAccessRight);

                    share.UserAccessRights.Add(
                        new UserAccessRight(
                            GetUserId(accessRightPolicy.GetOrNull("Username")),
                            accessRightPolicy.GetOrNull("AccessRight")
                        ));
                }
            }

            if (this.ShouldProcess(this.Name,
                string.Format("Updating '{0}' in device '{1}' with name '{2}'.",
                    HelpMessageShare.ObjectName, this.DeviceName, this.Name)))
            {
                share = this.StackEdgeManagementClient.Shares.CreateOrUpdate(
                    this.DeviceName,
                    this.Name,
                    share,
                    this.ResourceGroupName);
                var results = new List<PSStackEdgeShare>()
                {
                    new PSStackEdgeShare(share)
                };
                WriteObject(results, true);
            }
        }
    }
}