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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRoutePortsLocation"), OutputType(typeof(PSExpressRoutePortsLocation))]
    public partial class GetAzureRmExpressRoutePortsLocation : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the location.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string LocationName { get; set; }

        public override void Execute()
        {
            base.Execute();

            if(!string.IsNullOrEmpty(this.LocationName))
            {
                var vExpressRoutePortsLocation = this.NetworkClient.NetworkManagementClient.ExpressRoutePortsLocations.Get(LocationName);
                var vExpressRoutePortsLocationModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSExpressRoutePortsLocation>(vExpressRoutePortsLocation);
                vExpressRoutePortsLocationModel.Tag = TagsConversionHelper.CreateTagHashtable(vExpressRoutePortsLocation.Tags);
                WriteObject(vExpressRoutePortsLocationModel, true);
            }
            else
            {
                var vExpressRoutePortsLocationList = this.NetworkClient.NetworkManagementClient.ExpressRoutePortsLocations.List();
                List<PSExpressRoutePortsLocation> psExpressRoutePortsLocationList = new List<PSExpressRoutePortsLocation>();
                foreach (var vExpressRoutePortsLocation in vExpressRoutePortsLocationList)
                {
                    var vExpressRoutePortsLocationModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSExpressRoutePortsLocation>(vExpressRoutePortsLocation);
                    vExpressRoutePortsLocationModel.Tag = TagsConversionHelper.CreateTagHashtable(vExpressRoutePortsLocation.Tags);
                    psExpressRoutePortsLocationList.Add(vExpressRoutePortsLocationModel);
                }
                WriteObject(psExpressRoutePortsLocationList, true);
            }
        }
    }
}
