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

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System;
using System.Collections.Generic;
using System.Management.Automation.Subsystem;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// Represents the suggestions to show to the user and the related information of the suggestions.
    /// </summary>
    /// <remarks>
    /// Because the performance requirement in <see cref="AzPredictor.GetSuggestion(PredictionContext,System.Threading.CancellationToken)"/>,
    /// it contains lists of each piece of information, for example, a collection of predictive suggestion and a list of
    /// suggestion sources. Note that the count of each list should be the same. And each element in the list corresonds to
    /// the element in other list at the same index.
    /// </remarks>
    public sealed class CommandLineSuggestion
    {
        private readonly List<PredictiveSuggestion> _predictiveSuggestions = new();

        /// <summary>
        /// Gets the suggestions returned to show to the user. This can be adjusted from <see cref="SourceTexts"/> based on
        /// the user input.
        /// </summary>
        public IReadOnlyList<PredictiveSuggestion> PredictiveSuggestions { get { CheckObjectInvariant(); return _predictiveSuggestions; } }

        private readonly List<string> _sourceTexts = new();
        /// <summary>
        /// Gets the texts that <see cref="PredictiveSuggestions"/> is based on.
        /// </summary>
        public IReadOnlyList<string> SourceTexts { get { CheckObjectInvariant(); return _sourceTexts; } }

        private readonly List<SuggestionSource> _suggestionSources = new();
        /// <summary>
        /// Gets or sets the sources where the text is from.
        /// </summary>
        public IReadOnlyList<SuggestionSource> SuggestionSources { get { CheckObjectInvariant(); return _suggestionSources; } }

        /// <summary>
        /// Gets the number of suggestions.
        /// </summary>
        public int Count { get { CheckObjectInvariant(); return _suggestionSources.Count; } }

        /// <summary>
        /// Adds a new suggestion.
        /// </summary>
        /// <param name="predictiveSuggestion">The suggestion to show to the user.</param>
        /// <param name="sourceText">The text that used to construct <paramref name="predictiveSuggestion"/>.</param>
        public void AddSuggestion(PredictiveSuggestion predictiveSuggestion, string sourceText) => AddSuggestion(predictiveSuggestion, sourceText, SuggestionSource.None);

        /// <summary>
        /// Adds a new suggestion.
        /// </summary>
        /// <param name="predictiveSuggestion">The suggestion to show to the user.</param>
        /// <param name="sourceText">The text that used to construct <paramref name="predictiveSuggestion"/>.</param>
        /// <param name="suggestionSource">The source where the suggestion is from.</param>
        public void AddSuggestion(PredictiveSuggestion predictiveSuggestion, string sourceText, SuggestionSource suggestionSource)
        {
            Validation.CheckArgument(predictiveSuggestion, $"{nameof(predictiveSuggestion)} cannot be null.");
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(predictiveSuggestion.SuggestionText), $"{nameof(predictiveSuggestion)} cannot have a null or whitespace suggestion text.");
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(sourceText), $"{nameof(sourceText)} cannot be null or whitespace.");

            _predictiveSuggestions.Add(predictiveSuggestion);
            _sourceTexts.Add(sourceText);
            _suggestionSources.Add(suggestionSource);

            CheckObjectInvariant();
        }

        /// <summary>
        /// Updates the suggestion source of a suggestion.
        /// </summary>
        /// <param name="index">The index of a suggestion.</param>
        /// <param name="suggestionSource">The new suggestion source.</param>
        public void UpdateSuggestionSource(int index, SuggestionSource suggestionSource)
        {
            Validation.CheckArgument<ArgumentOutOfRangeException>((index >= 0) && (index < _suggestionSources.Count), $"{nameof(index)} is out of range.");

            _suggestionSources[index] = suggestionSource;
            CheckObjectInvariant();
        }

        private void CheckObjectInvariant()
        {
            Validation.CheckInvariant(_predictiveSuggestions.Count == _sourceTexts.Count && _predictiveSuggestions.Count == _suggestionSources.Count);
        }
    }
}
