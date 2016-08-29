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


using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you create a new Azure Web app using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmWebApp", DefaultParameterSetName = ParameterSet1Name)]
    public class NewAzureWebAppCmdlet : WebAppBaseClientCmdLet
    {
        const string ParameterSet1Name = "S1";
        const string ParameterSet2Name = "S2";

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web app.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The Location of the web app eg: West US.")]
        public string Location { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The name of the app service plan eg: Default1.")]
        public string AppServicePlan { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The source web app to clone", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Site SourceWebApp { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 5, Mandatory = false, HelpMessage = "Resource Id of existing traffic manager profile")]
        [ValidateNotNullOrEmpty]
        public string TrafficManagerProfileId { get; set; }

        [Parameter(ParameterSetName = ParameterSet2Name, Position = 5, Mandatory = false, HelpMessage = "Name of new traffic manager profile")]
        [ValidateNotNullOrEmpty]
        public string TrafficManagerProfileName { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = "Ignore source control on source web app")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IgnoreSourceControl { get; set; }

        [Parameter(Position = 7, Mandatory = false, HelpMessage = "Ignore custom hostnames on source web app")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IgnoreCustomHostNames { get; set; }

        [Parameter(Position = 8, Mandatory = false, HelpMessage = "Overrides all application settings in new web app")]
        [ValidateNotNullOrEmpty]
        public Hashtable AppSettingsOverrides { get; set; }

        [Parameter(Position = 9, Mandatory = false, HelpMessage = "Application Service environment Name")]
        [ValidateNotNullOrEmpty]
        public string AseName { get; set; }

        [Parameter(Position = 9, Mandatory = false, HelpMessage = "Resource group of Application Service environment")]
        [ValidateNotNullOrEmpty]
        public string AseResourceGroupName { get; set; }

        [Parameter(Position = 10, Mandatory = false, HelpMessage = "Clones slots associated with source web app")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IncludeSourceWebAppSlots { get; set; }

        public override void ExecuteCmdlet()
        {
            CloningInfo cloningInfo = null;
            if (SourceWebApp != null)
            {
                cloningInfo = new CloningInfo
                {
                    SourceWebAppId = SourceWebApp.Id,
                    CloneCustomHostNames = !IgnoreCustomHostNames.IsPresent,
                    CloneSourceControl = !IgnoreSourceControl.IsPresent,
                    TrafficManagerProfileId = TrafficManagerProfileId,
                    TrafficManagerProfileName = TrafficManagerProfileName,
                    ConfigureLoadBalancing = !string.IsNullOrEmpty(TrafficManagerProfileId) || !string.IsNullOrEmpty(TrafficManagerProfileName),
                    AppSettingsOverrides = AppSettingsOverrides == null ? null : AppSettingsOverrides.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString(), StringComparer.Ordinal)
                };
            }

            var cloneWebAppSlots = false;
            string[] slotNames = null;
            string srcResourceGroupName = null;
            string srcwebAppName = null;
            string srcSlotName = null;
            if (IncludeSourceWebAppSlots.IsPresent)
            {
                CmdletHelpers.TryParseWebAppMetadataFromResourceId(SourceWebApp.Id, out srcResourceGroupName,
                    out srcwebAppName, out srcSlotName);
                var slots = WebsitesClient.ListWebApps(srcResourceGroupName, srcwebAppName);
                if (slots != null && slots.Any())
                {
                    slotNames = slots.Select(s => s.Name.Replace(srcwebAppName + "/", string.Empty)).ToArray();
                    cloneWebAppSlots = true;
                }
            }

            if (cloneWebAppSlots)
            {
                WriteVerboseWithTimestamp("Cloning source web app '{0}' to destination web app {1}", srcwebAppName, Name);
            }

            WriteObject(WebsitesClient.CreateWebApp(ResourceGroupName, Name, null, Location, AppServicePlan, cloningInfo, AseName, AseResourceGroupName));

            if (cloneWebAppSlots)
            {
                WriteVerboseWithTimestamp("Cloning all deployment slots of source web app '{0}' to destination web app {1}", srcwebAppName, Name);
                CloneSlots(slotNames);
            }
        }

        private void CloneSlots(string[] slotNames)
        {
            var hostingEnvironmentProfile = WebsitesClient.CreateHostingEnvironmentProfile(ResourceGroupName, AseResourceGroupName, AseName);
            var template = DeploymentTemplateHelper.CreateSlotCloneDeploymentTemplate(Location, AppServicePlan, Name, SourceWebApp.Id,
                slotNames, hostingEnvironmentProfile, WebsitesClient.WrappedWebsitesClient.ApiVersion);

            var deployment = new Management.Resources.Models.Deployment
            {
                Properties = new DeploymentProperties
                {
                    Mode = DeploymentMode.Incremental,
                    Template = template
                }
            };

            var deploymentName = string.Format("CloneSlotsFor{0}", Name);
            ResourcesClient.ResourceManagementClient.Deployments.CreateOrUpdate(ResourceGroupName, deploymentName, deployment);
            var result = ResourcesClient.ProvisionDeploymentStatus(ResourceGroupName, deploymentName, deployment);
            WriteObject(result.ToPSResourceGroupDeployment(ResourceGroupName));
        }
    }
}



