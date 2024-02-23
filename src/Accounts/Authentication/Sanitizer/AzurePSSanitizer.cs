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

using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.WindowsAzure.Commands.Common.Sanitizer;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Microsoft.Azure.Commands.Common.Authentication.Sanitizer
{
    public class AzurePSSanitizer : IAzurePSSanitizer
    {
        private readonly ISanitizerProviderResolver _providerResolver = DefaultProviderResolver.Instance;

        public bool RequireSecretsDetection
        {
            get
            {
                try
                {
                    if (AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var configManager))
                    {
                        return configManager?.GetConfigValue<bool>(ConfigKeysForCommon.ShowSecretsWarning) ?? false;
                    }
                }
                catch
                {
                    // Ignore exceptions
                }

                return false;
            }
        }

        public void Sanitize(object sanitizingObject, out SanitizerTelemetry telemetryData)
        {
            var watch = Stopwatch.StartNew();

            var sanitizingStack = new Stack<object>();
            telemetryData = new SanitizerTelemetry
            {
                ShowSecretsWarning = true
            };

            if (sanitizingObject != null)
            {
                try
                {
                    var provider = _providerResolver.ResolveProvider(sanitizingObject.GetType());
                    provider?.SanitizeValue(sanitizingObject, sanitizingStack, _providerResolver, null, telemetryData);
                }
                catch (Exception ex)
                {
                    telemetryData.HasErrorInDetection = true;
                    telemetryData.DetectionError = ex;
                }
            }

            watch.Stop();
            telemetryData.SanitizeDuration = watch.Elapsed;
        }
    }
}
