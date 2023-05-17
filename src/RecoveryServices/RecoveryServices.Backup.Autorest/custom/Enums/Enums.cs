

namespace Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support
{
    public enum DatasourceTypes
    {
        AzureVM = 0,
        MSSQL,
        SAPHANA,
        AzureFiles /*,
        MAB */
    }

    public enum BackupContainerType
    {
        AzureVM = 0,
        Windows,
        AzureStorage,
        AzureVMAppContainer
    }

    public enum StorageSettingType
    {
        GeoRedundant = 0,
        LocallyRedundant,
        ZoneRedundant
    }

    public enum BackupFrequency
    {
        Daily = 0,
        Weekly,
        Hourly
    }

    public enum PolicySubTypes
    {
        Standard = 0,
        Enhanced
    }

    public enum RetentionRuleName
    {
        Default = 0,
        Daily,
        Weekly,
        Monthly,
        Yearly
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
}