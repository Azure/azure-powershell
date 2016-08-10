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
using System.Management.Automation;
using System.Linq;
using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.WindowsAzure.Commands.ServiceManagement;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    [Cmdlet(
        VerbsCommon.Set,
        VirtualMachineChefExtensionNoun,
        DefaultParameterSetName = WindowsParameterSetName),
    OutputType(
        typeof(IPersistentVM))]
    public class SetAzureVMChefExtensionCommand : VirtualMachineChefExtensionCmdletBase
    {
        protected const string LinuxParameterSetName = OS.Linux;
        protected const string WindowsParameterSetName = OS.Windows;

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
            HelpMessage = "Chef client version to be installed with the extension")]
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

        internal void ExecuteCommand()
        {
            SetDefault();
            ValidateParameters();
            SetPrivateConfig();
            SetPublicConfig();
            RemovePredicateExtensions();
            AddResourceExtension();
            WriteObject(VM);
        }

        private string GetLatestChefExtensionVersion()
        {
            var extensionList = this.ComputeClient.VirtualMachineExtensions.List();
            var version = extensionList.ResourceExtensions.Where(
                extension => extension.Publisher == ExtensionDefaultPublisher
                && extension.Name == base.extensionName).Max(extension => extension.Version);
            string[] separators = {"."};
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
                base.extensionName = LinuxExtensionName;
            }
            else if (this.Windows.IsPresent)
            {
                base.extensionName = ExtensionDefaultName;
            }
            this.Version = this.Version ?? GetLatestChefExtensionVersion();
        }

        private void SetPrivateConfig()
        {
            this.PrivateConfiguration = string.Format(PrivateConfigurationTemplate,
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
            string BootstrapVersion = this.BootstrapVersion;

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
                    "\"|'", "\\\"").TrimEnd('\r', '\n').Replace("\r\n", "\\r\\n");
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
                    this.PublicConfiguration = string.Format("{{{0},{1}}}",
                        string.Format(ClientRbTemplate, ClientConfig),
                        string.Format(BootstrapVersionTemplate, BootstrapVersion));
                }
                else
                {
                    this.PublicConfiguration = string.Format("{{{0},{1},{2}}}",
                        string.Format(ClientRbTemplate, ClientConfig),
                        string.Format(BootStrapOptionsTemplate, this.BootstrapOptions),
                        string.Format(BootstrapVersionTemplate, BootstrapVersion));
                }
            }
            else
            {
                if (IsBootstrapOptionsEmpty)
                {
                    this.PublicConfiguration = string.Format("{{{0},{1},{2}}}",
                        string.Format(ClientRbTemplate, ClientConfig),
                        string.Format(RunListTemplate, this.RunList),
                        string.Format(BootstrapVersionTemplate, BootstrapVersion));
                }
                else
                {
                    this.PublicConfiguration = string.Format("{{{0},{1},{2},{3}}}",
                         string.Format(ClientRbTemplate, ClientConfig),
                         string.Format(RunListTemplate, this.RunList),
                         string.Format(BootStrapOptionsTemplate, this.BootstrapOptions),
                         string.Format(BootstrapVersionTemplate, BootstrapVersion));
                }
            }
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
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
