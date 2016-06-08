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

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.TrafficManager.Models;
using Microsoft.WindowsAzure.Commands.TrafficManager.Utilities;

namespace Microsoft.WindowsAzure.Commands.TrafficManager.Endpoint
{
    [Cmdlet(VerbsCommon.Remove, "AzureTrafficManagerEndpoint"), OutputType(typeof(IProfileWithDefinition))]
    public class RemoveAzureTrafficManagerEndpoint : TrafficManagerConfigurationBaseCmdlet
    {
        [Parameter(Mandatory = true)]
        public string DomainName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not confirm endpoint deletion")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ProfileWithDefinition profile = TrafficManagerProfile.GetInstance();
            if (!profile.Endpoints.Any(e => e.DomainName.Equals(DomainName, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new Exception(Resources.RemoveTrafficManagerEndpointMissing);
            }

            TrafficManagerEndpoint endpoint = profile.Endpoints.First(e => e.DomainName.Equals(DomainName, StringComparison.InvariantCultureIgnoreCase));
            profile.Endpoints.Remove(endpoint);

            WriteObject(profile);
        }
    }
}
