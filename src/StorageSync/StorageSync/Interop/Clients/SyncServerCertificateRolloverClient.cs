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

using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Properties;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Commands.StorageSync.Interop.Clients
{
    /// <summary>
    /// Function performs server certificate rollover
    /// Implements the <see cref="Commands.StorageSync.Interop.Interfaces.ISyncServerCertificateRollover" />
    /// </summary>
    /// <seealso cref="Commands.StorageSync.Interop.Interfaces.ISyncServerCertificateRollover" />
    public class SyncServerCertificateRolloverClient : ISyncServerCertificateRollover
    {
        /// <summary>
        /// The m is disposed
        /// </summary>
        private bool m_isDisposed;

        /// <summary>
        /// ECS Management Interop Client
        /// </summary>
        /// <value>The ecs management interop client.</value>
        protected IEcsManagement EcsManagementInteropClient { get; private set; }

        /// <summary>
        /// Parameterzed constructor for Sync Server certificate rollover Client
        /// </summary>
        /// <param name="ecsManagementInteropClient">The ecs management interop client.</param>
        public SyncServerCertificateRolloverClient(IEcsManagement ecsManagementInteropClient)
        {
            EcsManagementInteropClient = ecsManagementInteropClient;
        }

        /// <summary>
        /// Function performs server certificate rollover
        /// </summary>
        /// <param name="certificateProviderName">Certificate Provider Name</param>
        /// <param name="certificateHashAlgorithm">Certificate Hash Algorithm</param>
        /// <param name="certificateKeyLength">Certificate Key Length</param>
        /// <param name="triggerServiceRollover">Trigger service request callback for service call</param>
        /// <param name="verboseLogger">powershell tracing function</param>
        public void RolloverServerCertificate(
            string certificateProviderName, 
            string certificateHashAlgorithm, 
            uint certificateKeyLength,
            Action<string, Guid> triggerServiceRollover,
            Action<string> verboseLogger
            )
        {
            // Rollover Secondary Certificate
            Guid serverId;
            string secondaryCertificate = RolloverSecondaryCertificate(verboseLogger, out serverId);

            // Call service with new certificate
            triggerServiceRollover(secondaryCertificate, serverId);

            // Switch primary to secondary, update monitoring and delete the old certificate
            SwitchCertificate(verboseLogger);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                if (EcsManagementInteropClient != null)
                {
                    EcsManagementInteropClient.Dispose();
                }

                EcsManagementInteropClient = null;
                m_isDisposed = true;
            }
        }

        /// <summary>
        /// Rollovers the secondary certificate.
        /// </summary>
        /// <param name="verboseLogger">The verbose logger.</param>
        /// <param name="serverId">The server identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">serverId</exception>
        /// <exception cref="Exception">Certificate thumbprints not found. Check if server is registered.
        /// or</exception>
        private string RolloverSecondaryCertificate(Action<string> verboseLogger, out Guid serverId)
        {
            string primaryCertificateThumbprint = string.Empty;
            string secondaryCertificateThumbprint = string.Empty;
            int hResult = 0;
            bool generateNewCertificate = true;
            string secondaryCertificate = string.Empty;
            string serverIdString = string.Empty;

            // Retrieve serverId from the configuration
            EcsManagementInteropClient.GetSyncServerId(out serverIdString);

            if (!Guid.TryParse(serverIdString, out serverId))
            {
                throw new ArgumentException(nameof(serverId));
            }

            verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat1, serverId));

            EcsManagementInteropClient.GetServerCertificateThumbprints(out primaryCertificateThumbprint, out secondaryCertificateThumbprint);
            if(string.IsNullOrEmpty(primaryCertificateThumbprint) || string.IsNullOrEmpty(secondaryCertificateThumbprint))
            {
                throw new Exception(StorageSyncResources.CertificateThumbprintNotFound);
            }

            verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat2,primaryCertificateThumbprint, secondaryCertificateThumbprint));

            if (!string.Equals(primaryCertificateThumbprint, secondaryCertificateThumbprint, StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    hResult = EcsManagementInteropClient.GetSyncServerCertificate(false, out secondaryCertificate);
                }
                catch (COMException ex)
                {
                    verboseLogger(string.Format(StorageSyncResources.GetSyncServerCertificateErrorMessageFormat, ex.HResult, ex.Message));
                    hResult = ex.HResult;
                }

                if (hResult == 0 && !string.IsNullOrEmpty(secondaryCertificate))
                {
                    verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat3, secondaryCertificateThumbprint, hResult));

                    generateNewCertificate = false;
                }
                else
                {
                    verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat4, hResult));
                }
            }

            if (generateNewCertificate)
            {
                secondaryCertificate = string.Empty;

                // Generate new Certificate
                verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat1, secondaryCertificateThumbprint));

                try
                {
                    hResult = EcsManagementInteropClient.RolloverSecondaryCertificate(
                    ManagementInteropConstants.CertificateProviderName,
                    ManagementInteropConstants.CertificateHashAlgorithm,
                    ManagementInteropConstants.CertificateKeyLength,
                    out secondaryCertificate);
                }
                catch (COMException ex)
                {
                    hResult = ex.HResult;
                }

                if (hResult != 0 || string.IsNullOrEmpty(secondaryCertificate))
                {
                    verboseLogger(string.Format(StorageSyncResources.RolloverSecondaryCertificateErrorMessageFormat, hResult));
                    throw new Exception(string.Format(StorageSyncResources.RolloverSecondaryCertificateErrorMessageFormat, hResult));
                }

            }

            ValidateCertificate(secondaryCertificate, verboseLogger);

            return secondaryCertificate;
        }

        /// <summary>
        /// Switches the certificate.
        /// </summary>
        /// <param name="verboseLogger">The verbose logger.</param>
        /// <exception cref="ArgumentException">primaryCertificateThumbprint
        /// or
        /// secondaryCertificateThumbprint</exception>
        /// <exception cref="Exception"></exception>
        private void SwitchCertificate(Action<string> verboseLogger)
        {

            int hResult = 0;
            string primaryCertificateThumbprint = string.Empty;
            string secondaryCertificateThumbprint = string.Empty;
            
            EcsManagementInteropClient.GetServerCertificateThumbprints(out primaryCertificateThumbprint, out secondaryCertificateThumbprint);

            if(string.IsNullOrEmpty(primaryCertificateThumbprint))
            {
                throw new ArgumentException(nameof(primaryCertificateThumbprint));
            }

            if (string.IsNullOrEmpty(secondaryCertificateThumbprint))
            {
                throw new ArgumentException(nameof(secondaryCertificateThumbprint));
            }

            if (string.Equals(primaryCertificateThumbprint, secondaryCertificateThumbprint, StringComparison.OrdinalIgnoreCase))
            {
                string errorMessage = string.Format(StorageSyncResources.ResetCertificateMessageFormat6, primaryCertificateThumbprint);
                verboseLogger(errorMessage);
                throw new Exception(errorMessage);
            }

            // Switch to secondary certificate 
            verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat7, primaryCertificateThumbprint, secondaryCertificateThumbprint));

            try
            {
                EcsManagementInteropClient.SwitchToSecondaryCertificateAndUpdateMonitoring();
            }
            catch (COMException ex)
            {
                verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat8, ex.HResult,ex.Message));
            }

            verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat9, secondaryCertificateThumbprint));

            try
            {
                verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat10, primaryCertificateThumbprint));

                hResult = EcsManagementInteropClient.DeleteServerCertificate(primaryCertificateThumbprint);

                verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat11, primaryCertificateThumbprint));
            }
            catch (COMException ex)
            {
                // Ignoring the failure to delete the stale certificate
                verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat12, ex.HResult, ex.Message));
            }
        }

        /// <summary>
        /// Validates the certificate.
        /// </summary>
        /// <param name="certificateString">The certificate string.</param>
        /// <param name="verboseLogger">The verbose logger.</param>
        /// <exception cref="Exception">MgmtInvalidOrExpiredCertificate</exception>
        private void ValidateCertificate(string certificateString, Action<string> verboseLogger)
        {
            string errorMessage = string.Empty;

            var certificate = new X509Certificate2(certificateString.ToBase64Bytes(true));

            verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat13, certificate.Thumbprint));

            // Validate certificate expiry
            if (DateTime.Compare(DateTime.Now, certificate.NotAfter) > 0)
            {
                errorMessage = string.Format(StorageSyncResources.ResetCertificateMessageFormat14, DateTime.Now, certificate.NotAfter);
            }

            // Validate certificate doesn't contain Private key
            if (certificate.HasPrivateKey)
            {
                errorMessage = StorageSyncResources.ResetCertificateMessageFormat15;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new Exception(errorMessage);
            }

            verboseLogger(string.Format(StorageSyncResources.ResetCertificateMessageFormat16, certificate.Thumbprint));
        }
    }
}
