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

using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{

    [Cmdlet(VerbsCommunications.Disconnect, "AzureRemoteAppSession"), OutputType(typeof(string))]
    public class DisconnectAzureRemoteAppSession : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = false,
            Position = 1,
            HelpMessage = "User UPN")]
        [ValidatePattern(UserPrincipalValdatorString)]
        public string UserUpn { get; set; }

        public override void ExecuteCmdlet()
        {
            SessionCommandParameter parameter = new SessionCommandParameter
            {
                UserUpn = UserUpn
            };

            var response = CallClient(() => Client.Collections.DisconnectSession(CollectionName, parameter), Client.Collections);

            WriteTrackingId(response);
        }
    }
}
