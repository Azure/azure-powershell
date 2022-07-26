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

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public static class Constants
    {
        public const string DefaultMsiAccountIdPrefix = "MSI@";

        /// <summary>
        /// Access token for Microsoft Graph service.
        /// </summary>
        public const string MicrosoftGraphAccessToken = "MicrosoftGraphAccessToken";

        public const string DefaultValue = "Default";

        public class ConfigProviderIds
        {
            public const string EnvironmentVariable = "Environment Variable";
            public const string UserConfig = "Config (User)";
            public const string ProcessConfig = "Config (Process)";
            /// <summary>
            /// Represents that the config is never set by user.
            /// </summary>
            public const string None = "None";
        }
    }
}
