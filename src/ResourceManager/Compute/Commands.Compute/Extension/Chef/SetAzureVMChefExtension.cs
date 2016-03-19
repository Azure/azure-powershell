using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System.Management.Automation;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using System.IO;

namespace Microsoft.Azure.Commands.Compute.Extension.Chef
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineChefExtension)]
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
        private string publicConfiguration;
        private string privateConfiguration;

        private string PrivateConfigurationTemplate = "{{\"validation_key\":\"{0}\"}}";
        private string AutoUpdateTemplate = "\"autoUpdateClient\":\"{0}\"";
        private string DeleteChefConfigTemplate = "\"deleteChefConfig\":\"{0}\"";
        private string ClientRbTemplate = "\"client_rb\":\"{0}\"";
        private string BootStrapOptionsTemplate = "\"bootstrap_options\":{0}";
        private string RunListTemplate = "\"runlist\": \"\\\"{0}\\\"\"";

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
            Mandatory = true,
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
            HelpMessage = "Flag to opt for auto chef-client update. Chef-client update is false by default.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AutoUpdateChefClient { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Delete the chef config files during update/uninstall extension. Default is false.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DeleteChefConfig { get; set; }

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

        private string PublicConfiguration
        {
            get
            {
                if (string.IsNullOrEmpty(this.publicConfiguration))
                {
                    string ClientConfig = string.Empty;
                    bool IsClientRbEmpty = string.IsNullOrEmpty(this.ClientRb);
                    bool IsChefServerUrlEmpty = string.IsNullOrEmpty(this.ChefServerUrl);
                    bool IsValidationClientNameEmpty = string.IsNullOrEmpty(this.ValidationClientName);
                    bool IsRunListEmpty = string.IsNullOrEmpty(this.RunList);
                    bool IsBootstrapOptionsEmpty = string.IsNullOrEmpty(this.BootstrapOptions);
                    string AutoUpdateChefClient = this.AutoUpdateChefClient.IsPresent ? "true" : "false";
                    string DeleteChefConfig = this.DeleteChefConfig.IsPresent ? "true" : "false";

                    //Cases handled:
                    // 1. When clientRb given by user and:
                    //    1.1 if ChefServerUrl and ValidationClientName given then append it to end of ClientRb
                    //    1.2 if ChefServerUrl given then append it to end of ClientRb
                    //    1.3 if ValidationClientName given then append it to end of ClientRb
                    // 2. When ClientRb not given but ChefServerUrl and ValidationClientName given by user then
                    //    create ClientRb config using these values.

                    if (!IsClientRbEmpty)
                    {
                        ClientConfig = Regex.Replace(File.ReadAllText(this.ClientRb),
                            "\"|'", "\\\"").TrimEnd('\r', '\n');
                        // Append ChefServerUrl and ValidationClientName to end of ClientRb
                        if (!IsChefServerUrlEmpty && !IsValidationClientNameEmpty)
                        {
                            string UserConfig = @"
chef_server_url  \""{0}\""
validation_client_name 	\""{1}\""
";
                            ClientConfig += string.Format(UserConfig, this.ChefServerUrl, this.ValidationClientName);
                        }
                        // Append ChefServerUrl to end of ClientRb
                        else if (!IsChefServerUrlEmpty)
                        {
                            string UserConfig = @"
chef_server_url  \""{0}\""
";
                            ClientConfig += string.Format(UserConfig, this.ChefServerUrl);
                        }
                        // Append ValidationClientName to end of ClientRb
                        else if (!IsValidationClientNameEmpty)
                        {
                            string UserConfig = @"
validation_client_name 	\""{0}\""
";
                            ClientConfig += string.Format(UserConfig, this.ValidationClientName);
                        }
                    }
                    // Create ClientRb config using ChefServerUrl and ValidationClientName
                    else if (!IsChefServerUrlEmpty && !IsValidationClientNameEmpty)
                    {
                        string UserConfig = @"
chef_server_url  \""{0}\""
validation_client_name 	\""{1}\""
";
                        ClientConfig = string.Format(UserConfig, this.ChefServerUrl, this.ValidationClientName);
                    }
                    if (IsRunListEmpty)
                    {
                        if (IsBootstrapOptionsEmpty)
                        {
                            this.publicConfiguration = string.Format("{{{0},{1},{2}}}",
                                string.Format(AutoUpdateTemplate, AutoUpdateChefClient),
                                string.Format(DeleteChefConfigTemplate, DeleteChefConfig),
                                string.Format(ClientRbTemplate, ClientConfig));
                        }
                        else
                        {
                            this.publicConfiguration = string.Format("{{{0},{1},{2},{3}}}",
                                string.Format(AutoUpdateTemplate, AutoUpdateChefClient),
                                string.Format(DeleteChefConfigTemplate, DeleteChefConfig),
                                string.Format(ClientRbTemplate, ClientConfig),
                                string.Format(BootStrapOptionsTemplate, this.BootstrapOptions));
                        }
                    }
                    else
                    {
                        if (IsBootstrapOptionsEmpty)
                        {
                            this.publicConfiguration = string.Format("{{{0},{1},{2},{3}}}",
                                string.Format(AutoUpdateTemplate, AutoUpdateChefClient),
                                string.Format(DeleteChefConfigTemplate, DeleteChefConfig),
                                string.Format(ClientRbTemplate, ClientConfig),
                                string.Format(RunListTemplate, this.RunList));
                        }
                        else
                        {
                            this.publicConfiguration = string.Format("{{{0},{1},{2},{3},{4}}}",
                                 string.Format(AutoUpdateTemplate, AutoUpdateChefClient),
                                 string.Format(DeleteChefConfigTemplate, DeleteChefConfig),
                                 string.Format(ClientRbTemplate, ClientConfig),
                                 string.Format(RunListTemplate, this.RunList),
                                 string.Format(BootStrapOptionsTemplate, this.BootstrapOptions));
                        }
                    }
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
                    this.privateConfiguration = string.Format(PrivateConfigurationTemplate,
                    File.ReadAllText(this.ValidationPem).TrimEnd('\r', '\n'));
                }                

                return this.privateConfiguration;
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
                    Type = VirtualMachineExtensionType,
                    Settings = this.PublicConfiguration,
                    ProtectedSettings = this.PrivateConfiguration,
                    Publisher = ExtensionDefaultPublisher,
                    ExtensionType = this.Name,
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

            //Uncomment this when GetLatestChefExtensionVersion() is implemented
            //this.TypeHandlerVersion = this.TypeHandlerVersion ?? GetLatestChefExtensionVersion();
        }

        private string GetLatestChefExtensionVersion()
        {       
            //Right now chef extension's major version is freezed as 1210. 
            //Todo: Implement proper logic to fetch the current major.minor version number
            return "1210.12";
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