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

using Microsoft.Azure.Commands.TrafficManager.Models;
using Microsoft.Azure.Commands.TrafficManager.Utilities;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.TrafficManager.Properties.Resources;

namespace Microsoft.Azure.Commands.TrafficManager
{
    using ResourceManager.Common.ArgumentCompleters;
    using System.Collections.Generic;
    using System.Linq;

    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "TrafficManagerIpAddressRange", SupportsShouldProcess = true), OutputType(typeof(TrafficManagerEndpoint))]
    public class AddAzureTrafficManagerIpAddressRange : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The first address in the range.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string First { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The optional last address in the range.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string Last { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The optional scope of the range.", ParameterSetName = "Fields")]
        public int? Scope { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The endpoint.")]
        public TrafficManagerEndpoint TrafficManagerEndpoint { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.TrafficManagerEndpoint.SubnetMapping != null && this.TrafficManagerEndpoint.SubnetMapping.Any(addressRange => string.Equals(this.First, addressRange.First)))
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_AddExistingAddressRange, this.First));
            }

            if (ShouldProcess(
                ProjectResources.Progress_AddingAddressRange,
                string.Format(ProjectResources.Confirm_AddAddressRange, this.First, this.TrafficManagerEndpoint.Name, this.TrafficManagerEndpoint.ProfileName, this.TrafficManagerEndpoint.ResourceGroupName),
                string.Empty))
            {
                if (this.TrafficManagerEndpoint.SubnetMapping == null)
                {
                    this.TrafficManagerEndpoint.SubnetMapping = new List<TrafficManagerIpAddressRange>();
                }

                this.TrafficManagerEndpoint.SubnetMapping.Add(
                    new TrafficManagerIpAddressRange
                    {
                        First = this.First,
                        Last = this.Last,
                        Scope = this.Scope
                    });

                this.WriteVerbose(ProjectResources.Success);
            }

            this.WriteObject(this.TrafficManagerEndpoint);
        }
    }
}
