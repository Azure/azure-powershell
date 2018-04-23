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
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;

namespace Microsoft.Azure.Commands.Cdn.Endpoint
{
    [Cmdlet(VerbsLifecycle.Confirm, "AzureRmCdnEndpointProbeURL"), OutputType(typeof(PSValidateProbeOutput))]
    public class ConfirmAzureRmCdnEndpointProbeUrl : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Proposed probe URL name to validate.")]
        [ValidateNotNullOrEmpty]
        public string ProbeUrl { get; set; }

        public override void ExecuteCmdlet()
        {
            var result = CdnManagementClient.ValidateProbe(ProbeUrl);

            WriteVerbose(Resources.Success);
            WriteObject(result.ToPsValideProbeOutput());
        }
    }
}
