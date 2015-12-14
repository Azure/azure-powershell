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
    public class SetAzureVMChefExtension : VirtualMachineExtensionBaseCmdlet
    {
        protected const string LinuxParameterSetName = "Linux";
        protected const string WindowsParameterSetName = "Windows";
        protected const string VirtualMachineChefExtensionNoun = "AzureVMChefExtension";

        protected const string ExtensionDefaultPublisher = "Chef.Bootstrap.WindowsAzure";
        protected const string ExtensionDefaultName = "ChefClient";
        protected const string LinuxExtensionName = "LinuxChefClient";
        protected const string PrivateConfigurationTemplate = "{{\"validation_key\":\"{0}\"}}";
        protected const string AutoUpdateTemplate = "\"autoUpdateClient\":\"{0}\"";
        protected const string DeleteChefConfigTemplate = "\"deleteChefConfig\":\"{0}\"";
        protected const string ClientRbTemplate = "\"client_rb\":\"{0}\"";
        protected const string BootStrapOptionsTemplate = "\"bootstrap_options\":{0}";
        protected const string RunListTemplate = "\"runlist\": \"\\\"{0}\\\"\"";

        protected string extensionName;
        protected string publisherName;
        protected string publicConfiguration;
        protected string privateConfiguration;

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version. Default is the latest available version")]
        [ValidateNotNullOrEmpty]
        public override string Version { get; set; }

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

        internal void ExecuteCommand()
        {
            SetDefault();
            ValidateParameters();
            SetPrivateConfig();
            SetPublicConfig();
            //RemovePredicateExtensions();
            //AddResourceExtension();
            WriteObject(VM);
        }

        private string GetLatestChefExtensionVersion()
        {
            var extensionList = this.ComputeClient.ComputeManagementClient.VirtualMachineExtensions.List();
            var version = extensionList.ResourceExtensions.Where(
                extension => extension.Publisher == ExtensionDefaultPublisher
                && extension.Name == extensionName).Max(extension => extension.Version);
            string[] separators = { "." };
            string majorVersion = version.Split(separators, StringSplitOptions.None)[0];
            return majorVersion + ".*";
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
                extensionName = LinuxExtensionName;
            }
            else if (this.Windows.IsPresent)
            {
                extensionName = ExtensionDefaultName;
            }
            this.Version = this.Version ?? GetLatestChefExtensionVersion();
        }

        private void SetPrivateConfig()
        {
            this.privateConfiguration = string.Format(PrivateConfigurationTemplate,
                File.ReadAllText(this.ValidationPem).TrimEnd('\r', '\n'));
        }

        private void SetPublicConfig()
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

        protected override void ValidateParameters()
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

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }       
    }
}