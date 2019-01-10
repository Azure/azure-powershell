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
