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
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Utils;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using System.Security;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Users
{
    [Cmdlet(VerbsCommon.New, Constants.User, DefaultParameterSetName = NewParameterSet,
         SupportsShouldProcess = true
     ),
     OutputType(typeof(PSStackEdgeDevice))]
    public class StackEdgeUserNewCmdletBase : AzureStackEdgeCmdletBase
    {
        private const string NewParameterSet = "NewParameterSet";

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageUsers.NameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageUsers.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = HelpMessageUsers.UserTypeHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Share", "ARM", "LocalManagement")]
        public string Type;

        [Parameter(Mandatory = true, HelpMessage = HelpMessageUsers.PasswordHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SecureString Password { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.EncryptionKeyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SecureString EncryptionKey { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private readonly string[] userTypes = new string[]
            {UserType.Share, UserType.ARM, UserType.LocalManagement};

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

        private string GetResourceAlreadyExistMessage()
        {
            return string.Format("'{0}'{1}{2}'.",
                HelpMessageUsers.ObjectName, Constants.ResourceAlreadyExists, this.Name);
        }

        private bool DoesResourceExists()
        {
            try
            {
                var resource = GetResource();
                if (resource == null) return false;
                var msg = GetResourceAlreadyExistMessage();
                throw new Exception(msg);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        private string GetUserType()
        {
            var userType = UserType.Share;
            if (string.IsNullOrEmpty(this.Type))
            {
                return userType;
            }

            if (Utility.IsOneOf(this.Type, userTypes))
            {
                return this.Type;
            }
            else
            {
                throw new PSArgumentException(HelpMessageUsers.InvalidUserType);
            }
        }

        private PSStackEdgeUser CreateResourceModel()
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
            var user = new User(GetUserType(), null, Name, encryptedPassword: encryptedSecret);
            return new PSStackEdgeUser(
                this.StackEdgeManagementClient.Users.CreateOrUpdate(
                    this.DeviceName,
                    this.Name,
                    user,
                    this.ResourceGroupName
                ));
        }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.Name,
                string.Format("Removing '{0}' in device '{1}' with name '{2}'.",
                    HelpMessageUsers.ObjectName, this.DeviceName, this.Name)))
            {
                DoesResourceExists();

                var results = new List<PSStackEdgeUser>()
                {
                    CreateResourceModel()
                };

                WriteObject(results, true);
            }
        }
    }
}