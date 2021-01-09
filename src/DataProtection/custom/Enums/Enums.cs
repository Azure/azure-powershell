

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support
{
    public enum StorageSettingType
    {
        GeoRedundant = 0,
        LocallyRedundant
    }

    public enum DataStoreType
    {
        ArchiveStore = 0,
        SnapshotStore,
        VaultStore
    }

}