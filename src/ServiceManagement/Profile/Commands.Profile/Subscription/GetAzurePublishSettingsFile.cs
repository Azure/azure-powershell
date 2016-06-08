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
using System.Security.Permissions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;

namespace Microsoft.WindowsAzure.Commands.Profile
{

    /// <summary>
    /// Get publish profile
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzurePublishSettingsFile"), OutputType(typeof(bool))]
    public class GetAzurePublishSettingsFileCommand : SubscriptionCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The targeted Microsoft Azure environment.")]
        [ValidateNotNullOrEmpty]
        public string Environment { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "Realm of the account.")]
        [ValidateNotNullOrEmpty]
        public string Realm { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "Returns true in success.")]
        public SwitchParameter PassThru { get; set; }

        public GetAzurePublishSettingsFileCommand() : base(false) { }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            AzureEnvironment environment = ProfileClient.GetEnvironmentOrDefault(Environment);
            string url = environment.GetPublishSettingsFileUrlWithRealm(Realm);
            ProcessHelper.Start(url);

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}