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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineExtension,
        DefaultParameterSetName = SettingsParamSet)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        protected const string SettingStringParamSet = "SettingString";
        protected const string SettingsParamSet = "Settings";

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

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The publisher.")]
        [ValidateNotNullOrEmpty]
        public string Publisher { get; set; }

        [Alias("Type")]
        [Parameter(
            Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type.")]
        [ValidateNotNullOrEmpty]
        public string ExtensionType { get; set; }

        [Alias("HandlerVersion", "Version")]
        [Parameter(
            Mandatory = true,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type.")]
        [ValidateNotNullOrEmpty]
        public string TypeHandlerVersion { get; set; }

        [Parameter(
            ParameterSetName = SettingsParamSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The settings.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Settings { get; set; }

        [Parameter(
            ParameterSetName = SettingsParamSet,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The protected settings.")]
        [ValidateNotNullOrEmpty]
        public Hashtable ProtectedSettings { get; set; }

        [Parameter(
            ParameterSetName = SettingStringParamSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The setting raw string.")]
        [ValidateNotNullOrEmpty]
        public string SettingString { get; set; }

        [Parameter(
            ParameterSetName = SettingStringParamSet,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The protected setting raw string.")]
        [ValidateNotNullOrEmpty]
        public string ProtectedSettingString { get; set; }

        [Parameter(
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disable auto-upgrade of minor version")]
        public SwitchParameter DisableAutoUpgradeMinorVersion { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Force re-run even if extension configuration has not changed")]
        [ValidateNotNullOrEmpty]
        public string ForceRerun { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (this.ParameterSetName.Equals(SettingStringParamSet))
                {
                    this.Settings = string.IsNullOrEmpty(this.SettingString)
                        ? null
                        : JsonConvert.DeserializeObject<Hashtable>(this.SettingString);
                    this.ProtectedSettings = string.IsNullOrEmpty(this.ProtectedSettingString)
                        ? null
                        : JsonConvert.DeserializeObject<Hashtable>(this.ProtectedSettingString);
                }

                var parameters = new VirtualMachineExtension
                {
                    Location = this.Location,
                    Publisher = this.Publisher,
                    VirtualMachineExtensionType = this.ExtensionType,
                    TypeHandlerVersion = this.TypeHandlerVersion,
                    Settings = this.Settings,
                    ProtectedSettings = this.ProtectedSettings,
                    AutoUpgradeMinorVersion = !this.DisableAutoUpgradeMinorVersion.IsPresent,
                    ForceUpdateTag = this.ForceRerun
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
    }
}
