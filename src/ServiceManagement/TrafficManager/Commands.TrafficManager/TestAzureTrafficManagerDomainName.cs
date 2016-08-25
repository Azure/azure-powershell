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
using Microsoft.WindowsAzure.Commands.TrafficManager.Utilities;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.WindowsAzure.Commands.TrafficManager
{
    [Cmdlet(VerbsDiagnostic.Test, "AzureTrafficManagerDomainName"), OutputType(typeof(bool))]
    public class TestAzureTrafficManagerDomainName : TrafficManagerBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DomainName { get; set; }

        public override void ExecuteCmdlet()
        {
            bool result = TrafficManagerClient.TestDomainAvailability(GetDomainNameToCheck(DomainName));
            WriteObject(result);
        }

        private string GetDomainNameToCheck(string domainName)
        {
            string TrafficManagerSuffix = !string.IsNullOrEmpty(Profile.Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.TrafficManagerDnsSuffix)) ?
                Profile.Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.TrafficManagerDnsSuffix) :
                AzureEnvironmentConstants.AzureTrafficManagerDnsSuffix;

            if (!string.IsNullOrEmpty(domainName) && !domainName.ToLower().EndsWith(TrafficManagerSuffix))
            {
                return string.Format("{0}.{1}", domainName, TrafficManagerSuffix);
            }

            return domainName;
        }
    }
}
