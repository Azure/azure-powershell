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
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    [Cmdlet(VerbsLifecycle.Disable, "AzureWebsiteDebug"), OutputType(typeof(bool))]
    public class DisableAzureWebsiteDebugCommand : WebsiteContextBaseCmdlet
    {
        private Site website;

        private SiteConfig siteConfig;

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            // Get current config
            website = WebsitesClient.GetWebsite(Name, Slot);
            siteConfig = WebsitesClient.GetWebsiteConfiguration(Name, Slot);

            // Update the configuration
            if (siteConfig.RemoteDebuggingEnabled.Value)
            {
                siteConfig.RemoteDebuggingEnabled = false;
                WebsitesClient.UpdateWebsiteConfiguration(Name, siteConfig, Slot);
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
