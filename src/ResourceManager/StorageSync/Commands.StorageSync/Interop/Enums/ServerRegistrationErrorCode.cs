namespace Commands.StorageSync.Interop.Enums
{
    public enum ServerRegistrationErrorCode
    {
        GenericError,
        CoCreateInstanceFailed,
        MonitoringDataPathIsNullOrEmpty,
        MonitoringDataPathIsInvalid,
        RegisterSyncServerError,
        GetSyncServerCertificateError,
        ConvertServerCertificateError,
        ServerNameIsNullOrEmpty,
        ServerIdIsNullOrEmpty,
        
        InvalidRegistrationResponse,
        UnableToGetAgentInstallerPathRegistryKeyValue,
        ServerResourceIsNull,
        ServiceEndpointIsNotSet,
        ValidateSyncServerFailed,
        EnsureSyncServerCertificateFailed,
        GetSyncServerCertificateFailed,
        GetSyncServerIdFailed,
        GetClusterInfoFailed,
        PersistSyncServerRegistrationFailed,
        RegisterOnlineSyncRegistrationFailed,
        ProcessSyncRegistrationFailed,
        SyncServerAlreadyExists,
        RegisterMonitoringAgentFailed,
        RegisterSyncServerAccessDenied,
        SyncServerNotFound,

    }
}
