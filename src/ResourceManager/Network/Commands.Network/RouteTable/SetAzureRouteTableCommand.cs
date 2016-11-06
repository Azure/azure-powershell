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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmRouteTable"), OutputType(typeof(PSRouteTable))]
    public class SetAzureRouteTableCommand : RouteTableBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The RouteTable")]
        public PSRouteTable RouteTable { get; set; }

        public override void Execute()
        {

            base.Execute();
            if (!this.IsRouteTablePresent(this.RouteTable.ResourceGroupName, this.RouteTable.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var routeTableModel = Mapper.Map<MNM.RouteTable>(this.RouteTable);
            routeTableModel.Tags = TagsConversionHelper.CreateTagDictionary(this.RouteTable.Tag, validate: true);

            // Execute the PUT RouteTable call
            this.RouteTableClient.CreateOrUpdate(this.RouteTable.ResourceGroupName, this.RouteTable.Name, routeTableModel);

            var getRouteTable = this.GetRouteTable(this.RouteTable.ResourceGroupName, this.RouteTable.Name);
            WriteObject(getRouteTable);
        }
    }
}
