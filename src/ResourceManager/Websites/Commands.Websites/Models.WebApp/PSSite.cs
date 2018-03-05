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

using Microsoft.Azure.Management.WebSites.Models;
using System.Security;

namespace Microsoft.Azure.Commands.WebApps.Models
{
    public class PSSite : Site
    {
        public PSSite(Site other)
            : base(
                  location: other.Location,
                  id: other.Id,
                  name: other.Name,
                  type: other.Type,
                  tags: other.Tags,
#if !NETSTANDARD
                  siteName: other.SiteName,
#endif
                  state: other.State,
                  hostNames: other.HostNames,
                  repositorySiteName: other.RepositorySiteName,
                  usageState: other.UsageState,
                  enabled: other.Enabled,
                  enabledHostNames: other.EnabledHostNames,
                  availabilityState: other.AvailabilityState,
                  hostNameSslStates: other.HostNameSslStates, serverFarmId: other.ServerFarmId,
                  lastModifiedTimeUtc: other.LastModifiedTimeUtc,
                  siteConfig: other.SiteConfig,
                  trafficManagerHostNames: other.TrafficManagerHostNames,
                  premiumAppDeployed: other.PremiumAppDeployed, scmSiteAlsoStopped: other.ScmSiteAlsoStopped,
                  targetSwapSlot: other.TargetSwapSlot,
                  hostingEnvironmentProfile: other.HostingEnvironmentProfile,
                  microService: other.MicroService,
                  gatewaySiteName: other.GatewaySiteName,
                  clientAffinityEnabled: other.ClientAffinityEnabled,
                  clientCertEnabled: other.ClientCertEnabled,
                  hostNamesDisabled: other.HostNamesDisabled,
                  outboundIpAddresses: other.OutboundIpAddresses,
                  containerSize: other.ContainerSize,
                  maxNumberOfWorkers: other.MaxNumberOfWorkers,
                  cloningInfo: other.CloningInfo,
                  resourceGroup: other.ResourceGroup,
                  isDefaultContainer: other.IsDefaultContainer,
                  defaultHostName: other.DefaultHostName)
        {
        }

        public string GitRemoteName { get; set; }
        public string GitRemoteUri { get; set; }
        public string GitRemoteUsername { get; set; }
        public SecureString  GitRemotePassword { get; set; }
    }
}
