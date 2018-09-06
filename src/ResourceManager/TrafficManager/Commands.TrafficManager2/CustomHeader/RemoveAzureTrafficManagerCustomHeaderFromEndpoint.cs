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
    using System;

    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "TrafficManagerCustomHeaderFromEndpoint", SupportsShouldProcess = true), OutputType(typeof(TrafficManagerEndpoint))]
    public class RemoveAzureTrafficManagerCustomHeaderFromEndpoint : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the custom header.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The endpoint the header will be removed from.")]
        public TrafficManagerEndpoint TrafficManagerEndpoint { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.TrafficManagerEndpoint.CustomHeaders == null)
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_CustomHeaderNotFound, this.Name));
            }

            if (ShouldProcess(
                ProjectResources.Progress_RemovingHeader,
                string.Format(ProjectResources.Confirm_RemoveHeaderFromEndpoint, this.Name, this.TrafficManagerEndpoint.Name, this.TrafficManagerEndpoint.ProfileName, this.TrafficManagerEndpoint.ResourceGroupName),
                string.Empty))
            {
                int customHeadersRemoved = this.TrafficManagerEndpoint.CustomHeaders.RemoveAll(
                    customHeader => string.Equals(this.Name, customHeader.Name));

                if (customHeadersRemoved == 0)
                {
                    throw new PSArgumentException(string.Format(ProjectResources.Error_CustomHeaderNotFound, this.Name));
                }

                this.WriteVerbose(ProjectResources.Success);
            }

            this.WriteObject(this.TrafficManagerEndpoint);
        }
    }
}
