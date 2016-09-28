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
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.Chef
{
    [Cmdlet(
        VerbsCommon.Set, ProfileNouns.VirtualMachineChefExtension, SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMChefExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        protected const string LinuxParameterSetName = "Linux";
        protected const string WindowsParameterSetName = "Windows";

        private string ExtensionDefaultName = "ChefClient";
        private string LinuxExtensionName = "LinuxChefClient";
        private bool autoUpgradeMinorVersion = false;
        private string ExtensionDefaultPublisher = "Chef.Bootstrap.WindowsAzure";
        private string location;
        private string version;
        private Hashtable publicConfiguration;
        private Hashtable privateConfiguration;

        private string PrivateConfigurationTemplate = "validation_key";
        private string BootstrapVersionTemplate = "bootstrap_version";
        private string ClientRbTemplate = "client_rb";
        private string BootStrapOptionsTemplate = "bootstrap_options";
        private string RunListTemplate = "runlist";

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

        [Alias("HandlerVersion", "Version")]
        [Parameter(
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
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Chef Server Validation Key File Path.")]
        [ValidateNotNullOrEmpty]
        public string ValidationPem { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Chef Server Client Config (ClientRb)File Path.")]
        [ValidateNotNullOrEmpty]
        public string ClientRb { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Chef Client bootstrap options in JSON format.")]
        [ValidateNotNullOrEmpty]
        public string BootstrapOptions { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Chef Server Node Runlist.")]
        [ValidateNotNullOrEmpty]
        public string RunList { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Chef Server Url.")]
        [ValidateNotNullOrEmpty]
        public string ChefServerUrl { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Chef ValidationClientName," +
                          " used to determine whether a chef-client may register with a Chef server.")]
        [ValidateNotNullOrEmpty]
        public string ValidationClientName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Chef Organization name, used to form Validation Client Name.")]
        [ValidateNotNullOrEmpty]
        public string OrganizationName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Chef client version to be installed with the extension. Works for only linux.")]
        [ValidateNotNullOrEmpty]
        public string BootstrapVersion { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = LinuxParameterSetName,
            HelpMessage = "Set extension for Linux.")]
        public SwitchParameter Linux { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = WindowsParameterSetName,
            HelpMessage = "Set extension for Windows.")]
        public SwitchParameter Windows { get; set; }

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
                return this.ExtensionDefaultName;
            }
            set
            {
                this.ExtensionDefaultName = value;
            }
        }

        [Parameter(
            Mandatory = false,
            Position = 10,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Pass a boolean value indicating whether auto upgrade chef extension minor version.")]
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
                    string ClientConfig = string.Empty;
                    bool IsClientRbEmpty = string.IsNullOrEmpty(this.ClientRb);
                    bool IsChefServerUrlEmpty = string.IsNullOrEmpty(this.ChefServerUrl);
                    bool IsValidationClientNameEmpty = string.IsNullOrEmpty(this.ValidationClientName);
                    bool IsRunListEmpty = string.IsNullOrEmpty(this.RunList);
                    bool IsBootstrapOptionsEmpty = string.IsNullOrEmpty(this.BootstrapOptions);
                    string BootstrapVersion = string.IsNullOrEmpty(this.BootstrapVersion) ? "" : this.BootstrapVersion;

                    //Cases handled:
                    // 1. When clientRb given by user and:
                    //    1.1 if ChefServerUrl and ValidationClientName given then append it to end of ClientRb
                    //    1.2 if ChefServerUrl given then append it to end of ClientRb
                    //    1.3 if ValidationClientName given then append it to end of ClientRb
                    // 2. When ClientRb not given but ChefServerUrl and ValidationClientName given by user then
                    //    create ClientRb config using these values.

                    if (!IsClientRbEmpty)
                    {
                        ClientConfig = File.ReadAllText(this.ClientRb).TrimEnd('\r', '\n');
                        // Append ChefServerUrl and ValidationClientName to end of ClientRb
                        if (!IsChefServerUrlEmpty && !IsValidationClientNameEmpty)
                        {
                            string UserConfig = @"
chef_server_url  '{0}'
validation_client_name 	'{1}'
";
                            ClientConfig += string.Format(UserConfig, this.ChefServerUrl, this.ValidationClientName);
                        }
                        // Append ChefServerUrl to end of ClientRb
                        else if (!IsChefServerUrlEmpty)
                        {
                            string UserConfig = @"
chef_server_url  '{0}'
";
                            ClientConfig += string.Format(UserConfig, this.ChefServerUrl);
                        }
                        // Append ValidationClientName to end of ClientRb
                        else if (!IsValidationClientNameEmpty)
                        {
                            string UserConfig = @"
validation_client_name 	'{0}'
";
                            ClientConfig += string.Format(UserConfig, this.ValidationClientName);
                        }
                    }
                    // Create ClientRb config using ChefServerUrl and ValidationClientName
                    else if (!IsChefServerUrlEmpty && !IsValidationClientNameEmpty)
                    {
                        string UserConfig = @"
chef_server_url  '{0}'
validation_client_name 	'{1}'
";
                        ClientConfig = string.Format(UserConfig, this.ChefServerUrl, this.ValidationClientName);
                    }
                    if (IsRunListEmpty)
                    {
                        if (IsBootstrapOptionsEmpty)
                        {
                            var hashTable = new Hashtable();
                            hashTable.Add(BootstrapVersionTemplate, BootstrapVersion);
                            hashTable.Add(ClientRbTemplate, ClientConfig);
                            this.publicConfiguration = hashTable;
                        }
                        else
                        {
                            var hashTable = new Hashtable();
                            hashTable.Add(BootstrapVersionTemplate, BootstrapVersion);
                            hashTable.Add(ClientRbTemplate, ClientConfig);
                            hashTable.Add(BootStrapOptionsTemplate, this.BootstrapOptions);
                            this.publicConfiguration = hashTable;
                        }
                    }
                    else
                    {
                        if (IsBootstrapOptionsEmpty)
                        {
                            var hashTable = new Hashtable();
                            hashTable.Add(BootstrapVersionTemplate, BootstrapVersion);
                            hashTable.Add(ClientRbTemplate, ClientConfig);
                            hashTable.Add(RunListTemplate, this.RunList);
                            this.publicConfiguration = hashTable;
                        }
                        else
                        {
                            var hashTable = new Hashtable();
                            hashTable.Add(BootstrapVersionTemplate, BootstrapVersion);
                            hashTable.Add(ClientRbTemplate, ClientConfig);
                            hashTable.Add(RunListTemplate, this.RunList);
                            hashTable.Add(BootStrapOptionsTemplate, this.BootstrapOptions);
                            this.publicConfiguration = hashTable;
                        }
                    }
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
                    var hashTable = new Hashtable();
                    hashTable.Add(PrivateConfigurationTemplate, File.ReadAllText(this.ValidationPem).TrimEnd('\r', '\n'));
                    this.privateConfiguration = hashTable;
                }

                return this.privateConfiguration;
            }
        }

        private void ExecuteCommand()
        {
            ConfirmAction("Set Chef Extension", this.VMName,
                () => {
                    var parameters = new VirtualMachineExtension
                    {
                        Location = this.Location,
                        Settings = this.PublicConfiguration,
                        ProtectedSettings = this.PrivateConfiguration,
                        Publisher = ExtensionDefaultPublisher,
                        VirtualMachineExtensionType = this.Name,
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

        private void SetDefault()
        {
            bool IsOrganizationNameEmpty = string.IsNullOrEmpty(this.OrganizationName);

            // form validation client name using organization name.
            if (!IsOrganizationNameEmpty)
            {
                this.ValidationClientName = this.OrganizationName + "-validator";
            }

            if (this.Linux.IsPresent)
            {
                this.Name = LinuxExtensionName;
            }
            else if (this.Windows.IsPresent)
            {
                this.Name = ExtensionDefaultName;
            }

            this.TypeHandlerVersion = this.TypeHandlerVersion ?? GetLatestChefExtensionVersion();
        }

        private string GetLatestChefExtensionVersion()
        {
            var result = ComputeClient.ComputeManagementClient.VirtualMachineExtensionImages.ListVersionsWithHttpMessagesAsync(this.Location, ExtensionDefaultPublisher, this.Name).GetAwaiter().GetResult();

            var images = from r in result.Body
                         select new PSVirtualMachineExtensionImage
                         {
                             RequestId = result.RequestId,
                             StatusCode = result.Response.StatusCode,
                             Id = r.Id,
                             Location = r.Location,
                             Version = r.Name,
                             PublisherName = ExtensionDefaultPublisher,
                             Type = this.Name
                         };

            var maxVersion = images.Max(extension => extension.Version);
            string[] separators = { "." };
            string[] splitVersion = maxVersion.Split(separators, StringSplitOptions.None);
            string majorMinorVersion = splitVersion[0] + "." + splitVersion[1];
            return majorMinorVersion;
        }

        private void ValidateParameters()
        {
            bool IsClientRbEmpty = string.IsNullOrEmpty(this.ClientRb);
            bool IsChefServerUrlEmpty = string.IsNullOrEmpty(this.ChefServerUrl);
            bool IsValidationClientNameEmpty = string.IsNullOrEmpty(this.ValidationClientName);
            // Validate ClientRb or ChefServerUrl and ValidationClientName should exist.
            if (IsClientRbEmpty && (IsChefServerUrlEmpty || IsValidationClientNameEmpty))
            {
                throw new ArgumentException(
                    "Required -ClientRb or -ChefServerUrl and -ValidationClientName options.");
            }
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            SetDefault();
            ValidateParameters();
            ExecuteCommand();
        }
    }
}