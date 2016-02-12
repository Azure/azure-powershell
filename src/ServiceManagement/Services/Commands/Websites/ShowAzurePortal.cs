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
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    /// <summary>
    /// Opens the azure portal.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "AzurePortal")]
    public class ShowAzurePortalCommand : AzureSMCmdlet
    {
        private string name;

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the website.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                // Convert to Unicode if necessary.
                name = IdnHelper.GetUnicode(value);
            }
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Realm of the account.")]
        [ValidateNotNullOrEmpty]
        public string Realm { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The environment name.")]
        public string Environment { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            AzureEnvironment environment;
            if (string.IsNullOrEmpty(Environment))
            {
                environment = Profile.Context.Environment;
            }
            else
            {
                environment = Profile.Environments[Environment];
            }

            string managementPortalUrl = environment.GetManagementPortalUrlWithRealm(Realm);

            if (!string.IsNullOrEmpty(Name))
            {
                managementPortalUrl = string.Format(
                    "{0}#{1}",
                    managementPortalUrl,
                    string.Format(Resources.WebsiteSufixUrl, Name));
            }

            ProcessHelper.Start(managementPortalUrl);
        }
    }
}