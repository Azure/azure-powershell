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
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;
using Microsoft.WindowsAzure.Commands.Common;


namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.StorageAccountCredential
{
    [Cmdlet(VerbsCommon.Set, Constants.Sac,
         SupportsShouldProcess = true,
         DefaultParameterSetName = SetByNameParameterSet
     ),
     OutputType(typeof(PSDataBoxEdgeStorageAccountCredential))]
    public class DataBoxEdgeStorageAccountCredentialSetCmdlet : AzureDataBoxEdgeCmdletBase
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
        [Alias("StorageAccountName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
            ParameterSetName = SetByParentObjectParameterSet,
            HelpMessage = Constants.InputObjectHelpMessage)]
        [ValidateNotNull]
        [Alias("StorageAccountCredential")]
        public PSDataBoxEdgeStorageAccountCredential InputObject;

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

        private Management.DataBoxEdge.Models.StorageAccountCredential GetResource()
        {
            return this.DataBoxEdgeManagementClient.StorageAccountCredentials.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private PSDataBoxEdgeStorageAccountCredential UpdateResource(Management.DataBoxEdge.Models.StorageAccountCredential storageAccountCredential)
        {
            var encryptedSecret =
                DataBoxEdgeManagementClient.Devices.GetAsymmetricEncryptedSecret(
                    this.DeviceName,
                    this.ResourceGroupName,
                    this.StorageAccountAccessKey.ConvertToString(),
                    GetKeyForEncryption()
                );
            return new PSDataBoxEdgeStorageAccountCredential(
                this.DataBoxEdgeManagementClient.StorageAccountCredentials.CreateOrUpdate(
                    this.DeviceName,
                    this.Name,
                    new Management.DataBoxEdge.Models.StorageAccountCredential(
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
                var resourceIdentifier = new DataBoxEdgeResourceIdentifier(this.ResourceId);
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

            var results = new List<PSDataBoxEdgeStorageAccountCredential>()
            {
                UpdateResource(GetResource())
            };
            WriteObject(results, true);
        }
    }
}