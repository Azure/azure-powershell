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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;
using Hyak.Common;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    /// <summary>
    /// Gets an azure website.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureWebsite"), OutputType(typeof(SiteWithConfig), typeof(IEnumerable<Site>))]
    public class GetAzureWebsiteCommand : WebsiteContextBaseCmdlet
    {
        public GetAzureWebsiteCommand()
        {
            websiteNameDiscovery = false;
        }

        protected virtual void WriteWebsites(IEnumerable<Site> websites)
        {
            WriteObject(websites, true);
        }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                GetByName();
            }
            else
            {
                GetNoName();
            }
        }

        private void GetByName()
        {
            Do(() =>
                {
                    if (string.IsNullOrEmpty(Slot))
                    {
                        List<Site> websites = WebsitesClient.GetWebsiteSlots(Name);
                        Cache.SaveSites(Profile.Context.Subscription.Id.ToString(), new Sites(websites));

                        if (websites.Count > 1)
                        {
                            WriteWebsites(websites);
                        }
                        else if (websites.Count == 1)
                        {
                            Site websiteObject = websites[0];
                            WriteWebsite(websiteObject);
                        }
                    }
                    else
                    {
                        Site websiteObject = WebsitesClient.GetWebsite(Name, Slot);
                        WriteWebsite(websiteObject);
                    }
                });
        }

        private void WriteWebsite(Site websiteObject)
        {
            SiteConfig config = WebsitesClient.GetWebsiteConfiguration(websiteObject.Name);

            var diagnosticSettings = new DiagnosticsSettings();
            try
            {
                diagnosticSettings = WebsitesClient.GetApplicationDiagnosticsSettings(websiteObject.Name);
            }
            catch
            {
                // Ignore exception and use default values
            }

            WebsiteInstance[] instanceIds;
            try
            {
                instanceIds = WebsitesClient.ListWebsiteInstances(websiteObject.WebSpace, websiteObject.Name);
            }
            catch
            {
                // TODO: Temporary workaround for issue where slots are not supported with this API (yet).
                instanceIds = new WebsiteInstance[0];
            }

            WriteObject(new SiteWithConfig(websiteObject, config, diagnosticSettings, instanceIds), false);
        }

        private void GetNoName()
        {
            Do(() =>
                {
                    List<Site> websites;
                    if (string.IsNullOrEmpty(Slot))
                    {
                        websites = WebsitesClient.ListWebsites();
                    }
                    else
                    {
                        websites = WebsitesClient.ListWebsites(Slot);
                    }

                    Cache.SaveSites(Profile.Context.Subscription.Id.ToString(), new Sites(websites));
                    WriteWebsites(websites);
                });
        }

        private void Do(Action call)
        {
            try
            {
                call();
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    WriteError(new ErrorRecord(new Exception(Resources.CommunicationCouldNotBeEstablished, ex), string.Empty, ErrorCategory.InvalidData, null));
                    throw;
                }
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception(string.Format(Resources.InvalidWebsite, Name));
                }
                throw;
            }
        }
    }
}
