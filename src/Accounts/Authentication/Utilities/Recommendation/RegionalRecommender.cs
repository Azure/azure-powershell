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

using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.Shared.Config;
using Microsoft.Azure.PowerShell.Common.Config;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common.Authentication.Utilities
{
    /// <summary>
    /// Giving recommendations based on the input location for resource creation.
    /// </summary>
    internal class RegionalRecommender : IRecommender
    {
        private readonly IDictionary<string, string> _regionMappings;

        public RegionalRecommender()
        {
            _regionMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                // to support both display name and code of any region,
                // this map contains duplicated values
                { "West Europe", "UK South" },
                { "westeurope", "UK South" },
                { "France Central", "North Europe" },
                { "francecentral", "North Europe" },
                { "Germany West Central", "North Europe" },
                { "germanywestcentral", "North Europe" }
            };
        }

        /// <inheritdoc/>
        public bool Process(InvocationInfo invocation, AzurePSQoSEvent qosEvent, out string recommendation)
        {
            recommendation = null;

            if (invocation?.MyCommand?.Name == null || invocation?.BoundParameters == null)
            {
                return false;
            }


            if (AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var configManager))
            {
                if (!configManager.GetConfigValue<bool>(ConfigKeys.DisplayRegionIdentified))
                {
                    return false;
                }
            }

            if (string.Equals("New-AzVM", invocation?.MyCommand.Name, StringComparison.InvariantCultureIgnoreCase)
                && invocation.BoundParameters.TryGetValue("Location", out object x)
                && x is string inputLocation)
            {
                inputLocation = inputLocation.Trim();

                if (_regionMappings.TryGetValue(inputLocation, out string recommendedLocation))
                {
                    recommendation = string.Format(Resources.RecommendationMessageForLocation, recommendedLocation);
                    qosEvent.DisplayRegionIdentified = recommendedLocation;
                    return true;
                }
            }
            return false;
        }
    }
}
