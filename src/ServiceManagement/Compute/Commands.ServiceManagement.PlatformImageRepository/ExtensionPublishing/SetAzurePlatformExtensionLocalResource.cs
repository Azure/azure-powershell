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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ExtensionPublishing
{
    /// <summary>
    /// Add or Update a Local Resource in the Config Set.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        AzurePlatformExtensionLocalResourceCommandNoun),
    OutputType(
        typeof(ExtensionLocalResourceConfigSet))]
    public class SetAzurePlatformExtensionLocalResourceCommand : PSCmdlet
    {
        protected const string AzurePlatformExtensionLocalResourceCommandNoun = "AzurePlatformExtensionLocalResource";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Local Resource Config Object.")]
        public ExtensionLocalResourceConfigSet LocalResourceConfig { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Local Resource Name.")]
        [ValidateNotNullOrEmpty]
        public string LocalResourceName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Local Resource Size.")]
        [ValidateNotNullOrEmpty]
        public int LocalResourceSizeInMb { get; set; }

        protected override void ProcessRecord()
        {
            if (this.LocalResourceConfig == null)
            {
                this.LocalResourceConfig = new ExtensionLocalResourceConfigSet();
            }

            if (this.LocalResourceConfig.LocalResources == null)
            {
                this.LocalResourceConfig.LocalResources = new List<ExtensionLocalResourceConfig>();
            }

            this.LocalResourceConfig.LocalResources.Add(
                new ExtensionLocalResourceConfig
                {
                    Name = this.LocalResourceName,
                    SizeInMB = this.LocalResourceSizeInMb
                });

            WriteObject(this.LocalResourceConfig);
        }
    }
}
