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

namespace Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Comparers;
    using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Formatter for WhatIf operation results.
    /// Works with any RP-specific implementation via IWhatIfOperationResult interface.
    /// </summary>
    public class WhatIfOperationResultFormatter : WhatIfJsonFormatter
    {
        // Diagnostic level constants
        protected const string LevelError = "Error";
        protected const string LevelWarning = "Warning";
        protected const string LevelInfo = "Info";

        public WhatIfOperationResultFormatter(ColoredStringBuilder builder)
            : base(builder)
        {
        }

        /// <summary>
        /// Formats a WhatIf operation result into a colored string.
        /// </summary>
        public static string Format(IWhatIfOperationResult result, string noiseNotice = null)
        {
            if (result == null)
            {
                return null;
            }

            var builder = new ColoredStringBuilder();
            var formatter = new WhatIfOperationResultFormatter(builder);

            formatter.FormatNoiseNotice(noiseNotice);
            formatter.FormatLegend(result.Changes, result.PotentialChanges);
            formatter.FormatResourceChanges(result.Changes, true);
            formatter.FormatStats(result.Changes, true);
            formatter.FormatResourceChanges(result.PotentialChanges, false);
            formatter.FormatStats(result.PotentialChanges, false);
            formatter.FormatDiagnostics(result.Diagnostics, result.Changes, result.PotentialChanges);

            return builder.ToString();
        }

        protected virtual void FormatNoiseNotice(string noiseNotice = null)
        {
            if (string.IsNullOrEmpty(noiseNotice))
            {
                noiseNotice = "Note: The result may contain false positive predictions (noise).";
            }

            this.Builder
                .AppendLine(noiseNotice)
                .AppendLine();
        }

        private static int GetMaxPathLength(IList<IWhatIfPropertyChange> propertyChanges)
        {
            if (propertyChanges == null)
            {
                return 0;
            }

            return propertyChanges
                .Where(ShouldConsiderPathLength)
                .Select(pc => pc.Path.Length)
                .DefaultIfEmpty()
                .Max();
        }

        private static bool ShouldConsiderPathLength(IWhatIfPropertyChange propertyChange)
        {
            switch (propertyChange.PropertyChangeType)
            {
                case PropertyChangeType.Create:
                case PropertyChangeType.NoEffect:
                    return propertyChange.After.IsLeaf();

                case PropertyChangeType.Delete:
                case PropertyChangeType.Modify:
                    return propertyChange.Before.IsLeaf();

                default:
                    return propertyChange.Children == null || propertyChange.Children.Count == 0;
            }
        }

        protected virtual void FormatStats(IList<IWhatIfChange> resourceChanges, bool definiteChanges)
        {
            if (definiteChanges)
            {
                this.Builder.AppendLine().Append("Resource changes: ");
            }
            else if (resourceChanges != null && resourceChanges.Count != 0)
            {
                this.Builder.AppendLine().Append("Potential changes: ");
            }
            else
            {
                return;
            }

            if (resourceChanges == null || resourceChanges.Count == 0)
            {
                this.Builder.Append("no change");
            }
            else
            {
                IEnumerable<string> stats = resourceChanges
                    .OrderBy(rc => rc.ChangeType, new ChangeTypeComparer())
                    .GroupBy(rc => rc.ChangeType)
                    .Select(g => new { ChangeType = g.Key, Count = g.Count() })
                    .Where(x => x.Count != 0)
                    .Select(x => this.FormatChangeTypeCount(x.ChangeType, x.Count));

                this.Builder.Append(string.Join(", ", stats));
            }

            this.Builder.Append(".");
        }

        protected virtual void FormatDiagnostics(
            IList<IWhatIfDiagnostic> diagnostics,
            IList<IWhatIfChange> changes,
            IList<IWhatIfChange> potentialChanges)
        {
            var diagnosticsList = diagnostics != null ? new List<IWhatIfDiagnostic>(diagnostics) : new List<IWhatIfDiagnostic>();

            // Add unsupported changes as warnings
            void AddUnsupportedWarnings(IList<IWhatIfChange> changeList)
            {
                if (changeList != null)
                {
                    var unsupportedChanges = changeList
                        .Where(c => c.ChangeType == ChangeType.Unsupported)
                        .ToList();

                    foreach (var change in unsupportedChanges)
                    {
                        diagnosticsList.Add(new WhatIfDiagnostic
                        {
                            Level = LevelWarning,
                            Code = "Unsupported",
                            Message = change.UnsupportedReason,
                            Target = change.FullyQualifiedResourceId
                        });
                    }
                }
            }

            AddUnsupportedWarnings(changes);
            AddUnsupportedWarnings(potentialChanges);

            if (diagnosticsList.Count == 0)
            {
                return;
            }

            this.Builder.AppendLine().AppendLine();
            this.Builder.Append($"Diagnostics ({diagnosticsList.Count}): ").AppendLine();

            foreach (var diagnostic in diagnosticsList)
            {
                using (this.Builder.NewColorScope(DiagnosticLevelToColor(diagnostic.Level)))
                {
                    this.Builder.Append($"({diagnostic.Target})").Append(Symbol.WhiteSpace);
                    this.Builder.Append(diagnostic.Message).Append(Symbol.WhiteSpace);
                    this.Builder.Append($"({diagnostic.Code})");
                    this.Builder.AppendLine();
                }
            }
        }

        protected virtual Color DiagnosticLevelToColor(string level)
        {
            if (string.IsNullOrEmpty(level))
            {
                return Color.Reset;
            }

            // Use the same logic as DiagnosticExtensions
            switch (level.ToLowerInvariant())
            {
                case "error":
                    return Color.Red;
                case "warning":
                    return Color.DarkYellow;
                case "info":
                    return Color.Blue;
                default:
                    return Color.Reset;
            }
        }

        protected virtual string FormatChangeTypeCount(ChangeType changeType, int count)
        {
            switch (changeType)
            {
                case ChangeType.Create:
                    return $"{count} to create";
                case ChangeType.Delete:
                    return $"{count} to delete";
                case ChangeType.Deploy:
                    return $"{count} to deploy";
                case ChangeType.Modify:
                    return $"{count} to modify";
                case ChangeType.Ignore:
                    return $"{count} to ignore";
                case ChangeType.NoChange:
                    return $"{count} no change";
                case ChangeType.Unsupported:
                    return $"{count} unsupported";
                default:
                    throw new ArgumentOutOfRangeException(nameof(changeType), changeType, null);
            }
        }

        protected virtual void FormatLegend(IList<IWhatIfChange> changes, IList<IWhatIfChange> potentialChanges)
        {
            var resourceChanges = changes != null ? new List<IWhatIfChange>(changes) : new List<IWhatIfChange>();

            if (potentialChanges != null && potentialChanges.Count > 0)
            {
                resourceChanges = resourceChanges.Concat(potentialChanges).ToList();
            }

            if (resourceChanges.Count == 0)
            {
                return;
            }

            var psChangeTypeSet = new HashSet<PSChangeType>();

            void PopulateChangeTypeSet(IList<IWhatIfPropertyChange> propertyChanges)
            {
                if (propertyChanges == null)
                {
                    return;
                }

                foreach (var propertyChange in propertyChanges)
                {
                    psChangeTypeSet.Add(propertyChange.PropertyChangeType.ToPSChangeType());
                    PopulateChangeTypeSet(propertyChange.Children);
                }
            }

            foreach (var resourceChange in resourceChanges)
            {
                psChangeTypeSet.Add(resourceChange.ChangeType.ToPSChangeType());
                PopulateChangeTypeSet(resourceChange.Delta);
            }

            this.Builder
                .Append("Resource and property changes are indicated with ")
                .AppendLine(psChangeTypeSet.Count == 1 ? "this symbol:" : "these symbols:");

            foreach (var changeType in psChangeTypeSet.OrderBy(x => x, new PSChangeTypeComparer()))
            {
                this.Builder
                    .Append(Indent())
                    .Append(changeType.ToSymbol(), changeType.ToColor())
                    .Append(Symbol.WhiteSpace)
                    .Append(changeType)
                    .AppendLine();
            }
        }

        protected virtual void FormatResourceChanges(IList<IWhatIfChange> resourceChanges, bool definiteChanges)
        {
            if (resourceChanges == null || resourceChanges.Count == 0)
            {
                return;
            }

            int scopeCount = resourceChanges.Select(rc => rc.Scope.ToUpperInvariant()).Distinct().Count();

            if (definiteChanges)
            {
                this.Builder
                    .AppendLine()
                    .Append("The deployment will update the following ")
                    .AppendLine(scopeCount == 1 ? "scope:" : "scopes:");
            }
            else
            {
                this.Builder
                    .AppendLine()
                    .AppendLine()
                    .AppendLine()
                    .Append("The following change MAY OR MAY NOT be deployed to the following ")
                    .AppendLine(scopeCount == 1 ? "scope:" : "scopes:");
            }

            var groupedByScope = resourceChanges
                .OrderBy(rc => rc.Scope.ToUpperInvariant())
                .GroupBy(rc => rc.Scope.ToUpperInvariant())
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var kvp in groupedByScope)
            {
                FormatResourceChangesInScope(kvp.Value[0].Scope, kvp.Value);
            }
        }

        protected virtual void FormatResourceChangesInScope(string scope, IList<IWhatIfChange> resourceChanges)
        {
            // Scope.
            this.Builder
                .AppendLine()
                .AppendLine($"Scope: {scope}");

            // Resource changes.
            List<IWhatIfChange> sortedResourceChanges = resourceChanges
                .OrderBy(rc => rc.ChangeType, new ChangeTypeComparer())
                .ThenBy(rc => rc.RelativeResourceId)
                .ToList();

            var groupedByChangeType = sortedResourceChanges
                .GroupBy(rc => rc.ChangeType)
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var kvp in groupedByChangeType)
            {
                using (this.Builder.NewColorScope(kvp.Key.ToColor()))
                {
                    foreach (var rc in kvp.Value)
                    {
                        this.FormatResourceChange(rc, rc == sortedResourceChanges.Last());
                    }
                }
            }
        }

        protected virtual void FormatResourceChange(IWhatIfChange resourceChange, bool isLast)
        {
            this.Builder.AppendLine();
            this.FormatResourceChangePath(
                resourceChange.ChangeType,
                resourceChange.RelativeResourceId,
                resourceChange.ApiVersion);

            switch (resourceChange.ChangeType)
            {
                case ChangeType.Create when resourceChange.After != null:
                    this.FormatJson(resourceChange.After, indentLevel: 2);
                    return;

                case ChangeType.Delete when resourceChange.Before != null:
                    this.FormatJson(resourceChange.Before, indentLevel: 2);
                    return;

                default:
                    if (resourceChange.Delta?.Count > 0)
                    {
                        using (this.Builder.NewColorScope(Color.Reset))
                        {
                            IList<IWhatIfPropertyChange> propertyChanges = resourceChange.Delta
                                .OrderBy(pc => pc.PropertyChangeType, new PropertyChangeTypeComparer())
                                .ThenBy(pc => pc.Path)
                                .ToList();

                            this.Builder.AppendLine();
                            this.FormatPropertyChanges(propertyChanges);
                        }

                        return;
                    }

                    if (isLast)
                    {
                        this.Builder.AppendLine();
                    }

                    return;
            }
        }

        protected virtual void FormatResourceChangePath(ChangeType changeType, string relativeResourceId, string apiVersion)
        {
            this.FormatPath(
                relativeResourceId,
                0,
                1,
                () => this.Builder.Append(changeType.ToSymbol()).Append(Symbol.WhiteSpace),
                () => this.FormatResourceChangeApiVersion(apiVersion));
        }

        protected virtual void FormatResourceChangeApiVersion(string apiVersion)
        {
            if (string.IsNullOrEmpty(apiVersion))
            {
                return;
            }

            using (this.Builder.NewColorScope(Color.Reset))
            {
                this.Builder
                    .Append(Symbol.WhiteSpace)
                    .Append(Symbol.LeftSquareBracket)
                    .Append(apiVersion)
                    .Append(Symbol.RightSquareBracket);
            }
        }

        protected virtual void FormatPropertyChanges(IList<IWhatIfPropertyChange> propertyChanges, int indentLevel = 2)
        {
            int maxPathLength = GetMaxPathLength(propertyChanges);
            foreach (var pc in propertyChanges)
            {
                this.FormatPropertyChange(pc, maxPathLength, indentLevel);
                this.Builder.AppendLine();
            }
        }

        protected virtual void FormatPropertyChange(IWhatIfPropertyChange propertyChange, int maxPathLength, int indentLevel)
        {
            PropertyChangeType propertyChangeType = propertyChange.PropertyChangeType;
            string path = propertyChange.Path;
            JToken before = propertyChange.Before;
            JToken after = propertyChange.After;
            IList<IWhatIfPropertyChange> children = propertyChange.Children;

            switch (propertyChange.PropertyChangeType)
            {
                case PropertyChangeType.Create:
                    this.FormatPropertyChangePath(propertyChangeType, path, after, children, maxPathLength, indentLevel);
                    this.FormatPropertyCreate(after, indentLevel + 1);
                    break;

                case PropertyChangeType.Delete:
                    this.FormatPropertyChangePath(propertyChangeType, path, before, children, maxPathLength, indentLevel);
                    this.FormatPropertyDelete(before, indentLevel + 1);
                    break;

                case PropertyChangeType.Modify:
                    this.FormatPropertyChangePath(propertyChangeType, path, before, children, maxPathLength, indentLevel);
                    this.FormatPropertyModify(propertyChange, indentLevel + 1);
                    break;

                case PropertyChangeType.Array:
                    this.FormatPropertyChangePath(propertyChangeType, path, null, children, maxPathLength, indentLevel);
                    this.FormatPropertyArrayChange(propertyChange, propertyChange.Children, indentLevel + 1);
                    break;

                case PropertyChangeType.NoEffect:
                    this.FormatPropertyChangePath(propertyChangeType, path, after, children, maxPathLength, indentLevel);
                    this.FormatPropertyNoEffect(after, indentLevel + 1);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected virtual void FormatPropertyChangePath(
            PropertyChangeType propertyChangeType,
            string path,
            JToken valueAfterPath,
            IList<IWhatIfPropertyChange> children,
            int maxPathLength,
            int indentLevel)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            int paddingWidth = maxPathLength - path.Length + 1;
            bool hasChildren = children != null && children.Count > 0;

            if (valueAfterPath.IsNonEmptyArray() || (propertyChangeType == PropertyChangeType.Array && hasChildren))
            {
                paddingWidth = 1;
            }
            if (valueAfterPath.IsNonEmptyObject())
            {
                paddingWidth = 0;
            }
            if (propertyChangeType == PropertyChangeType.Modify && hasChildren)
            {
                paddingWidth = 0;
            }

            this.FormatPath(
                path,
                paddingWidth,
                indentLevel,
                () => this.FormatPropertyChangeType(propertyChangeType),
                this.FormatColon);
        }

        protected virtual void FormatPropertyChangeType(PropertyChangeType propertyChangeType)
        {
            this.Builder
                .Append(propertyChangeType.ToSymbol(), propertyChangeType.ToColor())
                .Append(Symbol.WhiteSpace);
        }

        protected virtual void FormatPropertyCreate(JToken value, int indentLevel)
        {
            using (this.Builder.NewColorScope(Color.Green))
            {
                this.FormatJson(value, indentLevel: indentLevel);
            }
        }

        protected virtual void FormatPropertyDelete(JToken value, int indentLevel)
        {
            using (this.Builder.NewColorScope(Color.Orange))
            {
                this.FormatJson(value, indentLevel: indentLevel);
            }
        }

        protected virtual void FormatPropertyModify(IWhatIfPropertyChange propertyChange, int indentLevel)
        {
            if (propertyChange.Children != null && propertyChange.Children.Count > 0)
            {
                // Has nested changes.
                this.Builder.AppendLine().AppendLine();
                this.FormatPropertyChanges(propertyChange.Children
                        .OrderBy(pc => pc.PropertyChangeType, new PropertyChangeTypeComparer())
                        .ThenBy(pc => pc.Path)
                        .ToList(),
                    indentLevel);
            }
            else
            {
                JToken before = propertyChange.Before;
                JToken after = propertyChange.After;

                // The before value.
                this.FormatPropertyDelete(before, indentLevel);

                // Space before =>
                if (before.IsNonEmptyObject())
                {
                    this.Builder
                        .AppendLine()
                        .Append(Indent(indentLevel));
                }
                else
                {
                    this.Builder.Append(Symbol.WhiteSpace);
                }

                // =>
                this.Builder.Append("=>");

                // Space after =>
                if (!after.IsNonEmptyObject())
                {
                    this.Builder.Append(Symbol.WhiteSpace);
                }

                // The after value.
                this.FormatPropertyCreate(after, indentLevel);

                if (!before.IsLeaf() && after.IsLeaf())
                {
                    this.Builder.AppendLine();
                }
            }
        }

        protected virtual void FormatPropertyArrayChange(IWhatIfPropertyChange parentPropertyChange, IList<IWhatIfPropertyChange> propertyChanges, int indentLevel)
        {
            if (string.IsNullOrEmpty(parentPropertyChange.Path))
            {
                // The parent change doesn't have a path, which means the current
                // array change is a nested change. We need to decrease indent_level
                // and print indentation before printing "[".
                indentLevel--;
                FormatIndent(indentLevel);
            }

            if (propertyChanges.Count == 0)
            {
                this.Builder.AppendLine("[]");
                return;
            }

            // [
            this.Builder
                .Append(Symbol.LeftSquareBracket)
                .AppendLine();

            this.FormatPropertyChanges(propertyChanges
                    .OrderBy(pc => int.Parse(pc.Path))
                    .ThenBy(pc => pc.PropertyChangeType, new PropertyChangeTypeComparer())
                    .ToList(),
                indentLevel);

            // ]
            this.Builder
                .Append(Indent(indentLevel))
                .Append(Symbol.RightSquareBracket);
        }

        protected virtual void FormatPropertyNoEffect(JToken value, int indentLevel)
        {
            using (this.Builder.NewColorScope(Color.Gray))
            {
                this.FormatJson(value, indentLevel: indentLevel);
            }
        }

        /// <summary>
        /// Simple diagnostic implementation for internal use.
        /// </summary>
        private class WhatIfDiagnostic : IWhatIfDiagnostic
        {
            public string Code { get; set; }
            public string Message { get; set; }
            public string Level { get; set; }
            public string Target { get; set; }
            public string Details { get; set; }
        }
    }
}
