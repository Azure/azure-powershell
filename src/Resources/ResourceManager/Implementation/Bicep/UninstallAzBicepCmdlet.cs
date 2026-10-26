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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Bicep
{
    /// <summary>
    /// Removes Azure PowerShell's entire managed Bicep installation (all cached versions).
    /// </summary>
    [Cmdlet(VerbsLifecycle.Uninstall, AzureRMConstants.AzureRMPrefix + "Bicep", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class UninstallAzBicepCmdlet : AzureRMCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Indicates that this cmdlet returns a boolean result. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// The installer to use. Settable only for tests; defaults to a real <see cref="BicepInstaller"/>.
        /// </summary>
        internal BicepInstaller Installer { get; set; }

        public override void ExecuteCmdlet()
        {
            var installer = this.Installer ?? BicepInstaller.Create();

            if (ShouldProcess(installer.GetInstallationDirectory(), "Uninstall all managed Bicep installations"))
            {
                installer.UninstallAll(this.WriteVerbose);

                if (this.PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
