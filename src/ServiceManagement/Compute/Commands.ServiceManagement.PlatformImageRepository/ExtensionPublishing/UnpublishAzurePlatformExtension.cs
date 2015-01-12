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
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ExtensionPublishing
{
    /// <summary>
    /// Unpublish a Platform Extension Image.
    /// </summary>
    [Cmdlet(
        VerbsData.Unpublish,
        AzureVMPlatformExtensionCommandNoun),
    OutputType(
        typeof(ManagementOperationContext))]
    public class UnpublishAzurePlatformExtensionCommand : ServiceManagementBaseCmdlet
    {
        protected const string AzureVMPlatformExtensionCommandNoun = "AzurePlatformExtension";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Image Name.")]
        [ValidateNotNullOrEmpty]
        public string ExtensionName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Publisher.")]
        [ValidateNotNullOrEmpty]
        public string Publisher { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version.")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            HelpMessage = "To force the unpublish operation.")]
        public SwitchParameter Force { get; set; }

        protected override void OnProcessRecord()
        {
            ServiceManagementPlatformImageRepositoryProfile.Initialize();

            if (this.Force.IsPresent
             || this.ShouldContinue(Resources.ExtensionUnpublishingConfirmation, Resources.ExtensionUnpublishingCaption))
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.ComputeClient.ExtensionImages.Unregister(this.Publisher, this.ExtensionName, this.Version));
            }
        }
    }
}
