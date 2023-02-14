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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.PowerShell.Common.Config;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    internal static class ConfigScopeHelper
    {
        public static ConfigScope GetScopeByProviderId(string id)
        {
            switch (id)
            {
                case Constants.ConfigProviderIds.EnvironmentVariable:
                    return ConfigScope.Environment;
                case Constants.ConfigProviderIds.UserConfig:
                    return ConfigScope.CurrentUser;
                case Constants.ConfigProviderIds.ProcessConfig:
                    return ConfigScope.Process;
                case Constants.ConfigProviderIds.None:
                    return ConfigScope.Default;
                default:
                    throw new AzPSArgumentOutOfRangeException($"Unexpected provider ID [{id}]. See {nameof(Constants.ConfigProviderIds)} class for all valid IDs.", nameof(id));
            }
        }

        public static string GetProviderIdByScope(ConfigScope scope)
        {
            switch (scope)
            {
                case ConfigScope.CurrentUser:
                    return Constants.ConfigProviderIds.UserConfig;
                case ConfigScope.Environment:
                    return Constants.ConfigProviderIds.EnvironmentVariable;
                case ConfigScope.Process:
                    return Constants.ConfigProviderIds.ProcessConfig;
                case ConfigScope.Default:
                default:
                    return Constants.ConfigProviderIds.None;
            }
        }
    }
}
