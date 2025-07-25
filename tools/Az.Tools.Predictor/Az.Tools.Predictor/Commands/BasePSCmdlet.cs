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
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// Provides the common base class for creating a ps cmdlet.
    /// </summary>
    public abstract class BasePSCmdlet : PSCmdlet
    {
        /// <summary>
        /// Gets and sets the properties in the telemetry event.
        /// </summary>
        protected IDictionary<string, string> AdditionalTelemetryProperties { get; set; }

        /// <inheritdoc/>
        protected override void EndProcessing()
        {
            TelemetryClient telemetryClient = TelemetryUtilities.CreateApplicationInsightTelemetryClient();
            var settings = Settings.GetSettings();
            var nestedPowerShellRuntime = new PowerShellRuntime();
            var azContext = new AzContext(nestedPowerShellRuntime);

            var invocation = MyInvocation;
            var command = invocation.MyCommand;
            var boundParameters = new StringBuilder("{");

            foreach (var p in invocation.BoundParameters)
            {
                boundParameters.Append($"{p.Key}: {p.Value.ToString()},");
            }

            if (boundParameters.Length > 1)
            {
                // There is a ',' at the end. We need to remove it.
                boundParameters.Remove(boundParameters.Length - 1, 1);
            }

            boundParameters.Append("}");

            var properties = TelemetryUtilities.CreateCommonProperties(azContext);
            properties.Add("CommandName", command.Name);
            properties.Add("BoundParameters", boundParameters.ToString());

            if (AdditionalTelemetryProperties != null)
            {
                foreach (var property in AdditionalTelemetryProperties)
                {
                    properties.TryAdd(property.Key, property.Value);
                }
            }

            telemetryClient.TrackEvent($"{TelemetryUtilities.TelemetryEventPrefix}/Cmdlet", properties);

#if DEBUG
            WriteDebug($"command name: {command.Name}, parameters: {boundParameters.ToString()}");
#endif

            base.EndProcessing();
        }
    }
}
