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

using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "AzureRemoteAppWorkspace"), OutputType(typeof(TrackingResult))]
    public class SetAzureRemoteAppWorkspace : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "RemoteApp Workspace name.")]
        public string WorkspaceName { get; set; }

        public override void ExecuteCmdlet()
        {
            OperationResultWithTrackingId response = null;
            AccountDetailsParameter details = new AccountDetailsParameter()
            {
                AccountInfo = new AccountDetails()
                {
                    EndUserFeedName = WorkspaceName
                }
            };

            response = CallClient(() => Client.Account.Set(details), Client.Account);

            if (response != null)
            {
                WriteTrackingId(response);
            }
        }

    }
}
