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
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation.Language;
using System.Text.Json;
using System.Threading.Tasks.Dataflow;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry
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
        /// The action to handle the <see cref="ITelemetryData"/> in a thread pool.
        /// </summary>
        private readonly ActionBlock<ITelemetryData> _telemetryDispatcher;

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
            _telemetryDispatcher = new ActionBlock<ITelemetryData>(
                    (telemetryData) => DispatchTelemetryData(telemetryData));
        }

        /// <inheritdoc/>
        public void OnHistory(HistoryTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording CommandHistory");
#endif
        }

        /// <inheritdoc/>
        public void OnRequestPrediction(RequestPredictionTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording RequestPrediction");
#endif
        }

        /// <inheritdoc/>
        public void OnSuggestionAccepted(SuggestionAcceptedTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording AcceptSuggestion");
#endif
        }

        /// <inheritdoc/>
        public void OnGetSuggestion(GetSuggestionTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording GetSuggestion");
#endif
        }

        /// <inheritdoc/>
        public void OnLoadParameterMap(ParameterMapTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording LoadParameterMap");
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
        /// Construct a string from an exception and the string is sent to telemetry.
        /// The string should have minimum data that can help us to diagnose the exception
        /// but not too excessive that may have PII.
        /// </summary>
        /// <param name="exception">The exception to construct the string from.</param>
        /// <returns>A string to send to telemetry.</returns>
        private static string FormatException(Exception exception)
        {
            if (exception == null)
            {
                return string.Empty;
            }

            // The exception message may contain data such as file path if it is IO related exception.
            // It's this solution to throw the exception, the type and the stack trace only contain information related to the solution.
            return string.Format($"Type: {exception.GetType().ToString()}\nStack Trace: {exception.StackTrace?.ToString()}");
;        }

        private void PostTelemetryData(ITelemetryData telemetryData)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            telemetryData.SessionId = SessionId;
            telemetryData.CorrelationId = CorrelationId;

            _telemetryDispatcher.Post(telemetryData);
        }

        /// <summary>
        /// Dispatches <see cref="ITelemetryData"/> according to its implementation.
        /// </summary>
        private void DispatchTelemetryData(ITelemetryData telemetryData)
        {
            switch (telemetryData)
            {
                case HistoryTelemetryData history:
                    SendTelemetry(history);
                    break;
                case RequestPredictionTelemetryData requestPrediction:
                    SendTelemetry(requestPrediction);
                    break;
                case GetSuggestionTelemetryData getSuggestion:
                    SendTelemetry(getSuggestion);
                    break;
                case SuggestionAcceptedTelemetryData suggestionAccepted:
                    SendTelemetry(suggestionAccepted);
                    break;
                case ParameterMapTelemetryData parameterMap:
                    SendTelemetry(parameterMap);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Sends the telemetry with the command history.
        /// </summary>
        private void SendTelemetry(HistoryTelemetryData telemetryData)
        {
            var properties = CreateProperties(telemetryData);
            properties.Add("History", telemetryData.Command);

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/CommandHistory", properties);
        }

        /// <summary>
        /// Sends the telemetry with the commands for prediction.
        /// </summary>
        private void SendTelemetry(RequestPredictionTelemetryData telemetryData)
        {
            _userAcceptedAndSuggestion.Clear();

            var properties = CreateProperties(telemetryData);
            properties.Add("Command", telemetryData.Commands ?? string.Empty);
            properties.Add("HttpRequestSent", telemetryData.HasSentHttpRequest.ToString(CultureInfo.InvariantCulture));
            properties.Add("Exception", AzPredictorTelemetryClient.FormatException(telemetryData.Exception));

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/RequestPrediction", properties);
        }

        /// <summary>
        /// Sends the telemetry with the suggestion returned to the user.
        /// </summary>
        private void SendTelemetry(GetSuggestionTelemetryData telemetryData)
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
            properties.Add("Suggestion", sourceTexts != null ? JsonSerializer.Serialize(sourceTexts.Zip(suggestionSource).Select((s) => Tuple.Create(s.First, s.Second)), JsonUtilities.TelemetrySerializerOptions) : string.Empty);
            properties.Add("IsCancelled", telemetryData.IsCancellationRequested.ToString(CultureInfo.InvariantCulture));
            properties.Add("Exception", AzPredictorTelemetryClient.FormatException(telemetryData.Exception));

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/GetSuggestion", properties);
        }

        /// <summary>
        /// Sends the telemetry with the suggestion returned to the user.
        /// </summary>
        private void SendTelemetry(SuggestionAcceptedTelemetryData telemetryData)
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
        /// Sends the telemetry with the parameter map file loading information.
        /// </summary>
        private void SendTelemetry(ParameterMapTelemetryData telemetryData)
        {
            var properties = CreateProperties(telemetryData);
            properties.Add("Exception", AzPredictorTelemetryClient.FormatException(telemetryData.Exception));

            _telemetryClient.TrackEvent($"{AzPredictorTelemetryClient.TelemetryEventPrefix}/LoadParameterMap", properties);
        }

        /// <summary>
        /// Add the common properties to the telemetry event.
        /// </summary>
        private IDictionary<string, string> CreateProperties(ITelemetryData telemetryData)
        {
            return new Dictionary<string, string>()
            {
                { "SessionId", telemetryData.SessionId },
                { "CorrelationId", telemetryData.CorrelationId },
                { "UserId", _azContext.UserId },
                { "IsInternal", _azContext.IsInternal.ToString(CultureInfo.InvariantCulture) },
                { "SurveyId", (_azContext as AzContext)?.SurveyId },
                { "HashMacAddress", _azContext.MacAddress },
                { "PowerShellVersion", _azContext.PowerShellVersion.ToString() },
                { "ModuleVersion", _azContext.ModuleVersion.ToString() },
                { "OS", _azContext.OSVersion },
            };
        }
    }
}
