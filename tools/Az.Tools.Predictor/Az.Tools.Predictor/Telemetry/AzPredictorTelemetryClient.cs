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
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Profile;
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation.Language;
using System.Management.Automation.Subsystem.Prediction;
using System.Text.Json;
using System.Threading.Tasks.Dataflow;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry
{
    internal sealed class TelemetryDataCollection
    {
        public sealed class SuggestionSession
        {
            public uint SuggestionSessionId { get; set; }
            public Ast UserInput { get; set; }
            public CommandLineSuggestion FoundSuggestion { get; set; }
            public bool IsCancellationRequested { get; set; }
            public SuggestionDisplayMode DisplayMode { get; set; }
            public int DisplayedSuggestionCountOrIndex { get; set; }
            public string AcceptedSuggestion { get; set; }
        }

        public string CommandId { get; set; }

        public string RequestId { get; set; }

        public string SessionId { get; set; }

        public PredictionClient Client { get; init; }

        public bool HasSentHttpRequest { get; set; }

        public string CommandLine { get; set; }

        public bool IsCommandSuccess { get; set; }

        public IList<SuggstionSession> SuggestionSessions => new List<SuggestionSession>();

        public bool IsDataComplete { get; set; }
    }

    /// <summary>
    /// A telemetry client implementation to collect the telemetry data for AzPredictor.
    /// </summary>
    internal class AzPredictorTelemetryClient : ITelemetryClient
    {
        /// <inheritdoc/>
        public string RequestId { get; set; } = Guid.NewGuid().ToString();

        /// <inheritdoc/>
        public string SessionId => TelemetryUtilities.SessionId;

        /// <summary>
        /// The client that sends the telemetry to the server.
        /// </summary>
        private readonly TelemetryClient _telemetryClient;

        private readonly IAzContext _azContext;

        /// <inheritdoc/>
        public string CommandId { get; private set; } = Guid.NewGuid().ToString();

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
        /// The cached telemetry data collection sent when we process the command history data.
        /// </summary>
        /// <remarks>
        /// We only access it in the thread pool which is to handle the data at the target side of the data flow.
        /// We only handle one item at a time so there is no race condition.
        /// </remarks>
        private TelemetryDataCollection _cachedTelemetryDataCollection = new TelemetryDataCollection();

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictorTelemetryClient"/>.
        /// </summary>
        /// <param name="azContext">The Az context which this module runs with.</param>
        public AzPredictorTelemetryClient(IAzContext azContext)
        {
            _telemetryClient = GetApplicationInsightTelemetryClient();
            _azContext = azContext;
            _telemetryDispatcher = new ActionBlock<ITelemetryData>(
                    (telemetryData) => DispatchTelemetryData(telemetryData));
        }

        /// <inheritdoc/>
        public virtual void OnHistory(HistoryTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

            CommandId = Guid.NewGuid().ToString();

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording CommandHistory");
#endif
        }

        /// <inheritdoc/>
        public virtual void OnRequestPrediction(RequestPredictionTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording RequestPrediction");
#endif
        }

        /// <inheritdoc/>
        public virtual void OnGetSuggestion(GetSuggestionTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording GetSuggestion");
#endif
        }
        /// <inheritdoc/>
        public virtual void OnSuggestionDisplayed(SuggestionDisplayedTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording DisplaySuggestion");
#endif
        }

        /// <inheritdoc/>
        public virtual void OnSuggestionAccepted(SuggestionAcceptedTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording AcceptSuggestion");
#endif
        }

        /// <inheritdoc/>
        public virtual void OnLoadParameterMap(ParameterMapTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording LoadParameterMap");
#endif
        }

        /// <inheritdoc/>
        public void OnParseCommandLineFailure(CommandLineParsingTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording CommandLineParsing");
#endif
        }

        /// <summary>
        /// Gets the client that can send telemetry via Application Insight.
        /// </summary>
        protected virtual TelemetryClient GetApplicationInsightTelemetryClient() => TelemetryUtilities.CreateApplicationInsightTelemetryClient();

        /// <summary>
        /// Sends the telemetry event via Application Insight.
        /// </summary>
        protected virtual void SendTelemetry(string eventName, IDictionary<string, string> properties)
        {
            _telemetryClient.TrackEvent(eventName, properties);
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

            switch (exception)
            {
                case CommandLineException:
                case ServiceRequestException:
                    // This is the exception type created by us. We should not contain private data in the message.
                    return $"Message: {exception.Message}\nStack Trace: {exception.StackTrace?.ToString()}";
                default:
                    // The exception message may contain data such as file path if it is IO related exception.
                    // It's this solution to throw the exception, the type and the stack trace only contain information related to the solution.
                    return $"Type: {exception.GetType().ToString()}\nStack Trace: {exception.StackTrace?.ToString()}";
            }
        }

        private void PostTelemetryData(ITelemetryData telemetryData)
        {
            if (!IsDataCollectionAllowed())
            {
                return;
            }

            telemetryData.SessionId = SessionId;
            telemetryData.RequestId = RequestId;
            telemetryData.CommandId = CommandId;

            _telemetryDispatcher.Post(telemetryData);
        }

        /// <summary>
        /// Dispatches <see cref="ITelemetryData"/> according to its implementation.
        /// </summary>
        private void DispatchTelemetryData(ITelemetryData telemetryData)
        {
            // We'll aggregate all the telemetry data into one event. We include the data since last command history (not
            // inclusive) to this command history (inclusive).
            // If there is any exceptions, we'll record them separately in a different event.

            switch (telemetryData)
            {
                case HistoryTelemetryData history:
                    ProcessTelemetryData(history);
                    break;
                case RequestPredictionTelemetryData requestPrediction:
                    ProcessTelemetryData(requestPrediction);
                    break;
                case GetSuggestionTelemetryData getSuggestion:
                    ProcessTelemetryData(getSuggestion);
                    break;
                case SuggestionDisplayedTelemetryData suggestionDisplayed:
                    ProcessTelemetryData(suggestionDisplayed);
                    break;
                case SuggestionAcceptedTelemetryData suggestionAccepted:
                    ProcessTelemetryData(suggestionAccepted);
                    break;
                case ParameterMapTelemetryData parameterMap:
                    ProcessTelemetryData(parameterMap);
                    break;
                case CommandLineParsingTelemetryData commandLineParsing:
                    ProcessTelemetryData(commandLineParsing);
                    break;
            }
        }

        /// <summary>
        /// Processes the telemetry with the command history.
        /// </summary>
        private void SendTelemetry(HistoryTelemetryData telemetryData)
        {
            if (_cachedTelemetryDataCollection == null)
            {
                _cachedTelemetryDataCollection = new TelemetryDataCollection()
                {
                    IsDataComplete = false;
                }
            }
            else
            {
                _cachedTelemetryDataCollection.IsDataComplete = true;
            }

            _cachedTelemetryDataCollection.CommandLine = telemetryData.Command;
            .Add("History", telemetryData.Command);
            properties.Add("Success", telemetryData.Success.ToString(CultureInfo.InvariantCulture));

            SendTelemetry($"{TelemetryUtilities.TelemetryEventPrefix}/CommandHistory", properties);
        }

        /// <summary>
        /// Processes the telemetry with the commands for prediction.
        /// </summary>
        private void ProcessTelemetryData(RequestPredictionTelemetryData telemetryData)
        {
            _userAcceptedAndSuggestion.Clear();

            if (_cachedTelemetryDataCollection != null)
            {
                SendTelmetry(_cachedTelemetryDataCollection);
            }

            _cachedTelemetryDataCollection = new TelemetryDataCollection()
            {
                RequestId = ((ITelemetryData)telemetryData).RequestId,
                HasSentHttpRequest = telemetryData.HasSentHttpRequest,
            };

            if (telemetryData.Exception != null)
            {
                SendException("An error occurred when requesting predictions.", telemetryData.Exception);
            }
        }

        /// <summary>
        /// Sends the telemetry with the suggestion returned to the user.
        /// </summary>
        private void ProcessTelemetryData(GetSuggestionTelemetryData telemetryData)
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

            var properties = CreateProperties(telemetryData, telemetryData.Client);
            properties.Add("SuggestionSessionId", telemetryData != null ? telemetryData.SuggestionSessionId.ToString(CultureInfo.InvariantCulture) : string.Empty);
            properties.Add("UserInput", maskedUserInput ?? string.Empty);
            properties.Add("Suggestion", sourceTexts != null ? JsonSerializer.Serialize(sourceTexts.Zip(suggestionSource).Select((s) => Tuple.Create(s.First, s.Second)), JsonUtilities.TelemetrySerializerOptions) : string.Empty);
            properties.Add("IsCancelled", telemetryData.IsCancellationRequested.ToString(CultureInfo.InvariantCulture));
            properties.Add("Exception", AzPredictorTelemetryClient.FormatException(telemetryData.Exception));

            if (telemetryData.Exception != null)
            {
                SendException("An error occurred when getting suggestions.", telemetryData.Exception);
            }
        }

        /// <summary>
        /// Sends the telemetry about what suggestions are displayed to the user.
        /// </summary>
        private void SendTelemetry(SuggestionDisplayedTelemetryData telemetryData)
        {
            var properties = CreateProperties(telemetryData, telemetryData.Client);
            properties.Add("SuggestionSessionId", telemetryData.SuggestionSessionId.ToString(CultureInfo.InvariantCulture));
            properties.Add("SuggestionDisplayMode", telemetryData.DisplayMode.ToString());

            switch (telemetryData.DisplayMode)
            {
                case SuggestionDisplayMode.InlineView:
                    properties.Add("SuggestionIndex", telemetryData.SuggestionCountOrIndex.ToString(CultureInfo.InvariantCulture));
                    break;
                case SuggestionDisplayMode.ListView:
                    properties.Add("SuggestionCount", telemetryData.SuggestionCountOrIndex.ToString(CultureInfo.InvariantCulture));
                    break;
                default:
                    break;
            };

            SendTelemetry($"{TelemetryUtilities.TelemetryEventPrefix}/DisplaySuggestion", properties);
        }

        /// <summary>
        /// Sends the telemetry with the suggestion returned to the user.
        /// </summary>
        private void SendTelemetry(SuggestionAcceptedTelemetryData telemetryData)
        {
            if (!_userAcceptedAndSuggestion.TryGetValue(telemetryData.Suggestion, out var suggestion))
            {
                suggestion = telemetryData.Suggestion;
            }

            var properties = CreateProperties(telemetryData, telemetryData.Client);
            properties.Add("AcceptedSuggestion", suggestion);
            properties.Add("SuggestionSessionId", telemetryData.SuggestionSessionId.ToString(CultureInfo.InvariantCulture));

            SendTelemetry($"{TelemetryUtilities.TelemetryEventPrefix}/AcceptSuggestion", properties);
        }

        private void ProcessTelemetryData(ParameterMapTelemetryData telemetryData)
        {
            if (parameterMap.Exception != null)
            {
                SendException("An error occurred when loading parameter map.", telemetryData.Exception);
            }
        }

        /// <summary>
        /// Process the telemetry with the command line parsing information.
        /// </summary>
        private void SendTelemetry(CommandLineParsingTelemetryData telemetryData)
        {
            if (commandLineParsing.Exception != null)
            {
                var properties = new Dictionary<string,string>()
                {
                    { "Command", telemetryData.Command },
                };

                SendException("An error occurred when parsing command line.", telemetryData.Exception, properties);
            }
        }

        /// <summary>
        /// Add the common properties to the telemetry event.
        /// </summary>
        private IDictionary<string, string> CreateProperties(ITelemetryData telemetryData, PredictionClient client)
        {
            var properties = TelemetryUtilities.CreateCommonProperties(this._azContext);
            properties.Add("RequestId", telemetryData.RequestId);
            properties.Add("CommandId", telemetryData.CommandId);

            if (client != null)
            {
                properties.Add("ClientId", client.Name);
                properties.Add("ClientType", client.Kind.ToString());
            }

            return properties;
        }

        /// <summary>
        /// Sends the exception event when there is an exception is thrown.
        /// </summary>
        private void SendException(string message, Exception exception, IDictionary<string, string> extraProperties)
        {
            var properties = CreateProperties(telemetryData, telemetryData.Client);
            properties.Add("Message", message);
            properties.Add("Exception", AzPredictorTelemetryClient.FormatException(exception));

            if (extraProperties != null)
            {
                foreach (var p in extraProperties)
                {
                    properties.Add(p.Key, p.Value);
                }
            }

            SendTelemetry($"{TelemetryUtilities.TelemetryEventPrefix}/Exception", properties);
        }
    }
}
