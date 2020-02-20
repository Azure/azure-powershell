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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Attestation
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Attestation", DefaultParameterSetName = NameParameterSet)]
    [OutputType(typeof(PSAttestation))]
    public class GetAzureAttestation : AttestationManagementCmdletBase
    {
        #region Parameter Set Names

        private const string NameParameterSet = "NameParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        #endregion

        #region Input Parameter Definitions
        /// <summary>
        /// Attestation name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = NameParameterSet,
            HelpMessage = "Attestation Name.")]
        [ResourceNameCompleter("Microsoft.Attestation", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// ResourceId to which the attestation belongs.
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Specifies the name of the ResourceID associated with the attestation being queried")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }


        /// <summary>
        /// Resource group to which the attestation belongs.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = NameParameterSet,
            HelpMessage = "Specifies the name of the resource group associated with the attestation being queried.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                Name = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            PSAttestation attestation = AttestationClient.GetAttestation(Name, ResourceGroupName);
            this.WriteObject(attestation);
        }
    }
}