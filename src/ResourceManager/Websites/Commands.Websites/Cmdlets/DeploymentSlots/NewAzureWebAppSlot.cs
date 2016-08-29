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


using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.DeploymentSlots
{
    /// <summary>
    /// this commandlet will let you create a new Azure Web app slot using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmWebAppSlot")]
    public class NewAzureWebAppSlotCmdlet : WebAppBaseClientCmdLet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The name of the app service plan eg: Default1.")]
        public string AppServicePlan { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The source web app to clone", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Site SourceWebApp { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = "Ignore source control on source web app")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IgnoreSourceControl { get; set; }

        [Parameter(Position = 7, Mandatory = false, HelpMessage = "Ignore custom hostnames on source web app")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IgnoreCustomHostNames { get; set; }

        [Parameter(Position = 8, Mandatory = false, HelpMessage = "Overrides all application settings in new web app")]
        [ValidateNotNullOrEmpty]
        public Hashtable AppSettingsOverrides { get; set; }

        [Parameter(Position = 9, Mandatory = false, HelpMessage = "Name of application service environment")]
        [ValidateNotNullOrEmpty]
        public string AseName { get; set; }

        [Parameter(Position = 9, Mandatory = false, HelpMessage = "Resource group of Application Service environment")]
        [ValidateNotNullOrEmpty]
        public string AseResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            CloningInfo cloningInfo = null;
            if (SourceWebApp != null)
            {
                cloningInfo = new CloningInfo
                {
                    SourceWebAppId = SourceWebApp.Id,
                    CloneCustomHostNames = !IgnoreCustomHostNames.IsPresent,
                    CloneSourceControl = !IgnoreSourceControl.IsPresent,
                    ConfigureLoadBalancing = false,
                    AppSettingsOverrides = AppSettingsOverrides == null ? null : AppSettingsOverrides.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString(), StringComparer.Ordinal)
                };
            }

            var webApp = WebsitesClient.GetWebApp(ResourceGroupName, Name, null);

            WriteObject(WebsitesClient.CreateWebApp(ResourceGroupName, Name, Slot, webApp.Location, AppServicePlan, cloningInfo, AseName, AseResourceGroupName));
        }
    }
}



