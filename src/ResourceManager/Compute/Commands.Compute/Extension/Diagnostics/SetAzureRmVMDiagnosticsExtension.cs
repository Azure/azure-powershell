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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineDiagnosticsExtension)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureRmVMDiagnosticsExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        private Hashtable publicConfiguration;
        private Hashtable privateConfiguration;
        private string extensionName = "Microsoft.Insights.VMDiagnosticsSettings";
        private string location;
        private string version = "1.5";
        private bool autoUpgradeMinorVersion = true;
        private IStorageManagementClient storageClient;

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "XML Diagnostics Configuration")]
        [ValidateNotNullOrEmpty]
        public string DiagnosticsConfigurationPath
        {
            get;
            set;
        }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage account name.")]
        public string StorageAccountName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage account key.")]
        public string StorageAccountKey { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage account endpoint.")]
        public string StorageAccountEndpoint { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage connection context.")]
        [ValidateNotNullOrEmpty]
        public AzureStorageContext StorageContext { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location.")]
        public string Location
        {
            get
            {
                if (string.IsNullOrEmpty(this.location))
                {
                    this.Location = GetLocationFromVm(this.ResourceGroupName, this.VMName);
                }
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = false,
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name.")]
        public string Name
        {
            get
            {
                return this.extensionName;
            }
            set
            {
                this.extensionName = value;
            }
        }

        [Alias("HandlerVersion", "Version")]
        [Parameter(
            Mandatory = false,
            Position = 9,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension version.")]
        public string TypeHandlerVersion
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }

        [Parameter(
            Mandatory = false,
            Position = 10,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Pass a boolean value indicating whether auto upgrade diagnostics extension minor version.")]
        public bool AutoUpgradeMinorVersion
        {
            get
            {
                return this.autoUpgradeMinorVersion;
            }
            set
            {
                this.autoUpgradeMinorVersion = value;
            }
        }

        private Hashtable PublicConfiguration
        {
            get
            {
                if (this.publicConfiguration == null)
                {
                    var vm = ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                    this.publicConfiguration =
                        DiagnosticsHelper.GetPublicDiagnosticsConfigurationFromFile(this.DiagnosticsConfigurationPath,
                            this.StorageAccountName, vm.Id, cmdlet: this);
                }

                return this.publicConfiguration;
            }
        }

        private Hashtable PrivateConfiguration
        {
            get
            {
                if (this.privateConfiguration == null)
                {
                    this.privateConfiguration = DiagnosticsHelper.GetPrivateDiagnosticsConfiguration(this.DiagnosticsConfigurationPath,
                        this.StorageAccountName, this.StorageAccountKey, this.StorageAccountEndpoint);
                }

                return this.privateConfiguration;
            }
        }

        private IStorageManagementClient StorageClient
        {
            get
            {
                if (this.storageClient == null)
                {
                    this.storageClient = AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(
                        DefaultProfile.Context, AzureEnvironment.Endpoint.ResourceManager);
                }

                return this.storageClient;
            }
        }

        private void ExecuteCommand()
        {
            ExecuteClientAction(() =>
            {
                var parameters = new VirtualMachineExtension
                {
                    Location = this.Location,
                    Settings = this.PublicConfiguration,
                    ProtectedSettings = this.PrivateConfiguration,
                    Publisher = DiagnosticsExtensionConstants.ExtensionPublisher,
                    VirtualMachineExtensionType = DiagnosticsExtensionConstants.ExtensionType,
                    TypeHandlerVersion = this.TypeHandlerVersion,
                    AutoUpgradeMinorVersion = this.AutoUpgradeMinorVersion
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

        private void InitializeStorageParameters()
        {
            InitializeStorageAccountName();
            InitializeStorageAccountKey();
            InitializeStorageAccountEndpoint();
        }

        private void InitializeStorageAccountName()
        {
            this.StorageAccountName = this.StorageAccountName ??
                DiagnosticsHelper.InitializeStorageAccountName(this.StorageContext, this.DiagnosticsConfigurationPath);

            if (string.IsNullOrEmpty(this.StorageAccountName))
            {
                throw new ArgumentException(Properties.Resources.DiagnosticsExtensionNullStorageAccountName);
            }
        }

        private void InitializeStorageAccountKey()
        {
            this.StorageAccountKey = this.StorageAccountKey ??
                DiagnosticsHelper.InitializeStorageAccountKey(this.StorageClient, this.StorageAccountName, this.DiagnosticsConfigurationPath);

            if (string.IsNullOrEmpty(this.StorageAccountKey))
            {
                throw new ArgumentException(Properties.Resources.DiagnosticsExtensionNullStorageAccountKey);
            }
        }

        private void InitializeStorageAccountEndpoint()
        {
            this.StorageAccountEndpoint = this.StorageAccountEndpoint ??
                DiagnosticsHelper.InitializeStorageAccountEndpoint(this.StorageAccountName, this.StorageAccountKey, this.StorageClient,
                    this.StorageContext, this.DiagnosticsConfigurationPath, this.DefaultContext);

            if (string.IsNullOrEmpty(this.StorageAccountEndpoint))
            {
                throw new ArgumentNullException(Properties.Resources.DiagnosticsExtensionNullStorageAccountEndpoint);
            }
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            InitializeStorageParameters();
            ExecuteCommand();
        }
    }
}