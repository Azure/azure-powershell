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
using Newtonsoft.Json;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineExtension,
        DefaultParameterSetName = SettingsParamSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMExtensionCommand : SetAzureVMExtensionBaseCmdlet
    {
        protected const string SettingStringParamSet = "SettingString";
        protected const string SettingsParamSet = "Settings";

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The publisher.")]
        [ValidateNotNullOrEmpty]
        public string Publisher { get; set; }

        [Alias("Type")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type.")]
        [ValidateNotNullOrEmpty]
        public string ExtensionType { get; set; }

        [Parameter(
            ParameterSetName = SettingsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The settings.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Settings { get; set; }

        [Parameter(
            ParameterSetName = SettingsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The protected settings.")]
        [ValidateNotNullOrEmpty]
        public Hashtable ProtectedSettings { get; set; }

        [Parameter(
            ParameterSetName = SettingStringParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The setting raw string.")]
        [ValidateNotNullOrEmpty]
        public string SettingString { get; set; }

        [Parameter(
            ParameterSetName = SettingStringParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The protected setting raw string.")]
        [ValidateNotNullOrEmpty]
        public string ProtectedSettingString { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.ExtensionType, VerbsCommon.Set))
            {
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
}
