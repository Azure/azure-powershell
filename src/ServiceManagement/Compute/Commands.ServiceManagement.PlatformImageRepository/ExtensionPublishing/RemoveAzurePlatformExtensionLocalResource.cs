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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ExtensionPublishing
{
    /// <summary>
    /// Remove a Local Resource from the Config Set.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        AzurePlatformExtensionLocalResourceCommandNoun),
    OutputType(
        typeof(ExtensionLocalResourceConfigSet))]
    public class RemoveAzurePlatformExtensionLocalResourceCommand : PSCmdlet
    {
        protected const string AzurePlatformExtensionLocalResourceCommandNoun = "AzurePlatformExtensionLocalResource";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Local Resource Config Object.")]
        public ExtensionLocalResourceConfigSet LocalResourceConfig { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Local Resource Name.")]
        public string LocalResourceName { get; set; }

        protected override void ProcessRecord()
        {
            if (this.LocalResourceConfig != null && this.LocalResourceConfig.LocalResources != null)
            {
                this.LocalResourceConfig.LocalResources.RemoveAll(
                    c => string.Equals(c.Name, this.LocalResourceName, StringComparison.OrdinalIgnoreCase));
            }

            WriteObject(this.LocalResourceConfig);
        }
    }
}
