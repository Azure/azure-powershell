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
using Microsoft.Azure.Commands.Common.Resources;
using Microsoft.Azure.Management.WebSites.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Websites.Models.WebApp
{
    public class PSSite : PSFlattenedResource
    {
        public static implicit operator PSSite(Site site)
        {
            return site == null ? null : new PSSite(site);
        }

        public PSSite()
        {
        }

        protected PSSite(Site site) : base(site)
        {
            AvailabilityState = site.AvailabilityState;
            ClientAffinityEnabled = site.ClientAffinityEnabled;
            ClientCertEnabled = site.ClientCertEnabled;
            CloningInfo = site.CloningInfo;
            Enabled = site.Enabled;
            EnabledHostNames = site.EnabledHostNames;
            GatewaySiteName = site.GatewaySiteName;
            HostNameSslStates = site.HostNameSslStates;
            HostNames = site.HostNames;
            HostNamesDisabled = site.HostNamesDisabled;
            HostingEnvironmentProfile = site.HostingEnvironmentProfile;
            LastModifiedTimeUtc = site.LastModifiedTimeUtc;
            MicroService = site.MicroService;
            OutboundIpAddresses = site.OutboundIpAddresses;
            PremiumAppDeployed = site.PremiumAppDeployed;
            RepositorySiteName = site.RepositorySiteName;
            ScmSiteAlsoStopped = site.ScmSiteAlsoStopped;
            ServerFarmId = site.ServerFarmId;
            SiteConfig = (PSSiteConfig)site.SiteConfig;
            SiteName = site.SiteName;
            State = site.State;
            TargetSwapSlot = site.TargetSwapSlot;
            TrafficManagerHostNames = site.TrafficManagerHostNames;
            UsageState = site.UsageState;
        }

        /// <summary>
        /// Name of web app
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// State of the web app
        /// </summary>
        public string State { get; private set; }

        /// <summary>
        /// Hostnames associated with web app
        /// </summary>
        public IList<string> HostNames { get; private set; }

        [JsonIgnore]
        public string HostNamesText {
            get { return SerializationHelpers.SerializeJsonCollection(HostNames); } }

        /// <summary>
        /// Name of repository site
        /// </summary>
        public string RepositorySiteName { get; private set; }

        /// <summary>
        /// State indicating whether web app has exceeded its quota usage.
        /// Possible values for this property include: 'Normal', 'Exceeded'.
        /// </summary>
        public UsageState? UsageState { get; private set; }

        /// <summary>
        /// True if the site is enabled; otherwise, false. Setting this  value
        /// to false disables the site (takes the site off line).
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Hostnames for the web app that are enabled. Hostnames need to be
        /// assigned and enabled. If some hostnames are assigned but not
        /// enabled
        /// the app is not served on those hostnames
        /// </summary>
        public IList<string> EnabledHostNames { get; private set; }
        [JsonIgnore]
        public string EnabledHostNamesText { get { return EnabledHostNames.SerializeJsonCollection(); } }

        /// <summary>
        /// Management information availability state for the web app.
        /// Possible values are Normal or Limited.
        /// Normal means that the site is running correctly and
        /// that management information for the site is available.
        /// Limited means that only partial management information
        /// for the site is available and that detailed site information is
        /// unavailable. Possible values for this property include: 'Normal',
        /// 'Limited', 'DisasterRecoveryMode'.
        /// </summary>
        public SiteAvailabilityState? AvailabilityState { get; private set; }

        /// <summary>
        /// Hostname SSL states are  used to manage the SSL bindings for
        /// site's hostnames.
        /// </summary>
        public IList<HostNameSslState> HostNameSslStates { get; set; }

        [JsonIgnore]
        public string HostNameSslStatesText { get { return HostNameSslStates.SerializeJsonCollection(); } }
        /// <summary>
        /// </summary>
        public string ServerFarmId { get; set; }

        /// <summary>
        /// Last time web app was modified in UTC
        /// </summary>
        public DateTime? LastModifiedTimeUtc { get; private set; }

        /// <summary>
        /// Configuration of web app
        /// </summary>
        public PSSiteConfig SiteConfig { get; set; }

        [JsonIgnore]
        public string SiteConfigText { get { return SiteConfig.SerializeJson(); } }
        /// <summary>
        /// Read-only list of Azure Traffic manager hostnames associated with
        /// web app
        /// </summary>
        public IList<string> TrafficManagerHostNames { get; private set; }

        [JsonIgnore]
        public string TrafficManagerHostNamesText { get { return TrafficManagerHostNames.SerializeJsonCollection(); } }

        /// <summary>
        /// If set indicates whether web app is deployed as a premium app
        /// </summary>
        public bool? PremiumAppDeployed { get; private set; }

        /// <summary>
        /// If set indicates whether to stop SCM (KUDU) site when the web app
        /// is stopped. Default is false.
        /// </summary>
        public bool? ScmSiteAlsoStopped { get; set; }

        /// <summary>
        /// Read-only property that specifies which slot this app will swap
        /// into
        /// </summary>
        public string TargetSwapSlot { get; private set; }

        /// <summary>
        /// Specification for the hosting environment (App Service
        /// Environment) to use for the web app
        /// </summary>
        public HostingEnvironmentProfile HostingEnvironmentProfile { get; set; }
        [JsonIgnore]
        public string HostingEnvironmentProfileText { get { return HostingEnvironmentProfile.SerializeJson(); } }

        /// <summary>
        /// </summary>
        public string MicroService { get; set; }

        /// <summary>
        /// Name of gateway app associated with web app
        /// </summary>
        public string GatewaySiteName { get; set; }

        /// <summary>
        /// Specifies if the client affinity is enabled when load balancing
        /// http request for multiple instances of the web app
        /// </summary>
        public bool? ClientAffinityEnabled { get; set; }

        /// <summary>
        /// Specifies if the client certificate is enabled for the web app
        /// </summary>
        public bool? ClientCertEnabled { get; set; }

        /// <summary>
        /// Specifies if the public hostnames are disabled the web app.
        /// If set to true the app is only accessible via API
        /// Management process
        /// </summary>
        public bool? HostNamesDisabled { get; set; }

        /// <summary>
        /// List of comma separated IP addresses that this web app uses for
        /// outbound connections. Those can be used when configuring firewall
        /// rules for databases accessed by this web app.
        /// </summary>
        public string OutboundIpAddresses { get; private set; }

        /// <summary>
        /// This is only valid for web app creation. If specified, web app is
        /// cloned from
        /// a source web app
        /// </summary>
        public CloningInfo CloningInfo { get; set; }

        [JsonIgnore]
        public string CloningInfoText { get { return CloningInfo.SerializeJson(); } }

    }
}
