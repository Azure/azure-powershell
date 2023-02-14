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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Attestation.Models;
using Microsoft.Azure.Commands.Attestation.Properties;

namespace Microsoft.Azure.Commands.Attestation
{
    /// <summary>
    /// Get AttestationPolicy.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AttestationPolicySigners")]
    [OutputType(typeof(PSPolicySigners))]
    public class GetAzureAttestationPolicySigners : AttestationDataServiceCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Attestation provider name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameParameterSet,
            HelpMessage = "Specifies the name of an attestation provider.")]
        [ResourceNameCompleter("Microsoft.Attestation", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Resource group to which the attestation belongs.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameParameterSet,
            HelpMessage = "Specifies the resource group name of an attestation provider.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }
        
        /// <summary>
        /// ResourceId to which the attestation belongs.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Specifies the ResourceID of an attestation provider.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Location of the default attestation.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DefaultProviderParameterSet,
            HelpMessage = "Specifies the Location of the default attestation provider.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Flag for the default attestation.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DefaultProviderParameterSet,
            HelpMessage = "Specifies this is the request to a default attestation provider.")]
        public SwitchParameter DefaultProvider { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            String policySignersString;

            switch (ParameterSetName)
            {
                case DefaultProviderParameterSet:
                    policySignersString =
                        AttestationDataPlaneClient.GetPolicySigners(Name, ResourceGroupName, ResourceId, true, Location);
                    break;

                case NameParameterSet:
                case ResourceIdParameterSet:
                    policySignersString =
                        AttestationDataPlaneClient.GetPolicySigners(Name, ResourceGroupName, ResourceId);
                    break;

                default:
                    throw new ArgumentException(Resources.BadParameterSetName);
            }

            PSPolicySigners policySigners = new PSPolicySigners(policySignersString);
            WriteObject(policySigners);
        }
    }
}
