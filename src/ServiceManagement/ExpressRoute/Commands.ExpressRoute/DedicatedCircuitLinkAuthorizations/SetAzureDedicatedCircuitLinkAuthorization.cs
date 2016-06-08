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

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{

    [Cmdlet(VerbsCommon.Set, "AzureDedicatedCircuitLinkAuthorization"), OutputType(typeof(bool))]
    public class SetAzureDedicatedCircuitLinkAuthorizationAuthorizationCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Key for the Azure Circuit")]
        public Guid ServiceKey { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Authorization Id")]
        public Guid AuthorizationId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Maximum number of links")]
        public int Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Microsoft Ids")]
        public string MicrosoftIds { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                ExpressRouteClient.GetAzureDedicatedCircuitLinkAuthorization(ServiceKey, AuthorizationId);
                var updatedAuthorization = ExpressRouteClient.SetAzureDedicatedCircuitLinkAuthorization(ServiceKey, AuthorizationId, Description, Limit);
                WriteObject(updatedAuthorization, false);
            }
            catch
            {
                var newAuthorization = ExpressRouteClient.NewAzureDedicatedCircuitLinkAuthorization(ServiceKey, Description, Limit, MicrosoftIds);
                WriteObject(newAuthorization);
            }
        }
    }
}
