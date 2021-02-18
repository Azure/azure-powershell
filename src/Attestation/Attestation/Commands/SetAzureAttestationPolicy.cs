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
using Microsoft.Azure.Commands.Attestation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Attestation
{
    /// <summary>
    /// Set AttestationPolicy.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AttestationPolicy", SupportsShouldProcess = true)]
    [OutputType(typeof(String))]
    public class SetAzureAttestationPolicy : AttestationDataServiceCmdletBase
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
        /// Trusted Execution Environment
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage =
                "Specifies a type of Trusted Execution Environment. Four types of environment are supported: SgxEnclave, OpenEnclave, CyResComponent and VBSEnclave."
        )]
        [PSArgumentCompleter("SgxEnclave", "OpenEnclave", "CyResComponent", "VBSEnclave")]
        [ValidateNotNullOrEmpty]
        public string Tee { get; set; }
        
        /// <summary>
        /// Policy document
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage =
                "Specifies the policy document to set.  The policy format can be either Text or JSON Web Token (JWT)."
        )]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        /// <summary>
        /// Format of the policy document
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage =
                "Specifies the format for the policy, either Text or JWT (JSON Web Token).  The default policy format is Text."
        )]
        [PSArgumentCompleter(TextPolicyFormat, JwtPolicyFormat)]
        [PSDefaultValue(Value = TextPolicyFormat)]
        public string PolicyFormat { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "This Cmdlet does not return an object by default. If this switch is specified, it returns true if successful.")]
        public SwitchParameter PassThru { get; set; }
        
        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, "SetAttestationPolicy"))
            {
                AttestationDataPlaneClient.SetPolicy(Name, ResourceGroupName, ResourceId, Tee, Policy, PolicyFormat);
                if (PassThru)
                {
                    WriteObject(true);
                }
            }
        }

        internal const string JwtPolicyFormat = "JWT";
        internal const string TextPolicyFormat = "Text";
    }
}