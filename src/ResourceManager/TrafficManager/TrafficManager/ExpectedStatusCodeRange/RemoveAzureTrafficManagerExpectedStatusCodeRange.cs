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

    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "TrafficManagerExpectedStatusCodeRange", SupportsShouldProcess = true), OutputType(typeof(TrafficManagerProfile))]
    public class RemoveAzureTrafficManagerExpectedStatusCodeRange : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The minimum value of the expected status code range to be removed.", ParameterSetName = "Fields")]
        public int Min { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The profile from which the range will be removed.")]
        public TrafficManagerProfile TrafficManagerProfile { get; set; }

        public override void ExecuteCmdlet()
        {
            if (TrafficManagerProfile != null)
            {
                if (this.TrafficManagerProfile.ExpectedStatusCodeRanges == null)
                {
                    throw new PSArgumentException(string.Format(ProjectResources.Error_StatusCodeRangeNotFound, this.Min));
                }

                if (ShouldProcess(
                    ProjectResources.Progress_RemovingStatusCodeRange,
                    string.Format(ProjectResources.Confirm_RemoveStatusCodeRange, this.Min, this.TrafficManagerProfile.Name, this.TrafficManagerProfile.ResourceGroupName),
                    string.Empty))
                {
                    int statusCodeRangesRemoved = this.TrafficManagerProfile.ExpectedStatusCodeRanges.RemoveAll(
                        statusCodeRange => this.Min == statusCodeRange.Min);

                    if (statusCodeRangesRemoved == 0)
                    {
                        throw new PSArgumentException(string.Format(ProjectResources.Error_StatusCodeRangeNotFound, this.Min));
                    }

                    this.WriteVerbose(ProjectResources.Success);
                }

                this.WriteObject(this.TrafficManagerProfile);
            }
        }
    }
}
