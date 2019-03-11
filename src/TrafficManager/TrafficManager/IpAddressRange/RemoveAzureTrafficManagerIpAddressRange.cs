﻿// ----------------------------------------------------------------------------------
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
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "TrafficManagerIpAddressRange", SupportsShouldProcess = true), OutputType(typeof(TrafficManagerEndpoint))]
    public class RemoveAzureTrafficManagerIpAddressRange : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The first address in the range.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string First { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The endpoint.")]
        public TrafficManagerEndpoint TrafficManagerEndpoint { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.TrafficManagerEndpoint.SubnetMapping == null)
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_AddressRangeNotFound, this.First));
            }

            if (ShouldProcess(
                ProjectResources.Progress_RemovingAddressRange,
                string.Format(ProjectResources.Confirm_RemoveAddressRange, this.First, this.TrafficManagerEndpoint.Name, this.TrafficManagerEndpoint.ProfileName, this.TrafficManagerEndpoint.ResourceGroupName),
                string.Empty))
            {
                int addressRangesRemoved = this.TrafficManagerEndpoint.SubnetMapping.RemoveAll(addressRange => string.Equals(this.First, addressRange.First));

                if (addressRangesRemoved == 0)
                {
                    throw new PSArgumentException(string.Format(ProjectResources.Error_AddressRangeNotFound, this.First));
                }

                this.WriteVerbose(ProjectResources.Success);
            }

            this.WriteObject(this.TrafficManagerEndpoint);
        }
    }
}
