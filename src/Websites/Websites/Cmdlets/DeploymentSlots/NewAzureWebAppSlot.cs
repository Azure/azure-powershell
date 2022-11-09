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


using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.DeploymentSlots
{
    /// <summary>
    /// this commandlet will let you create a new Azure Web app slot using ARM APIs
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppSlot"), OutputType(typeof(PSSite))]
    public class NewAzureWebAppSlotCmdlet : WebAppBaseClientCmdLet
    {

		[Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Web/sites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The name of the app service plan eg: Default1.")]
        [ResourceNameCompleter("Microsoft.Web/serverfarms", "DoNotFilter")]
        public string AppServicePlan { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The source web app to clone", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSSite SourceWebApp { get; set; }

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

		[Parameter(Mandatory = false, HelpMessage = "Container Image Name and optional tag, for example (image:tag)")]
		[ValidateNotNullOrEmpty]
		public string ContainerImageName { get; set; }

		[Parameter(Mandatory = false, HelpMessage = "Private Container Registry Server Url")]
		[ValidateNotNullOrEmpty]
		public string ContainerRegistryUrl { get; set; }

		[Parameter(Mandatory = false, HelpMessage = "Private Container Registry Username")]
		[ValidateNotNullOrEmpty]
		public string ContainerRegistryUser { get; set; }

		[Parameter(Mandatory = false, HelpMessage = "Private Container Registry Password")]
		[ValidateNotNullOrEmpty]
		public SecureString ContainerRegistryPassword { get; set; }

		[Parameter(Mandatory = false, HelpMessage = "Enables/Disables container continuous deployment webhook")]
		public SwitchParameter EnableContainerContinuousDeployment { get; set; }


		[Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        	public SwitchParameter AsJob { get; set; }

		[Parameter(Mandatory = false, HelpMessage = "Tags are name/value pairs that enable you to categorize resources")]
		public Hashtable Tag { get; set; }

		private Hashtable GetAppSettingsToUpdate()
		{
			Hashtable appSettings = new Hashtable();
			if (ContainerRegistryUrl != null)
			{
				appSettings[CmdletHelpers.DockerRegistryServerUrl] = ContainerRegistryUrl;
			}
			if (ContainerRegistryUser != null)
			{
				appSettings[CmdletHelpers.DockerRegistryServerUserName] = ContainerRegistryUser;
			}
			if (ContainerRegistryPassword != null)
			{
				appSettings[CmdletHelpers.DockerRegistryServerPassword] = ContainerRegistryPassword.ConvertToString();
			}
			if (EnableContainerContinuousDeployment.IsPresent)
			{
				appSettings[CmdletHelpers.DockerEnableCI] = "true";
			}
			return appSettings;
		}

		private void UpdateConfigIfNeeded(Site site)
		{
			SiteConfig siteConfig = site.SiteConfig;

			bool configUpdateRequired = false;
			
			if (ContainerImageName != null)
			{
				if (site.IsXenon.GetValueOrDefault())
				{
					siteConfig.WindowsFxVersion = CmdletHelpers.DockerImagePrefix + ContainerImageName;
					configUpdateRequired = true;
				}
			}

			Hashtable appSettings = GetAppSettingsToUpdate();
			if (appSettings.Count > 0)
			{
				configUpdateRequired = true;
			}

			if (configUpdateRequired && siteConfig.AppSettings != null)
			{
				foreach (NameValuePair nameValuePair in siteConfig.AppSettings)
				{
					if (!appSettings.ContainsKey(nameValuePair.Name))
					{
						appSettings[nameValuePair.Name] = nameValuePair.Value;
					}
				}
			}

			if (configUpdateRequired)
			{
				WebsitesClient.UpdateWebAppConfiguration(ResourceGroupName, site.Location, Name, Slot, siteConfig, appSettings.ConvertToStringDictionary());
				site = WebsitesClient.GetWebApp(ResourceGroupName, Name, Slot);
			}
			WriteObject(site);
		}
		public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            
            CloningInfo cloningInfo = null;
            if (SourceWebApp != null)
            {
                cloningInfo = new CloningInfo
                {
                    SourceWebAppId = SourceWebApp.Id,
                    SourceWebAppLocation = SourceWebApp.Location,
                    CloneCustomHostNames = !IgnoreCustomHostNames.IsPresent,
                    CloneSourceControl = !IgnoreSourceControl.IsPresent,
                    ConfigureLoadBalancing = false,
                    AppSettingsOverrides = AppSettingsOverrides == null ? null : AppSettingsOverrides.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString(), StringComparer.Ordinal)
                };
                cloningInfo = new PSCloningInfo(cloningInfo);
            }

            var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, Name, null));
	    var site = new PSSite(WebsitesClient.CreateWebApp(ResourceGroupName, Name, Slot, webApp.Location, AppServicePlan==null?webApp.ServerFarmId : AppServicePlan, cloningInfo, AseName, AseResourceGroupName, (IDictionary<string, string>)CmdletHelpers.ConvertToStringDictionary(Tag)));
			UpdateConfigIfNeeded(site);
        }
    }
}
