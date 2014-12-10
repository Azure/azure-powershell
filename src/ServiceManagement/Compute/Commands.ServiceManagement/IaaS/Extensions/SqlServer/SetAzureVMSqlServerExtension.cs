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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// Set-AzureVMSqlServerExtension implementation.
    /// This cmdlet can be used to set AutoPatching / AutoBackup settings,  disable, uninstalls Sql Extension
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        VirtualMachineSqlServerExtensionNoun,
        DefaultParameterSetName = EnableExtensionParamSetName),
    OutputType(
        typeof(IPersistentVM))]
    public class SetAzureVMSqlServerExtensionCommand : VirtualMachineSqlServerExtensionCmdletBase
    {
        protected const string EnableExtensionParamSetName             = "EnableSqlServerExtension";
        protected const string DisableSqlServerExtensionParamSetName   = "DisableSqlServerExtension";
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

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }

        internal void ExecuteCommand()
        {
            ValidateParameters();
            RemovePredicateExtensions();
            AddResourceExtension();
            WriteObject(VM);
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            this.ReferenceName = string.IsNullOrEmpty(this.ReferenceName) ? ExtensionDefaultName : this.ReferenceName;

            this.PublicConfiguration = GetPublicConfiguration();
            this.PrivateConfiguration = GetPrivateConfiguration();
            this.Version = this.Version ?? ExtensionDefaultVersion;
        }
    }
}
