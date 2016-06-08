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
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.GeoEntities;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services
{
    public static class WebsitesExtensionMethods
    {
        public static WebSpaces GetWebSpaces(this IWebsitesServiceManagement proxy, string subscriptionId)
        {
            return proxy.EndGetWebSpaces(proxy.BeginGetWebSpaces(subscriptionId, null, null));
        }

        public static WebSpace GetWebSpace(this IWebsitesServiceManagement proxy, string subscriptionId, string name)
        {
            return proxy.EndGetWebSpace(proxy.BeginGetWebSpace(subscriptionId, name, null, null));
        }

        public static WebSpace CreateWebSpace(this IWebsitesServiceManagement proxy, string subscriptionId, bool allowPendingState, WebSpace webSpace)
        {
            return proxy.EndCreateWebSpace(proxy.BeginCreateWebSpace(subscriptionId, allowPendingState, webSpace, null, null));
        }

        public static WebSpace UpdateWebSpace(this IWebsitesServiceManagement proxy, string subscriptionId, string name, bool allowPendingState, WebSpace webSpace)
        {
            return proxy.EndUpdateWebSpace(proxy.BeginUpdateWebSpace(subscriptionId, name, allowPendingState, webSpace, null, null));
        }

        public static void DeleteWebSpace(this IWebsitesServiceManagement proxy, string subscriptionId, string name)
        {
            proxy.EndDeleteWebSpace(proxy.BeginDeleteWebSpace(subscriptionId, name, null, null));
        }

        public static string[] GetSubscriptionPublishingUsers(this IWebsitesServiceManagement proxy, string subscriptionId)
        {
            return proxy.EndGetSubscriptionPublishingUsers(proxy.BeginGetSubscriptionPublishingUsers(subscriptionId, null, null));
        }

        public static Sites GetSites(this IWebsitesServiceManagement proxy, string subscriptionId, string webspaceName, string propertiesToInclude)
        {
            return proxy.EndGetSites(proxy.BeginGetSites(subscriptionId, webspaceName, propertiesToInclude, null, null));
        }

        public static Site GetSite(this IWebsitesServiceManagement proxy, string subscriptionId, string webspaceName, string name, string propertiesToInclude)
        {
            return proxy.EndGetSite(proxy.BeginGetSite(subscriptionId, webspaceName, name, propertiesToInclude, null, null));
        }

        public static Site CreateSite(this IWebsitesServiceManagement proxy, string subscriptionId, string webspaceName, Site site)
        {
            return proxy.EndCreateSite(proxy.BeginCreateSite(subscriptionId, webspaceName, site, null, null));
        }

        public static void UpdateSite(this IWebsitesServiceManagement proxy, string subscriptionId, string webspaceName, string name, Site site)
        {
            proxy.EndUpdateSite(proxy.BeginUpdateSite(subscriptionId, webspaceName, name, site, null, null));
        }

        public static void DeleteSite(this IWebsitesServiceManagement proxy, string subscriptionId, string webspaceName, string name, string deleteMetrics)
        {
            proxy.EndDeleteSite(proxy.BeginDeleteSite(subscriptionId, webspaceName, name, deleteMetrics, null, null));
        }

        public static SiteConfig GetSiteConfig(this IWebsitesServiceManagement proxy, string subscriptionId, string webspaceName, string name)
        {
            return proxy.EndGetSiteConfig(proxy.BeginGetSiteConfig(subscriptionId, webspaceName, name, null, null));
        }

        public static void UpdateSiteConfig(this IWebsitesServiceManagement proxy, string subscriptionId, string webspaceName, string name, SiteConfig siteConfig)
        {
            proxy.EndUpdateSiteConfig(proxy.BeginUpdateSiteConfig(subscriptionId, webspaceName, name, siteConfig, null, null));
        }

        public static void CreateSiteRepository(this IWebsitesServiceManagement proxy, string subscriptionId, string webspaceName, string name)
        {
            proxy.EndCreateSiteRepository(proxy.BeginCreateSiteRepository(subscriptionId, webspaceName, name, null, null));
        }

        public static GeoRegions GetRegions(this IWebsitesServiceManagement proxy, bool listOnlyOnline)
        {
            return proxy.EndGetRegions(proxy.BeginGetRegions(listOnlyOnline, null, null));
        }

        public static GeoLocations GetLocations(this IWebsitesServiceManagement proxy, string regionName)
        {
            return proxy.EndGetLocations(proxy.BeginGetLocations(regionName, null, null));
        }

        public static Site GetSiteWithCache(
            this IWebsitesServiceManagement proxy,
            string subscriptionId,
            string website,
            string propertiesToInclude)
        {
            // Try to get the website's webspace from the cache
            Site site = Cache.GetSite(subscriptionId, website, propertiesToInclude);
            if (site != null)
            {
                try
                {
                    return proxy.GetSite(subscriptionId, site.WebSpace, site.Name, propertiesToInclude);
                }
                catch
                {
                    // The website is removed or it's webspace changed.
                    Cache.RemoveSite(subscriptionId, site);
                    throw;
                }
            }

            // Get all available webspace using REST API
            WebSpaces webspaces = proxy.GetWebSpaces(subscriptionId);

            // Iterate over all the webspaces until finding the website.
            foreach (WebSpace webspace in webspaces)
            {
                Sites websites = proxy.GetSites(subscriptionId, webspace.Name, propertiesToInclude);
                var matchWebsite = websites.FirstOrDefault(w => w.Name.Equals(website, System.StringComparison.InvariantCultureIgnoreCase));
                if (matchWebsite != null)
                {
                    return matchWebsite;
                }
            }

            // The website does not exist.
            return null;
        }
    }
}
