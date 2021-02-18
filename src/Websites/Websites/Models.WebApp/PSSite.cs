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

using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
<<<<<<< HEAD
=======
using System.Reflection;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
                  kind: other.Kind,
                  tags: other.Tags,
                  state: other.State,
                  hostNames: other.HostNames,
                  repositorySiteName: other.RepositorySiteName,
                  usageState: other.UsageState,
                  enabled: other.Enabled,
                  enabledHostNames: other.EnabledHostNames,
                  availabilityState: other.AvailabilityState,
<<<<<<< HEAD
                  hostNameSslStates: other.HostNameSslStates, 
=======
                  hostNameSslStates: other.HostNameSslStates,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                  serverFarmId: other.ServerFarmId,
                  lastModifiedTimeUtc: other.LastModifiedTimeUtc,
                  siteConfig: other.SiteConfig,
                  trafficManagerHostNames: other.TrafficManagerHostNames,
                  scmSiteAlsoStopped: other.ScmSiteAlsoStopped,
                  targetSwapSlot: other.TargetSwapSlot,
                  hostingEnvironmentProfile: other.HostingEnvironmentProfile,
                  clientAffinityEnabled: other.ClientAffinityEnabled,
                  clientCertEnabled: other.ClientCertEnabled,
                  hostNamesDisabled: other.HostNamesDisabled,
                  outboundIpAddresses: other.OutboundIpAddresses,
                  containerSize: other.ContainerSize,
                  maxNumberOfWorkers: other.MaxNumberOfWorkers,
                  cloningInfo: other.CloningInfo,
                  resourceGroup: other.ResourceGroup,
                  isDefaultContainer: other.IsDefaultContainer,
                  defaultHostName: other.DefaultHostName,
                  reserved: other.Reserved,
                  isXenon: other.IsXenon,
                  possibleOutboundIpAddresses: other.PossibleOutboundIpAddresses,
                  dailyMemoryTimeQuota: other.DailyMemoryTimeQuota,
<<<<<<< HEAD
                  suspendedTill:other.SuspendedTill,
=======
                  suspendedTill: other.SuspendedTill,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                  slotSwapStatus: other.SlotSwapStatus,
                  httpsOnly: other.HttpsOnly,
                  identity: other.Identity
                  )
        {
<<<<<<< HEAD
            if (other.SiteConfig != null)
            {
                AzureStoragePath = other.SiteConfig.AzureStorageAccounts.ConvertToWebAppAzureStorageArray();
=======
            PropertyInfo AzureStoragePathProp = other.GetType().GetProperty("AzureStoragePath");
            if (AzureStoragePathProp != null)
            {
                object val = AzureStoragePathProp.GetValue(other, null);
                AzureStoragePath = (WebAppAzureStoragePath[])val;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }
        }

        public string GitRemoteName { get; set; }
        public string GitRemoteUri { get; set; }
        public string GitRemoteUsername { get; set; }
<<<<<<< HEAD
        public SecureString  GitRemotePassword { get; set; }

=======
        public SecureString GitRemotePassword { get; set; }
        public AzureStoragePropertyDictionaryResource AzureStorageAccounts { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public WebAppAzureStoragePath[] AzureStoragePath { get; set; }
    }
}
