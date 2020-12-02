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
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Profile;
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utitlities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation.Language;
using System.Threading.Tasks.Dataflow;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// A telemetry client implementation to collect the telemetry data for AzPredictor.
    /// </summary>
    sealed class AzPredictorTelemetryClient : ITelemetryClient
    {
        private const string TelemetryEventPrefix = "Az.Tools.Predictor";

        /// <inheritdoc/>
        public string SessionId { get; } = Guid.NewGuid().ToString();

        /// <inheritdoc/>
        public string CorrelationId { get; private set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// The client that sends the telemetry to the server.
        /// </summary>
        private readonly TelemetryClient _telemetryClient;

        private readonly IAzContext _azContext;

        /// <summary>
        /// The action to handle the <see cref="TelemetryData.ITelemetryData"/> in a thread pool.
        /// </summary>
        private readonly ActionBlock<TelemetryData.ITelemetryData> _telemetryDispatcher;

        /// <summary>
        /// The adjusted texts and the source text for the suggestion.
        /// </summary>
        /// <remarks>
        /// We only access it in the thread pool which is to handle the data at the target side of the data flow.
        /// We only handle one item at a time so there is no race condition.
        /// </remarks>
        private IDictionary<string, string> _userAcceptedAndSuggestion = new Dictionary<string, string>();

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictorTelemetryClient"/>.
        /// </summary>
        /// <param name="azContext">The Az context which this module runs with.</param>
        public AzPredictorTelemetryClient(IAzContext azContext)
        {
            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = "7df6ff70-8353-4672-80d6-568517fed090"; // Use Azuer-PowerShell instrumentation key. see https://github.com/Azure/azure-powershell-common/blob/master/src/Common/AzurePSCmdlet.cs
            _telemetryClient = new TelemetryClient(configuration);
            _telemetryClient.Context.Location.Ip = "0.0.0.0";
            _telemetryClient.Context.Cloud.RoleInstance = "placeholderdon'tuse";
            _telemetryClient.Context.Cloud.RoleName = "placeholderdon'tuse";
            _azContext = azContext;
            _telemetryDispatcher = new ActionBlock<TelemetryData.ITelemetryData>(
                    (telemetryData) => DispatchTelemetryData(telemetryData));
        }

        /// <inheritdoc/>
        public void OnHistory(TelemetryData.History telemetryData)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            telemetryData.SessionId = SessionId;
            telemetryData.CorrelationId = CorrelationId;

            _telemetryDispatcher.Post(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording CommandHistory");
#endif
        }

        /// <inheritdoc/>
        public void OnRequestPrediction(TelemetryData.RequestPrediction telemetryData)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            CorrelationId = Guid.NewGuid().ToString();

            telemetryData.SessionId = SessionId;
            telemetryData.CorrelationId = CorrelationId;

            _telemetryDispatcher.Post(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording RequestPrediction");
#endif
        }

        /// <inheritdoc/>
        public void OnSuggestionAccepted(TelemetryData.SuggestionAccepted telemetryData)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            telemetryData.SessionId = SessionId;
            telemetryData.CorrelationId = CorrelationId;

            _telemetryDispatcher.Post(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording AcceptSuggestion");
#endif
        }

        /// <inheritdoc/>
        public void OnGetSuggestion(TelemetryData.GetSuggestion telemetryData)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            telemetryData.SessionId = SessionId;
            telemetryData.CorrelationId = CorrelationId;

            _telemetryDispatcher.Post(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording GetSuggestion");
#endif
        }

        /// <summary>
        /// Check whether the data collection is opted in from user.
        /// </summary>
        /// <returns>true if allowed.</returns>
        private static bool IsDataCollectionAllowed()
        {
            if (AzurePSDataCollectionProfile.Instance.EnableAzureDataCollection == true)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Dispatches <see cref="TelemetryData.ITelemetryData"/> according to its implementation.
        /// </summary>
        private void DispatchTelemetryData(TelemetryData.ITelemetryData telemetryData)
        {
            switch (telemetryData)
            {
                case TelemetryData.History history:
                    SendTelemetry(history);
                    break;
                case TelemetryData.RequestPrediction requestPrediction:
                    SendTelemetry(requestPrediction);
                    break;
                case TelemetryData.GetSuggestion getSuggestion:
                    SendTelemetry(getSuggestion);
                    break;
                case TelemetryData.SuggestionAccepted suggestionAccepted:
                    SendTelemetry(suggestionAccepted);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Sends the telemetry with the command history.
        /// </summary>
        private void SendTelemetry(TelemetryData.History telemetryData)
        {
            var properties = CreateProperties(telemetryData);
            properties.Add("History", telemetryData.Command);

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/CommandHistory", properties);
        }

        /// <summary>
        /// Sends the telemetry with the commands for prediction.
        /// </summary>
        private void SendTelemetry(TelemetryData.RequestPrediction telemetryData)
        {
            _userAcceptedAndSuggestion.Clear();

            var properties = CreateProperties(telemetryData);
            properties.Add("Command", telemetryData.Commands ?? string.Empty);
            properties.Add("HttpRequestSent", telemetryData.HasSentHttpRequest.ToString(CultureInfo.InvariantCulture));
            properties.Add("Exception", telemetryData.Exception?.ToString() ?? string.Empty);

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/RequestPrediction", properties);
        }

        /// <summary>
        /// Sends the telemetry with the suggestion returned to the user.
        /// </summary>
        private void SendTelemetry(TelemetryData.GetSuggestion telemetryData)
        {
            var suggestions = telemetryData.Suggestion?.PredictiveSuggestions;
            var suggestionSource = telemetryData.Suggestion?.SuggestionSources;
            var sourceTexts = telemetryData.Suggestion?.SourceTexts;
            var maskedUserInput = CommandLineUtilities.MaskCommandLine(telemetryData.UserInput?.FindAll((ast) => ast is CommandAst, true).LastOrDefault() as CommandAst);

            if ((suggestions != null) && (sourceTexts != null))
            {
                for (int i = 0; i < suggestions.Count; ++i)
                {
                    _userAcceptedAndSuggestion[suggestions[i].SuggestionText] = sourceTexts[i];
                }
            }

            var properties = CreateProperties(telemetryData);
            properties.Add("UserInput", maskedUserInput ?? string.Empty);
            properties.Add("Suggestion", sourceTexts != null ? JsonConvert.SerializeObject(sourceTexts.Zip(suggestionSource).Select((s) => ValueTuple.Create(s.First, s.Second))) : string.Empty);
            properties.Add("IsCancelled", telemetryData.IsCancellationRequested.ToString(CultureInfo.InvariantCulture));
            properties.Add("Exception", telemetryData.Exception?.ToString() ?? string.Empty);

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/GetSuggestion", properties);
        }

        /// <summary>
        /// Sends the telemetry with the suggestion returned to the user.
        /// </summary>
        private void SendTelemetry(TelemetryData.SuggestionAccepted telemetryData)
        {
            if (!_userAcceptedAndSuggestion.TryGetValue(telemetryData.Suggestion, out var suggestion))
            {
                suggestion = "NoRecord";
            }

            var properties = CreateProperties(telemetryData);
            properties.Add("AcceptedSuggestion", suggestion);

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/AcceptSuggestion", properties);
        }

        /// <summary>
        /// Add the common properties to the telemetry event.
        /// </summary>
        private IDictionary<string, string> CreateProperties(TelemetryData.ITelemetryData telemetryData)
        {
            return new Dictionary<string, string>()
            {
                { "SessionId", telemetryData.SessionId },
                { "CorrelationId", telemetryData.CorrelationId },
                { "UserId", _azContext.UserId },
                { "HashMacAddress", _azContext.MacAddress },
                { "PowerShellVersion", _azContext.PowerShellVersion.ToString() },
                { "ModuleVersion", _azContext.ModuleVersion.ToString() },
                { "OS", _azContext.OSVersion },
            };
        }
    }
}
