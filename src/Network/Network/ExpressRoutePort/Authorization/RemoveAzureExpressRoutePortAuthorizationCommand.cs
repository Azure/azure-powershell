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
using System.Linq;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRoutePortAuthorization", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureExpressRoutePortAuthorizationCommand : NetworkBaseCmdlet
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to delete resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, Name),
                Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    this.NetworkClient.NetworkManagementClient.ExpressRoutePortAuthorizations.DeleteWithHttpMessagesAsync(ExpressRoutePortObject.ResourceGroupName, ExpressRoutePortObject.Name, Name).GetAwaiter().GetResult();
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
