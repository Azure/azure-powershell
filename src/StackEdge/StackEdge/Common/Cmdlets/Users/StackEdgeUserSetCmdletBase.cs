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
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Utils;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Users
{
    [Cmdlet(VerbsCommon.Set, Constants.User, DefaultParameterSetName = SetByNameParameterSet,
         SupportsShouldProcess = true),
     OutputType(typeof(PSStackEdgeUser))]
    public class StackEdgeUserSetCmdletBase : AzureStackEdgeCmdletBase
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
            ParameterSetName = SetByInputObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.InputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageUsers.InputObjectAlias)]
        public PSStackEdgeUser InputObject { get; set; }

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
            ParameterSetName = SetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessageUsers.NameHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageUsers.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageUsers.PasswordHelpMessage)]
        [ValidateNotNullOrEmpty]

        public SecureString Password { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.EncryptionKeyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SecureString EncryptionKey { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private string GetKeyForEncryption()
        {
            return this.EncryptionKey.ConvertToString();
        }

        private User GetResource()
        {
            return this.StackEdgeManagementClient.Users.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private User UpdateUser(User user)
        {
            var password = this.Password.ConvertToString();
            PasswordUtility.ValidateUserPasswordPattern(nameof(this.Password), password);

            var encryptedSecret =
                StackEdgeManagementClient.Devices.GetAsymmetricEncryptedSecret(
                    this.DeviceName,
                    this.ResourceGroupName,
                    password,
                    this.GetKeyForEncryption()
                );
            user.EncryptedPassword = encryptedSecret;
            return this.StackEdgeManagementClient.Users.CreateOrUpdate(
                this.DeviceName,
                this.Name,
                user,
                this.ResourceGroupName);
        }

        private PSStackEdgeUser SetResource()
        {
            return new PSStackEdgeUser(UpdateUser(GetResource()));
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var identifier = new StackEdgeResourceIdentifier(this.ResourceId);
                this.Name = Name;
                this.DeviceName = identifier.DeviceName;
                this.ResourceGroupName = identifier.ResourceGroupName;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.Name = this.InputObject.Name;
                this.DeviceName = this.InputObject.DeviceName;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
            }

            if (this.ShouldProcess(this.Name,
                string.Format("Updating '{0}' in device '{1}' with name '{2}'.",
                    HelpMessageUsers.ObjectName, this.DeviceName, this.Name)))
            {
                var results = new List<PSStackEdgeUser>()
                {
                    SetResource()
                };

                WriteObject(results, true);
            }
        }
    }
}