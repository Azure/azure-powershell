using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace StorageSync.Management.PowerShell.Cmdlets.CertificateRollover
{
    /// <summary>
    /// Function performs server certificate rollover
    /// </summary>
    public class SyncServerCertificateRolloverClient : ISyncServerCertificateRollover
    {
        private bool m_isDisposed;

        /// <summary>
        /// ECS Management Interop Client
        /// </summary>
        protected IEcsManagement EcsManagementInteropClient { get; private set; }

        /// <summary>
        /// Parameterzed constructor for Sync Server certificate rollover Client
        /// </summary>
        /// <param name="ecsManagementInteropClient"></param>
        public SyncServerCertificateRolloverClient(IEcsManagement ecsManagementInteropClient)
        {
            this.EcsManagementInteropClient = ecsManagementInteropClient;
        }

        /// <summary>
        /// Function performs server certificate rollover
        /// </summary>
        /// <param name="certificateProviderName">Certificate Provider Name</param>
        /// <param name="certificateHashAlgorithm">Certificate Hash Algorithm</param>
        /// <param name="certificateKeyLength">Certificate Key Length</param>
        /// <param name="triggerServiceRollover">Trigger service request callback for service call</param>
        /// <param name="verboseLogger"> powershell tracing function </param>
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

        private string RolloverSecondaryCertificate(Action<string> verboseLogger, out Guid serverId)
        {
            string primaryCertificateThumbprint = string.Empty;
            string secondaryCertificateThumbprint = string.Empty;
            int hResult = 0;
            bool generateNewCertificate = true;
            string secondaryCertificate = string.Empty;
            string serverIdString = string.Empty;

            // Retrieve serverId from the configuration
            this.EcsManagementInteropClient.GetSyncServerId(out serverIdString);

            if (!Guid.TryParse(serverIdString, out serverId))
            {
                throw new ArgumentException(nameof(serverId));
            }

            verboseLogger($"ServerId: {serverId}");

            this.EcsManagementInteropClient.GetServerCertificateThumbprints(out primaryCertificateThumbprint, out secondaryCertificateThumbprint);

            verboseLogger("Primary Certificate Thumbprint: " + primaryCertificateThumbprint + " Secondary Certificate Thumbprint: " + secondaryCertificateThumbprint);

            if(string.IsNullOrEmpty(primaryCertificateThumbprint) || string.IsNullOrEmpty(secondaryCertificateThumbprint))
            {
                //throw new HfsBackendException(HfsErrorCodes.MgmtUnexpectedServerCertificateConfiguration, "Certificate thumbprints not found. Check if server is registered.", null);
                throw new Exception("Certificate thumbprints not found. Check if server is registered.");
            }

            if (!string.Equals(primaryCertificateThumbprint, secondaryCertificateThumbprint, StringComparison.OrdinalIgnoreCase))
            {
                verboseLogger($"Primary and Secondary certificate thumbprints are different. Attempting to load the secondary certificate from store instead of generating new certificate..");

                try
                {
                    hResult = this.EcsManagementInteropClient.GetSyncServerCertificate(false, out secondaryCertificate);
                }
                catch (COMException ex)
                {
                    verboseLogger($"COM Exception while loading certificate: HResult: {ex.HResult} Message: {ex.Message}");
                    hResult = ex.HResult;
                }

                if (hResult == 0 && !string.IsNullOrEmpty(secondaryCertificate))
                {
                    verboseLogger($"Succesfully retrieved secondary certificate with thumbprint: {secondaryCertificateThumbprint} from store with HResult: {hResult}");

                    generateNewCertificate = false;
                }
                else
                {
                    verboseLogger($"Failed to retrieve the secondary certificate from store with HResult: {hResult}");
                }
            }

            if (generateNewCertificate)
            {
                secondaryCertificate = string.Empty;

                // Generate new Certificate
                verboseLogger($"Generating new Secondary Certificate.. Current Thumbprint: {secondaryCertificateThumbprint}");
                verboseLogger("Generating new Secondary certificate..");

                try
                {
                    hResult = this.EcsManagementInteropClient.RolloverSecondaryCertificate(
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
                    string errorMessage = $"Failed to generate secondary certificate. HResult: {hResult}";
                    verboseLogger(errorMessage);
                    //throw new HfsBackendException(HfsErrorCodes.MgmtServerCertificateGenerationFailed, errorMessage, null);
                    throw new Exception(errorMessage);
                }

                verboseLogger($"Successfully generated certificate in the store");
            }
            
            ValidateCertificate(secondaryCertificate, verboseLogger);

            return secondaryCertificate;
        }

        private void SwitchCertificate(Action<string> verboseLogger)
        {

            int hResult = 0;
            string primaryCertificateThumbprint = string.Empty;
            string secondaryCertificateThumbprint = string.Empty;
            
            this.EcsManagementInteropClient.GetServerCertificateThumbprints(out primaryCertificateThumbprint, out secondaryCertificateThumbprint);

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
                string errorMessage = $"Primary and Secondary certificates are same. Cannot proceed to switch and delete certificate step. Primary Thumbprint: {primaryCertificateThumbprint}";
                verboseLogger(errorMessage);

                //throw new HfsBackendException(HfsErrorCodes.MgmtUnexpectedServerCertificateConfiguration, errorMessage, null);
                throw new Exception(errorMessage);
            }

            // Switch to secondary certificate 
            verboseLogger($"Switching primary certificate to secondary and updating monitoring with latest certificate. Primary Certificate: {primaryCertificateThumbprint} Secondary Certificate: {secondaryCertificateThumbprint}");

            try
            {
                this.EcsManagementInteropClient.SwitchToSecondaryCertificateAndUpdateMonitoring();
            }
            catch (COMException ex)
            {
                verboseLogger($"COM Exception while switching certificate: HResult:{ex.HResult} Message:{ex.Message}");
            }

            verboseLogger($"Successfully switched to secondary certificate. Certificate: {secondaryCertificateThumbprint}");

            try
            {
                verboseLogger($"Deleting old certificate  with thumbprint: {primaryCertificateThumbprint}");

                hResult = this.EcsManagementInteropClient.DeleteServerCertificate(primaryCertificateThumbprint);

                verboseLogger($"Successfully deleted the certificate from the store: {primaryCertificateThumbprint}");
            }
            catch (COMException ex)
            {
                // Ignoring the failure to delete the stale certificate
                verboseLogger($"COM Exception during deletion of old Primary certificate: HResult:{ex.HResult} Message:{ex.Message}. Ignoring the error..");
            }
        }
        
        private void ValidateCertificate(string certificateString, Action<string> verboseLogger)
        {
            string errorMessage = string.Empty;

            var certificate = new X509Certificate2(certificateString.ToBase64Bytes(true));

            verboseLogger($"Validating Certificate with Thumbprint: {certificate.Thumbprint}");

            // Validate certificate expiry
            if (DateTime.Compare(DateTime.Now, certificate.NotAfter) > 0)
            {
                errorMessage = $"Certificate is expired. Current Time: {DateTime.Now} Certificate NotAfter: {certificate.NotAfter}";
            }

            // Validate certificate doesn't contain Private key
            if (certificate.HasPrivateKey)
            {
                errorMessage = $"Certificate contains Private Key";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                //throw new HfsBackendException(HfsErrorCodes.MgmtInvalidOrExpiredCertificate, errorMessage, null);
                throw new Exception("MgmtInvalidOrExpiredCertificate");
            }

            verboseLogger($"Successfully validated certificate with thumbprint: {certificate.Thumbprint}");
        }
    }
}
