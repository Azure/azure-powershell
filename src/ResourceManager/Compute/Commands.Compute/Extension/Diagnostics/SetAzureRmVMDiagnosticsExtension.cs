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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Xml.Linq;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineDiagnosticsExtension)]
    public class SetAzureRmVMDiagnosticsExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        private string publicConfiguration;
        private string privateConfiguration;
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
        public string Location {
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

        private string PublicConfiguration
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

        private string PrivateConfiguration
        {
            get
            {
                if (string.IsNullOrEmpty(this.privateConfiguration))
                {
                    this.privateConfiguration = DiagnosticsHelper.GetJsonSerializedPrivateDiagnosticsConfiguration(this.StorageAccountName, this.StorageAccountKey,
                            this.StorageAccountEndpoint);
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
                    this.storageClient = AzureSession.ClientFactory.CreateClient<StorageManagementClient>(
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
                    Name = this.Name,
                    Type = DiagnosticsExtensionConstants.VirtualMachineExtensionResourceType,
                    Settings = this.PublicConfiguration,
                    ProtectedSettings = this.PrivateConfiguration,
                    Publisher = DiagnosticsExtensionConstants.ExtensionPublisher,
                    ExtensionType = DiagnosticsExtensionConstants.ExtensionType,
                    TypeHandlerVersion = this.TypeHandlerVersion,
                    AutoUpgradeMinorVersion = this.AutoUpgradeMinorVersion
                };

                var op = this.VirtualMachineExtensionClient.CreateOrUpdate(
                    this.ResourceGroupName,
                    this.VMName,
                    parameters);

                WriteObject(op);
            });
        }

        private void InitializeStorageParameters()
        {
            InitializeStorageAccountName();

            var storageAccounts = this.StorageClient.StorageAccounts.List().StorageAccounts;
            var storageAccount = storageAccounts == null ? null : storageAccounts.FirstOrDefault(account => account.Name.Equals(this.StorageAccountName));

            InitializeStorageAccountKey(storageAccount);
            InitializeStorageAccountEndpoint(storageAccount);
        }

        /// <summary>
        /// Make sure the storage account name is set.
        /// It can be defined in multiple places, we only take the one with higher precedence. And the precedence is:
        /// 1. Directly specified from command line parameter
        /// 2. The one get from StorageContext parameter
        /// 3. The one parsed from the diagnostics configuration file
        /// </summary>
        private void InitializeStorageAccountName()
        {
            if (string.IsNullOrEmpty(this.StorageAccountName))
            {
                if (this.StorageContext != null)
                {
                    this.StorageAccountName = this.StorageContext.StorageAccountName;
                }
                else
                {
                    var config = XElement.Load(this.DiagnosticsConfigurationPath);
                    var storageNode = config.Elements().FirstOrDefault(ele => ele.Name.LocalName == "StorageAccount");

                    if (storageNode == null)
                    {
                        throw new ArgumentNullException(Properties.Resources.DiagnosticsExtensionStorageAccountNameNotDefined);
                    }
                    else
                    {
                        this.StorageAccountName = storageNode.Value;
                    }
                }
            }
        }

        /// <summary>
        /// Make sure the storage account key is set.
        /// If user doesn't specify it in command line, we try to resolve the key for the user given the storage account.
        /// </summary>
        /// <param name="storageAccount">The storage account to list the key.</param>
        private void InitializeStorageAccountKey(StorageAccount storageAccount)
        {
            if (string.IsNullOrEmpty(this.StorageAccountKey))
            {
                if (storageAccount == null)
                {
                    throw new Exception(string.Format(CultureInfo.InvariantCulture, Properties.Resources.DiagnosticsExtensionFailedToListKeyForNoStorageAccount, this.StorageAccountName));
                }

                var psStorageAccount = new PSStorageAccount(storageAccount);
                var credentials = StorageUtilities.GenerateStorageCredentials(this.StorageClient, psStorageAccount.ResourceGroupName, psStorageAccount.StorageAccountName);
                this.StorageAccountKey = credentials.ExportBase64EncodedKey();
            }
        }

        /// <summary>
        /// Make sure we set the correct storage account endpoint.
        /// We can get the value from multiple places, we only take the one with higher precedence. And the precedence is:
        /// 1. Directly specified from command line parameter
        /// 2. The one get from StorageContext parameter
        /// 3. The one get from the storage account we list
        /// 4. The one get from current Azure Environment
        /// </summary>
        /// <param name="storageAccount">The storage account to help get the endpoint.</param>
        private void InitializeStorageAccountEndpoint(StorageAccount storageAccount)
        {
            if (string.IsNullOrEmpty(this.StorageAccountEndpoint))
            {
                var context = this.StorageContext;
                if (context == null)
                {
                    Uri blobEndpoint = null, queueEndpoint = null, tableEndpoint = null, fileEndpoint = null;
                    if (storageAccount != null)
                    {
                        // Create storage context from storage account
                        var endpoints = storageAccount.PrimaryEndpoints;
                        blobEndpoint = endpoints.Blob;
                        queueEndpoint = endpoints.Queue;
                        tableEndpoint = endpoints.Table;
                        fileEndpoint = endpoints.File;
                    }
                    else if (this.DefaultContext != null && this.DefaultContext.Environment != null)
                    {
                        // Create storage context from default azure environment. Default to use https
                        blobEndpoint = DefaultContext.Environment.GetStorageBlobEndpoint(this.StorageAccountName);
                        queueEndpoint = DefaultContext.Environment.GetStorageQueueEndpoint(this.StorageAccountName);
                        tableEndpoint = DefaultContext.Environment.GetStorageTableEndpoint(this.StorageAccountName);
                        fileEndpoint = DefaultContext.Environment.GetStorageFileEndpoint(this.StorageAccountName);
                    }
                    else
                    {
                        // Can't automatically get the endpoint to create storage context
                        throw new ArgumentNullException(Properties.Resources.DiagnosticsExtensionStorageAccountEndpointNotDefined);
                    }
                    var credentials = new StorageCredentials(this.StorageAccountName, this.StorageAccountKey);
                    var cloudStorageAccount = new CloudStorageAccount(credentials, blobEndpoint, queueEndpoint, tableEndpoint, fileEndpoint);
                    context = new AzureStorageContext(cloudStorageAccount);
                }

                var scheme = context.BlobEndPoint.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ? "https://" : "http://";
                this.StorageAccountEndpoint = scheme + context.EndPointSuffix;
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