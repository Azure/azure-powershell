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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.TrafficManager.Utilities;

namespace Microsoft.WindowsAzure.Commands.TrafficManager.Profile
{
    [Cmdlet(VerbsCommon.Remove, "AzureTrafficManagerProfile"), OutputType(typeof(bool))]
    public class RemoveAzureTrafficManagerProfile : TrafficManagerBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the Traffic Manager profile to remove.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not confirm profile deletion")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveTrafficManagerProfileWarning, Name),
                Resources.RemoveTrafficManagerProfileWarning,
                Name,
                () =>
                    {
                        TrafficManagerClient.RemoveTrafficManagerProfile(Name);

                        WriteVerboseWithTimestamp(Resources.RemoveTrafficManagerProfileSucceeded, Name);
                        if (PassThru.IsPresent)
                        {
                            WriteObject(true);
                        }
                    });
        }
    }
}
