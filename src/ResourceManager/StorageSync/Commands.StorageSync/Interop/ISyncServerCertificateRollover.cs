using System;

namespace StorageSync.Management.PowerShell.Cmdlets.CertificateRollover
{
    /// <summary>
    /// Function performs server certificate rollover
    /// </summary>
    public interface ISyncServerCertificateRollover : IDisposable
    {
        /// <summary>
        /// Function performs server certificate rollover
        /// </summary>
        /// <param name="managementEndpointUri">Management endpoint Uri</param>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="storageSyncServiceName">Storage Sync Service Name</param>
        /// <param name="resourceGroupName">Resource Group Name</param>
        /// <param name="certificateProviderName">Certificate Provider Name</param>
        /// <param name="certificateHashAlgorithm">Certificate Hash Algorithm</param>
        /// <param name="certificateKeyLength">Certificate Key Length</param>
        /// <param name="monitoringDataPath">Monitoring data path</param>
        /// <param name="agentVersion">Agent Version</param>
        /// <param name="registerOnlineCallback">Register online callback for updating cloud service.</param>
        /// <returns>Registered Server Resource</returns>
        void RolloverServerCertificate(
            string certificateProviderName, 
            string certificateHashAlgorithm, 
            uint certificateKeyLength, 
            Action<string, Guid> TriggerServiceRollover,
            Action<string> tracelog
            );
    }
}
