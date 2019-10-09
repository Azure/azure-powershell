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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you update the access restriction settings of an Azure Website
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppAccessRestrictionConfig", SupportsShouldProcess = true, DefaultParameterSetName = InputValuesParameterSet)]
    [OutputType(typeof(PSAccessRestrictionConfig))]
    public class UpdateAzureWebAppAccessRestrictionConfigCmdlet : WebAppBaseClientCmdLet
    {
        private const string InputValuesParameterSet = "InputValuesParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(ParameterSetName = InputValuesParameterSet, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = InputValuesParameterSet, Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Web/sites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = InputValuesParameterSet, Mandatory = true, HelpMessage = "Scm site inherits rules set on Main site.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ScmSiteUseMainSiteRestrictionConfig { get; set; }

        [Parameter(ParameterSetName = InputValuesParameterSet, Mandatory = false, HelpMessage = "Deployment Slot name.")]
        public string SlotName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return the access restriction config object.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The access restriction config object")]
        [ValidateNotNullOrEmpty]
        public PSAccessRestrictionConfig InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            bool inheritConfig = false;
            switch (ParameterSetName)
            {
                case InputValuesParameterSet:
                    inheritConfig = ScmSiteUseMainSiteRestrictionConfig;
                    break;
                case InputObjectParameterSet:
                    inheritConfig = InputObject.ScmSiteUseMainSiteRestrictionConfig;
                    ResourceGroupName = InputObject.ResourceGroupName;
                    Name = InputObject.WebAppName;
                    SlotName = InputObject.SlotName;
                    break;
            }
            string updateActionText = inheritConfig ? "" : "not ";

            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(Name))
            {
                if (ShouldProcess(Name, $"Update Scm Site of WebApp '{Name}' to {updateActionText}use Main Site Access Restriction Config"))
                {
                    var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, Name, SlotName));
                    SiteConfig siteConfig = webApp.SiteConfig;

                    if (siteConfig.ScmIpSecurityRestrictionsUseMain != inheritConfig)
                    {
                        siteConfig.ScmIpSecurityRestrictionsUseMain = inheritConfig;

                        // Update web app configuration
                        WebsitesClient.UpdateWebAppConfiguration(ResourceGroupName, webApp.Location, Name, SlotName, siteConfig);
                    }

                    if (PassThru)
                    {
                        var accessRestrictionConfig = new PSAccessRestrictionConfig(ResourceGroupName, Name, webApp.SiteConfig, SlotName);
                        WriteObject(accessRestrictionConfig);
                    }
                }
            }
        }
    }
}
