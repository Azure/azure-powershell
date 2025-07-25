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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Linq;
using System.Management.Automation;
using System.Net;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRoutePortAuthorization", SupportsShouldProcess = true), OutputType(typeof(PSExpressRoutePortAuthorization))]
    public class AddAzureExpressRoutePortAuthorizationCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Authorization")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = "The ExpressRoutePort Object")]
        public PSExpressRoutePort ExpressRoutePortObject { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = true;

            try
            {
                this.NetworkClient.NetworkManagementClient.ExpressRoutePortAuthorizations.GetWithHttpMessagesAsync(this.ExpressRoutePortObject.ResourceGroupName, this.ExpressRoutePortObject.Name, this.Name).GetAwaiter().GetResult();
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            if (present)
            {
                throw new ArgumentException("Authorization with the specified name already exists");
            }

            var authorizationParameters = new MNM.ExpressRoutePortAuthorization();
            authorizationParameters.Name = this.Name;

            // Execute the PUT ExpressRoutePortAuthorizations call
            var putExpressRoutePortAuthorization = this.NetworkClient.NetworkManagementClient.ExpressRoutePortAuthorizations.CreateOrUpdateWithHttpMessagesAsync(this.ExpressRoutePortObject.ResourceGroupName, this.ExpressRoutePortObject.Name, this.Name, authorizationParameters).GetAwaiter().GetResult().Body;
            var psExpressRoutePortAuthorization = NetworkResourceManagerProfile.Mapper.Map<PSExpressRoutePortAuthorization>(putExpressRoutePortAuthorization);
            WriteObject(psExpressRoutePortAuthorization, true);
        }
    }
}
