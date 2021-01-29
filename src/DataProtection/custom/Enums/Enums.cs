

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support
{

    public enum DatasourceTypes
    {
        AzureDatabaseForPostgreSQL = 0,
        AzureBlob
    }

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

    public enum DurationType
    {
        Days = 0,
        Weeks,
        Months,
        Years
    }

    public enum CopyOption
    {
        CustomCopyOption = 0,
        ImmediateCopyOption
    }

    public enum BackupFrequency
    {
        Daily = 0,
        Weekly
    }

    public enum AbsoluteTagCriteria
    {
        AllBackup = 0,
        FirstOfDay,
        FirstOfMonth,
        FirstOfWeek,
        FirstOfYear
    }
    
    public enum WeeksOfMonth
    {
        First = 0,
        Second,
        Third,
        Fourth,
        Last
    }

    public enum MonthsOfYear
    {
        January = 0,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    public enum DaysOfWeek
    {
        Sunday = 0,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public enum RestoreRequestType
    {
        RecoveryPointBased = 0
    }
}