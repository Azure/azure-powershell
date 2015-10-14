namespace Commands.Intune.Helpers
{
    using Commands.Intune.RestClient;
    using System;

    /// <summary>
    /// Helper class for Getting tenant location as per Intune provisioning.
    /// </summary>
    internal static class LocationHelper
    {
        /// <summary>
        /// Tenant location as per Intune deployment convention.
        /// </summary>
        private static string azureScaleUnitName = null;

        /// <summary>
        /// cache the TenantId for which we already did latest GetLocation call.
        /// </summary>
        private static Guid? cachedTenantId = null;

        /// <summary>
        /// Get tenant location as per Intune provisioning.
        /// </summary>
        /// <param name="client"> IntuneResourceManagementClient</param>
        /// <param name="tenantId">TenantId for which the location needs to queried.</param>
        /// <returns>tenant location</returns>
        public static string GetLocation(IntuneResourceManagementClient client, Guid tenantId)
        {
            if (azureScaleUnitName == null || tenantId != cachedTenantId)
            {
                var location = client.GetLocationByHostName();
                azureScaleUnitName = location.Properties.HostName;
                cachedTenantId = tenantId;
            }

            return azureScaleUnitName;
        }

    }
}
