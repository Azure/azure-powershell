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
    /// Constants used in the project..
    /// </summary>
    public class IntuneConstants
    {
        public static int DefaultPinNumRetry = 15;
        public static int DefaultAccessRecheckOfflineTimeout = 720;
        public static int DefaultAccessRecheckOnlineTimeout = 30;
        public static int DefaultOfflineWipeTimeout = 1;        

        public static string AppUriFormat = "https://{0}/providers/Microsoft.Intune/locations/{1}/apps/{2}";
        public static string GroupUriFormat = "https://{0}/providers/Microsoft.Intune/locations/{1}/groups/{2}";

        public static string PlatformFilterQueryParam = "platform eq '{0}'";

        // Policy Properties
        public static string PinNumRetryProperty = "PinNumRetry";
        public static string AccessRecheckOfflineTimeoutProperty = "AccessRecheckOfflineTimeout";
        public static string AccessRecheckOnlineTimeoutProperty = "AccessRecheckOnlineTimeout";
        public static string OfflineWipeTimeoutProperty = "OfflineWipeTimeout";
    }
}
