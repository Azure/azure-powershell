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

using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes.Model
{
    public class SimpleRouteTable : IRouteTable
    {
        public SimpleRouteTable(string name, string location, string label)
        {
            this.Name = name;
            this.Location = location;
            this.Label = label;
        }

        public SimpleRouteTable(RouteTable routeTableFromGetResponse) :
            this(
            routeTableFromGetResponse.Name,
            routeTableFromGetResponse.Location,
            routeTableFromGetResponse.Label)
        {

        }

        public string Name { get; set; }
        public string Location { get; set; }
        public string Label { get; set; }

        SimpleRouteTable IRouteTable.GetInstance()
        {
            return this;
        }
    }
}
