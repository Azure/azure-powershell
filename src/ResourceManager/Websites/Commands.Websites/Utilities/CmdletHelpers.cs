using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    public static class CmdletHelpers
    {
        public static HashSet<string> SiteConfigParameters = new HashSet<string>
            {
                "DefaultDocuments",
                "NetFrameworkVersion",
                "PhpVersion",
                "RequestTracingEnabled",
                "HttpLoggingEnabled",
                "DetailedErrorLoggingEnabled",
                "HandlerMappings",
                "ManagedPipelineMode",
                "WebSocketsEnabled",
                "Use32BitWorkerProcess",
                "AutoSwapSlotName"
            };

        private static readonly Regex AppWithSlotNameRegex = new Regex(@"^(?<siteName>[^\(]+)\((?<slotName>[^\)]+)\)$");

        private static readonly Regex WebAppResourceIdRegex =
            new Regex(@"^\/subscriptions\/(?<subscriptionName>[^\/]+)\/resourceGroups\/(?<resourceGroupName>[^\/]+)\/providers\/Microsoft.Web\/sites\/(?<siteName>[^\/]+)$", RegexOptions.IgnoreCase);

        private static readonly Regex WebAppSlotResourceIdRegex =
           new Regex(@"^\/subscriptions\/(?<subscriptionName>[^\/]+)\/resourceGroups\/(?<resourceGroupName>[^\/]+)\/providers\/Microsoft.Web\/sites\/(?<siteName>[^\/]+)\/slots\/(?<slotName>[^\/]+)$", RegexOptions.IgnoreCase);

        private static readonly Regex AppServicePlanResourceIdRegex =
           new Regex(@"^\/subscriptions\/(?<subscriptionName>[^\/]+)\/resourceGroups\/(?<resourceGroupName>[^\/]+)\/providers\/Microsoft.Web\/serverFarms\/(?<serverFarmName>[^\/]+)$", RegexOptions.IgnoreCase);

        private static readonly Dictionary<string, int> WorkerSizes = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase) { { "Small", 1 }, { "Medium", 2 }, { "Large", 3 }, { "ExtraLarge", 4 } };

        private const string ProductionSlotName = "Production";

        private const string FmtSiteWithSlotName = "{0}({1})";
        public const string ApplicationServiceEnvironmentResourcesName = "hostingEnvironments";
        private const string ApplicationServiceEnvironmentResourceIdFormat =
            "/subscriptions/{0}/resourcegroups/{1}/providers/Microsoft.Web/{2}/{3}";

        public static Dictionary<string, string> ConvertToStringDictionary(this Hashtable hashtable)
        {
            return hashtable == null ? null : hashtable.Cast<DictionaryEntry>()
                .ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString(), StringComparer.Ordinal);
        }

        public static Dictionary<string, ConnStringValueTypePair> ConvertToConnectionStringDictionary(this Hashtable hashtable)
        {
            return hashtable == null ? null : hashtable.Cast<DictionaryEntry>()
                .ToDictionary(
                kvp => kvp.Key.ToString(), kvp =>
                {
                    var typeValuePair = new Hashtable((Hashtable)kvp.Value, StringComparer.OrdinalIgnoreCase);
                    var type = (DatabaseServerType?)Enum.Parse(typeof(DatabaseServerType), typeValuePair["Type"].ToString(), true);
                    return new ConnStringValueTypePair
                    {
                        Type = type,
                        Value = typeValuePair["Value"].ToString()
                    };
                });
        }

        internal static bool ShouldUseDeploymentSlot(string webSiteName, string slotName, out string qualifiedSiteName)
        {
            bool result = false;
            qualifiedSiteName = webSiteName;
            var siteNamePattern = "{0}({1})";
            if (!string.IsNullOrEmpty(slotName) && !string.Equals(slotName, "Production", StringComparison.OrdinalIgnoreCase))
            {
                result = true;
                qualifiedSiteName = string.Format(siteNamePattern, webSiteName, slotName);
            }

            return result;
        }

        internal static HostingEnvironmentProfile CreateHostingEnvironmentProfile(string subscriptionId, string resourceGroupName, string aseResourceGroupName, string aseName)
        {
            var rg = string.IsNullOrEmpty(aseResourceGroupName) ? resourceGroupName : aseResourceGroupName;
            var aseResourceId = CmdletHelpers.GetApplicationServiceEnvironmentResourceId(subscriptionId, rg, aseName);
            return new HostingEnvironmentProfile
            {
                Id = aseResourceId,
                Type = CmdletHelpers.ApplicationServiceEnvironmentResourcesName,
                Name = aseName
            };
        }

        internal static string BuildMetricFilter(DateTime? startTime, DateTime? endTime, string timeGrain, IReadOnlyList<string> metricNames)
        {
            var dateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
            var filter = "";
            if (metricNames != null && metricNames.Count > 0)
            {
                if (metricNames.Count == 1)
                {
                    filter = "name.value eq '" + metricNames[0] + "'";
                }
                else
                {
                    filter = "(name.value eq '" + string.Join("' or name.value eq '", metricNames) + "')";
                }
            }

            if (startTime.HasValue)
            {
                filter += string.Format("and startTime eq {0}", startTime.Value.ToString(dateTimeFormat));
            }

            if (endTime.HasValue)
            {
                filter += string.Format("and endTime eq {0}", endTime.Value.ToString(dateTimeFormat));
            }

            if (!string.IsNullOrWhiteSpace(timeGrain))
            {
                filter += string.Format("and timeGrain eq duration'{0}'", timeGrain);
            }

            return filter;
        }

        internal static bool TryParseWebAppMetadataFromResourceId(string resourceId, out string resourceGroupName,
            out string webAppName, out string slotName, bool failIfSlot = false)
        {
            var match = WebAppSlotResourceIdRegex.Match(resourceId);
            if (match.Success)
            {
                resourceGroupName = match.Groups["resourceGroupName"].Value;
                webAppName = match.Groups["siteName"].Value;
                slotName = match.Groups["slotName"].Value;

                return !failIfSlot & true;
            }

            match = WebAppResourceIdRegex.Match(resourceId);
            if (match.Success)
            {
                resourceGroupName = match.Groups["resourceGroupName"].Value;
                webAppName = match.Groups["siteName"].Value;
                slotName = null;

                return true;
            }

            resourceGroupName = null;
            webAppName = null;
            slotName = null;

            return false;
        }

        internal static bool TryParseAppServicePlanMetadataFromResourceId(string resourceId, out string resourceGroupName,
            out string appServicePlanName)
        {
            var match = AppServicePlanResourceIdRegex.Match(resourceId);
            if (match.Success)
            {
                resourceGroupName = match.Groups["resourceGroupName"].Value;
                appServicePlanName = match.Groups["serverFarmName"].Value;

                return true;
            }

            resourceGroupName = null;
            appServicePlanName = null;

            return false;
        }

        internal static string GetSkuName(string tier, int workerSize)
        {
            string sku;
            if (string.Equals("Shared", tier, StringComparison.OrdinalIgnoreCase))
            {
                sku = "D";
            }
            else
            {
                sku = string.Empty + tier[0];
            }

            sku += workerSize;
            return sku;
        }

        internal static string GetSkuName(string tier, string workerSize)
        {
            string sku;
            if (string.Equals("Shared", tier, StringComparison.OrdinalIgnoreCase))
            {
                sku = "D";
            }
            else
            {
                sku = string.Empty + tier[0];
            }

            sku += WorkerSizes[workerSize];
            return sku;
        }

        internal static bool IsDeploymentSlot(string name)
        {
            return AppWithSlotNameRegex.IsMatch(name);
        }

        internal static bool TryParseAppAndSlotNames(string name, out string webAppName, out string slotName)
        {
            var match = AppWithSlotNameRegex.Match(name);
            if (match.Success)
            {
                webAppName = match.Groups["siteName"].Value;
                slotName = match.Groups["slotName"].Value;
                return true;
            }

            webAppName = name;
            slotName = null;

            return false;
        }

        public static string GenerateSiteWithSlotName(string siteName, string slotName)
        {
            if (!string.IsNullOrEmpty(slotName) && !string.Equals(slotName, ProductionSlotName, StringComparison.OrdinalIgnoreCase))
            {
                return string.Format(FmtSiteWithSlotName, siteName, slotName);
            }

            return siteName;
        }

        internal static string GetApplicationServiceEnvironmentResourceId(string subscriptionId, string resourceGroupName, string applicationServiceEnvironmentName)
        {
            return string.Format(ApplicationServiceEnvironmentResourceIdFormat, subscriptionId, resourceGroupName, ApplicationServiceEnvironmentResourcesName,
                applicationServiceEnvironmentName);
        }

        internal static HostNameSslState[] GetHostNameSslStatesFromSiteResponse(Site site, string hostName = null)
        {
            var hostNameSslState = new HostNameSslState[0];
            if (site.HostNameSslStates != null)
            {
                hostNameSslState = site.HostNameSslStates.Where(h => h.SslState.HasValue && h.SslState.Value != SslState.Disabled).ToArray();
                if (!string.IsNullOrEmpty(hostName))
                {
                    hostNameSslState = hostNameSslState.Where(h => string.Equals(h.Name, hostName)).ToArray();
                }
            }
            return hostNameSslState;
        }

        internal static string GetResourceGroupFromResourceId(string resourceId)
        {
            return new ResourceIdentifier(resourceId).ResourceGroupName;
        }

        internal static void ExtractWebAppPropertiesFromWebApp(Site webapp, out string resourceGroupName, out string webAppName, out string slot)
        {
            resourceGroupName = GetResourceGroupFromResourceId(webapp.Id);

            string webAppNameTemp, slotNameTemp;
            if (TryParseAppAndSlotNames(webapp.SiteName, out webAppNameTemp, out slotNameTemp))
            {
                webAppName = webAppNameTemp;
                slot = slotNameTemp;
            }
            else
            {
                webAppName = webapp.Name;
                slot = null;
            }
        }

        internal static Certificate[] GetCertificates(ResourcesClient resourceClient, WebsitesClient websitesClient, string resourceGroupName, string thumbPrint)
        {
            var certificateResources = resourceClient.FilterPSResources(new BasePSResourceParameters()
            {
                ResourceType = "Microsoft.Web/Certificates"
            }).ToArray();

            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                certificateResources = certificateResources.Where(c => string.Equals(c.ResourceGroupName, resourceGroupName, StringComparison.OrdinalIgnoreCase)).ToArray();
            }

            var certificates =
                certificateResources.Select(
                    certificateResource =>
                    websitesClient.GetCertificate(certificateResource.ResourceGroupName, certificateResource.Name));

            if (!string.IsNullOrEmpty(thumbPrint))
            {
                certificates = certificates.Where(c => string.Equals(c.Thumbprint, thumbPrint, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return certificates.ToArray();
        }
    }
}
