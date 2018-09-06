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
    using System.Collections.Generic;
    using System.Linq;

    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "TrafficManagerExpectedStatusCodeRange", SupportsShouldProcess = true), OutputType(typeof(TrafficManagerProfile))]
    public class AddAzureTrafficManagerExpectedStatusCodeRange : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The minimum value of the expected status code range.", ParameterSetName = "Fields")]
        public int Min { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The maximum value of the expected status code range.", ParameterSetName = "Fields")]
        public int Max { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The profile to which the range will be added.")]
        public TrafficManagerProfile TrafficManagerProfile { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.TrafficManagerProfile.ExpectedStatusCodeRanges != null && this.TrafficManagerProfile.ExpectedStatusCodeRanges.Any(statusCodeRange => this.Min == statusCodeRange.Min))
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_AddExistingStatusCodeRange, this.Min));
            }

            if (ShouldProcess(
                ProjectResources.Progress_AddingStatusCodeRange,
                string.Format(ProjectResources.Confirm_AddStatusCodeRange, this.Min, this.TrafficManagerProfile.Name, this.TrafficManagerProfile.ResourceGroupName),
                string.Empty))
            {
                if (this.TrafficManagerProfile.ExpectedStatusCodeRanges == null)
                {
                    this.TrafficManagerProfile.ExpectedStatusCodeRanges = new List<TrafficManagerExpectedStatusCodeRange>();
                }

                this.TrafficManagerProfile.ExpectedStatusCodeRanges.Add(
                    new TrafficManagerExpectedStatusCodeRange
                    {
                        Min = (int)this.Min,
                        Max = (int)this.Max
                    });

                this.WriteVerbose(ProjectResources.Success);
            }

            this.WriteObject(this.TrafficManagerProfile);
        }
    }
}
