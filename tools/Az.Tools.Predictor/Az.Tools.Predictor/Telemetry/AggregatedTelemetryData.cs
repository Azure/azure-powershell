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

using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation.Subsystem.Prediction;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry
{
    internal sealed class SuggestionSession
    {
        private const int _SeparatorSize = 1;
        private const int _QuoteSize = 2; // The biginning and ending quote.
        private const int _BracketSize = 2;
        private const int _OneDigitSize = 1; // The number we have in the telementry data is only one digit.

        private bool _isUnitTest;
        private int _estimateTelemetrySize;
        public int EstimateTelemetrySize
        {
            get
            {
                if (IsSuggestionComplete || _isUnitTest)
                {
                    return _estimateTelemetrySize;
                }

                return _estimateTelemetrySize + SuggestionSession.GetKeySize(GetSuggestionTelemetryData.PropertyNameSuggestionSessionId.Length) + SuggestionSessionId.Value.ToString(CultureInfo.InvariantCulture).Length;
            }
            // This is internal to allow access from unit test.
            internal set
            {
                _estimateTelemetrySize = value;
                _isUnitTest = true;
            }
        }

        public uint? SuggestionSessionId { get; set; }

        private string _userInput;
        public string UserInput
        {
            get { return _userInput; }
            set
            {
                int keySize = SuggestionSession.GetKeySize(GetSuggestionTelemetryData.PropertyNameUserInput.Length);

                if (_userInput is not null)
                {
                    _estimateTelemetrySize -= SuggestionSession.GetStringSize(_userInput.Length);
                }

                if ((_userInput is null) && (value is not null))
                {
                    _estimateTelemetrySize += keySize;
                }
                if ((_userInput is not null) && (value is null))
                {
                    _estimateTelemetrySize -= keySize;
                }

                _userInput = value;

                _estimateTelemetrySize += SuggestionSession.GetStringSize(_userInput?.Length ?? 0);
            }
        }

        private CommandLineSuggestion _foundSuggestion;
        public CommandLineSuggestion FoundSuggestion
        {
            get { return _foundSuggestion; }
            set
            {
                int keySize = SuggestionSession.GetKeySize(GetSuggestionTelemetryData.PropertyNameFound.Length);
                if (_foundSuggestion is not null)
                {
                    _estimateTelemetrySize -= GetCommandLineSuggestionSize(_foundSuggestion);
                }

                if ((_foundSuggestion is null) && (value is not null))
                {
                    _estimateTelemetrySize += keySize;
                }
                else if ((_foundSuggestion is not null) && (value is null))
                {
                    _estimateTelemetrySize -= keySize;
                }

                _foundSuggestion = value;

                _estimateTelemetrySize += GetCommandLineSuggestionSize(_foundSuggestion);

                static int GetCommandLineSuggestionSize(CommandLineSuggestion suggestion)
                {
                    int suggestionSize = 0;

                    if (suggestion is not null)
                    {
                        for (var i = 0; i < suggestion.Count; ++i)
                        {
                            var elementSize = SuggestionSession.GetStringSize(suggestion.SourceTexts[i].Length);
                            // The SuggestionSource is an enum and we record it as a number.
                            elementSize += SuggestionSession._OneDigitSize;

                            // Each suggestion will be written like "["Get-AzSubscription", 3].
                            suggestionSize += SuggestionSession.GetArraySize(elementSize, elementCount: 2);
                        }
                    }

                    // All the suggestions will be written like:
                    // ["Get-AzSubscription",3],["Get-AzResourceGroup",3]
                    var result = SuggestionSession.GetArraySize(suggestionSize, suggestion?.Count ?? 0);
                    return result;
                }
            }
        }

        private bool? _isCancellationRequested;
        public bool IsCancellationRequested
        {
            get { return _isCancellationRequested.Value; }
            set
            {
                int keySize = SuggestionSession.GetKeySize(GetSuggestionTelemetryData.PropertyNameIsCancelled.Length);
                if (_isCancellationRequested.HasValue)
                {
                    _estimateTelemetrySize -= _isCancellationRequested.Value.ToString(CultureInfo.InvariantCulture).Length;
                }

                if (!_isCancellationRequested.HasValue)
                {
                    _estimateTelemetrySize += keySize;
                }

                _isCancellationRequested = value;

                if (_isCancellationRequested.HasValue)
                {
                    _estimateTelemetrySize += _isCancellationRequested.Value.ToString(CultureInfo.InvariantCulture).Length;
                }
            }
        }

        // This will be written with DisplayedSuggestionCountOrIndex, so calculate the telemetry size in that property.
        public SuggestionDisplayMode? DisplayMode { get; set; }

        private int? _displayedSuggestionCountOrIndex;
        public int? DisplayedSuggestionCountOrIndex
        {
            get { return _displayedSuggestionCountOrIndex; }
            set
            {
                // Together with DisplayMode, the telemetry data written is {"Displayed":[1,7]}

                int keySize = SuggestionSession.GetKeySize(SuggestionDisplayedTelemetryData.PropertyNameDisplayed.Length);
                int valueSize = SuggestionSession.GetArraySize(2 * SuggestionSession._OneDigitSize, elementCount: 2);
                if (_displayedSuggestionCountOrIndex.HasValue)
                {
                    _estimateTelemetrySize -= valueSize;
                }

                if (!_displayedSuggestionCountOrIndex.HasValue&& value.HasValue)
                {
                    _estimateTelemetrySize += keySize;
                }
                else if (_displayedSuggestionCountOrIndex.HasValue && !value.HasValue)
                {
                    _estimateTelemetrySize -= keySize;
                }

                _displayedSuggestionCountOrIndex = value;

                if (_displayedSuggestionCountOrIndex.HasValue)
                {
                    _estimateTelemetrySize += valueSize;
                }
            }
        }

        private string _acceptedSuggestion;
        public string AcceptedSuggestion
        {
            get { return _acceptedSuggestion; }
            set
            {
                // It's written like
                // {"Accepted":"Get-AzSubscription -SubscriptionId 'xxxx-xxxx-xxxx-xxxx'"}

                int keySize = SuggestionSession.GetKeySize(SuggestionAcceptedTelemetryData.PropertyNameAccepted.Length);
                if (_acceptedSuggestion is not null)
                {
                    _estimateTelemetrySize -= SuggestionSession.GetStringSize(_acceptedSuggestion.Length);
                }

                if ((_acceptedSuggestion is null) && (value is not null))
                {
                    _estimateTelemetrySize += keySize;
                }
                else if ((_acceptedSuggestion is not null) && (value is null))
                {
                    _estimateTelemetrySize -= keySize;
                }

                _acceptedSuggestion = value;

                if (_acceptedSuggestion is not null)
                {
                    _estimateTelemetrySize += SuggestionSession.GetStringSize(_acceptedSuggestion.Length);
                }
            }
        }

        /// <summary>
        /// Whether the suggestions, displaying suggestions, and accepting suggestion are in the same telemetry event.
        /// </summary>
        public bool IsSuggestionComplete { get; set; } = true;

        // The calculation includes the quotes, ":", and ",", e.g. {"field:value",}. We tend to undercaculate it, so we
        // always include "," in the calculation.
        private static int GetKeySize(int keyNameSize) => keyNameSize + SuggestionSession._QuoteSize + 2 * SuggestionSession._SeparatorSize;

        private static int GetArraySize(int elementSize, int elementCount) => elementCount == 0 ? SuggestionSession._BracketSize : (elementSize + SuggestionSession._SeparatorSize * (elementCount - 1) + SuggestionSession._BracketSize);

        private static int GetStringSize(int stringSize) => stringSize + SuggestionSession._QuoteSize;
    }

    internal sealed class AggregatedTelemetryData : ITelemetryData
    {
        public int EstimateSuggestionSessionSize
        {
            get
            {
                int size = 0;

                // After we add an item into SuggestionSessions, we will update the new item's contents. So we need to
                // re-calculate the size.
                for (var i = 0; i < SuggestionSessions.Count; ++i)
                {
                    // We have a SuggestionSession as an object in an array. So plus 3. 3 includes a comma but this is an estimate so this is ok.
                    size += SuggestionSessions[i].EstimateTelemetrySize + 3;
                }

                return size + 2; // 2 for the array bracket.
            }
        }

        public string CommandId { get; set; }

        public string RequestId { get; set; }

        public PredictionClient Client { get; set; }

        public bool? HasSentHttpRequest { get; set; }

        public string CommandLine { get; set; }

        public bool IsCommandSuccess { get; set; }

        public IList<SuggestionSession> SuggestionSessions { get; } = new List<SuggestionSession>();

        public void UpdateFromTelemetryData(ITelemetryData telemetryData)
        {
            Client = telemetryData.Client;
            CommandId = telemetryData.CommandId;
            RequestId = telemetryData.RequestId;
        }
    }
}
