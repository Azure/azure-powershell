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

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalRUsage")]
    [OutputType(typeof(PSSignalRUsage))]
    public class GetAzureRmSignalRUsage : SignalRCmdletBottom
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "The SignalR service location.")]
        [LocationCompleter("Microsoft.SignalR/SignalR")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdlet(() =>
            {
                var usages = Client.Usages.List(Location);
                foreach (var usage in usages)
                {
                    WriteObject(new PSSignalRUsage(usage));
                }
            });
        }
    }
}
