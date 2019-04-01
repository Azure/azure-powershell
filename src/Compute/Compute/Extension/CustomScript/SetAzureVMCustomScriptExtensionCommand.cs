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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMCustomScriptExtension",
        SupportsShouldProcess = true,
        DefaultParameterSetName = ByNameWithContainerParameterSet)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMCustomScriptExtensionCommand : SetAzureVMExtensionBaseCmdlet
    {
        private const string WithContainerAndFileNamesParameterSet = "WithContainerAndFileNamesParameterSet";
        private const string WithUrisParameterSet = "WithFileUriParameterSet";

        private const string ByNameParameterSet = "ByName";
        private const string ByParentObjectParameterSet = "ByParentObject";
        private const string ByResourceIdParameterSet = "ByResourceId";
        private const string ByInputObjectParameterSet = "ByInputObject";

        protected const string ByNameWithContainerParameterSet = ByNameParameterSet + WithContainerAndFileNamesParameterSet;
        protected const string ByParentObjectWithContainerParameterSet = ByParentObjectParameterSet + WithContainerAndFileNamesParameterSet;
        protected const string ByResourceIdWithContainerParameterSet = ByResourceIdParameterSet + WithContainerAndFileNamesParameterSet;
        protected const string ByInputObjectWithContainerParameterSet = ByInputObjectParameterSet + WithContainerAndFileNamesParameterSet;

        protected const string ByNameWithUrisParameterSet = ByNameParameterSet + WithUrisParameterSet;
        protected const string ByParentObjectWithUrisParameterSet = ByParentObjectParameterSet + WithUrisParameterSet;
        protected const string ByResourceIdWithUrisParameterSet = ByResourceIdParameterSet + WithUrisParameterSet;
        protected const string ByInputObjectWithUrisParameterSet = ByInputObjectParameterSet + WithUrisParameterSet;

        private const string fileUrisKey = "fileUris";
        private const string commandToExecuteKey = "commandToExecute";
        private const string storageAccountNameKey = "storageAccountName";
        private const string storageAccountKeyKey = "storageAccountKey";


        private const string poshCmdFormatStr = "powershell {0} -file {1} {2}";
        private const string defaultPolicyStr = "Unrestricted";
        private const string policyFormatStr = "-ExecutionPolicy {0}";

        [Parameter(
            ParameterSetName = ByNameWithContainerParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            ParameterSetName = ByNameWithUrisParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public new string ResourceGroupName { get; set; }

        // TopLevelResourceName
        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = ByNameWithContainerParameterSet,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [Parameter(
            ParameterSetName = ByNameWithUrisParameterSet,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public new string VMName { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            ParameterSetName = ByNameWithContainerParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name.")]
        [Parameter(
            ParameterSetName = ByNameWithUrisParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name.")]
        [Parameter(
            ParameterSetName = ByParentObjectWithContainerParameterSet,
            Mandatory = true,
            HelpMessage = "The extension name.")]
        [Parameter(
            ParameterSetName = ByParentObjectWithUrisParameterSet,
            Mandatory = true,
            HelpMessage = "The extension name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines/extensions", "ResourceGroupName", "VMName")]
        [ValidateNotNullOrEmpty]
        public new string Name { get; set; }

        // TopLevelResourceObject
        [Parameter(
            ParameterSetName = ByParentObjectWithContainerParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "VM object.")]
        [Parameter(
            ParameterSetName = ByParentObjectWithUrisParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "VM object.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VMObject { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdWithContainerParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "VM extension ResourceID.")]
        [Parameter(
            ParameterSetName = ByResourceIdWithUrisParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "VM extension ResourceID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectWithContainerParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "VM extension object.")]
        [Parameter(
            ParameterSetName = ByInputObjectWithUrisParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "VM extension object.")]
        [ValidateNotNullOrEmpty]
        public VirtualMachineCustomScriptExtensionContext InputObject { get; set; }

        [Parameter(
            ParameterSetName = ByNameWithContainerParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Name of the Container.")]
        [Parameter(
            ParameterSetName = ByParentObjectWithContainerParameterSet,
            Mandatory = true,
            HelpMessage = "The Name of the Container.")]
        [Parameter(
            ParameterSetName = ByResourceIdWithContainerParameterSet,
            Mandatory = true,
            HelpMessage = "The Name of the Container.")]
        [Parameter(
            ParameterSetName = ByInputObjectWithContainerParameterSet,
            Mandatory = true,
            HelpMessage = "The Name of the Container.")]
        [ValidateNotNullOrEmpty]
        public string ContainerName { get; set; }

        [Parameter(
            ParameterSetName = ByNameWithContainerParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Blob Files in the Container.")]
        [Parameter(
            ParameterSetName = ByParentObjectWithContainerParameterSet,
            Mandatory = true,
            HelpMessage = "The Blob Files in the Container.")]
        [Parameter(
            ParameterSetName = ByResourceIdWithContainerParameterSet,
            Mandatory = true,
            HelpMessage = "The Blob Files in the Container.")]
        [Parameter(
            ParameterSetName = ByInputObjectWithContainerParameterSet,
            Mandatory = true,
            HelpMessage = "The Blob Files in the Container.")]
        [ValidateNotNullOrEmpty]
        public string[] FileName { get; set; }

        [Parameter(
             ParameterSetName = ByNameWithContainerParameterSet,
             Mandatory = false,
            ValueFromPipelineByPropertyName = true,
             HelpMessage = "The Storage Account Name.")]
        [Parameter(
             ParameterSetName = ByParentObjectWithContainerParameterSet,
             Mandatory = false,
             HelpMessage = "The Storage Account Name.")]
        [Parameter(
             ParameterSetName = ByResourceIdWithContainerParameterSet,
             Mandatory = false,
             HelpMessage = "The Storage Account Name.")]
        [Parameter(
             ParameterSetName = ByInputObjectWithContainerParameterSet,
             Mandatory = false,
             HelpMessage = "The Storage Account Name.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(
            ParameterSetName = ByNameWithContainerParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Storage Endpoint Suffix.")]
        [Parameter(
            ParameterSetName = ByParentObjectWithContainerParameterSet,
            Mandatory = false,
            HelpMessage = "The Storage Endpoint Suffix.")]
        [Parameter(
            ParameterSetName = ByResourceIdWithContainerParameterSet,
            Mandatory = false,
            HelpMessage = "The Storage Endpoint Suffix.")]
        [Parameter(
            ParameterSetName = ByInputObjectWithContainerParameterSet,
            Mandatory = false,
            HelpMessage = "The Storage Endpoint Suffix.")]
        [ValidateNotNullOrEmpty]
        public string StorageEndpointSuffix { get; set; }

        [Parameter(
            ParameterSetName = ByNameWithContainerParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Storage Account Key.")]
        [Parameter(
            ParameterSetName = ByParentObjectWithContainerParameterSet,
            Mandatory = false,
            HelpMessage = "The Storage Account Key.")]
        [Parameter(
            ParameterSetName = ByResourceIdWithContainerParameterSet,
            Mandatory = false,
            HelpMessage = "The Storage Account Key.")]
        [Parameter(
            ParameterSetName = ByInputObjectWithContainerParameterSet,
            Mandatory = false,
            HelpMessage = "The Storage Account Key.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountKey { get; set; }

        [Parameter(
            ParameterSetName = ByNameWithUrisParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The File URIs.")]
        [Parameter(
            ParameterSetName = ByParentObjectWithUrisParameterSet,
            Mandatory = false,
            HelpMessage = "The File URIs.")]
        [Parameter(
            ParameterSetName = ByResourceIdWithUrisParameterSet,
            Mandatory = false,
            HelpMessage = "The File URIs.")]
        [Parameter(
            ParameterSetName = ByInputObjectWithUrisParameterSet,
            Mandatory = false,
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
                    if (this.VMObject != null)
                    {
                        this.ResourceGroupName = this.VMObject.ResourceGroupName;
                        this.VMName = this.VMObject.Name;
                    }

                    if (this.InputObject != null)
                    {
                        this.ResourceGroupName = this.InputObject.ResourceGroupName;
                        this.VMName = this.InputObject.VMName;
                        this.Name = this.InputObject.Name;

                        this.Location = string.IsNullOrEmpty(this.Location) ? this.InputObject.Location : this.Location;
                        this.TypeHandlerVersion = string.IsNullOrEmpty(this.TypeHandlerVersion) ? this.InputObject.TypeHandlerVersion : this.TypeHandlerVersion;
                        this.FileUri = (this.FileUri == null || !this.FileUri.Any()) ? this.InputObject.Uri : this.FileUri;

                        string cmdToExe = this.InputObject.CommandToExecute;
                        int startIndexFile = cmdToExe.IndexOf("-file ");
                        if (startIndexFile > 0)
                        {
                            string cmdToExeFinal = cmdToExe.Substring(startIndexFile + 6);
                            string[] splits = cmdToExeFinal.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                            this.Run = string.IsNullOrEmpty(this.Run) ? splits[0] : this.Run;
                            this.Argument = string.IsNullOrEmpty(this.Argument) ? string.Join(" ", splits.Skip(1)) : this.Argument;
                        }
                    }

                    if (!string.IsNullOrEmpty(this.ResourceId))
                    {
                        var identifier = new ResourceIdentifier(this.ResourceId);
                        this.ResourceGroupName = identifier.ResourceGroupName;
                        this.VMName = identifier.ParentResource.Split('/').Last();
                        this.Name = identifier.ResourceName;
                    }

                    if (this.ParameterSetName.Contains(WithContainerAndFileNamesParameterSet))
                    {
                        this.StorageEndpointSuffix = string.IsNullOrEmpty(this.StorageEndpointSuffix) ?
                            DefaultProfile.DefaultContext.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix) : this.StorageEndpointSuffix;
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
                    var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                    WriteObject(result);
                });
            }
        }

        protected string GetStorageName()
        {
            return DefaultProfile.DefaultContext.Subscription.GetStorageAccount();
        }

        protected string GetStorageKey(string storageName)
        {
            string storageKey = string.Empty;

            if (!string.IsNullOrEmpty(storageName))
            {
                var storageClient = AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(DefaultProfile.DefaultContext,
                        AzureEnvironment.Endpoint.ResourceManager);

                var storageAccount = storageClient.StorageAccounts.GetProperties(this.ResourceGroupName, storageName);

                if (storageAccount != null)
                {
                    var keys = storageClient.StorageAccounts.ListKeys(this.ResourceGroupName, storageName);
                    if (keys != null)
                    {
                        storageKey = keys.GetFirstAvailableKey();
                    }
                }
            }

            return storageKey;
        }

        protected string GetSasUrlStr(string storageName, string storageKey, string containerName, string blobName)
        {
            var storageClient = AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(DefaultProfile.DefaultContext,
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
