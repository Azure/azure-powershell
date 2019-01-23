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
    using System.Collections.Generic;
    using System.Linq;

    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "TrafficManagerCustomHeaderToEndpoint", SupportsShouldProcess = true), OutputType(typeof(TrafficManagerEndpoint))]
    public class AddAzureTrafficManagerCustomHeaderToEndpoint : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the custom header.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The value of the custom header.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The endpoint the header will be added to.")]
        public TrafficManagerEndpoint TrafficManagerEndpoint { get; set; }

        public override void ExecuteCmdlet()
        {
            if (TrafficManagerEndpoint != null)
            {
                if (this.TrafficManagerEndpoint.CustomHeaders != null && this.TrafficManagerEndpoint.CustomHeaders.Any(header => string.Equals(this.Name, header.Name)))
                {
                    throw new PSArgumentException(string.Format(ProjectResources.Error_AddExistingHeader, this.Name));
                }

                if (ShouldProcess(
                    ProjectResources.Progress_AddingHeader,
                    string.Format(ProjectResources.Confirm_AddHeaderToEndpoint, this.Name, this.TrafficManagerEndpoint.Name, this.TrafficManagerEndpoint.ProfileName, this.TrafficManagerEndpoint.ResourceGroupName),
                    string.Empty))
                {
                    if (this.TrafficManagerEndpoint.CustomHeaders == null)
                    {
                        this.TrafficManagerEndpoint.CustomHeaders = new List<TrafficManagerCustomHeader>();
                    }

                    this.TrafficManagerEndpoint.CustomHeaders.Add(
                        new TrafficManagerCustomHeader
                        {
                            Name = this.Name,
                            Value = Value
                        });

                    this.WriteVerbose(ProjectResources.Success);
                }

                this.WriteObject(this.TrafficManagerEndpoint);
            }
        }
    }
}
