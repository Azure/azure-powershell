
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
using System.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.WebSites;
using Microsoft.WindowsAzure.Management.WebSites.Models;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services
{
    using Utilities = WebEntities;

    /// <summary>
    /// Extension methods for converting return values from the websites
    /// management clients from "get" methods into corresponding
    /// other types so that we can easily send updates or return to callers.
    /// </summary>
    internal static class WebSitesManagementConversionMethods
    {
        internal static WebSiteUpdateConfigurationParameters ToUpdate(this WebSiteGetConfigurationResponse getConfigResponse)
        {
            var update = new WebSiteUpdateConfigurationParameters
            {
                DetailedErrorLoggingEnabled = getConfigResponse.DetailedErrorLoggingEnabled,
                HttpLoggingEnabled = getConfigResponse.HttpLoggingEnabled,
                NetFrameworkVersion = getConfigResponse.NetFrameworkVersion,
                NumberOfWorkers = getConfigResponse.NumberOfWorkers,
                PhpVersion = getConfigResponse.PhpVersion,
                RequestTracingEnabled = getConfigResponse.RequestTracingEnabled,
                RequestTracingExpirationTime = getConfigResponse.RequestTracingExpirationTime,
                ScmType = getConfigResponse.ScmType,
                Use32BitWorkerProcess = getConfigResponse.Use32BitWorkerProcess,
                ManagedPipelineMode = getConfigResponse.ManagedPipelineMode,
                WebSocketsEnabled = getConfigResponse.WebSocketsEnabled,
                RemoteDebuggingEnabled = getConfigResponse.RemoteDebuggingEnabled,
                RemoteDebuggingVersion = getConfigResponse.RemoteDebuggingVersion,
            };

            getConfigResponse.AppSettings.ForEach(kvp => update.AppSettings.Add(kvp.Key, kvp.Value));
            getConfigResponse.ConnectionStrings.ForEach(cs => update.ConnectionStrings.Add(new WebSiteUpdateConfigurationParameters.ConnectionStringInfo
            {
                ConnectionString = cs.ConnectionString,
                Name = cs.Name,
                Type = cs.Type
            }));
            getConfigResponse.DefaultDocuments.ForEach(dd => update.DefaultDocuments.Add(dd));
            getConfigResponse.HandlerMappings.ForEach(hm => update.HandlerMappings.Add(new WebSiteUpdateConfigurationParameters.HandlerMapping
            {
                Arguments = hm.Arguments,
                Extension = hm.Extension,
                ScriptProcessor = hm.ScriptProcessor
            }));
            getConfigResponse.Metadata.ForEach(kvp => update.Metadata.Add(kvp.Key, kvp.Value));

            return update;
        }

        internal static Utilities.SiteConfig ToSiteConfig(this WebSiteGetConfigurationResponse getConfigResponse)
        {
            var config = new Utilities.SiteConfig
            {
                NumberOfWorkers = getConfigResponse.NumberOfWorkers,
                DefaultDocuments = getConfigResponse.DefaultDocuments.ToArray(),
                NetFrameworkVersion = getConfigResponse.NetFrameworkVersion,
                PhpVersion = getConfigResponse.PhpVersion,
                RequestTracingEnabled = getConfigResponse.RequestTracingEnabled,
                HttpLoggingEnabled = getConfigResponse.HttpLoggingEnabled,
                DetailedErrorLoggingEnabled = getConfigResponse.DetailedErrorLoggingEnabled,
                PublishingUsername = getConfigResponse.PublishingUserName,
                PublishingPassword = getConfigResponse.PublishingPassword,
                AppSettings = getConfigResponse.AppSettings.Select(ToNameValuePair).ToList(),
                Metadata = getConfigResponse.Metadata.Select(ToNameValuePair).ToList(),
                ConnectionStrings = new Utilities.ConnStringPropertyBag(
                    getConfigResponse.ConnectionStrings.Select(cs => new Utilities.ConnStringInfo
                    {
                        ConnectionString = cs.ConnectionString,
                        Name = cs.Name,
                        Type = (Utilities.DatabaseType)Enum.Parse(typeof(Utilities.DatabaseType), cs.Type.ToString(), ignoreCase: true)
                    }).ToList()),
                HandlerMappings = getConfigResponse.HandlerMappings.Select(hm => new Utilities.HandlerMapping
                {
                    Arguments = hm.Arguments,
                    Extension = hm.Extension,
                    ScriptProcessor = hm.ScriptProcessor
                }).ToArray(),
                ManagedPipelineMode = getConfigResponse.ManagedPipelineMode,
                WebSocketsEnabled = getConfigResponse.WebSocketsEnabled,
                RemoteDebuggingEnabled = getConfigResponse.RemoteDebuggingEnabled,
                RemoteDebuggingVersion = getConfigResponse.RemoteDebuggingVersion,
                RoutingRules = getConfigResponse.RoutingRules.Select(r => r.ToRoutingRule()).ToList(),
                Use32BitWorkerProcess = getConfigResponse.Use32BitWorkerProcess,
                AutoSwapSlotName = getConfigResponse.AutoSwapSlotName,
            };
            return config;
        }

        internal static Utilities.RoutingRule ToRoutingRule(this Management.WebSites.Models.RoutingRule rule)
        {
            Utilities.RoutingRule result = null;
            if (rule is Management.WebSites.Models.RampUpRule)
            {
                Management.WebSites.Models.RampUpRule rampupRule = rule as Management.WebSites.Models.RampUpRule;
                result = new Utilities.RampUpRule()
                {
                    ReroutePercentage = rampupRule.ReroutePercentage,
                    ActionHostName = rampupRule.ActionHostName,
                    MinReroutePercentage = rampupRule.MinReroutePercentage,
                    MaxReroutePercentage = rampupRule.MaxReroutePercentage,
                    ChangeDecisionCallbackUrl = rampupRule.ChangeDecisionCallbackUrl,
                    ChangeIntervalInMinutes = rampupRule.ChangeIntervalInMinutes,
                    ChangeStep = rampupRule.ChangeStep,
                };
            }

            if (result != null)
            {
                // base class properties
                result.Name = rule.Name;
            }

            return result;
        }

        internal static Utilities.Site ToSite(this WebSiteGetResponse response)
        {
            return new Utilities.Site
            {
                Name = response.WebSite.Name,
                State = response.WebSite.State.ToString(),
                HostNames = response.WebSite.HostNames.ToArray(),
                WebSpace = response.WebSite.WebSpace,
                SelfLink = response.WebSite.Uri,
                RepositorySiteName = response.WebSite.RepositorySiteName,
                UsageState = (Utilities.UsageState)(int)response.WebSite.UsageState,
                Enabled = response.WebSite.Enabled,
                AdminEnabled = response.WebSite.AdminEnabled,
                EnabledHostNames = response.WebSite.EnabledHostNames.ToArray(),
                SiteProperties = new Utilities.SiteProperties
                {
                    Metadata = response.WebSite.SiteProperties.Metadata.Select(ToNameValuePair).ToList(),
                    Properties = response.WebSite.SiteProperties.Properties.Select(ToNameValuePair).ToList()
                },
                AvailabilityState = (Utilities.SiteAvailabilityState)(int)response.WebSite.AvailabilityState,
                // SSLCertificates = response.WebSite.SslCertificates.Select(ToCertificate).ToArray(),
                HostNameSslStates = new Utilities.HostNameSslStates(response.WebSite.HostNameSslStates.Select(ToNameSslState).ToList()),
                Sku = response.WebSite.Sku
            };
        }

        internal static Utilities.Site ToSite(this WebSite site)
        {
            return new Utilities.Site
            {
                Name = site.Name,
                State = site.State.ToString(),
                HostNames = site.HostNames.ToArray(),
                WebSpace = site.WebSpace,
                SelfLink = site.Uri,
                RepositorySiteName = site.RepositorySiteName,
                UsageState = (Utilities.UsageState)(int)site.UsageState,
                Enabled = site.Enabled,
                AdminEnabled = site.AdminEnabled,
                EnabledHostNames = site.EnabledHostNames.ToArray(),
                SiteProperties = new Utilities.SiteProperties
                {
                    Metadata = site.SiteProperties.Metadata.Select(ToNameValuePair).ToList(),
                    Properties = site.SiteProperties.Properties.Select(ToNameValuePair).ToList()
                },
                AvailabilityState = (Utilities.SiteAvailabilityState)(int)site.AvailabilityState,
                // SSLCertificates = site.SslCertificates.Select(ToCertificate).ToArray(),
                HostNameSslStates = new Utilities.HostNameSslStates(site.HostNameSslStates.Select(ToNameSslState).ToList()),
                Sku = site.Sku
            };
        }

        private static Utilities.NameValuePair ToNameValuePair(KeyValuePair<string, string> kvp)
        {
            return new Utilities.NameValuePair
            {
                Name = kvp.Key,
                Value = kvp.Value
            };
        }

        private static KeyValuePair<string, string> ToKeyValuePair(Utilities.NameValuePair nvp)
        {
            return new KeyValuePair<string, string>(nvp.Name, nvp.Value);
        }
        internal static IList<Utilities.MetricResponse> ToMetricResponses(this WebSiteGetHistoricalUsageMetricsResponse metricsResponse)
        {
            var result = new List<Utilities.MetricResponse>();
            if (metricsResponse == null || metricsResponse.UsageMetrics == null)
            {
                return result;
            }

            foreach (var response in metricsResponse.UsageMetrics)
            {
                var metrics = response.Data.ToMetricSet();
                var rsp = new Utilities.MetricResponse
                {
                    Code = response.Code,
                    Message = response.Message,
                    Data = metrics
                };
                result.Add(rsp);
            }

            return result;
        }

        internal static IList<Utilities.MetricResponse> ToMetricResponses(this WebHostingPlanGetHistoricalUsageMetricsResponse metricsResponse)
        {
            var result = new List<Utilities.MetricResponse>();
            if (metricsResponse == null || metricsResponse.UsageMetrics == null)
            {
                return result;
            }

            foreach (var response in metricsResponse.UsageMetrics)
            {
                var metrics = response.Data.ToMetricSet();
                var rsp = new Utilities.MetricResponse
                {
                    Code = response.Code,
                    Message = response.Message,
                    Data = metrics
                };
                result.Add(rsp);
            }

            return result;
        }

        internal static Utilities.MetricSet ToMetricSet(this HistoricalUsageMetricData data)
        {
            var metrics = new Utilities.MetricSet
            {
                Name = data.Name,
                PrimaryAggregationType = data.PrimaryAggregationType,
                TimeGrain = data.TimeGrain,
                StartTime = data.StartTime,
                EndTime = data.EndTime,
                Unit = data.Unit,
                Values = data.Values.ToMetricSamples().ToList(),
            };

            return metrics;
        }

        internal static IList<Utilities.MetricSample> ToMetricSamples(this IList<HistoricalUsageMetricSample> samples)
        {
            var result = new List<Utilities.MetricSample>();

            foreach (var s in samples)
            {
                var converted = new Utilities.MetricSample()
                {
                    Count = s.Count,
                    TimeCreated = s.TimeCreated,
                    InstanceName = s.InstanceName,
                };
                long val = 0;

                if (!string.IsNullOrEmpty(s.Minimum))
                {
                    long.TryParse(s.Minimum, out val);
                    converted.Minimum = val;
                }

                if (!string.IsNullOrEmpty(s.Maximum))
                {
                    long.TryParse(s.Maximum, out val);
                    converted.Maximum = val;
                }

                if (!string.IsNullOrEmpty(s.Total))
                {
                    long.TryParse(s.Total, out val);
                    converted.Total = val;
                }

                result.Add(converted);
            }

            return result;
        }

        private static Utilities.HostNameSslState ToNameSslState(WebSite.WebSiteHostNameSslState state)
        {
            return new Utilities.HostNameSslState
            {
                Name = state.Name,
                SslState = (Utilities.SslState)(int)state.SslState
            };
        }

        internal static Utilities.WebSpace ToWebSpace(this WebSpacesListResponse.WebSpace webspace)
        {
            return new Utilities.WebSpace
            {
                Name = webspace.Name,
                Plan = webspace.Plan,
                Subscription = webspace.Subscription,
                GeoLocation = webspace.GeoLocation,
                GeoRegion = webspace.GeoRegion,
                ComputeMode = null, // TODO: Update
                WorkerSize =
                    webspace.WorkerSize.HasValue
                        ? new Utilities.WorkerSizeOptions?((Utilities.WorkerSizeOptions)(int)webspace.WorkerSize.Value)
                        : null,
                NumberOfWorkers = webspace.CurrentNumberOfWorkers,
                Status = (Utilities.StatusOptions)(int)webspace.Status,
                AvailabilityState = (WebEntities.WebSpaceAvailabilityState)(int)webspace.AvailabilityState
            };
        }

        internal static WebSiteUpdateConfigurationParameters ToConfigUpdateParameters(this Utilities.SiteConfig config)
        {
            var parameters = new WebSiteUpdateConfigurationParameters
            {
                DetailedErrorLoggingEnabled = config.DetailedErrorLoggingEnabled,
                HttpLoggingEnabled = config.HttpLoggingEnabled,
                NetFrameworkVersion = config.NetFrameworkVersion,
                NumberOfWorkers = config.NumberOfWorkers,
                PhpVersion = config.PhpVersion,
                RequestTracingEnabled = config.RequestTracingEnabled,
                ManagedPipelineMode = config.ManagedPipelineMode,
                WebSocketsEnabled = config.WebSocketsEnabled,
                RemoteDebuggingEnabled = config.RemoteDebuggingEnabled,
                RemoteDebuggingVersion = config.RemoteDebuggingVersion,
                RoutingRules = config.RoutingRules.Select(r => r.ToRoutingRule()).ToArray(),
                Use32BitWorkerProcess = config.Use32BitWorkerProcess,
                AutoSwapSlotName = config.AutoSwapSlotName,
            };
            if (config.AppSettings != null)
                config.AppSettings.ForEach(nvp => parameters.AppSettings.Add(ToKeyValuePair(nvp)));

            if (config.ConnectionStrings != null)
                config.ConnectionStrings.ForEach(
                csi => parameters.ConnectionStrings.Add(new WebSiteUpdateConfigurationParameters.ConnectionStringInfo
                {
                    Name = csi.Name,
                    ConnectionString = csi.ConnectionString,
                    Type = (Management.WebSites.Models.ConnectionStringType)Enum.Parse(typeof(Management.WebSites.Models.ConnectionStringType), csi.Type.ToString(), ignoreCase: true)
                }));

            if (config.DefaultDocuments != null)
                config.DefaultDocuments.ForEach(d => parameters.DefaultDocuments.Add(d));

            if (config.HandlerMappings != null)
                config.HandlerMappings.ForEach(
                hm => parameters.HandlerMappings.Add(new WebSiteUpdateConfigurationParameters.HandlerMapping
                {
                    Arguments = hm.Arguments,
                    Extension = hm.Extension,
                    ScriptProcessor = hm.ScriptProcessor
                }));

            if (config.Metadata != null)
                config.Metadata.ForEach(nvp => parameters.Metadata.Add(ToKeyValuePair(nvp)));

            return parameters;
        }

        internal static Management.WebSites.Models.RoutingRule ToRoutingRule(this Utilities.RoutingRule rule)
        {
            Management.WebSites.Models.RoutingRule result = null;
            if (rule is Utilities.RampUpRule)
            {
                var rampupRule = rule as Utilities.RampUpRule;
                result = new Management.WebSites.Models.RampUpRule()
                {
                    ReroutePercentage = rampupRule.ReroutePercentage,
                    ActionHostName = rampupRule.ActionHostName,
                    MinReroutePercentage = rampupRule.MinReroutePercentage,
                    MaxReroutePercentage = rampupRule.MaxReroutePercentage,
                    ChangeDecisionCallbackUrl = rampupRule.ChangeDecisionCallbackUrl,
                    ChangeIntervalInMinutes = rampupRule.ChangeIntervalInMinutes,
                    ChangeStep = rampupRule.ChangeStep,
                };
            }

            if (result != null)
            {
                // base class properties
                result.Name = rule.Name;
            }

            return result;
        }

        internal static SlotConfigNamesUpdate ToSlotConfigNamesUpdate(this Utilities.SiteConfig config)
        {
            return new SlotConfigNamesUpdate
            {
                AppSettingNames = config.SlotStickyAppSettingNames,
                ConnectionStringNames = config.SlotStickyConnectionStringNames
            };
        }

        internal static Utilities.WebHostingPlan ToWebHostingPlan(this Management.WebSites.Models.WebHostingPlan plan, string webSpace)
        {
            return new Utilities.WebHostingPlan
            {
                Name = plan.Name,
                CurrentNumberOfWorkers = plan.NumberOfWorkers,
                CurrentWorkerSize = plan.WorkerSize.HasValue
                        ? new Utilities.WorkerSizeOptions?((Utilities.WorkerSizeOptions)(int)plan.WorkerSize.Value)
                        : null,
                WorkerSize = plan.WorkerSize.HasValue
                        ? new Utilities.WorkerSizeOptions?((Utilities.WorkerSizeOptions)(int)plan.WorkerSize.Value)
                        : null,
                NumberOfWorkers = plan.NumberOfWorkers,
                SKU = plan.SKU.ToString(),
                WebSpace = webSpace,
            };
        }

        internal static Utilities.WebHostingPlan ToWebHostingPlan(this Management.WebSites.Models.WebHostingPlanGetResponse plan)
        {
            return ToWebHostingPlan(plan.WebHostingPlan, webSpace: null);
        }
    }

    /// <summary>
    /// General extension methods on the various web site management operations
    /// </summary>
    public static class WebSitesManagementExtensionMethods
    {
        public static Utilities.Site GetSiteWithCache(
            this IWebSiteManagementClient client,
            string website)
        {
            return GetFromCache(client, website) ?? GetFromAzure(client, website);
        }

        private static Utilities.Site GetFromCache(IWebSiteManagementClient client,
            string website)
        {
            Utilities.Site site = Cache.GetSite(client.Credentials.SubscriptionId, website);
            if (site != null)
            {
                // Verify site still exists
                try
                {
                    WebSiteGetParameters input = new WebSiteGetParameters();
                    input.PropertiesToInclude.Add("repositoryuri");
                    input.PropertiesToInclude.Add("publishingpassword");
                    input.PropertiesToInclude.Add("publishingusername");

                    return client.WebSites.Get(site.WebSpace, site.Name, input).ToSite();
                }
                catch
                {
                    // Website is removed or webspace changed, remove from cache
                    Cache.RemoveSite(client.Credentials.SubscriptionId, site);
                    throw;
                }
            }
            return null;
        }

        private static Utilities.Site GetFromAzure(IWebSiteManagementClient client,
            string website)
        {
            // Get all available webspace using REST API
            var spaces = client.WebSpaces.List();
            foreach (var space in spaces.WebSpaces)
            {
                WebSiteListParameters input = new WebSiteListParameters();
                input.PropertiesToInclude.Add("repositoryuri");
                input.PropertiesToInclude.Add("publishingpassword");
                input.PropertiesToInclude.Add("publishingusername");
                var sites = client.WebSpaces.ListWebSites(space.Name, input);
                var site = sites.WebSites.FirstOrDefault(
                    ws => ws.Name.Equals(website, StringComparison.InvariantCultureIgnoreCase));
                if (site != null)
                {
                    return site.ToSite();
                }
            }

            // The website does not exist.
            return null;
        }
    }
}
