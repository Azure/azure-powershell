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


using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes
{
    [Cmdlet(VerbsCommon.Get, "AzureRouteTable"), OutputType(typeof(IEnumerable<IRouteTable>))]
    public class GetAzureRouteTable : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, HelpMessage = "The new route table's name.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Set this parameter to include in the response the routes in this route table.")]
        public SwitchParameter Detailed { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                GetNoName();
            }
            else
            {
                GetByName();
            }
        }

        private void GetByName()
        {
            IRouteTable routeTable = Client.GetRouteTable(Name, this.Detailed);
            WriteRouteTable(routeTable);
        }

        private void GetNoName()
        {
            IEnumerable<IRouteTable> routeTables = Client.ListRouteTables(this.Detailed);
            WriteRouteTables(routeTables);
        }

        private void WriteRouteTable(IRouteTable networkSecurityGroup)
        {
            WriteObject(networkSecurityGroup, true);
        }

        private void WriteRouteTables(IEnumerable<IRouteTable> routeTables)
        {
            WriteObject(routeTables, true);
        }
    }
}
