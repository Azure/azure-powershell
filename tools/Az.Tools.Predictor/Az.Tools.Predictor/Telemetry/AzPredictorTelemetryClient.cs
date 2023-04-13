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
    /// <summary>
    /// A telemetry client implementation to collect the data at the interested places, aggregate them and send it to
    /// Application Insight.
    /// </summary>
    internal class AzPredictorTelemetryClient : ITelemetryClient, IDisposable
    {
        // The maximum size we can have in the telemetry property
        // Application Insight has a limit of 8192 (https://github.com/MicrosoftDocs/azure-docs/blob/master/includes/application-insights-limits.md).
        // Substract (arbitrary but hopefully enough) 100 as the buffer of other properties in the event.
        internal const int MaxAppInsightPropertyValueSize = 8192;
        internal const int MaxPropertyValueSizeWithBuffer = MaxAppInsightPropertyValueSize - 100;

        /// <inheritdoc/>
        public string RequestId { get; set; } = Guid.NewGuid().ToString();

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
        private readonly IDictionary<string, string> _userAcceptedAndSuggestion = new Dictionary<string, string>();

        /// <summary>
        /// The cached aggregated telemetry data sent when we process the command history data.
        /// </summary>
        /// <remarks>
        /// We only access it in the thread pool which is to handle the data at the target side of the data flow.
        /// We only handle one item at a time so there is no race condition.
        /// </remarks>
        protected AggregatedTelemetryData CachedAggregatedTelemetryData { get; private set; } = new();

        private bool _isDisposed;

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

        /// <inheritdoc />
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;
            Dispose(disposing: true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _telemetryDispatcher.Complete();
            }
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

        /// <inheritdoc/>
        public virtual void OnGeneralException(GeneralExceptionTelemetryData telemetryData)
        {
            PostTelemetryData(telemetryData);

#if TELEMETRY_TRACE && DEBUG
            System.Diagnostics.Trace.WriteLine("Recording GeneralException");
#endif
        }

        /// <summary>
        /// Gets the client that can send telemetry via Application Insight.
        /// </summary>
        protected virtual TelemetryClient GetApplicationInsightTelemetryClient() => TelemetryUtilities.CreateApplicationInsightTelemetryClient();

        /// <summary>
        /// Dispatches <see cref="ITelemetryData"/> according to its implementation.
        /// </summary>
        protected virtual void DispatchTelemetryData(ITelemetryData telemetryData)
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
                case GeneralExceptionTelemetryData exception:
                    ProcessTelemetryData(exception);
                    break;
            }
        }

        /// <summary>
        /// Sends the aggregated telemetry data.
        /// </summary>
        protected void SendAggregatedTelemetryData()
        {
            var aggregatedData = CachedAggregatedTelemetryData;
            CachedAggregatedTelemetryData = new AggregatedTelemetryData();

            var properties = CreateProperties(aggregatedData);

            // Add the request prediction data.
            if (aggregatedData.HasSentHttpRequest.HasValue)
            {
                properties.Add(RequestPredictionTelemetryData.PropertyNameHttpRequestSent, aggregatedData.HasSentHttpRequest.Value.ToString(CultureInfo.InvariantCulture));
            }

            var suggestions = new List<Dictionary<string, object>>();
            for (var i = 0; i < aggregatedData.SuggestionSessions.Count; ++i)
            {
                var suggestionSession = aggregatedData.SuggestionSessions[i];
                var toAddSuggestion = new Dictionary<string, object>();

                // Add the get suggestion data.
                var foundSuggestions = suggestionSession.FoundSuggestion;
                if (foundSuggestions != null)
                {
                    var suggestionSource = foundSuggestions.SuggestionSources;
                    var sourceTexts = foundSuggestions.SourceTexts;

#if TELEMETRY_PLACEHOLDER
                    toAddSuggestion.Add(GetSuggestionTelemetryData.PropertyNameFound, "PLACEHOLDER");
#else
                    toAddSuggestion.Add(GetSuggestionTelemetryData.PropertyNameFound, sourceTexts?.Zip(suggestionSource)?.Select((s) => new object[] { s.First, (int)s.Second }));
#endif
                    toAddSuggestion.Add(GetSuggestionTelemetryData.PropertyNameIsCancelled, suggestionSession.IsCancellationRequested.ToString(CultureInfo.InvariantCulture));
                }

                if (suggestionSession.UserInput != null)
                {
                    toAddSuggestion.Add(GetSuggestionTelemetryData.PropertyNameUserInput, suggestionSession.UserInput);
                }

                // Add the display suggestion data
                if (suggestionSession.DisplayedSuggestionCountOrIndex.HasValue)
                {
                    toAddSuggestion.Add(SuggestionDisplayedTelemetryData.PropertyNameDisplayed, new int[]
                    {
                        (int)suggestionSession.DisplayMode.Value,
                        suggestionSession.DisplayedSuggestionCountOrIndex.Value
                    });
                }

                // Add accept suggestion data
                if (suggestionSession.AcceptedSuggestion != null)
                {
                    toAddSuggestion.Add(SuggestionAcceptedTelemetryData.PropertyNameAccepted, suggestionSession.AcceptedSuggestion);
                }

                if (!suggestionSession.IsSuggestionComplete)
                {
                    // The aggregated data is divided into different telemetry events. SuggestionSessionId is used to
                    // associate the related suggestion related data in different events.
                    toAddSuggestion.Add(GetSuggestionTelemetryData.PropertyNameSuggestionSessionId, suggestionSession.SuggestionSessionId.Value);
                }

                suggestions.Add(toAddSuggestion);
            }

            if (suggestions.Count > 0)
            {
                properties.Add(GetSuggestionTelemetryData.PropertyNamePrediction, JsonSerializer.Serialize(suggestions, JsonUtilities.TelemetrySerializerOptions));
            }

            if (aggregatedData.CommandLine != null)
            {
                // Add the command history data.
                properties.Add(HistoryTelemetryData.PropertyNameSuccess, aggregatedData.IsCommandSuccess.ToString(CultureInfo.InvariantCulture));
                properties.Add(HistoryTelemetryData.PropertyNameCommand, aggregatedData.CommandLine);
            }

            SendTelemetry($"{TelemetryUtilities.TelemetryEventPrefix}/Aggregation", properties);
        }

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

            telemetryData.RequestId = RequestId;
            telemetryData.CommandId = CommandId;

            _telemetryDispatcher.Post(telemetryData);
        }

        /// <summary>
        /// Processes the telemetry with the command history.
        /// </summary>
        private void ProcessTelemetryData(HistoryTelemetryData telemetryData)
        {
            if (CachedAggregatedTelemetryData == null)
            {
                CachedAggregatedTelemetryData = new AggregatedTelemetryData();
            }

            if (CachedAggregatedTelemetryData.EstimateSuggestionSessionSize >= AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer)
            {
                var newSuggestionSession = SendAggregateTelemetryDataDuringSuggestionCycle(telemetryData, CachedAggregatedTelemetryData.SuggestionSessions.LastOrDefault().SuggestionSessionId);
                newSuggestionSession.IsSuggestionComplete = false; // This can correlate to the suggestions in the previous events.
            }

            CachedAggregatedTelemetryData.UpdateFromTelemetryData(telemetryData);
            CachedAggregatedTelemetryData.CommandLine = telemetryData.Command;
            CachedAggregatedTelemetryData.IsCommandSuccess = telemetryData.Success;

            SendAggregatedTelemetryData();
        }

        /// <summary>
        /// Processes the telemetry with the commands for prediction.
        /// </summary>
        private void ProcessTelemetryData(RequestPredictionTelemetryData telemetryData)
        {
            // We may have two consecutive requests.
            if (CachedAggregatedTelemetryData != null && !string.IsNullOrWhiteSpace(CachedAggregatedTelemetryData.RequestId))
            {
                SendAggregatedTelemetryData();
            }

            if (CachedAggregatedTelemetryData == null)
            {
                CachedAggregatedTelemetryData = new AggregatedTelemetryData();
            }

            CachedAggregatedTelemetryData.UpdateFromTelemetryData(telemetryData);
            CachedAggregatedTelemetryData.HasSentHttpRequest = telemetryData.HasSentHttpRequest;

            if (telemetryData.Exception != null)
            {
                SendException("An error occurred when requesting predictions.", telemetryData, telemetryData.Exception);
            }
        }

        /// <summary>
        /// Sends the telemetry with the suggestion returned to the user.
        /// </summary>
        private void ProcessTelemetryData(GetSuggestionTelemetryData telemetryData)
        {
            var suggestions = telemetryData.Suggestion?.PredictiveSuggestions;
            var sourceTexts = telemetryData.Suggestion?.SourceTexts;

            if ((suggestions != null) && (sourceTexts != null))
            {
                for (int i = 0; i < suggestions.Count; ++i)
                {
                    _userAcceptedAndSuggestion[suggestions[i].SuggestionText] = sourceTexts[i];
                }
            }

            var maskedUserInput = telemetryData.IsSupported ?
                CommandLineUtilities.MaskCommandLine(CommandLineUtilities.GetCommandAst(telemetryData.UserInput)) :
                AzPredictorConstants.CommandPlaceholder;

            var suggestionSession = new SuggestionSession()
            {
                SuggestionSessionId = telemetryData.SuggestionSessionId,
                FoundSuggestion = telemetryData.Suggestion,
                UserInput = maskedUserInput,
                IsCancellationRequested = telemetryData.IsCancellationRequested,
            };

            if (CachedAggregatedTelemetryData.EstimateSuggestionSessionSize + suggestionSession.EstimateTelemetrySize >= AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer)
            {
                // GetSuggestion starts a new suggestion session cycle. So let's assume the new suggestion session will be
                // complete. We will modify it later if it is not.
                var newSuggestionSession = SendAggregateTelemetryDataDuringSuggestionCycle(telemetryData, telemetryData.SuggestionSessionId);
                newSuggestionSession.FoundSuggestion = suggestionSession.FoundSuggestion;
                newSuggestionSession.UserInput = suggestionSession.UserInput;
                newSuggestionSession.IsCancellationRequested = suggestionSession.IsCancellationRequested;
            }
            else
            {
                CachedAggregatedTelemetryData.SuggestionSessions.Add(suggestionSession);
            }

            if (telemetryData.Exception != null)
            {
                SendException("An error occurred when getting suggestions.",
                        telemetryData,
                        telemetryData.Exception,
                        new Dictionary<string, string>()
                        {
                            { GetSuggestionTelemetryData.PropertyNameUserInput, maskedUserInput },
                        });
            }
        }

        /// <summary>
        /// Processes the telemetry about what suggestions are displayed to the user.
        /// </summary>
        private void ProcessTelemetryData(SuggestionDisplayedTelemetryData telemetryData)
        {
            var suggestionSession = CachedAggregatedTelemetryData.SuggestionSessions.LastOrDefault((s) => s.SuggestionSessionId.Value == telemetryData.SuggestionSessionId);

            if (suggestionSession == null)
            {
                suggestionSession = new SuggestionSession()
                {
                    SuggestionSessionId = telemetryData.SuggestionSessionId,
                    IsSuggestionComplete = false,
                };

                CachedAggregatedTelemetryData.SuggestionSessions.Add(suggestionSession);
            }

            // Usually GetSuggestion occurs before SuggestionDisplayTelemetryData. In case the property size becomes too large after GetSuggestion, we send it now.
            if (CachedAggregatedTelemetryData.EstimateSuggestionSessionSize >= AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer)
            {
                suggestionSession = SendAggregateTelemetryDataDuringSuggestionCycle(telemetryData, telemetryData.SuggestionSessionId);
                suggestionSession.IsSuggestionComplete = false; // This continue from the previous suggestion session. So mark it as incomplete.
            }

            suggestionSession.DisplayMode = telemetryData.DisplayMode;
            suggestionSession.DisplayedSuggestionCountOrIndex = telemetryData.SuggestionCountOrIndex;
        }

        /// <summary>
        /// Processes the telemetry with the suggestion returned to the user.
        /// </summary>
        private void ProcessTelemetryData(SuggestionAcceptedTelemetryData telemetryData)
        {
            if (!_userAcceptedAndSuggestion.TryGetValue(telemetryData.Suggestion, out var suggestion))
            {
                suggestion = CommandLineUtilities.MaskCommandLine(telemetryData.Suggestion);
            }
            _userAcceptedAndSuggestion.Clear();

            var suggestionSession = CachedAggregatedTelemetryData.SuggestionSessions.LastOrDefault(s => s.SuggestionSessionId.Value == telemetryData.SuggestionSessionId);

            if (suggestionSession == null)
            {
                suggestionSession = new SuggestionSession()
                {
                    SuggestionSessionId = telemetryData.SuggestionSessionId,
                    IsSuggestionComplete = false,
                };

                CachedAggregatedTelemetryData.SuggestionSessions.Add(suggestionSession);
            }

            if (CachedAggregatedTelemetryData.EstimateSuggestionSessionSize >= AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer)
            {
                suggestionSession = SendAggregateTelemetryDataDuringSuggestionCycle(telemetryData, telemetryData.SuggestionSessionId);
                suggestionSession.IsSuggestionComplete = false; // This continue from the previous suggestionsession. So mark it as incomplete.
            }

            suggestionSession.AcceptedSuggestion = suggestion;
        }

        /// <summary>
        /// Processes the telemetry when the parmaeter map is loaded.
        /// </summary>
        private void ProcessTelemetryData(ParameterMapTelemetryData telemetryData)
        {
            if (telemetryData.Exception != null)
            {
                SendException("An error occurred when loading parameter map.", telemetryData, telemetryData.Exception);
            }
        }

        /// <summary>
        /// Processes the telemetry with the command line parsing information.
        /// </summary>
        private void ProcessTelemetryData(CommandLineParsingTelemetryData telemetryData)
        {
            if (telemetryData.Exception != null)
            {
                var properties = new Dictionary<string,string>()
                {
                    { "Command", telemetryData.Command },
                };

                SendException("An error occurred when parsing command line.", telemetryData, telemetryData.Exception, properties);
            }
        }

        /// <summary>
        /// Processes the telemetry with the exception.
        /// </summary>
        private void ProcessTelemetryData(GeneralExceptionTelemetryData telemetryData)
        {
            if (telemetryData.Exception != null)
            {
                SendException("An error occurred that wasn't caught in any scenarios.", telemetryData, telemetryData.Exception);
            }
        }

        /// <summary>
        /// Add the common properties to the telemetry event.
        /// </summary>
        private IDictionary<string, string> CreateProperties(ITelemetryData telemetryData)
        {
            var properties = TelemetryUtilities.CreateCommonProperties(this._azContext);
            properties.Add("RequestId", telemetryData.RequestId);
            properties.Add("CommandId", telemetryData.CommandId);

            var client = telemetryData.Client;
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
        private void SendException(string message, ITelemetryData telemetryData, Exception exception, IDictionary<string, string> extraProperties = null)
        {
            var properties = CreateProperties(telemetryData);
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

        /// <summary>
        /// Sends the cached aggregated telemetry data when we're aggregating suggestion cycle related data.
        /// </summary>
        private SuggestionSession SendAggregateTelemetryDataDuringSuggestionCycle(ITelemetryData telemetryData, uint? suggestionSessionId)
        {
            var suggestionSession = CachedAggregatedTelemetryData.SuggestionSessions.LastOrDefault(s => s.SuggestionSessionId.Value == suggestionSessionId);
            if (suggestionSession != null)
            {
                suggestionSession.IsSuggestionComplete = false;
            }

            CachedAggregatedTelemetryData.UpdateFromTelemetryData(telemetryData);
            SendAggregatedTelemetryData();

            var newSuggestionSession = new SuggestionSession()
            {
                SuggestionSessionId = suggestionSessionId,
                // Don't need to mark IsSuggestionComplete. If method is called when we process GetSuggestionTelemetryEvent,
                // all the previous suggestion session should be complete and this starts a new suggestion session.
            };
            CachedAggregatedTelemetryData.SuggestionSessions.Add(newSuggestionSession);
            return newSuggestionSession;
        }
    }
}
