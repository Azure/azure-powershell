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

using Microsoft.Azure.Commands.Attestation.Models;
using Microsoft.Azure.Commands.Attestation.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Attestation
{
    /// <summary>
    /// Create a new Attestation.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Attestation",SupportsShouldProcess = true)]
    [OutputType(typeof(PSAttestation))] 
    public class NewAzureAttestation : AttestationManagementCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Instance name
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Specifies a name of the Instance to create. The name can be any combination of letters, digits, or hyphens. The name must start and end with a letter or digit. The name must be universally unique."
            )]
        [ValidateNotNullOrEmpty]
        [Alias("InstanceName")]
        public string Name { get; set; }
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of an existing resource group in which to create the attestation.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }


        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Specifies the attestation policy passed in which to create the attestation."
        )]
        [ValidateNotNullOrEmpty]
        public string AttestationPolicy { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Resources.CreateAttestation)) 
            {
                var newAttestation = AttestationClient.CreateNewAttestation(new AttestationCreationParameters()
                {
                    ProviderName = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    AttestationPolicy = this.AttestationPolicy
                });
                this.WriteObject(newAttestation);
            } 
        }
    }
}
