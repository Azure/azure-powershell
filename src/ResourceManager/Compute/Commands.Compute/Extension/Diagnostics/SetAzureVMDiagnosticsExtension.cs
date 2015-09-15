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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineDiagnosticsExtension)]
    public class SetAzureVMDiagnosticsExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        private string publicConfiguration;
        private string privateConfiguration;
        private string storageKey;
        private const string VirtualMachineExtension = "Microsoft.Compute/virtualMachines/extensions";
        private const string IaaSDiagnosticsExtension = "IaaSDiagnostics";
        private const string ExtensionPublisher = "Microsoft.Azure.Diagnostics";
        private StorageManagementClient storageClient;

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
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage connection context")]
        [ValidateNotNullOrEmpty]
        public AzureStorageContext StorageContext
        {
            get;
            set;
        }

        [Parameter(
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = true,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Extension Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public string StorageAccountName
        {
            get
            {
                return this.StorageContext.StorageAccountName;
            }
        }

        public string Endpoint
        {
            get
            {
                return "https://" + this.StorageContext.EndPointSuffix;
            }
        }

        public string StorageKey
        {
            get
            {
                if (string.IsNullOrEmpty(this.storageKey))
                {
                    this.storageKey = GetStorageKey();
                }

                return this.storageKey;
            }
        }

        public string PublicConfiguration
        {
            get
            {
                if (string.IsNullOrEmpty(this.publicConfiguration))
                {
                    this.publicConfiguration =
                        DiagnosticsHelper.GetJsonSerializedPublicDiagnosticsConfigurationFromFile(
                            this.DiagnosticsConfigurationPath, this.StorageAccountName);
                }

                return this.publicConfiguration;
            }
        }

        public string PrivateConfiguration
        {
            get
            {
                if (string.IsNullOrEmpty(this.privateConfiguration))
                {
                    this.privateConfiguration = DiagnosticsHelper.GetJsonSerializedPrivateDiagnosticsConfiguration(this.StorageAccountName, this.StorageKey,
                            this.Endpoint);
                }

                return this.privateConfiguration;
            }
        }

        public StorageManagementClient StorageClient
        {
            get
            {
                if (this.storageClient == null)
                {
                    this.storageClient = AzureSession.ClientFactory.CreateClient<StorageManagementClient>(
                        Profile.Context, AzureEnvironment.Endpoint.ServiceManagement);
                }

                return this.storageClient;
            }
        }

        internal void ExecuteCommand()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                var parameters = new VirtualMachineExtension
                {
                    Location = this.Location,
                    Name = this.Name,
                    Type = VirtualMachineExtension,
                    Settings = this.PublicConfiguration,
                    ProtectedSettings = this.PrivateConfiguration,
                    Publisher = ExtensionPublisher,
                    ExtensionType = IaaSDiagnosticsExtension,
                    TypeHandlerVersion = "1.4"
                };

                var op = this.VirtualMachineExtensionClient.CreateOrUpdate(
                    this.ResourceGroupName,
                    this.VMName,
                    parameters);

                WriteObject(op);
            });
        }

        protected string GetStorageKey()
        {
            string storageKey = string.Empty;

            if (!string.IsNullOrEmpty(StorageAccountName))
            {
                var storageAccount = this.StorageClient.StorageAccounts.Get(StorageAccountName);
                if (storageAccount != null)
                {
                    var keys = this.StorageClient.StorageAccounts.GetKeys(StorageAccountName);
                    if (keys != null)
                    {
                        storageKey = !string.IsNullOrEmpty(keys.PrimaryKey) ? keys.PrimaryKey : keys.SecondaryKey;
                    }
                }
            }

            return storageKey;
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }
    }
}