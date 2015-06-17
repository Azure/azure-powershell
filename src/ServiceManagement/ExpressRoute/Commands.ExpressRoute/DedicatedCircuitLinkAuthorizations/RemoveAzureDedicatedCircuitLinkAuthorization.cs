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

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{
    using Properties;
    using System;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Remove, "AzureDedicatedCircuitLinkAuthorization"), OutputType(typeof(bool))]
    public class RemoveAzureDedicatedCircuitLinkAuthorizationCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Key for the Azure Circuit")]
        public Guid ServiceKey { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Authorization Id")]
        public Guid AuthorizationId { get; set; }

        [Parameter(HelpMessage = "Do not confirm")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveAzureDedicatedCircuitLinkAuthorizationWarning, ServiceKey, AuthorizationId),
                Resources.RemoveAzureDedicatedCircuitLinkAuthorizationMessage,
                ServiceKey + " " + AuthorizationId,
                () =>
                {
                    if (!ExpressRouteClient.RemoveAzureDedicatedCircuitLinkAuthorization(ServiceKey, AuthorizationId))
                    {
                        throw new Exception(Resources.RemoveAzureDedicatedCircuitLinkAuthorizationFailed);
                    }

                    WriteVerboseWithTimestamp(Resources.RemoveAzureDedicatedCircuitLinkAuthorizationSucceeded, ServiceKey, AuthorizationId);
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
