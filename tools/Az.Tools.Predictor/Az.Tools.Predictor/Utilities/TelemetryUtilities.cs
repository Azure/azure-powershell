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

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities
{
    /// <summary>
    /// A utilities class to provide functions around telemetry.
    /// </summary>
    internal static class TelemetryUtilities
    {
        /// <summary>
        /// The telemetry event prefix to use in Az.Tools.Predictor.
        /// </summary>
        public const string TelemetryEventPrefix = "Az.Tools.Predictor";

        /// <summary>
        /// Gets the session id for the telemetry events.
        /// </summary>
        public static readonly string SessionId = Guid.NewGuid().ToString();

        /// <summary>
        /// Creates a new instance of telemetry client.
        /// </summary>
        public static TelemetryClient CreateApplicationInsightTelemetryClient()
        {
            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            // Use Aladdin Telemetry Instrumentation Key
            configuration.InstrumentationKey = "036e159f-c9a8-4cc2-9dba-1b0a9352835d";
            var telemetryClient = new TelemetryClient(configuration);
            telemetryClient.Context.Location.Ip = "0.0.0.0";
            telemetryClient.Context.Cloud.RoleInstance = "placeholderdon'tuse";
            telemetryClient.Context.Cloud.RoleName = "placeholderdon'tuse";

            return telemetryClient;
        }

        /// <summary>
        /// Creates common telemetry properties.
        /// </summary>
        /// <param name="azContext">The current Azure PowerShell context.</param>
        public static IDictionary<string, string> CreateCommonProperties(IAzContext azContext) => new Dictionary<string, string>()
            {
                { "SessionId", SessionId },
                { "Cohort", azContext.Cohort.ToString(CultureInfo.InvariantCulture) },
                { "InstallationId", azContext.InstallationId },
                { "IsInternal", azContext.IsInternal.ToString(CultureInfo.InvariantCulture) },
                { "HashMacAddress", azContext.MacAddress },
                { "PowerShellVersion", azContext.PowerShellVersion.ToString() },
                { "ModuleVersion", azContext.ModuleVersion.ToString() },
                { "OS", azContext.OSVersion },
                { "UserAgent", CreateUserAgent(azContext) },
            };

        private static string CreateUserAgent(IAzContext azContext)
        {
            string result = string.Format("AzurePowerShell/Az{0}", azContext.AzVersion);

            if (!string.IsNullOrWhiteSpace(azContext.HostEnvironment))
            {
                result += string.Format(" {0}", azContext.HostEnvironment);
            }

            return result;
        }
    }
}
