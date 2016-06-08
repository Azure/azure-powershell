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

using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;
using System.Collections.Generic;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to list the currently downloaded accounts and their
    /// associated subscriptions.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureAccount")]
    [OutputType(typeof(AzureAccount))]
    public class GetAzureAccount : SubscriptionCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, HelpMessage = "Name of account to get information for")]
        public string Name { get; set; }

        public GetAzureAccount() : base(false)
        {
        }

        public override void ExecuteCmdlet()
        {
            IEnumerable<AzureAccount> accounts = Profile.Accounts.Values.Where(a => Name == null || a.Id == Name);
            List<PSAzureAccount> output = new List<PSAzureAccount>();
            foreach (AzureAccount account in accounts) {
                output.Add(account.ToPSAzureAccount());
            }
            WriteObject(output, true);
        }
    }
}