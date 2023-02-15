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
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test.Mocks
{
    sealed class MockAzPredictorTelemetryClient : AzPredictorTelemetryClient
    {
        public record TelemetryRecord(string EventName, IDictionary<string, string> Properties);

        public HistoryTelemetryData HistoryData { get; internal set; }
        public RequestPredictionTelemetryData RequestPredictionData { get; internal set; }
        public GetSuggestionTelemetryData GetSuggestionData { get; internal set; }
        public SuggestionDisplayedTelemetryData SuggestionDisplayedData { get; internal set; }
        public SuggestionAcceptedTelemetryData SuggestionAcceptedData { get; internal set; }
        public ParameterMapTelemetryData ParameterMapData { get; internal set; }
        public GeneralExceptionTelemetryData ExceptionData { get; internal set; }
        public IList<TelemetryRecord> RecordedTelemetry { get; internal set; } = new List<TelemetryRecord>();
        public IList<ITelemetryData> DispatchedTelemetry { get; internal set; } = new List<ITelemetryData>();
        public AggregatedTelemetryData RecordedAggregatedData { get; private set; }
        public bool FlushAtDispatch { get; set; }

        private int _expctedTelemetryDispatchCount = 1;
        public int ExceptedTelemetryDispatchCount
        {
            get
            {
                return _expctedTelemetryDispatchCount;
            }
            set
            {
                RecordedTelemetry.Clear();
                DispatchedTelemetry.Clear();
                _expctedTelemetryDispatchCount = value;
            }
        }

        public TaskCompletionSource HistoryTaskCompletionSource { get; private set; }
        public TaskCompletionSource RequestPredictionTaskCompletionSource { get; private set; }
        public TaskCompletionSource DispatchTelemetryTaskCompletionSource { get; private set; }

        public MockAzPredictorTelemetryClient() : base(new MockAzContext())
        {
        }

        /// <inheritdoc/>
        public override void OnHistory(HistoryTelemetryData telemetryData)
        {
            base.OnHistory(telemetryData);
            HistoryData = telemetryData;
            HistoryTaskCompletionSource?.TrySetResult();
        }

        /// <inheritdoc/>
        public override void OnRequestPrediction(RequestPredictionTelemetryData telemetryData)
        {
            base.OnRequestPrediction(telemetryData);
            RequestPredictionData = telemetryData;
            RequestPredictionTaskCompletionSource?.TrySetResult();
        }

        /// <inheritdoc/>
        public override void OnGetSuggestion(GetSuggestionTelemetryData telemetryData)
        {
            base.OnGetSuggestion(telemetryData);
            GetSuggestionData = telemetryData;
        }

        /// <inheritdoc/>
        public override void OnSuggestionDisplayed(SuggestionDisplayedTelemetryData telemetryData)
        {
            base.OnSuggestionDisplayed(telemetryData);
            SuggestionDisplayedData = telemetryData;
        }

        /// <inheritdoc/>
        public override void OnSuggestionAccepted(SuggestionAcceptedTelemetryData telemetryData)
        {
            base.OnSuggestionAccepted(telemetryData);
            SuggestionAcceptedData = telemetryData;
        }

        /// <inheritdoc/>
        public override void OnLoadParameterMap(ParameterMapTelemetryData telemetryData)
        {
            base.OnLoadParameterMap(telemetryData);
            ParameterMapData = telemetryData;
        }

        /// <inheritdoc/>
        public override void OnGeneralException(GeneralExceptionTelemetryData telemetryData)
        {
            base.OnGeneralException(telemetryData);
            ExceptionData = telemetryData;
        }

        public void FlushTelemetry() => SendAggregatedTelemetryData();

        public void ResetWaitingTasks()
        {
            HistoryTaskCompletionSource = new TaskCompletionSource();
            RequestPredictionTaskCompletionSource  = new TaskCompletionSource();
            DispatchTelemetryTaskCompletionSource = new TaskCompletionSource();
            HistoryData = default;
            RequestPredictionData = default;
        }

        protected override TelemetryClient GetApplicationInsightTelemetryClient()
        {
            return null;
        }

        protected override void DispatchTelemetryData(ITelemetryData telemetryData)
        {
            base.DispatchTelemetryData(telemetryData);
            DispatchedTelemetry.Add(telemetryData);

            if (DispatchedTelemetry.Count == ExceptedTelemetryDispatchCount)
            {
                RecordedAggregatedData = CachedAggregatedTelemetryData;

                if (FlushAtDispatch && base.CachedAggregatedTelemetryData.EstimateSuggestionSessionSize > 0)
                {
                    CachedAggregatedTelemetryData.UpdateFromTelemetryData(telemetryData);
                    SendAggregatedTelemetryData();
                }

                DispatchTelemetryTaskCompletionSource?.TrySetResult();
            }
        }

        protected override void SendTelemetry(string eventName, IDictionary<string, string> properties)
        {
            RecordedTelemetry.Add(new TelemetryRecord(eventName, properties));
        }
    }
}
