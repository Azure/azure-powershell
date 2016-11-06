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

using AutoMapper;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineCustomScriptExtension,
        SupportsShouldProcess = true,
        DefaultParameterSetName = SetCustomScriptExtensionByContainerBlobsParamSetName)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMCustomScriptExtensionCommand : SetAzureVMExtensionBaseCmdlet
    {
        protected const string SetCustomScriptExtensionByContainerBlobsParamSetName = "SetCustomScriptExtensionByContainerAndFileNames";
        protected const string SetCustomScriptExtensionByUrisParamSetName = "SetCustomScriptExtensionByUriLinks";

        private const string fileUrisKey = "fileUris";
        private const string commandToExecuteKey = "commandToExecute";
        private const string storageAccountNameKey = "storageAccountName";
        private const string storageAccountKeyKey = "storageAccountKey";


        private const string poshCmdFormatStr = "powershell {0} -file {1} {2}";
        private const string defaultPolicyStr = "Unrestricted";
        private const string policyFormatStr = "-ExecutionPolicy {0}";

        [Parameter(
            ParameterSetName = SetCustomScriptExtensionByContainerBlobsParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Name of the Container.")]
        [ValidateNotNullOrEmpty]
        public string ContainerName { get; set; }

        [Parameter(
            ParameterSetName = SetCustomScriptExtensionByContainerBlobsParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Blob Files in the Container.")]
        [ValidateNotNullOrEmpty]
        public string[] FileName { get; set; }

        [Parameter(
             ParameterSetName = SetCustomScriptExtensionByContainerBlobsParamSetName,
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The Storage Account Name.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(
            ParameterSetName = SetCustomScriptExtensionByContainerBlobsParamSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Storage Endpoint Suffix.")]
        [ValidateNotNullOrEmpty]
        public string StorageEndpointSuffix { get; set; }

        [Parameter(
            ParameterSetName = SetCustomScriptExtensionByContainerBlobsParamSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Storage Account Key.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountKey { get; set; }

        [Parameter(
            ParameterSetName = SetCustomScriptExtensionByUrisParamSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The File URIs.")]
        [ValidateNotNullOrEmpty]
        public string[] FileUri { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Run File to Execute in PowerShell on the VM.")]
        [ValidateNotNullOrEmpty]
        [Alias("RunFile", "Command")]
        public string Run { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Argument String for the Run File.")]
        [ValidateNotNullOrEmpty]
        public string Argument { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Set command to execute in private config.")]
        public SwitchParameter SecureExecution { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(VirtualMachineCustomScriptExtensionContext.ExtensionDefaultName, VerbsCommon.Set))
            {
                ExecuteClientAction(() =>
                {
                    if (string.Equals(this.ParameterSetName, SetCustomScriptExtensionByContainerBlobsParamSetName))
                    {
                        this.StorageEndpointSuffix = string.IsNullOrEmpty(this.StorageEndpointSuffix) ?
                            DefaultProfile.Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix) : this.StorageEndpointSuffix;
                        var sName = string.IsNullOrEmpty(this.StorageAccountName) ? GetStorageName() : this.StorageAccountName;
                        var sKey = string.IsNullOrEmpty(this.StorageAccountKey) ? GetStorageKey(sName) : this.StorageAccountKey;

                        if (this.FileName != null && this.FileName.Any())
                        {
                            this.FileUri = (from blobName in this.FileName
                                            select GetSasUrlStr(sName, sKey, this.ContainerName, blobName)).ToArray();

                            if (string.IsNullOrEmpty(this.Run))
                            {
                                WriteWarning(Microsoft.Azure.Commands.Compute.Properties.Resources.CustomScriptExtensionTryToUseTheFirstSpecifiedFileAsRunScript);
                                this.Run = this.FileName[0];
                            }
                        }
                    }

                    var policyStr = string.Format(policyFormatStr, defaultPolicyStr);
                    var commandToExecute = string.Format(poshCmdFormatStr, policyStr, this.Run, this.Argument);

                    var privateSettings = GetPrivateConfiguration();

                    var publicSettings = new Hashtable();
                    publicSettings.Add(fileUrisKey, FileUri ?? new string[] { });

                    if (this.SecureExecution.IsPresent)
                    {
                        if (privateSettings == null)
                        {
                            privateSettings = new Hashtable();
                        }
                        privateSettings.Add(commandToExecuteKey, commandToExecute ?? "");
                    }
                    else
                    {
                        publicSettings.Add(commandToExecuteKey, commandToExecute ?? "");
                    }

                    var parameters = new VirtualMachineExtension
                    {
                        Location = this.Location,
                        Publisher = VirtualMachineCustomScriptExtensionContext.ExtensionDefaultPublisher,
                        VirtualMachineExtensionType = VirtualMachineCustomScriptExtensionContext.ExtensionDefaultName,
                        TypeHandlerVersion = (this.TypeHandlerVersion) ?? VirtualMachineCustomScriptExtensionContext.ExtensionDefaultVersion,
                        Settings = publicSettings,
                        ProtectedSettings = privateSettings,
                        AutoUpgradeMinorVersion = !this.DisableAutoUpgradeMinorVersion.IsPresent,
                        ForceUpdateTag = this.ForceRerun
                    };

                    var op = this.VirtualMachineExtensionClient.CreateOrUpdateWithHttpMessagesAsync(
                    this.ResourceGroupName,
                    this.VMName,
                    this.Name,
                    parameters).GetAwaiter().GetResult();
                    var result = Mapper.Map<PSAzureOperationResponse>(op);
                    WriteObject(result);
                });
            }
        }

        protected string GetStorageName()
        {
            return DefaultProfile.Context.Subscription.GetProperty(AzureSubscription.Property.StorageAccount);
        }

        protected string GetStorageKey(string storageName)
        {
            string storageKey = string.Empty;

            if (!string.IsNullOrEmpty(storageName))
            {
                var storageClient = AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(DefaultProfile.Context,
                        AzureEnvironment.Endpoint.ResourceManager);

                var storageAccount = storageClient.StorageAccounts.GetProperties(this.ResourceGroupName, storageName);

                if (storageAccount != null)
                {
                    var keys = storageClient.StorageAccounts.ListKeys(this.ResourceGroupName, storageName);
                    if (keys != null)
                    {
                        storageKey = !string.IsNullOrEmpty(keys.Key1) ? keys.Key1 : keys.Key2;
                    }
                }
            }

            return storageKey;
        }

        protected string GetSasUrlStr(string storageName, string storageKey, string containerName, string blobName)
        {
            var storageClient = AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(DefaultProfile.Context,
                        AzureEnvironment.Endpoint.ResourceManager);
            var cred = new StorageCredentials(storageName, storageKey);
            var storageAccount = string.IsNullOrEmpty(this.StorageEndpointSuffix)
                               ? new CloudStorageAccount(cred, true)
                               : new CloudStorageAccount(cred, this.StorageEndpointSuffix, true);

            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            var cloudBlob = container.GetBlockBlobReference(blobName);
            var sasToken = cloudBlob.GetSharedAccessSignature(
                new SharedAccessBlobPolicy()
                {
                    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24.0),
                    Permissions = SharedAccessBlobPermissions.Read
                });

            // Try not to use a Uri object in order to keep the following
            // special characters in the SAS signature section:
            //     '+'   ->   '%2B'
            //     '/'   ->   '%2F'
            //     '='   ->   '%3D'
            return cloudBlob.Uri + sasToken;
        }

        protected Hashtable GetPrivateConfiguration()
        {
            if (string.IsNullOrEmpty(this.StorageAccountName) || string.IsNullOrEmpty(this.StorageAccountKey))
            {
                return null;
            }
            else
            {
                var privateSettings = new Hashtable();
                privateSettings.Add(storageAccountNameKey, StorageAccountName);
                privateSettings.Add(storageAccountKeyKey, StorageAccountKey);
                return privateSettings;
            }
        }
    }
}
