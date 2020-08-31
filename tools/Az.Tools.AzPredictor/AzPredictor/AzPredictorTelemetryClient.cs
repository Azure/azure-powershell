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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Microsoft.Azure.PowerShell.AzPredictor
{
    /// <summary>
    /// A telemetry client implementation to collect the telemetry data for AzPredictor
    /// </summary>
    sealed class AzPredictorTelemetryClient : ITelemetryClient
    {
        private readonly TelemetryClient _telemetryClient;
        private int _accepts;
        private readonly string _sessionId;

        private object lockObject = new object();
        private AzurePSDataCollectionProfile _cachedProfile = null;

        private AzurePSDataCollectionProfile DataCollectionProfile
        {
            get
            {
                lock (lockObject)
                {
                    DataCollectionController controller;
                    if (_cachedProfile == null && AzureSession.Instance.TryGetComponent(DataCollectionController.RegistryKey, out controller))
                    {
                        _cachedProfile = controller.GetProfile(() => {});
                    }
                    else if (_cachedProfile == null)
                    {
                        _cachedProfile = new AzurePSDataCollectionProfile(true);
                    }

                    return _cachedProfile;
                }
            }
        }

        /// <summary>
        /// Check whether the data collection is opted in from user
        /// </summary>
        /// <returns>true if allowed</returns>
        private bool IsDataCollectionAllowed()
        {
            if (DataCollectionProfile != null &&
                DataCollectionProfile.EnableAzureDataCollection.HasValue &&
                DataCollectionProfile.EnableAzureDataCollection.Value)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictorTelemetryClient"/>
        /// </summary>
        public AzPredictorTelemetryClient()
        {
            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = "7df6ff70-8353-4672-80d6-568517fed090"; // Use Azuer-PowerShell instrumentation key. see https://github.com/Azure/azure-powershell-common/blob/master/src/Common/AzurePSCmdlet.cs
            _telemetryClient = new TelemetryClient(configuration);
            _sessionId = Guid.NewGuid().ToString();
        }

        /// <inheritdoc/>
        public void OnSuggestionForHistory(string historyLine,
                             int? suggestionIndex,
                             int? fallbackIndex,
                             IEnumerable<string> topSuggestions)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            var currentLog = new Dictionary<string, string>();
            currentLog["History"] = historyLine;
            currentLog["SessionId"] = _sessionId;

            if (suggestionIndex.HasValue)
            {
                currentLog["SuggestionIndex"] = suggestionIndex.Value.ToString(CultureInfo.InvariantCulture);
            }

            if (fallbackIndex.HasValue)
            {
                currentLog["FallbackIndex"] = fallbackIndex.Value.ToString(CultureInfo.InvariantCulture);
            }

            if (topSuggestions != null)
            {
                currentLog["Top5Suggestions"] = string.Join(',', topSuggestions.Take(5));
            }

            this._telemetryClient.TrackEvent("GetSuggestion", currentLog);
        }

        /// <inheritdoc/>
        public void OnSuggestionAccepted(string acceptedSuggestion)
        {
            ++this._accepts;

            if (!IsDataCollectionAllowed())
            {
                return;
            }
        }
    }
}
