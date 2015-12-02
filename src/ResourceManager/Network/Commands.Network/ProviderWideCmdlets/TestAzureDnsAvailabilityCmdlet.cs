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
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsDiagnostic.Test, "AzureRmDnsAvailability"), OutputType(typeof(bool))]
    public class TestAzureDnsAvailabilityCmdlet : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The Domain Qualified Name.")]
        [ValidateNotNullOrEmpty]
        public string DomainQualifiedName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            this.Location = this.Location.Replace(" ", string.Empty);
            var result = this.NetworkClient.NetworkResourceProviderClient.CheckDnsNameAvailability(this.Location, this.DomainQualifiedName);
            WriteObject(result.DnsNameAvailability);
        }
    }
}
