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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Remove,
        ProfileNouns.VaultSecretGroup,
        SupportsShouldProcess = true),
    OutputType(
        typeof(PSVirtualMachine))]
    public class RemoveAzureVMSecretCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Alias("Id")]
        [Parameter(
            Position = 1,
            HelpMessage = "The ID for Source Vault")]
        [ValidateNotNullOrEmpty]
        public string [] SourceVaultId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess("SourceVault", VerbsCommon.Remove))
            {
                var osProfile = this.VM.OSProfile;

                if (osProfile != null && osProfile.Secrets != null)
                {
                    var secrets = osProfile.Secrets.ToList();
                    var comp = StringComparison.OrdinalIgnoreCase;

                    if (this.SourceVaultId == null)
                    {
                        secrets.Clear();
                    }
                    else
                    {
                        foreach (var id in this.SourceVaultId)
                        {
                            secrets.RemoveAll(d => string.Equals(d.SourceVault.Id, id, comp));
                        }
                    }
                    osProfile.Secrets = secrets;
                }

                this.VM.OSProfile = osProfile;

                WriteObject(this.VM);
            }
        }
    }
}
