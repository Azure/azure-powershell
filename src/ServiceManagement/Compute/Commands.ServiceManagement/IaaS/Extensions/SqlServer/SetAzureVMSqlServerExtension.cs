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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using System.Net;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management;
using Hyak.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// Set-AzureVMSqlServerExtension implementation.
    /// This cmdlet can be used to set AutoPatching / AutoBackup / Key Vault Credential settings,  disable, uninstalls Sql Extension
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        VirtualMachineSqlServerExtensionNoun,
        DefaultParameterSetName = EnableExtensionParamSetName),
    OutputType(
        typeof(IPersistentVM))]
    public class SetAzureVMSqlServerExtensionCommand : VirtualMachineSqlServerExtensionCmdletBase
    {
        protected const string EnableExtensionParamSetName = "EnableSqlServerExtension";
        protected const string DisableSqlServerExtensionParamSetName = "DisableSqlServerExtension";
        protected const string UninstallSqlServerExtensionParamSetName = "UninstallSqlServerExtension";

        [Parameter(
            Mandatory = false,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Reference Name.")]
        [ValidateNotNullOrEmpty]
        public override string ReferenceName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version.")]
        [ValidateNotNullOrEmpty]
        public override string Version { get; set; }

        [Parameter(
            ParameterSetName = DisableSqlServerExtensionParamSetName,
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disable Sql Server Extension")]
        public override SwitchParameter Disable { get; set; }

        [Parameter(
            ParameterSetName = UninstallSqlServerExtensionParamSetName,
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Uninstall Sql Server Extension")]
        public override SwitchParameter Uninstall { get; set; }

        [Parameter(
            ParameterSetName = EnableExtensionParamSetName,
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Automatic Patching configuration.")]
        [ValidateNotNullOrEmpty]
        public override AutoPatchingSettings AutoPatchingSettings { get; set; }

        [Parameter(
            ParameterSetName = EnableExtensionParamSetName,
            Mandatory = false,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Automatic Backup configuration.")]
        [ValidateNotNullOrEmpty]
        public override AutoBackupSettings AutoBackupSettings { get; set; }
        
        [Parameter(
            ParameterSetName = EnableExtensionParamSetName,
            Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure Key Vault SQL Credentials configuration.")]
        [ValidateNotNullOrEmpty]
        public override KeyVaultCredentialSettings KeyVaultCredentialSettings { get; set; }
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            this.ExecuteCommand();
        }

        internal void ExecuteCommand()
        {
            ValidateParameters();

            if ((this.KeyVaultCredentialSettings != null) && !this.KeyVaultCredentialSettings.Enable)
            {
                WriteVerboseWithTimestamp("SQL Server Azure key vault disabled. Previously configured credentials are not removed but no status will be reported");
            }

            RemovePredicateExtensions();
            AddResourceExtension();
            WriteObject(VM);
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            this.ReferenceName = string.IsNullOrEmpty(this.ReferenceName) ? ExtensionPublishedName : this.ReferenceName;
            this.SetupAutoTelemetrySettings();
            this.PublicConfiguration = GetPublicConfiguration();
            this.PrivateConfiguration = GetPrivateConfiguration();
            this.Version = this.Version ?? ExtensionDefaultVersion;
        }

        private void SetupAutoTelemetrySettings()
        {
            if (this.AutoTelemetrySettings == null || string.IsNullOrEmpty(this.AutoTelemetrySettings.Region))
            {
                foreach (var hs in this.ComputeClient.HostedServices.List().HostedServices)
                {
                    try
                    {
                        var deployment = this.ComputeClient.Deployments.GetBySlot(hs.ServiceName, Management.Compute.Models.DeploymentSlot.Production);
                        if (deployment != null)
                        {
                            var role = deployment.RoleInstances.FirstOrDefault(r => r.RoleName == VM.GetInstance().RoleName);

                            string location = String.Empty;
                            if (role != null)
                            {
                                if (null != hs.Properties)
                                {
                                    if (!string.IsNullOrEmpty(hs.Properties.Location))
                                    {
                                        location = hs.Properties.Location;
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(hs.Properties.AffinityGroup))
                                        {
                                            location = this.ManagementClient.AffinityGroups.Get(hs.Properties.AffinityGroup).Location;
                                        }
                                    }
                                }

                                this.AutoTelemetrySettings = new AutoTelemetrySettings() { Region = location };
                                WriteVerboseWithTimestamp("VM Location:" + location);
                                break;
                            }
                        }
                    }
                    catch (CloudException e)
                    {
                        if (e.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            throw;
                        }
                    }
                }
            }
        }
    }
}
