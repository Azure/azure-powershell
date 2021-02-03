using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    public static class CmdletHelpers
    {
        public static NetworkManagementClient networkClient
        {
            get;
            private set;
        }
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
                "AutoSwapSlotName",
                "NumberOfWorkers",
                "AlwaysOn",
                "MinTlsVersion",
                "FtpsState"
            };

        public static HashSet<string> SiteParameters = new HashSet<string>
            {
                "HttpsOnly",
                "AssignIdentity"
            };

        private static readonly Regex AppWithSlotNameRegex = new Regex(@"^(?<siteName>[^\(]+)/(?<slotName>[^\)]+)$");

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

        public const string DockerRegistryServerUrl = "DOCKER_REGISTRY_SERVER_URL";
        public const string DockerRegistryServerUserName = "DOCKER_REGISTRY_SERVER_USERNAME";
        public const string DockerRegistryServerPassword = "DOCKER_REGISTRY_SERVER_PASSWORD";
        public const string DockerEnableCI = "DOCKER_ENABLE_CI";
        public const string DockerImagePrefix = "DOCKER|";

        public static Dictionary<string, string> ConvertToStringDictionary(this Hashtable hashtable)
        {
            return hashtable?.Cast<DictionaryEntry>()
                .ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString(), StringComparer.Ordinal);
        }

        public static Dictionary<string, ConnStringValueTypePair> ConvertToConnectionStringDictionary(this Hashtable hashtable)
        {
            return hashtable?.Cast<DictionaryEntry>()
                .ToDictionary(
                    kvp => kvp.Key.ToString(), kvp =>
                    {
                        var typeValuePair = new Hashtable((Hashtable)kvp.Value, StringComparer.OrdinalIgnoreCase);
                        var type = (ConnectionStringType)Enum.Parse(typeof(ConnectionStringType), typeValuePair["Type"].ToString(), true);
                        return new ConnStringValueTypePair
                        {
                            Type = type,
                            Value = typeValuePair["Value"].ToString()
                        };
                    });
        }

        public static AzureStoragePropertyDictionaryResource ConvertToAzureStorageAccountPathPropertyDictionary(this Hashtable hashtable)
        {
            if (hashtable == null)
                return null;
            AzureStoragePropertyDictionaryResource result = new AzureStoragePropertyDictionaryResource();
            result.Properties = hashtable.Cast<DictionaryEntry>()
                .ToDictionary(
                kvp => kvp.Key.ToString(), kvp =>
                {
                    var typeValuePair = new Hashtable((Hashtable)kvp.Value, StringComparer.OrdinalIgnoreCase);
                    return new AzureStorageInfoValue
                    {
                        AccessKey = typeValuePair["AccessKey"].ToString(),
                        AccountName = typeValuePair["AccountName"].ToString(),
                        MountPath = typeValuePair["MountPath"].ToString(),
                        ShareName = typeValuePair["ShareName"].ToString(),
                        Type = (AzureStorageType)Enum.Parse(typeof(AzureStorageType), typeValuePair["Type"].ToString(), true)
                    };
                });

            return result;
        }

        public static AzureStoragePropertyDictionaryResource ConvertToAzureStorageAccountPathPropertyDictionary(this WebAppAzureStoragePath[] webAppAzureStorageProperties)
        {
            if (webAppAzureStorageProperties == null)
                return null;
            AzureStoragePropertyDictionaryResource result = new AzureStoragePropertyDictionaryResource();
            result.Properties = new Dictionary<string, AzureStorageInfoValue>();
            foreach (var item in webAppAzureStorageProperties)
            {
                result.Properties.Add(
                    new KeyValuePair<string, AzureStorageInfoValue>(
                        item.Name,
                        new AzureStorageInfoValue(
                            item.Type,
                            item.AccountName,
                            item.ShareName,
                            item.AccessKey,
                            item.MountPath)));
            }

            return result;
        }

        public static WebAppAzureStoragePath[] ConvertToWebAppAzureStorageArray(this IDictionary<string, AzureStorageInfoValue> webAppAzureStorageDictionary)
        {
            if (webAppAzureStorageDictionary == null)
                return null;
            List<WebAppAzureStoragePath> result = new List<WebAppAzureStoragePath>();
            foreach (var item in webAppAzureStorageDictionary)
            {
                var azureStoragePath = new WebAppAzureStoragePath()
                {
                    Name = item.Key,
                    AccessKey = item.Value.AccessKey,
                    AccountName = item.Value.AccountName,
                    ShareName = item.Value.ShareName,
                    MountPath = item.Value.MountPath,
                    Type = item.Value.Type
                };

                result.Add(azureStoragePath);
            }

            return result.ToArray();
        }


        internal static bool ShouldUseDeploymentSlot(string webSiteName, string slotName, out string qualifiedSiteName)
        {
            var result = false;
            qualifiedSiteName = webSiteName;
            // TODO: Remove IfDef
#if NETSTANDARD
            const string siteNamePattern = "{0}/{1}";
#else
            const string siteNamePattern = "{0}({1})";
#endif
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
            return new HostingEnvironmentProfile(
                aseResourceId,
                CmdletHelpers.ApplicationServiceEnvironmentResourcesName,
                aseName);
        }

        internal static string BuildMetricFilter(DateTime? startTime, DateTime? endTime, string timeGrain, IReadOnlyList<string> metricNames)
        {
            const string dateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
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
            else if (string.Equals("PremiumV2", tier, StringComparison.OrdinalIgnoreCase))
            {
                sku = "P" + workerSize + "V2";
                return sku;
            }
            else if (string.Equals("PremiumV3", tier, StringComparison.OrdinalIgnoreCase))
            {
                sku = "P" + workerSize + "V3";
                return sku;
            }
            else if (string.Equals("PremiumContainer", tier, StringComparison.OrdinalIgnoreCase))
            {
                sku = "PC" + (workerSize + 1);
                return sku;
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
            else if (string.Equals("PremiumV2", tier, StringComparison.OrdinalIgnoreCase))
            {
                sku = "P" + WorkerSizes[workerSize] + "V2";
                return sku;
            }
            else if (string.Equals("PremiumV3", tier, StringComparison.OrdinalIgnoreCase))
            {
                sku = "P" + WorkerSizes[workerSize] + "V3";
                return sku;
            }
            else if (string.Equals("PremiumContainer", tier, StringComparison.OrdinalIgnoreCase))
            {
                sku = "PC" + (WorkerSizes[workerSize] + 1);
                return sku;
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
            if (TryParseAppAndSlotNames(
                webapp.Name,
                out webAppNameTemp,
                out slotNameTemp))
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

        internal static Certificate[] GetCertificates(ResourceClient resourceClient, WebsitesClient websitesClient, string resourceGroupName, string thumbPrint)
        {
            var certificateResources = resourceClient.ResourceManagementClient.FilterResources(new FilterResourcesOptions
            {
                ResourceGroup = resourceGroupName,
                ResourceType = "Microsoft.Web/Certificates"
            }).ToArray();

            var certificates =
                certificateResources.Select(
                    certificateResource =>
                    websitesClient.GetCertificate(certificateResource.ResourceGroupName ?? GetResourceGroupFromResourceId(certificateResource.Id), certificateResource.Name));

            if (!string.IsNullOrEmpty(thumbPrint))
            {
                certificates = certificates.Where(c => string.Equals(c.Thumbprint, thumbPrint, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return certificates.ToArray();
        }

        internal static string CheckServicePrincipalPermissions(ResourceClient resourceClient, KeyVaultClient keyVaultClient, string resourceGroupName, string keyVault)
        {
            var perm1 = " ";
            var kv2 = keyVaultClient.GetKeyVault(resourceGroupName, keyVault);
            foreach (var policy in kv2.Properties.AccessPolicies)
            {
                if (policy.ObjectId == ("f8daea97-62e7-4026-becf-13c2ea98e8b4"))
                {
                    foreach (var perm in policy.Permissions.Secrets)
                    {
                        if ((perm == "Get") || (perm == "get"))
                        {
                            perm1 = perm;
                            Console.WriteLine("Success");
                            break;
                        }
                    }
                }
            }
            return perm1.ToString();
        }

        internal static SiteConfigResource ConvertToSiteConfigResource(this SiteConfig config)
        {
            return new SiteConfigResource
            {
                AlwaysOn = config.AlwaysOn,
                ApiDefinition = config.ApiDefinition,
                AppCommandLine = config.AppCommandLine,
                AppSettings = config.AppSettings,
                AutoHealEnabled = config.AutoHealEnabled,
                AutoHealRules = config.AutoHealRules,
                AutoSwapSlotName = config.AutoSwapSlotName,
                ConnectionStrings = config.ConnectionStrings,
                Cors = config.Cors,
                DefaultDocuments = config.DefaultDocuments,
                DetailedErrorLoggingEnabled = config.DetailedErrorLoggingEnabled,
                DocumentRoot = config.DocumentRoot,
                Experiments = config.Experiments,
                HandlerMappings = config.HandlerMappings,
                HttpLoggingEnabled = config.HttpLoggingEnabled,
                IpSecurityRestrictions = config.IpSecurityRestrictions,
                ScmIpSecurityRestrictions = config.ScmIpSecurityRestrictions,
                ScmIpSecurityRestrictionsUseMain = config.ScmIpSecurityRestrictionsUseMain,
                Http20Enabled = config.Http20Enabled,
                JavaContainer = config.JavaContainer,
                JavaContainerVersion = config.JavaContainerVersion,
                JavaVersion = config.JavaVersion,
                Limits = config.Limits,
                LinuxFxVersion = config.LinuxFxVersion,
                LoadBalancing = config.LoadBalancing,
                LocalMySqlEnabled = config.LocalMySqlEnabled,
                LogsDirectorySizeLimit = config.LogsDirectorySizeLimit,
                ManagedPipelineMode = config.ManagedPipelineMode,
                NetFrameworkVersion = config.NetFrameworkVersion,
                NodeVersion = config.NodeVersion,
                NumberOfWorkers = config.NumberOfWorkers,
                PhpVersion = config.PhpVersion,
                PublishingUsername = config.PublishingUsername,
                Push = config.Push,
                PythonVersion = config.PythonVersion,
                RemoteDebuggingEnabled = config.RemoteDebuggingEnabled,
                RemoteDebuggingVersion = config.RemoteDebuggingVersion,
                RequestTracingEnabled = config.RequestTracingEnabled,
                RequestTracingExpirationTime = config.RequestTracingExpirationTime,
                ScmType = config.ScmType,
                TracingOptions = config.TracingOptions,
                Use32BitWorkerProcess = config.Use32BitWorkerProcess,
                VirtualApplications = config.VirtualApplications,
                VnetName = config.VnetName,
                WebSocketsEnabled = config.WebSocketsEnabled,
                WindowsFxVersion = config.WindowsFxVersion,
                ManagedServiceIdentityId = config.ManagedServiceIdentityId,
                MinTlsVersion = config.MinTlsVersion,
                FtpsState = config.FtpsState
            };
        }

        internal static SiteConfig ConvertToSiteConfig(this SiteConfigResource config)
        {
            return new SiteConfig
            {
                AlwaysOn = config.AlwaysOn,
                ApiDefinition = config.ApiDefinition,
                AppCommandLine = config.AppCommandLine,
                AppSettings = config.AppSettings,
                AutoHealEnabled = config.AutoHealEnabled,
                AutoHealRules = config.AutoHealRules,
                AutoSwapSlotName = config.AutoSwapSlotName,
                ConnectionStrings = config.ConnectionStrings,
                Cors = config.Cors,
                DefaultDocuments = config.DefaultDocuments,
                DetailedErrorLoggingEnabled = config.DetailedErrorLoggingEnabled,
                DocumentRoot = config.DocumentRoot,
                Experiments = config.Experiments,
                HandlerMappings = config.HandlerMappings,
                HttpLoggingEnabled = config.HttpLoggingEnabled,
                IpSecurityRestrictions = config.IpSecurityRestrictions,
                JavaContainer = config.JavaContainer,
                JavaContainerVersion = config.JavaContainerVersion,
                JavaVersion = config.JavaVersion,
                Limits = config.Limits,
                LinuxFxVersion = config.LinuxFxVersion,
                LoadBalancing = config.LoadBalancing,
                LocalMySqlEnabled = config.LocalMySqlEnabled,
                LogsDirectorySizeLimit = config.LogsDirectorySizeLimit,
                ManagedPipelineMode = config.ManagedPipelineMode,
                NetFrameworkVersion = config.NetFrameworkVersion,
                NodeVersion = config.NodeVersion,
                NumberOfWorkers = config.NumberOfWorkers,
                PhpVersion = config.PhpVersion,
                PublishingUsername = config.PublishingUsername,
                Push = config.Push,
                PythonVersion = config.PythonVersion,
                RemoteDebuggingEnabled = config.RemoteDebuggingEnabled,
                RemoteDebuggingVersion = config.RemoteDebuggingVersion,
                RequestTracingEnabled = config.RequestTracingEnabled,
                RequestTracingExpirationTime = config.RequestTracingExpirationTime,
                ScmType = config.ScmType,
                TracingOptions = config.TracingOptions,
                Use32BitWorkerProcess = config.Use32BitWorkerProcess,
                VirtualApplications = config.VirtualApplications,
                VnetName = config.VnetName,
                WebSocketsEnabled = config.WebSocketsEnabled,
                WindowsFxVersion = config.WindowsFxVersion,
                ManagedServiceIdentityId = config.ManagedServiceIdentityId,
                MinTlsVersion = config.MinTlsVersion,
                FtpsState = config.FtpsState,
                ScmIpSecurityRestrictions = config.ScmIpSecurityRestrictions,
                ScmIpSecurityRestrictionsUseMain = config.ScmIpSecurityRestrictionsUseMain,
                Http20Enabled = config.Http20Enabled
            };
        }

        internal static string ValidateSubnet(string subnet, string virtualNetworkName, string resourceGroupName, string subscriptionId)
        {
            //Resource Id Format: "subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}/subnets/{3}"
            ResourceIdentifier subnetResourceId = null;
            if (subnet.ToLowerInvariant().Contains("/subnets/"))
            {
                try
                {
                    subnetResourceId = new ResourceIdentifier(subnet);
                }
                catch (ArgumentException ae)
                {
                    throw new ArgumentException("Subnet ResourceId is invalid.", ae);
                }
            }
            else
            {
                subnetResourceId = new ResourceIdentifier();
                subnetResourceId.Subscription = subscriptionId;
                subnetResourceId.ResourceGroupName = resourceGroupName;
                subnetResourceId.ResourceType = "Microsoft.Network/virtualNetworks/subnets";
                subnetResourceId.ParentResource = $"virtualNetworks/{virtualNetworkName}";
                subnetResourceId.ResourceName = subnet;
            }
            return subnetResourceId.ToString();
        }

        internal static void VerifySubnetDelegation(string subnet)
        {
            var subnetResourceId = new ResourceIdentifier(subnet);
            var resourceGroupName = subnetResourceId.ResourceGroupName;
            var virtualNetworkName = subnetResourceId.ParentResource.Substring(subnetResourceId.ParentResource.IndexOf('/') + 1);
            var subnetName = subnetResourceId.ResourceName;

            Subnet subnetObj = networkClient.Subnets.Get(resourceGroupName, virtualNetworkName, subnetName);
            var serviceEndpointServiceName = "Microsoft.Web";
            var serviceEndpointLocations = new List<string>() { "*" };
            if (subnetObj.ServiceEndpoints == null)
            {
                subnetObj.ServiceEndpoints = new List<ServiceEndpointPropertiesFormat>();                
                subnetObj.ServiceEndpoints.Add(new ServiceEndpointPropertiesFormat(serviceEndpointServiceName, serviceEndpointLocations));
                networkClient.Subnets.CreateOrUpdate(resourceGroupName, virtualNetworkName, subnetName, subnetObj);
            }
            else
            {
                bool serviceEndpointExists = false;
                foreach (var serviceEndpoint in subnetObj.ServiceEndpoints)
                {
                    if (serviceEndpoint.Service == serviceEndpointServiceName)
                    {
                        serviceEndpointExists = true;
                        break;
                    }
                }
                if (!serviceEndpointExists)
                {
                    subnetObj.ServiceEndpoints.Add(new ServiceEndpointPropertiesFormat(serviceEndpointServiceName, serviceEndpointLocations));
                    networkClient.Subnets.CreateOrUpdate(resourceGroupName, virtualNetworkName, subnetName, subnetObj);
                }
            }            
        }

        internal static string GetSubnetResourceGroupName(IAzureContext context, string Subnet, string VirtualNetworkName)
        {
            networkClient = AzureSession.Instance.ClientFactory.CreateArmClient<NetworkManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            var matchedVNetwork = networkClient.VirtualNetworks.ListAll().FirstOrDefault(item => item.Name == VirtualNetworkName);
            if (matchedVNetwork != null)
            {
                var subNets = matchedVNetwork.Subnets.ToList();
                Subnet matchedSubnet = matchedVNetwork.Subnets.FirstOrDefault(sItem => sItem.Name == Subnet || sItem.Id == Subnet);
                if (matchedSubnet != null)
                {
                    var subnetResourceId = new ResourceIdentifier(matchedSubnet.Id);
                    return subnetResourceId.ResourceGroupName;
                }
            }
            return null;
        }

        //To set a Value to Property of a Generic Type object
        internal static void SetObjectProperty(object inputObject, string propertyName, object propertyVal)
        {
            //find out the type
            Type type = inputObject.GetType();

            //get the property information based on the type
            PropertyInfo propertyInfo = type.GetProperty(propertyName);

            //find the property type
            Type propertyType = propertyInfo.PropertyType;

            //Convert.ChangeType does not handle conversion to nullable types
            //if the property type is nullable, we need to get the underlying type of the property
            var targetType = IsNullableType(propertyType) ? Nullable.GetUnderlyingType(propertyType) : propertyType;

            //Returns an System.Object with the specified System.Type and whose value is
            //equivalent to the specified object.
            propertyVal = Convert.ChangeType(propertyVal, targetType);

            //Set the value of the property
            propertyInfo.SetValue(inputObject, propertyVal, null);
        }

        //To check the property IsNullableType
        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }

    }
}
