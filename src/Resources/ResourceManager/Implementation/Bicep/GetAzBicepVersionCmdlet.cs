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
    /// Reports the Bicep CLI version currently installed at the single default (unpinned)
    /// managed location, matching 'az bicep version' semantics.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "BicepVersion"), OutputType(typeof(PSBicepVersion))]
    public class GetAzBicepVersionCmdlet : AzureRMCmdlet
    {
        /// <summary>
        /// The installer to use. Settable only for tests; defaults to a real <see cref="BicepInstaller"/>.
        /// </summary>
        internal BicepInstaller Installer { get; set; }

        public override void ExecuteCmdlet()
        {
            var installer = this.Installer ?? BicepInstaller.Create();
            var version = installer.GetInstalledVersion();

            if (version != null)
            {
                WriteObject(new PSBicepVersion
                {
                    Version = version.ToString(),
                    Path = installer.GetInstallationPath()
                });
            }
        }
    }
}
