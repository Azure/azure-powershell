using Microsoft.Azure.Management.WebSites.Models;
using System;

namespace Microsoft.Azure.Commands.WebApps.Models.WebApp
{
    class PSAppServicePlan: AppServicePlan
    {
        public PSAppServicePlan(AppServicePlan other): base(
            location: other.Location,
            name: other.Name,
            id: other.Id,
            kind: other.Kind,
            type: other.Type,
            tags: other.Tags,
            workerTierName: other.WorkerTierName,
            status: other.Status,
            subscription: other.Subscription,
            adminSiteName: other.AdminSiteName,
            hostingEnvironmentProfile: other.HostingEnvironmentProfile,
            maximumNumberOfWorkers: other.MaximumNumberOfWorkers,
            geoRegion: other.GeoRegion,
            perSiteScaling: other.PerSiteScaling,
            numberOfSites: other.NumberOfSites,
            isSpot: other.IsSpot,
            spotExpirationTime: other.SpotExpirationTime,
            freeOfferExpirationTime: other.FreeOfferExpirationTime,
            resourceGroup: other.ResourceGroup,
            reserved: other.Reserved,
            isXenon: other.IsXenon,
            targetWorkerCount: other.TargetWorkerCount,
            targetWorkerSizeId: other.TargetWorkerSizeId,
            provisioningState: other.ProvisioningState,
            sku: other.Sku
            )
        {

        }

        [Obsolete("This property is deprecated and will be removed in a future releases.")]
        public string AppServicePlanName { get { return Name; } }
    }
}
