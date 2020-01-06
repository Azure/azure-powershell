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
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Utils;
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;
using PSResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeUser;
using ResourceModel = Microsoft.Azure.Management.DataBoxEdge.Models.User;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Users
{
    [Cmdlet(VerbsCommon.Set, Constants.User, DefaultParameterSetName = SetByNameParameterSet,
         SupportsShouldProcess = true),
     OutputType(typeof(PSResourceModel))]
    public class DataBoxEdgeUserSetCmdletBase : AzureDataBoxEdgeCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = SetByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = SetByInputObjectParameterSet,
            HelpMessage = Constants.InputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSResourceModel InputObject { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = HelpMessageUsers.NameHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
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

        private ResourceModel GetResource()
        {
            return this.DataBoxEdgeManagementClient.Users.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private ResourceModel UpdateUser(ResourceModel user)
        {
            var password = this.Password.ConvertToString();
            PasswordUtility.ValidateUserPasswordPattern(nameof(this.Password), password);

            var encryptedSecret =
                DataBoxEdgeManagementClient.Devices.GetAsymmetricEncryptedSecret(
                    this.DeviceName,
                    this.ResourceGroupName,
                    password,
                    this.GetKeyForEncryption()
                );
            user.EncryptedPassword = encryptedSecret;
            return this.DataBoxEdgeManagementClient.Users.CreateOrUpdate(
                this.DeviceName,
                this.Name,
                user,
                this.ResourceGroupName);
        }

        private PSResourceModel SetResource()
        {
            return new PSDataBoxEdgeUser(UpdateUser(GetResource()));
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var identifier = new DataBoxEdgeResourceIdentifier(this.ResourceId);
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
                var results = new List<PSDataBoxEdgeUser>()
                {
                    SetResource()
                };

                WriteObject(results, true);
            }
        }
    }
}