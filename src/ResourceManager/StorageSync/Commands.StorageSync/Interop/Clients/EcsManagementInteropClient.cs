using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Enums;
using Commands.StorageSync.Interop.Exceptions;
using Commands.StorageSync.Interop.Interfaces;
using System;
using System.Management.Automation;
using System.Runtime.InteropServices;


namespace Commands.StorageSync.Interop.Clients
{
    public class EcsManagementInteropClient : IEcsManagement
    {
        // Non-constants because they are passed as ref parameters.
        private static Guid CLSID_CEcsManagement = ManagementInteropConstants.CLSID_CEcsManagement;
        private static Guid IID_IEcsManagement = ManagementInteropConstants.IID_IEcsManagement;
        private static Guid IID_IUnknown = ManagementInteropConstants.IID_IUnknown;

        private COMReleaseHandle m_managementObjectHandle = new COMReleaseHandle();
        private IEcsManagement m_managementObject;

        protected virtual bool HasValidHandle
        {
            get { return !this.m_managementObjectHandle.IsInvalid; }
        }
        public EcsManagementInteropClient()
        {
            m_managementObject = Initialize();
        }

        protected virtual IEcsManagement Initialize()
        {
            var managementInterfacePointer = IntPtr.Zero;

            //HfsTracer.TraceInfo($"EcsManagementClient:Initialize : Creating object with CLSID: {CLSID_CEcsManagement}");

            int hr = Win32Helper.CoCreateInstance(
                ref CLSID_CEcsManagement,
                null,
                ManagementInteropConstants.CLSCTX_LOCAL_SERVER,
                ref IID_IEcsManagement,
                out managementInterfacePointer);

            //HfsTracer.TraceInfo($"EcsManagementClient:Initialize : CoCreateInstance HRESULT: {hr}");

            //  Validations for ensuring success of creating com instance.
            if (hr != 0)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.CoCreateInstanceFailed, hr, ErrorCategory.InvalidResult);
            }

            if (managementInterfacePointer == IntPtr.Zero)
            {
                //HfsTracer.TraceError("EcsManagementClient:Initialize : CoCreateInstance returned null object pointer.");

                throw new ServerRegistrationException(ServerRegistrationErrorCode.CoCreateInstanceFailed, ErrorCategory.InvalidOperation);
            }

            m_managementObjectHandle.AttachHandle(managementInterfacePointer);

            //HfsTracer.TraceInfo("EcsManagementClient:Initialize : Getting Management Interface.");

            m_managementObject = (IEcsManagement)Marshal.GetObjectForIUnknown(managementInterfacePointer);

            if (m_managementObject == null)
            {
                //HfsTracer.TraceError("EcsManagementClient:Initialize : GetObjectForIUnknown returned null.");
                throw new ServerRegistrationException(ServerRegistrationErrorCode.CoCreateInstanceFailed, ErrorCategory.InvalidOperation);
            }

            CoSetProxyBlanket(managementInterfacePointer);

            return m_managementObject;
        }

        public void Dispose()
        {
            DisposeInternal(true);
        }

        ~EcsManagementInteropClient()
        {
            DisposeInternal(false);
        }

        private void DisposeInternal(bool disposing)
        {
            if (m_managementObject != null)
            {
                if (Marshal.IsComObject(m_managementObject))
                {
                    Marshal.ReleaseComObject(m_managementObject);
                }
                m_managementObject = null;
            }
            if (m_managementObjectHandle != null)
            {
                m_managementObjectHandle.Dispose();
                m_managementObjectHandle = null;
            }

            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        public int ValidateSyncServer([In, MarshalAs(UnmanagedType.BStr)] string serviceUri, [In, MarshalAs(UnmanagedType.BStr)] string subscriptionId, [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceName, [In, MarshalAs(UnmanagedType.BStr)] string resourceGroupName)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.ValidateSyncServer(serviceUri, subscriptionId, storageSyncServiceName, resourceGroupName);
        }

        public int EnsureSyncServerCertificate([In, MarshalAs(UnmanagedType.BStr)] string serviceUri, [In, MarshalAs(UnmanagedType.BStr)] string subscriptionId, [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceName, [In, MarshalAs(UnmanagedType.BStr)] string resourceGroupName, [In, MarshalAs(UnmanagedType.BStr)] string certificateProviderName, [In, MarshalAs(UnmanagedType.BStr)] string certificateHashAlgorithm, [In, MarshalAs(UnmanagedType.U4)] uint certificateKeyLength)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.EnsureSyncServerCertificate(serviceUri, subscriptionId, storageSyncServiceName, resourceGroupName, certificateProviderName, certificateHashAlgorithm, certificateKeyLength);
        }

        public int RegisterSyncServer([In, MarshalAs(UnmanagedType.BStr)] string serviceUri, [In, MarshalAs(UnmanagedType.BStr)] string subscriptionId, [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceName, [In, MarshalAs(UnmanagedType.BStr)] string resourceGroupName, [In, MarshalAs(UnmanagedType.BStr)] string certificateProviderName, [In, MarshalAs(UnmanagedType.BStr)] string certificateHashAlgorithm, [In, MarshalAs(UnmanagedType.U4)] uint certificateKeyLength, [In, MarshalAs(UnmanagedType.BStr)] string monitoringDataPath)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.RegisterSyncServer(serviceUri, subscriptionId, storageSyncServiceName, resourceGroupName, certificateProviderName, certificateHashAlgorithm, certificateKeyLength, monitoringDataPath);
        }

        public int ResetSyncServerConfiguration([In, MarshalAs(UnmanagedType.Bool)] bool cleanClusterRegistration)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.ResetSyncServerConfiguration(cleanClusterRegistration);
        }

        public int GhostPath([In, MarshalAs(UnmanagedType.BStr)] string path, [In, MarshalAs(UnmanagedType.Struct), Out] ref GHOSTING_STATS ghostingStats)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.GhostPath(path, ref ghostingStats);
        }

        public void SetProxySetting([In, MarshalAs(UnmanagedType.Struct)] ProxySetting proxySetting)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            m_managementObject.SetProxySetting(proxySetting);
        }

        public ProxySetting GetProxySetting()
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.GetProxySetting();
        }

        public void RemoveProxySetting()
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            m_managementObject.RemoveProxySetting();
        }

        public int ScrubFiles([In, MarshalAs(UnmanagedType.BStr)] string path, [In, MarshalAs(UnmanagedType.U4)] ScrubbingMode mode, [In, MarshalAs(UnmanagedType.Bool)] bool isDeepScan, [In, MarshalAs(UnmanagedType.BStr)] string reportPath, [In, MarshalAs(UnmanagedType.Struct), Out] ref SCRUBBING_STATS scrubbingStats)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.ScrubFiles(path, mode, isDeepScan, reportPath, ref scrubbingStats);
        }

        public int GetStorageSyncServerEndpointStatus([In, MarshalAs(UnmanagedType.BStr)] string path, [In, Out, MarshalAs(UnmanagedType.BStr)] ref string serverEndpointReports)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.GetStorageSyncServerEndpointStatus(path, ref serverEndpointReports);
        }

        public int GetStorageSyncRegisteredServerStatus([In, MarshalAs(UnmanagedType.BStr), Out] ref string registeredServerStats)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.GetStorageSyncRegisteredServerStatus(ref registeredServerStats);
        }

        public bool IsTieredFileOrphaned([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.IsTieredFileOrphaned(path);
        }

        public bool DeleteOrphanedTieredFile([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.DeleteOrphanedTieredFile(path);
        }

        public int GarbageCollectStableVersions([In, MarshalAs(UnmanagedType.BStr)] string path, [In, MarshalAs(UnmanagedType.U4)] GarbageCollectionMode mode, [In, MarshalAs(UnmanagedType.Struct), Out] ref GARBAGECOLLECTION_STATS garbageCollectionStats)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.GarbageCollectStableVersions(path, mode, ref garbageCollectionStats);
        }

        public RecallOutput RecallFile([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.RecallFile(path);
        }

        public bool IsPathUnderSyncShare([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.IsPathUnderSyncShare(path);
        }

        public int PersistSyncServerRegistration(
            [In, MarshalAs(UnmanagedType.BStr)] string serviceUri,
            [In, MarshalAs(UnmanagedType.BStr)] string subscriptionId,
            [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceName,
            [In, MarshalAs(UnmanagedType.BStr)] string resourceGroupName,
            [In, MarshalAs(UnmanagedType.BStr)] string clusterId,
            [In, MarshalAs(UnmanagedType.BStr)] string clusterName,
            [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceUid,
            [In, MarshalAs(UnmanagedType.BStr)] string discoveryUri,
            [In, MarshalAs(UnmanagedType.BStr)] string serviceLocation,
            [In, MarshalAs(UnmanagedType.BStr)] string resourceLocation)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.PersistSyncServerRegistration(
                serviceUri,
                subscriptionId,
                storageSyncServiceName,
                resourceGroupName,
                clusterId,
                clusterName,
                storageSyncServiceUid,
                discoveryUri,
                serviceLocation,
                resourceLocation);
        }

        public int RolloverSecondaryCertificate(
            [In, MarshalAs(UnmanagedType.BStr)]    string certificateProviderName,
            [In, MarshalAs(UnmanagedType.BStr)]    string certificateHashAlgorithm,
            [In, MarshalAs(UnmanagedType.U4)]      uint certificateKeyLength,
            [Out, MarshalAs(UnmanagedType.BStr)]   out string serverCertificateThumbprint)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.RolloverSecondaryCertificate(certificateProviderName, certificateHashAlgorithm, certificateKeyLength, out serverCertificateThumbprint);
        }

        public int GetServerCertificateThumbprints(
            [Out, MarshalAs(UnmanagedType.BStr)] out string primaryCertificateThumbprint,
            [Out, MarshalAs(UnmanagedType.BStr)] out string secondaryCertificateThumbprint)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.GetServerCertificateThumbprints(out primaryCertificateThumbprint, out secondaryCertificateThumbprint);
        }

        public int DeleteServerCertificate(
            [In, MarshalAs(UnmanagedType.BStr)] string certificateThumbprint)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.DeleteServerCertificate(certificateThumbprint);
        }

        public int SwitchToSecondaryCertificateAndUpdateMonitoring()
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.SwitchToSecondaryCertificateAndUpdateMonitoring();
        }

        public int GetSyncServerCertificate([In, MarshalAs(UnmanagedType.Bool)] bool isPrimary, [MarshalAs(UnmanagedType.BStr), Out] out string serverCertificate)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.GetSyncServerCertificate(isPrimary, out serverCertificate);
        }

        public int GetSyncServerId([MarshalAs(UnmanagedType.BStr), Out] out string serverId)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.GetSyncServerId(out serverId);
        }

        public int GetClusterInfo([MarshalAs(UnmanagedType.BStr), Out] out string clusterId, [MarshalAs(UnmanagedType.BStr), Out] out string clusterName)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.GetClusterInfo(out clusterId, out clusterName);
        }

        public bool IsInCluster()
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.IsInCluster();
        }

        public int RegisterMonitoringAgent([MarshalAs(UnmanagedType.BStr)] string serverRegistrationData, [MarshalAs(UnmanagedType.BStr)] string monitoringDataPath)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.RegisterMonitoringAgent(serverRegistrationData, monitoringDataPath);
        }

        [return: MarshalAs(UnmanagedType.BStr)]
        public string NewNetworkLimit([In, MarshalAs(UnmanagedType.Interface)] INetworkLimitConfigEntry config)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.NewNetworkLimit(config);
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public INetworkLimitConfigurationEntryEnumeration GetNetworkLimits()
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.GetNetworkLimits();
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public INetworkLimitConfigEntry GetNetworkLimit([In, MarshalAs(UnmanagedType.BStr)] string id)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            return m_managementObject.GetNetworkLimit(id);
        }

        public void RemoveNetworkLimit([In, MarshalAs(UnmanagedType.BStr)] string id)
        {
            //Check.True(nameof(this.HasValidHandle), this.HasValidHandle);
            m_managementObject.RemoveNetworkLimit(id);
        }

        private static int CoSetProxyBlanket(IntPtr proxy,
           uint dwAuthnSvc = ManagementInteropConstants.RPC_C_AUTHN_DEFAULT,
           uint dwAuthzSvc = ManagementInteropConstants.RPC_C_AUTHZ_NONE,
           string pServerPrincName = null,
           RpcAuthnLevel dwAuthnLevel = RpcAuthnLevel.Default,
           RpcImpLevel dwImpLevel = RpcImpLevel.Impersonate,
           OleAuthCapabilities dwCapababilities = OleAuthCapabilities.EOACNONE,
           bool exception = true)
        {
            return CoSetProxyBlanket(
                proxy,
                dwAuthnSvc,
                dwAuthzSvc,
                pServerPrincName,
                dwAuthnLevel,
                dwImpLevel,
                IntPtr.Zero,
                dwCapababilities,
                exception);
        }

        private static int CoSetProxyBlanket(IntPtr proxy,
            uint dwAuthnSvc,
            uint dwAuthzSvc,
            string pServerPrincName,
            RpcAuthnLevel dwAuthnLevel,
            RpcImpLevel dwImpLevel,
            IntPtr pAuthInfo,
            OleAuthCapabilities dwCapababilities,
            bool throwOnError)
        {
            //should be called once for process to be able to call into ecs com api's
            int hr = Win32Helper.CoSetProxyBlanket(
                proxy,
                dwAuthnSvc,
                dwAuthzSvc,
                pServerPrincName,
                dwAuthnLevel,
                dwImpLevel,
                pAuthInfo,
                dwCapababilities);

            //expected is 0
            if (HResult.Failed(hr) && throwOnError)
            {
                //HfsTracer.TraceError($"EcsManagementClient:Initialize:CoSetProxyBlanket : CoSetProxyBlanket failed with HRESULT {hr:X}.");
                throw new COMException($"CoSetProxyBlanket failed with HRESULT {hr:X}");
            }

            return hr;
        }
   }
}
