﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Add an Additional Unattend Content Object to VM
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMAdditionalUnattendContent"),OutputType(typeof(PSVirtualMachine))]
    public class NewAzureAdditionalUnattendContentCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        private const ComponentNames defaultComponentName = ComponentNames.MicrosoftWindowsShellSetup;
        private const PassNames defaultPassName = PassNames.OobeSystem;

        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "XML Formatted Content.")]
        [ValidateNotNullOrEmpty]
        public string Content { get; set; }

        [Parameter(
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Setting Name.")]
        public SettingNames? SettingName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.VM.OSProfile == null)
            {
                this.VM.OSProfile = new OSProfile();
            }

            if (this.VM.OSProfile.WindowsConfiguration == null && this.VM.OSProfile.LinuxConfiguration == null)
            {
                this.VM.OSProfile.WindowsConfiguration = new WindowsConfiguration();
            }
            else if (this.VM.OSProfile.WindowsConfiguration == null && this.VM.OSProfile.LinuxConfiguration != null)
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Compute.Properties.Resources.BothWindowsAndLinuxConfigurationsSpecified);
            }

            if (this.VM.OSProfile.WindowsConfiguration.AdditionalUnattendContent == null)
            {
                this.VM.OSProfile.WindowsConfiguration.AdditionalUnattendContent = new List<AdditionalUnattendContent>();
            }

            this.VM.OSProfile.WindowsConfiguration.AdditionalUnattendContent.Add(
                new AdditionalUnattendContent
                {
                    ComponentName = defaultComponentName,
                    Content = this.Content,
                    PassName = defaultPassName,
                    SettingName = this.SettingName,
                });

            WriteObject(this.VM);
        }
    }
}
