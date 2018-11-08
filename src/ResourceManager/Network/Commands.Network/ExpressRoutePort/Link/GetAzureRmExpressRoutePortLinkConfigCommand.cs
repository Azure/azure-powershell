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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRoutePortLinkConfig", DefaultParameterSetName = ResourceNameParameterSet), OutputType(typeof(PSExpressRouteLink))]
    public partial class GetAzureRmExpressRoutePortLinkConfigCommand : NetworkBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "ResourceId of the link.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the express route port resource.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSExpressRoutePort ExpressRoutePort { get; set; }

        [Parameter(
            ParameterSetName = ResourceNameParameterSet,
            Mandatory = false,
            HelpMessage = "Name of the link.")]
        public string Name { get; set; }


        public override void Execute()
        {
            base.Execute();

            if (string.Equals(this.ParameterSetName, ResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                Name = resourceInfo.ResourceName;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                var vLinks =
                        this.ExpressRoutePort.Links.First(
                            resource =>
                                string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));
                WriteObject(vLinks);
            }
            else
            {
                WriteObject(ExpressRoutePort.Links, true);
            }
        }
    }
}
