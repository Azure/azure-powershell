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
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    [Cmdlet(VerbsLifecycle.Disable, "AzureWebsiteApplicationDiagnostic"), OutputType(typeof(bool))]
    public class DisableAzureWebsiteApplicationDiagnosticCommand : WebsiteContextBaseCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "File switch.")]
        public SwitchParameter File { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Storage switch.")]
        public SwitchParameter Storage { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!File.IsPresent && !Storage.IsPresent)
            {
                WebsitesClient.DisableApplicationDiagnostic(Name, WebsiteDiagnosticOutput.FileSystem);
                WebsitesClient.DisableApplicationDiagnostic(Name, WebsiteDiagnosticOutput.StorageTable);
            }
            else
            {
                if (File.IsPresent)
                {
                    WebsitesClient.DisableApplicationDiagnostic(Name, WebsiteDiagnosticOutput.FileSystem, Slot);
                }

                if (Storage.IsPresent)
                {
                    WebsitesClient.DisableApplicationDiagnostic(Name, WebsiteDiagnosticOutput.StorageTable, Slot);
                }
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
