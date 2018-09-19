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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;
using Microsoft.WindowsAzure.Management.WebSites.Models;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    /// <summary>
    /// Sets an azure website properties.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureWebsite"), OutputType(typeof(bool))]
    public class SetAzureWebsiteCommand : WebsiteContextBaseCmdlet
    {
        private string[] hostNames;

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Number of workers.")]
        [ValidateNotNullOrEmpty]
        public int? NumberOfWorkers { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Default Documents.")]
        public string[] DefaultDocuments { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ".NET framework version.")]
        [ValidateNotNullOrEmpty]
        public string NetFrameworkVersion { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "PHP Version.")]
        [ValidateNotNullOrEmpty]
        public string PhpVersion { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Request tracing enabled.")]
        [ValidateNotNullOrEmpty]
        public bool? RequestTracingEnabled { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "HTTP Logging enabled.")]
        [ValidateNotNullOrEmpty]
        public bool? HttpLoggingEnabled { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Detailed Error Logging enabled.")]
        [ValidateNotNullOrEmpty]
        public bool? DetailedErrorLoggingEnabled { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Hostnames.")]
        [ValidateNotNullOrEmpty]
        public string[] HostNames
        {
            get
            {
                return hostNames;
            }
            set
            {
                hostNames = value;

                // Convert each host name to Unicode if necessary.
                if (hostNames != null)
                {
                    for (int i = 0; i < hostNames.Length; i++)
                    {
                        hostNames[i] = IdnHelper.GetUnicode(hostNames[i]);
                    }
                }
            }
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A string for the App Settings.")]
        public Hashtable AppSettings { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The Metadata.")]
        public List<NameValuePair> Metadata { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The Connection Strings.")]
        public ConnStringPropertyBag ConnectionStrings { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The Handler Mappings.")]
        public HandlerMapping[] HandlerMappings { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A previous site configuration.")]
        public SiteWithConfig SiteWithConfig { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed pipeline mode of a website.")]
        public ManagedPipelineMode? ManagedPipelineMode { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The web sockets flag.")]
        public bool? WebSocketsEnabled { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of routing rules for testing in production.")]
        public List<Utilities.Websites.Services.WebEntities.RoutingRule> RoutingRules { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates if 32-bit mode is enabled.")]
        public bool? Use32BitWorkerProcess { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Sets the slot name to swap with after successful deployment. To remove set to null or empty string.")]
        public string AutoSwapSlotName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Sets the list of application setting names to be bound to slot and not swapped on swap operation.")]
        public List<string> SlotStickyAppSettingNames { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Sets the list of connection string names to be bound to slot and not swapped on swap operation.")]
        public List<string> SlotStickyConnectionStringNames { get; set; }

        private Site website;
        private SiteConfig currentSiteConfig;

        public override void ExecuteCmdlet()
        {
            GetCurrentSiteState();
            UpdateConfig();
            UpdateHostNames();
            Slot = null;

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }

        private void GetCurrentSiteState()
        {
            website = WebsitesClient.GetWebsite(Name, Slot);
            currentSiteConfig = WebsitesClient.GetWebsiteConfiguration(Name, Slot);
        }

        private void UpdateConfig()
        {
            bool changes = false;
            var websiteConfigUpdate = new SiteWithConfig(website, currentSiteConfig);
            if (SiteWithConfig != null)
            {
                websiteConfigUpdate = SiteWithConfig;
                changes = true;
            }

            changes = changes || ObjectDeltaMapper.Map(this, currentSiteConfig, websiteConfigUpdate, "HostNames", "SiteWithConfig", "PassThru");

            if (changes)
            {
                WebsitesClient.UpdateWebsiteConfiguration(Name, websiteConfigUpdate.GetSiteConfig(), Slot);
            }
        }

        private void UpdateHostNames()
        {
            if (HostNames != null)
            {
                string hostname = WebsitesClient.GetHostName(Name, Slot);
                List<string> newHostNames = new List<string>();
                if (!HostNames.Contains(hostname))
                {
                    newHostNames.Add(hostname);
                    newHostNames.AddRange(HostNames);
                }

                if (newHostNames.Count > 0)
                {
                    WebsitesClient.UpdateWebsiteHostNames(website, newHostNames, Slot);
                }
            }

        }
    }
}
