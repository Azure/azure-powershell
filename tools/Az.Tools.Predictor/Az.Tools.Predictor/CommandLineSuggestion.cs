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
using System.Management.Automation.Language;
using System.Management.Automation.Subsystem.Prediction;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// Represents the suggestions to show to the user and the related information of the suggestions.
    /// </summary>
    /// <remarks>
    /// Because the performance requirement in <see cref="AzPredictor.GetSuggestion"/>,
    /// it contains lists of each piece of information, for example, a collection of predictive suggestion and a list of
    /// suggestion sources. Note that the count of each list should be the same. And each element in the list corresponds to
    /// the element in other list at the same index.
    /// </remarks>
    public sealed class CommandLineSuggestion
    {
        /// <summary>
        /// Since PSReadLine can accept at most 10 suggestions, we pre-allocate that many items in the collection to avoid
        /// re-allocation when we try to find the suggestion to return.
        /// </summary>
        private const int CollectionDefaultCapacity = 10;

        private readonly List<PredictiveSuggestion> _predictiveSuggestions = new List<PredictiveSuggestion>(CommandLineSuggestion.CollectionDefaultCapacity);

        /// <summary>
        /// Gets or sets the AST the suggestions are provided for. Note this is not always the same as the whole user input.
        /// </summary>
        public CommandAst CommandAst { get; set; }

        /// <summary>
        /// Gets the suggestions returned to show to the user. This can be adjusted from <see cref="SourceTexts"/> based on
        /// the user input.
        /// </summary>
        public IReadOnlyList<PredictiveSuggestion> PredictiveSuggestions { get { return _predictiveSuggestions; } }

        private readonly List<string> _sourceTexts = new List<string>(CommandLineSuggestion.CollectionDefaultCapacity);
        /// <summary>
        /// Gets the texts that <see cref="PredictiveSuggestions"/> is based on.
        /// </summary>
        public IReadOnlyList<string> SourceTexts { get { return _sourceTexts; } }

        private readonly List<SuggestionSource> _suggestionSources = new List<SuggestionSource>(CommandLineSuggestion.CollectionDefaultCapacity);
        /// <summary>
        /// Gets or sets the sources where the text is from.
        /// </summary>
        public IReadOnlyList<SuggestionSource> SuggestionSources { get { return _suggestionSources; } }

        /// <summary>
        /// Gets the number of suggestions.
        /// </summary>
        public int Count { get { return _suggestionSources.Count; } }

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
        /// <returns>True if the suggestion is added. Otherwise, it returns false.</returns>
        public bool AddSuggestion(PredictiveSuggestion predictiveSuggestion, string sourceText, SuggestionSource suggestionSource)
        {
            Validation.CheckArgument(predictiveSuggestion, $"{nameof(predictiveSuggestion)} cannot be null.");
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(predictiveSuggestion.SuggestionText), $"{nameof(predictiveSuggestion)} cannot have a null or whitespace suggestion text.");
            Validation.CheckArgument(!string.IsNullOrWhiteSpace(sourceText), $"{nameof(sourceText)} cannot be null or whitespace.");

            for (var i = 0; i < _predictiveSuggestions.Count; ++i)
            {
                if (string.Equals(_predictiveSuggestions[i].SuggestionText, predictiveSuggestion.SuggestionText, StringComparison.Ordinal))
                {
                    return false;
                }
            }

            _predictiveSuggestions.Add(predictiveSuggestion);
            _sourceTexts.Add(sourceText);
            _suggestionSources.Add(suggestionSource);

            CheckObjectInvariant();

            return true;
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
