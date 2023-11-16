

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support
{

    public enum DatasourceTypes
    {
        AzureDisk = 0,
        AzureBlob,
        AzureDatabaseForPostgreSQL,
        AzureKubernetesService
    }

    public enum StorageSettingType
    {
        GeoRedundant = 0,
        LocallyRedundant,
        ZoneRedundant
    }

    public enum DataStoreType
    {
        ArchiveStore = 0,
        OperationalStore,
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
        ImmediateCopyOption,
        CopyOnExpiryOption
    }

    public enum BackupFrequency
    {
        Daily = 0,
        Weekly,
        Hourly
    }

    public enum RetentionRuleName
    {
        Default = 0,
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    public enum TagName
    {
        Daily = 0,
        Weekly,
        Monthly,
        Yearly
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

    public enum RestoreMode
    {
        RecoveryPointBased = 0,
        PointInTimeBased
    }

    public enum RestoreTargetType
    {
        AlternateLocation = 0,
        OriginalLocation,
        RestoreAsFiles
    }

    public enum SecretStoreTypes
    {
        AzureKeyVault = 0
    }

    public enum ProtectionStatus
    {
        ConfiguringProtection = 0,
        ProtectionConfigured,
        ConfiguringProtectionFailed,
        ProtectionError
    }

    public enum JobOperation
    {
        OnDemandBackup = 0,
        ScheduledBackup,
        Restore
    }

    public enum JobStatus
    {
        InProgress = 0,
        Completed,
        Failed
    }
}