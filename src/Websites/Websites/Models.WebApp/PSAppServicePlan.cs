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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.WebApps.Models.WebApp
{
    public class PSAppServicePlan: AppServicePlan
    {
        public PSAppServicePlan(AppServicePlan other): base(
            location: other.Location,
            name: other.Name,
            id: other.Id,
            kind: other.Kind,
            type: other.Type,
            systemData: other.SystemData,
            extendedLocation: other.ExtendedLocation,
            tags: other.Tags,
            identity: other.Identity,
            workerTierName: other.WorkerTierName,
            status: other.Status,
            subscription: other.Subscription,
            hostingEnvironmentProfile: other.HostingEnvironmentProfile,
            kubeEnvironmentProfile: other.KubeEnvironmentProfile,
            maximumNumberOfWorkers: other.MaximumNumberOfWorkers,
            numberOfWorkers: other.NumberOfWorkers,
            geoRegion: other.GeoRegion,
            perSiteScaling: other.PerSiteScaling,
            elasticScaleEnabled: other.ElasticScaleEnabled,
            maximumElasticWorkerCount: other.MaximumElasticWorkerCount,
            numberOfSites: other.NumberOfSites,
            isSpot: other.IsSpot,
            spotExpirationTime: other.SpotExpirationTime,
            freeOfferExpirationTime: other.FreeOfferExpirationTime,
            resourceGroup: other.ResourceGroup,
            reserved: other.Reserved,
            isXenon: other.IsXenon,
            hyperV: other.HyperV,
            targetWorkerCount: other.TargetWorkerCount,
            targetWorkerSizeId: other.TargetWorkerSizeId,
            provisioningState: other.ProvisioningState,
            sku: other.Sku,
            zoneRedundant: other.ZoneRedundant,
            asyncScalingEnabled: other.AsyncScalingEnabled,
            planDefaultIdentity: other.PlanDefaultIdentity,
            isCustomMode: other.IsCustomMode,
            registryAdapters: other.RegistryAdapters,
            installScripts: other.InstallScripts,
            network: other.Network,
            storageMounts: other.StorageMounts,
            rdpEnabled: other.RdpEnabled
            )
        {

        }

        public string AdminSiteName { get; set; }
    }
}
