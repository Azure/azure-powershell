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
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.CloudService.Development
{
    /// <summary>
    /// Runs the service in the emulator
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "AzureEmulator"), OutputType(typeof(bool))]
    public class StopAzureEmulatorCommand : AzureSMCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public void StopAzureEmulatorProcess()
        {
            CloudServiceProject service = new CloudServiceProject();
            WriteVerbose(Resources.StopEmulatorMessage);
            
            string warning;
            service.StopEmulators(out warning);
            if (!string.IsNullOrEmpty(warning))
            {
                WriteWarning(warning);
            }

            WriteVerbose(Resources.StoppedEmulatorMessage);

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            AzureTool.Validate();
            StopAzureEmulatorProcess();
        }
    }
}