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

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry;
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation.Subsystem.Prediction;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// This class is to test the logic in <see cref="SuggestionSession"/>.
    /// </summary>
    public sealed class SuggestionSessionTests
    {
        // Includes the quotes around the key, the colon to separate the key and the value, and the comma.
        private const int _AdditionalSizeForKey = 4; // It's for "":, e.g. "Key":<value>,
        private const int _AdditionalSizeForString = 2; // It's for ""
        private const int _AdditionalSizeForArrayBracket = 2; // It's the size for []
        private const int _AdditionalSizeForTwoElementArray = SuggestionSessionTests._AdditionalSizeForArrayBracket + 1; // It's for [,]

        /// <summary>
        /// Tests the estimate size when there is only one suggestion found.
        /// </summary>
        [Theory]
        [InlineData("Get-AzSubscription", SuggestionSource.StaticCommands, false, "ge")]
        [InlineData("Get-AzSecurityPricing -DefaultProfile <IAzureContextContainer>", SuggestionSource.CurrentCommand, true, "get-A")]
        public void TestSizeForOneSuggestion(string suggestion, SuggestionSource source, bool isCancelled, string userInput)
        {
            // The text in the telemetry data is like
            // { "Found":[["Get-AzSubscription",1]],"IsCanclled":"False","UserInput":"ge" }
            var commandLineSuggestion = new CommandLineSuggestion();
            commandLineSuggestion.AddSuggestion(new PredictiveSuggestion(suggestion, null), suggestion, source);

            var suggestionSession = new SuggestionSession()
            {
                FoundSuggestion = commandLineSuggestion,
                IsCancellationRequested = isCancelled,
                UserInput = userInput,
                IsSuggestionComplete = true,
            };

            var expectedSize = GetSuggestionTelemetryData.PropertyNameFound.Length + SuggestionSessionTests._AdditionalSizeForKey
                + suggestion.Length + SuggestionSessionTests._AdditionalSizeForString
                + 1 // For the one digit of source
                + SuggestionSessionTests._AdditionalSizeForTwoElementArray // for [,]
                + SuggestionSessionTests._AdditionalSizeForArrayBracket // for [] in Found
                + GetSuggestionTelemetryData.PropertyNameUserInput.Length + SuggestionSessionTests._AdditionalSizeForKey
                + userInput.Length + SuggestionSessionTests._AdditionalSizeForString
                + GetSuggestionTelemetryData.PropertyNameIsCancelled.Length + SuggestionSessionTests._AdditionalSizeForKey
                + isCancelled.ToString(CultureInfo.InvariantCulture).Length;

            Assert.Equal(expectedSize, suggestionSession.EstimateTelemetrySize);
        }

        /// <summary>
        /// Tests the estimate size when there is two suggestions found.
        /// </summary>
        [Theory]
        [InlineData("Get-AzSubscription", SuggestionSource.StaticCommands, "Get-AzSecurityPricing -DefaultProfile <IAzureContextContainer>", SuggestionSource.CurrentCommand, false, "ge")]
        public void TestSizeForTwoSuggestions(string suggestion1, SuggestionSource source1, string suggestion2, SuggestionSource source2, bool isCancelled, string userInput)
        {
            // The text in the telemetry data is like
            // { "Found":[["Get-AzSubscription",3],["Get-AzSecurityPricing -DefaultProfile <IAzureContextContainer>",1]],"IsCanclled":"False","UserInput":"ge" }
            var commandLineSuggestion = new CommandLineSuggestion();
            commandLineSuggestion.AddSuggestion(new PredictiveSuggestion(suggestion1, null), suggestion1, source1);
            commandLineSuggestion.AddSuggestion(new PredictiveSuggestion(suggestion2, null), suggestion2, source2);

            var suggestionSession = new SuggestionSession()
            {
                FoundSuggestion = commandLineSuggestion,
                IsCancellationRequested = isCancelled,
                UserInput = userInput,
                IsSuggestionComplete = true,
            };

            var expectedSize = GetSuggestionTelemetryData.PropertyNameFound.Length + SuggestionSessionTests._AdditionalSizeForKey
                + suggestion1.Length + SuggestionSessionTests._AdditionalSizeForString
                + 1 // For the one digit of source1
                + SuggestionSessionTests._AdditionalSizeForTwoElementArray // for [,]
                + suggestion2.Length + SuggestionSessionTests._AdditionalSizeForString
                + 1 // for the one digit of source2
                + SuggestionSessionTests._AdditionalSizeForTwoElementArray // for [,]
                + SuggestionSessionTests._AdditionalSizeForTwoElementArray // for [,] in Found
                + GetSuggestionTelemetryData.PropertyNameUserInput.Length + SuggestionSessionTests._AdditionalSizeForKey
                + userInput.Length + SuggestionSessionTests._AdditionalSizeForString
                + GetSuggestionTelemetryData.PropertyNameIsCancelled.Length + SuggestionSessionTests._AdditionalSizeForKey
                + isCancelled.ToString(CultureInfo.InvariantCulture).Length;

            Assert.Equal(expectedSize, suggestionSession.EstimateTelemetrySize);
        }

        /// <summary>
        /// Tests the estimate size when there is only one suggestion found and display suggestion.
        /// </summary>
        [Theory]
        [InlineData("Get-AzSubscription", SuggestionSource.StaticCommands, false, "ge", SuggestionDisplayMode.InlineView, 0)]
        [InlineData("Get-AzSecurityPricing -DefaultProfile <IAzureContextContainer>", SuggestionSource.CurrentCommand, true, "get-A", SuggestionDisplayMode.ListView, 7)]
        public void TestSizeForDisplaySuggestion(string suggestion, SuggestionSource source, bool isCancelled, string userInput, SuggestionDisplayMode mode, int index)
        {
            // The text in the telemetry data is like
            // { "Found":[["Get-AzSubscription",3]],"IsCanclled":"False","UserInput":"ge","Displayed":[1,7] }
            var commandLineSuggestion = new CommandLineSuggestion();
            commandLineSuggestion.AddSuggestion(new PredictiveSuggestion(suggestion, null), suggestion, source);

            var suggestionSession = new SuggestionSession()
            {
                FoundSuggestion = commandLineSuggestion,
                IsCancellationRequested = isCancelled,
                UserInput = userInput,
                DisplayMode = mode,
                DisplayedSuggestionCountOrIndex = index,
                IsSuggestionComplete = true,
            };

            var expectedSize = GetSuggestionTelemetryData.PropertyNameFound.Length + SuggestionSessionTests._AdditionalSizeForKey
                + suggestion.Length + SuggestionSessionTests._AdditionalSizeForString
                + 1 // For the one digit of source
                + SuggestionSessionTests._AdditionalSizeForTwoElementArray // for [,]
                + SuggestionSessionTests._AdditionalSizeForArrayBracket // for [] in Found
                + GetSuggestionTelemetryData.PropertyNameUserInput.Length + SuggestionSessionTests._AdditionalSizeForKey
                + userInput.Length + SuggestionSessionTests._AdditionalSizeForString
                + GetSuggestionTelemetryData.PropertyNameIsCancelled.Length + SuggestionSessionTests._AdditionalSizeForKey
                + isCancelled.ToString(CultureInfo.InvariantCulture).Length
                + SuggestionDisplayedTelemetryData.PropertyNameDisplayed.Length + SuggestionSessionTests._AdditionalSizeForKey
                + 2 // for the two digit 5 and 7.
                + SuggestionSessionTests._AdditionalSizeForTwoElementArray;

            Assert.Equal(expectedSize, suggestionSession.EstimateTelemetrySize);
        }

        /// <summary>
        /// Tests the estimate size when there is only one suggestion found and accept suggestion.
        /// </summary>
        [Theory]
        [InlineData("Get-AzSubscription", SuggestionSource.StaticCommands, false, "ge", "Get-AzSubscription")]
        public void TestSizeForAcceptSuggestion(string suggestion, SuggestionSource source, bool isCancelled, string userInput, string acceptedSuggestion)
        {
            // The text in the telemetry data is like
            // { "Found":[["Get-AzSubscription",3]],"IsCanclled":"False","UserInput":"ge","Accepted":"Get-AzSubscription" }
            var commandLineSuggestion = new CommandLineSuggestion();
            commandLineSuggestion.AddSuggestion(new PredictiveSuggestion(suggestion, null), suggestion, source);

            var suggestionSession = new SuggestionSession()
            {
                FoundSuggestion = commandLineSuggestion,
                IsCancellationRequested = isCancelled,
                UserInput = userInput,
                AcceptedSuggestion = acceptedSuggestion,
                IsSuggestionComplete = true,
            };

            var expectedSize = GetSuggestionTelemetryData.PropertyNameFound.Length + SuggestionSessionTests._AdditionalSizeForKey
                + suggestion.Length + SuggestionSessionTests._AdditionalSizeForString
                + 1 // For the one digit of source
                + SuggestionSessionTests._AdditionalSizeForTwoElementArray // for [,]
                + SuggestionSessionTests._AdditionalSizeForArrayBracket // for [] in Found
                + GetSuggestionTelemetryData.PropertyNameUserInput.Length + SuggestionSessionTests._AdditionalSizeForKey
                + userInput.Length + SuggestionSessionTests._AdditionalSizeForString
                + GetSuggestionTelemetryData.PropertyNameIsCancelled.Length + SuggestionSessionTests._AdditionalSizeForKey
                + isCancelled.ToString(CultureInfo.InvariantCulture).Length
                + SuggestionAcceptedTelemetryData.PropertyNameAccepted.Length + SuggestionSessionTests._AdditionalSizeForKey
                + acceptedSuggestion.Length + SuggestionSessionTests._AdditionalSizeForString;

            Assert.Equal(expectedSize, suggestionSession.EstimateTelemetrySize);
        }

        /// <summary>
        /// Tests the incomplete suggestion session.
        /// </summary>
        [Theory]
        [InlineData(243, SuggestionDisplayMode.InlineView, 0, "Get-AzSubscription")]
        public void TestSizeForIncompleteSuggestion(uint suggestionSessionId, SuggestionDisplayMode mode, int index, string acceptedSuggestion)
        {
            // The text in the telemetry data is like
            // { "Displayed":[2,0],Accepted":"Get-AzSubscription","SuggestionSessionId":"243" }

            var suggestionSession = new SuggestionSession()
            {
                SuggestionSessionId = suggestionSessionId,
                DisplayMode = mode,
                DisplayedSuggestionCountOrIndex = index,
                AcceptedSuggestion = acceptedSuggestion,
                IsSuggestionComplete = false,
            };

            var expectedSize = GetSuggestionTelemetryData.PropertyNameSuggestionSessionId.Length + SuggestionSessionTests._AdditionalSizeForKey
                + suggestionSessionId.ToString(CultureInfo.InvariantCulture).Length
                + SuggestionDisplayedTelemetryData.PropertyNameDisplayed.Length + SuggestionSessionTests._AdditionalSizeForKey
                + 2 // For the two digits 1 and 7
                + SuggestionSessionTests._AdditionalSizeForTwoElementArray
                + SuggestionAcceptedTelemetryData.PropertyNameAccepted.Length + SuggestionSessionTests._AdditionalSizeForKey
                + acceptedSuggestion.Length + SuggestionSessionTests._AdditionalSizeForString;

            Assert.Equal(expectedSize, suggestionSession.EstimateTelemetrySize);
        }

        /// <summary>
        /// Tests one SuggestionSession in AggregatedTelemetryData
        /// </summary>
        [Theory]
        [InlineData(120)]
        public void TestOneSuggestionSession(int suggestionSessionSize)
        {
            // The aggregated will look like:
            // { "Suggestion":[{<suggestion session data placeholder>}] }
            var aggregatedData = new AggregatedTelemetryData();
            aggregatedData.SuggestionSessions.Add(new SuggestionSession()
                    {
                        EstimateTelemetrySize = suggestionSessionSize,
                    });

            var expectedSize = suggestionSessionSize + 3 + 2;
            Assert.Equal(expectedSize, aggregatedData.EstimateSuggestionSessionSize);
        }

        /// <summary>
        /// Tests one SuggestionSession in AggregatedTelemetryData
        /// </summary>
        [Theory]
        [InlineData(120, 230)]
        public void TestTwoSuggestionSessions(int suggestionSessionSize1, int suggestionSessionSize2)
        {
            // The aggregated will look like:
            // { "Suggestion":[{<suggestion session data placeholder>},{<suggestion session data placeholder>}] }
            var aggregatedData = new AggregatedTelemetryData();
            aggregatedData.SuggestionSessions.Add(new SuggestionSession()
            {
                EstimateTelemetrySize = suggestionSessionSize1,
            });
            aggregatedData.SuggestionSessions.Add(new SuggestionSession()
                    {
                        EstimateTelemetrySize = suggestionSessionSize2,
                    });

            var expectedSize = suggestionSessionSize1 + 3 + suggestionSessionSize2 + 3 + 2;
            Assert.Equal(expectedSize, aggregatedData.EstimateSuggestionSessionSize);
        }
    }
}
