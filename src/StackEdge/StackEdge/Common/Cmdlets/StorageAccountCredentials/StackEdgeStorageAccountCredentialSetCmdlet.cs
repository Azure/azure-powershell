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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security;


namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.StorageAccountCredentials
{
    [Cmdlet(VerbsCommon.Set, Constants.Sac,
         SupportsShouldProcess = true,
         DefaultParameterSetName = SetByNameParameterSet
     ),
     OutputType(typeof(PSStackEdgeStorageAccountCredential))]
    public class StackEdgeStorageAccountCredentialSetCmdlet : AzureStackEdgeCmdletBase
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
            ParameterSetName = SetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessageStorageAccountCredential.StorageAccountNameHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageStorageAccountCredential.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
            ParameterSetName = SetByParentObjectParameterSet,
            HelpMessage = Constants.InputObjectHelpMessage)]
        [ValidateNotNull]
        [Alias(HelpMessageStorageAccountCredential.InputObjectAlias)]
        public PSStackEdgeStorageAccountCredential InputObject;

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageStorageAccountCredential.StorageAccountAccessKeyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SecureString StorageAccountAccessKey { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = Constants.EncryptionKeyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SecureString EncryptionKey { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private string GetKeyForEncryption()
        {
            var encryptionKey = this.EncryptionKey.ConvertToString();
            return encryptionKey;
        }

        private StorageAccountCredential GetResource()
        {
            return this.StackEdgeManagementClient.StorageAccountCredentials.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private PSStackEdgeStorageAccountCredential UpdateResource(StorageAccountCredential storageAccountCredential)
        {
            var encryptedSecret =
                StackEdgeManagementClient.Devices.GetAsymmetricEncryptedSecret(
                    this.DeviceName,
                    this.ResourceGroupName,
                    this.StorageAccountAccessKey.ConvertToString(),
                    GetKeyForEncryption()
                );
            return new PSStackEdgeStorageAccountCredential(
                this.StackEdgeManagementClient.StorageAccountCredentials.CreateOrUpdate(
                    this.DeviceName,
                    this.Name,
                    new StorageAccountCredential(
                        storageAccountCredential.Name,
                        storageAccountCredential.SslStatus,
                        storageAccountCredential.AccountType,
                        userName: storageAccountCredential.Name,
                        accountKey: encryptedSecret
                    ),
                    this.ResourceGroupName
                ));
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new StackEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => this.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.DeviceName = this.InputObject.DeviceName;
                this.Name = this.InputObject.Name;
            }

            var results = new List<PSStackEdgeStorageAccountCredential>()
            {
                UpdateResource(GetResource())
            };
            WriteObject(results, true);
        }
    }
}