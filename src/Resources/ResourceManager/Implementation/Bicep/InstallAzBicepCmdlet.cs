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
    /// Installs a specific (or the latest) version of the Bicep CLI into Azure PowerShell's
    /// managed, version-addressed cache.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Install, AzureRMConstants.AzureRMPrefix + "Bicep", SupportsShouldProcess = true), OutputType(typeof(PSBicepVersion))]
    public class InstallAzBicepCmdlet : AzureRMCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The specific Bicep version to install (e.g. '0.26.54'). If not specified, the latest available version is installed.")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates that this cmdlet returns the installed version. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// The installer to use. Settable only for tests; defaults to a real <see cref="BicepInstaller"/>.
        /// </summary>
        internal BicepInstaller Installer { get; set; }

        public override void ExecuteCmdlet()
        {
            var target = string.IsNullOrEmpty(this.Version) ? "the latest Bicep version" : $"Bicep {this.Version}";

            if (ShouldProcess(target, "Install"))
            {
                var installer = this.Installer ?? BicepInstaller.Create();
                var installedVersion = installer.InstallVersion(this.Version, this.WriteVerbose);

                if (this.PassThru.IsPresent)
                {
                    WriteObject(new PSBicepVersion
                    {
                        Version = installedVersion.ToString(),
                        Path = installer.GetVersionedInstallationPath(installedVersion)
                    });
                }
            }
        }
    }
}
