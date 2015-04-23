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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Properties;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes.Utilities;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes
{
    [Cmdlet(VerbsCommon.Remove, "AzureRoute"), OutputType(typeof(IRouteTable))]
    public class RemoveAzureRoute : RouteTableConfigurationBaseCmdlet
    {
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the route to remove.")]
        public string RouteName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not confirm Route deletion")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            string routeTableName = this.RouteTable.GetInstance().Name;

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveRouteWarning, this.RouteName, routeTableName),
                Resources.RemoveRouteWarning,
                RouteName,
                () =>
                {
                    Client.DeleteRoute(routeTableName, this.RouteName);
                    WriteObject(Client.GetRouteTable(routeTableName, true));
                });
        }
    }
}
