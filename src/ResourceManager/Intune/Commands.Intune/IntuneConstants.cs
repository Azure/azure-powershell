namespace Commands.Intune
{   
    public enum PlatformType
    {
        iOS,
        Android,
        Windows,
        None
    }

    public enum AppSharingType
    {
        none,
        policyManagedApps,
        allApps
    }

    public enum ChoiceType
    {
        required,
        notRequired
    }

    public enum ClipboardSharingLevelType
    {
        blocked,
        policyManagedApps,
        policyManagedAppsWithPasteIn,
        allApps
    }
    public enum FilterType
    {
        allow,
        block
    }
    public enum OptionType
    {
        enable,
        disable
    }

    public enum DeviceLockType
    {
        deviceLocked,
        deviceLockedExceptFilesOpen,
        afterDeviceRestart,
        useDeviceSettings
    }
    public class IntuneConstants
    {
        public static string ApiVersion = "2015-01-11-alpha";

        public static int DEFAULT_PIN_RETRIES = 15;
        public static int DEFAULT_RECHECK_ACCESS_OFFLINE_GRACEPERIOD_MINUTES = 720;
        public static int DEFAULT_RECHECK_ACCESSTIMEOUT_MINUTES = 30;
        public static int DEFAULT_OFFLINE_WIPEINTERVAL_DAYS = 1;        
    }
}
