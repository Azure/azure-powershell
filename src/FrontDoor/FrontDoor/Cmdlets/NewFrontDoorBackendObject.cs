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

using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoorRoutingRuleObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorBackendObject"), OutputType(typeof(PSBackend))]
    public class NewFrontDoorBackendObject : AzureFrontDoorCmdletBase
    {

        /// <summary>
        /// Location of the backend (IP address or FQDN).
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Location of the backend (IP address or FQDN)")]
        public string Address { get; set; }

        /// <summary>
        /// The HTTP TCP port number. 
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The HTTP TCP port number. Must be between 1 and 65535. Default value is 80")]
        [ValidateRange(1, 65535)]
        public int HttpPort { get; set; }

        /// <summary>
        /// The HTTPs TCP port number.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The HTTPS TCP port number. Must be between 1 and 65535. Default value is 443")]
        [ValidateRange(1, 65535)]
        public int HttpsPort { get; set; }

        /// <summary>
        /// Priority to use for load balancing.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Priority to use for load balancing. Must be between 1 and 5. Default value is 1")]
        [ValidateRange(1, 5)]
        public int Priority { get; set; }

        /// <summary>
        /// Weight of this endpoint for load balancing purposes.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Weight of this endpoint for load balancing purposes. Must be between 1 and 1000. Default value is 50")]
        [ValidateRange(1, 1000)]
        public int Weight { get; set; }

        /// <summary>
        /// Whether to enable use of this backend.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Whether to enable use of this backend. Default value is Enabled")]
        public PSEnabledState EnabledState { get; set; }

        /// <summary>
        /// The value to use as the host header sent to the backend. 
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The value to use as the host header sent to the backend. Default value is the backend address.")]
        public string BackendHostHeader { get; set; }

        /// <summary>
        /// The Alias of the Private Link resource. Populating this optional field indicates that this backend is 'Private'
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The Alias of the Private Link resource. Populating this optional field indicates that this backend is 'Private'")]
        public string PrivateLinkAlias { get; set; }

        /// <summary>
        /// The Resource ID of the Private Link. Populating this optional field indicates that this backend is 'Private'
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The Resource ID of the Private Link. Populating this optional field indicates that this backend is 'Private'")]
        public string PrivateLinkResourceId { get; set; }

        /// <summary>
        /// The Location of Private Link resource. Location is required when PrivateLinkResourceId is set
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The Location of Private Link resource. Location is required when PrivateLinkResourceId is set")]
        public string PrivateLinkLocation { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A custom message to be included in the approval request to connect to the Private Link")]
        public string PrivateLinkApprovalMessage { get; set; }

        public override void ExecuteCmdlet()
        {
            var Backend = new PSBackend
            {
                Address = Address,
                HttpPort = !this.IsParameterBound(c => c.HttpPort) ? 80 : HttpPort,
                HttpsPort = !this.IsParameterBound(c => c.HttpsPort) ? 443 : HttpsPort,
                EnabledState = !this.IsParameterBound(c => c.EnabledState) ? PSEnabledState.Enabled : EnabledState,
                Priority = !this.IsParameterBound(c => c.Priority) ? 1 : Priority,
                Weight = !this.IsParameterBound(c => c.Weight) ? 50 : Weight,
                BackendHostHeader = !this.IsParameterBound(c => c.BackendHostHeader) ? Address : BackendHostHeader,
                PrivateLinkAlias = PrivateLinkAlias,
                PrivateLinkResourceId = PrivateLinkResourceId,
                PrivateLinkLocation = PrivateLinkLocation,
                PrivateLinkApprovalMessage = PrivateLinkApprovalMessage
            };
            WriteObject(Backend);
        }

    }
}
