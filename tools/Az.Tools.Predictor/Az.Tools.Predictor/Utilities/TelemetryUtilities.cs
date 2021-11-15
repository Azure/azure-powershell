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

using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

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
            // Use Azuer-PowerShell instrumentation key. see https://github.com/Azure/azure-powershell-common/blob/master/src/Common/AzurePSCmdlet.cs
            configuration.InstrumentationKey = "7df6ff70-8353-4672-80d6-568517fed090";
            var telemetryClient = new TelemetryClient(configuration);
            telemetryClient.Context.Location.Ip = "0.0.0.0";
            telemetryClient.Context.Cloud.RoleInstance = "placeholderdon'tuse";
            telemetryClient.Context.Cloud.RoleName = "placeholderdon'tuse";

            return telemetryClient;
        }

        /// <summary>
        /// Creates common telemetry properties.
        /// </summary>
        public static IDictionary<string, string> CreateCommonProperties(IAzContext azContext) => new Dictionary<string, string>()
            {
                { "SessionId", TelemetryUtilities.SessionId },
                { "Cohort", azContext.Cohort.ToString(CultureInfo.InvariantCulture) },
                { "UserId", azContext.HashUserId },
                { "IsInternal", azContext.IsInternal.ToString(CultureInfo.InvariantCulture) },
                { "HashMacAddress", azContext.MacAddress },
                { "PowerShellVersion", azContext.PowerShellVersion.ToString() },
                { "ModuleVersion", azContext.ModuleVersion.ToString() },
                { "OS", azContext.OSVersion },
            };
    }
}
