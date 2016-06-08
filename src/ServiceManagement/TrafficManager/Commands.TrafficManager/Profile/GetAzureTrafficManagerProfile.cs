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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.TrafficManager.Models;
using Microsoft.WindowsAzure.Commands.TrafficManager.Utilities;

namespace Microsoft.WindowsAzure.Commands.TrafficManager.Profile
{
    [Cmdlet(VerbsCommon.Get, "AzureTrafficManagerProfile"), OutputType(typeof(IEnumerable<SimpleProfile>))]
    public class GetAzureTrafficManagerProfile : TrafficManagerBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                GetNoName();
            }
            else
            {
                GetByName();
            }
        }

        private void GetByName()
        {
            ProfileWithDefinition profile = TrafficManagerClient.GetTrafficManagerProfileWithDefinition(Name);
            WriteProfile(profile);
        }

        private void GetNoName()
        {
            IEnumerable<SimpleProfile> profiles = TrafficManagerClient.ListProfiles();
            WriteProfiles(profiles);
        }

        private void WriteProfile(SimpleProfile profile)
        {
            WriteObject(profile, true);
        }

        private void WriteProfiles(IEnumerable<SimpleProfile> profiles)
        {
            WriteObject(profiles, true);
        }
    }
}
