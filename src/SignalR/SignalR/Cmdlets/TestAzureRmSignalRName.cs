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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("Test", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalRName")]
    [Alias("Test-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalR")]
    [OutputType(typeof(bool))]
    public class TestAzureRmSignalRName : SignalRCmdletBottom
    {
        private const string NameAvailabilityType = "Microsoft.SignalRService/SignalR";

        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "The SignalR service name.")]
        [ValidateNotNullOrEmpty()]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            HelpMessage = "The SignalR service location.")]
        [LocationCompleter("Microsoft.SignalR/SignalR")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdlet(() =>
            {
                var parameters = new NameAvailabilityParameters(
                    type: NameAvailabilityType,
                    name: Name);

                var availability = Client.SignalR.CheckNameAvailability(Location, parameters);
                bool result = (bool)availability.NameAvailable;
                WriteObject(result);
            });
        }
    }
}
