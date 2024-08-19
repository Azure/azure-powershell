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
using Microsoft.Azure.Commands.Shared.Config;
using Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Providers;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Authentication.Sanitizer
{
    public class OutputSanitizer : IOutputSanitizer
    {
        private readonly ISanitizerProviderResolver _providerResolver = DefaultProviderResolver.Instance;

        public bool RequireSecretsDetection
        {
            get
            {
                if (AzureSession.Instance != null && AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var configManager))
                    return configManager.GetConfigValue<bool>(ConfigKeys.DisplaySecretsWarning);

                return false;
            }
        }

        public IEnumerable<string> IgnoredModules => Enumerable.Empty<string>();

        public IEnumerable<string> IgnoredCmdlets => new[]
        {
            "Get-AzActivityLog",
            "Get-AzComputeResourceSku",
            "Get-AzConsumptionUsageDetail",
        };

        public void Sanitize(object sanitizingObject, out SanitizerTelemetry telemetry)
        {
            var watch = Stopwatch.StartNew();

            var sanitizingStack = new Stack<object>();
            telemetry = new SanitizerTelemetry(showSecretsWarning: true);

            if (sanitizingObject != null)
            {
                try
                {
                    var provider = _providerResolver.ResolveProvider(sanitizingObject.GetType());
                    provider?.SanitizeValue(sanitizingObject, sanitizingStack, _providerResolver, null, telemetry);
                }
                catch (Exception ex)
                {
                    telemetry.HasErrorInDetection = true;
                    telemetry.DetectionError = ex;
                }
            }

            watch.Stop();
            telemetry.SanitizeDuration = watch.Elapsed;
        }
    }
}
