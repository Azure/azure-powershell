// Copyright (c) Microsoft Corporation. All rights reserved.
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
//
using System;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity.Core
{
    /// <summary>
    /// Helper for interacting with AppConfig settings and their related Environment variable settings.
    /// </summary>
    internal static class AppContextSwitchHelper
    {
        /// <summary>
        /// Determines if either an AppContext switch or its corresponding Environment Variable is set
        /// </summary>
        /// <param name="appContexSwitchName">Name of the AppContext switch.</param>
        /// <param name="environmentVariableName">Name of the Environment variable.</param>
        /// <returns>If the AppContext switch has been set, returns the value of the switch.
        /// If the AppContext switch has not been set, returns the value of the environment variable.
        /// False if neither is set.
        /// </returns>
        public static bool GetConfigValue(string appContexSwitchName, string environmentVariableName)
        {
            // First check for the AppContext switch, giving it priority over the environment variable.
            if (AppContext.TryGetSwitch(appContexSwitchName, out bool value))
            {
                return value;
            }
            // AppContext switch wasn't used. Check the environment variable.
            string envVar = Environment.GetEnvironmentVariable(environmentVariableName);
            if (envVar != null && (envVar.Equals("true", StringComparison.OrdinalIgnoreCase) || envVar.Equals("1")))
            {
                return true;
            }

            // Default to false.
            return false;
        }
    }
}
