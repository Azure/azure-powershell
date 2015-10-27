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

namespace Microsoft.Azure.Commands.Intune
{   
    /// <summary>
    /// The platforms supported
    /// </summary>
    public enum PlatformType
    {
        iOS,
        Android,
        Windows,
        None
    }

    /// <summary>
    /// The application sharing options
    /// </summary>
    public enum AppSharingType
    {
        none,
        policyManagedApps,
        allApps
    }

    /// <summary>
    /// Defines choices
    /// </summary>
    public enum ChoiceType
    {
        required,
        notRequired
    }
    /// <summary>
    /// Types of clipboard sharing levels
    /// </summary>
    public enum ClipboardSharingLevelType
    {
        blocked,
        policyManagedApps,
        policyManagedAppsWithPasteIn,
        allApps
    }

    /// <summary>
    /// Filtering types
    /// </summary>
    public enum FilterType
    {
        allow,
        block
    }

    /// <summary>
    /// Option types.
    /// </summary>
    public enum OptionType
    {
        enable,
        disable
    }

    /// <summary>
    /// Types of device locking available..
    /// </summary>
    public enum DeviceLockType
    {
        deviceLocked,
        deviceLockedExceptFilesOpen,
        afterDeviceRestart,
        useDeviceSettings
    }

    /// <summary>
    /// Constants used in the project..
    /// </summary>
    public class IntuneConstants
    {
        public static string ApiVersion = "2015-01-11-alpha";

        public static int DEFAULT_PIN_RETRIES = 15;
        public static int DEFAULT_RECHECK_ACCESS_OFFLINE_GRACEPERIOD_MINUTES = 720;
        public static int DEFAULT_RECHECK_ACCESSTIMEOUT_MINUTES = 30;
        public static int DEFAULT_OFFLINE_WIPEINTERVAL_DAYS = 1;
        public static int BATCH_SIZE = 10;

        public static string AppUriFormat = "https://{0}/providers/Microsoft.Intune/locations/{1}/apps/{2}";
        public static string GroupUriFormat = "https://{0}/providers/Microsoft.Intune/locations/{1}/groups/{2}";
    }
}
