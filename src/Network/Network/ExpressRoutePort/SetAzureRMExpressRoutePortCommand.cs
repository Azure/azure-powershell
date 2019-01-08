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
using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{

    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRoutePort", SupportsShouldProcess = true), OutputType(typeof(PSExpressRoutePort))]
    public class SetAzureExpressRoutePortCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The express route port object")]
        [Alias("InputObject")]
        public PSExpressRoutePort ExpressRoutePort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.ExpressRoutePorts.Get(this.ExpressRoutePort.ResourceGroupName, this.ExpressRoutePort.Name);
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

            if(!present)
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var vExpressRoutePortModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ExpressRoutePort>(this.ExpressRoutePort);
            vExpressRoutePortModel.Tags = TagsConversionHelper.CreateTagDictionary(this.ExpressRoutePort.Tag, validate: true);

            // Execute the PUT ExpressRoutePort call
            this.NetworkClient.NetworkManagementClient.ExpressRoutePorts.CreateOrUpdate(this.ExpressRoutePort.ResourceGroupName, this.ExpressRoutePort.Name, vExpressRoutePortModel);

            var getExpressRoutePort = this.NetworkClient.NetworkManagementClient.ExpressRoutePorts.Get(this.ExpressRoutePort.ResourceGroupName, this.ExpressRoutePort.Name);
            var psExpressRoutePort = NetworkResourceManagerProfile.Mapper.Map<PSExpressRoutePort>(getExpressRoutePort);
            psExpressRoutePort.ResourceGroupName = this.ExpressRoutePort.ResourceGroupName;
            psExpressRoutePort.Tag = TagsConversionHelper.CreateTagHashtable(getExpressRoutePort.Tags);
            WriteObject(psExpressRoutePort, true);
        }
    }
}
