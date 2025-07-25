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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.PolicyInsights.Common;
using Microsoft.Azure.Commands.PolicyInsights.Models.Attestations;
using Microsoft.Azure.Commands.PolicyInsights.Models.Remediation;
using Microsoft.Azure.Commands.PolicyInsights.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.PolicyInsights;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.PolicyInsights.Cmdlets.Attestations
{
    /// <summary>
    /// Removes a policy attestation.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, AzureRMConstants.AzureRMPrefix + "PolicyAttestation", DefaultParameterSetName = ParameterSetNames.ByName, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmAttestation: AttestationCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Name)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Scope)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Id")]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.AttestationObject)]
        [ValidateNotNull]
        public PSAttestation InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            if (!string.IsNullOrEmpty(this.Name) && new[] { this.Scope, this.ResourceGroupName }.Count(s => s != null) > 1)
            {
                throw new AzPSArgumentException(Resources.Error_TooManyScopes, nameof(this.Scope));
            }

            var rootScope = this.GetRootScope(scope: this.Scope, resourceId: this.ResourceId, resourceGroupName: this.ResourceGroupName, inputObject: this.InputObject);
            var attestationName = this.GetAttestationName(name: this.Name, resourceId: this.ResourceId, inputObject: this.InputObject);

            if (this.ShouldProcess(target: attestationName, action: string.Format(CultureInfo.InvariantCulture, Resources.DeletingAttestation, attestationName, rootScope)))
            {
                this.PolicyInsightsClient.Attestations.DeleteAtResource(resourceId: rootScope, attestationName: attestationName);
                if (this.PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
