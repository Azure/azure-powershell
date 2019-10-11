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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Comparers;
    using Extensions;
    using Management.ResourceManager.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using SdkModels.Deployments;

    public class WhatIfOperationResultFormatter : WhatIfJsonFormatter
    {
        private const string PropertyModifyIndicator = "=>";

        private const string EmptyArray = "[]";

        public static string Format(PSWhatIfOperationResult result)
        {
            var formatter = new WhatIfOperationResultFormatter();

            formatter.FormatLegend(result.Changes);
            formatter.FormatResourceChanges(result.Changes);
            formatter.FormatStats(result.Changes);

            return formatter.Result;
        }

        private static int GetMaxPathLength(IList<PSWhatIfPropertyChange> propertyChanges)
        {
            if (propertyChanges == null)
            {
                return 0;
            }

            bool ShouldConsiderPathLength(PSWhatIfPropertyChange propertyChange)
            {
                switch (propertyChange.PropertyChangeType)
                {
                    case PropertyChangeType.Create:
                        return IsLeaf(propertyChange.After);

                    case PropertyChangeType.Delete:
                    case PropertyChangeType.Modify when propertyChange.Before != null:
                        return IsLeaf(propertyChange.Before);

                    default:
                        return propertyChange.Children == null || propertyChange.Children.Count == 0;
                }
            }

            return propertyChanges
                .Where(ShouldConsiderPathLength)
                .Select(pc => pc.Path.Length)
                .DefaultIfEmpty()
                .Max();
        }

        private void FormatStats(IList<PSWhatIfChange> resourceChanges)
        {
            this.Builder.AppendLine().Append("Resource changes: ");

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

        private string FormatChangeTypeCount(ChangeType changeType, int count)
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(changeType), changeType, null);
            }
        }

        private void FormatLegend(IList<PSWhatIfChange> resourceChanges)
        {
            if (resourceChanges == null || resourceChanges.Count == 0)
            {
                return;
            }

            var changeTypeSet = new HashSet<ChangeType>();

            void PopulateChangeTypeSet(IList<PSWhatIfPropertyChange> propertyChanges)
            {
                propertyChanges?.ForEach(propertyChange =>
                {
                    changeTypeSet.Add(propertyChange.PropertyChangeType.ToChangeType());
                    PopulateChangeTypeSet(propertyChange.Children);
                });
            }

            foreach (PSWhatIfChange resourceChange in resourceChanges)
            {
                changeTypeSet.Add(resourceChange.ChangeType);
                PopulateChangeTypeSet(resourceChange.Delta);
            }

            this.Builder
                .Append("Resource and property changes are indicated with ")
                .AppendLine(changeTypeSet.Count == 1 ? "this symbol:" : "these symbols:");

            changeTypeSet
                .OrderBy(changeType => changeType, new ChangeTypeComparer())
                .ForEach(changeType => this.Builder
                    .Append(Indent())
                    .Append(changeType.ToSymbol(), changeType.ToColor())
                    .Append(Symbol.WhiteSpace)
                    .Append(changeType)
                    .AppendLine());
        }

        private void FormatResourceChanges(IList<PSWhatIfChange> resourceChanges)
        {
            if (resourceChanges == null || resourceChanges.Count == 0)
            {
                return;
            }

            int scopeCount = resourceChanges.Select(rc => rc.Scope).Distinct().Count();

            this.Builder
                .AppendLine()
                .Append("The deployment will update the following ")
                .AppendLine(scopeCount == 1 ? "scope:" : "scopes:");

            resourceChanges
                .OrderBy(rc => rc.Scope)
                .GroupBy(rc => rc.Scope)
                .ToDictionary(g => g.Key, g => g.ToList())
                .ForEach(kvp => FormatResourceChangesOfScope(kvp.Key, kvp.Value));
        }

        private void FormatResourceChangesOfScope(string scope, IList<PSWhatIfChange> resourceChanges)
        {
            // Print scope.
            this.Builder.AppendLine().AppendLine($"Scope: {scope}");

            // Print resource changes.
            List<PSWhatIfChange> sortedResourceChanges = resourceChanges
                .OrderBy(rc => rc.ChangeType, new ChangeTypeComparer())
                .ThenBy(rc => rc.ShortResourceId)
                .ToList();

            sortedResourceChanges
                .GroupBy(rc => rc.ChangeType)
                .ToDictionary(g => g.Key, g => g.ToList())
                .ForEach(kv =>
                {
                    using (this.Builder.NewColorScope(kv.Key.ToColor()))
                    {
                        kv.Value.ForEach(rc => this.FormatResourceChange(rc, rc == sortedResourceChanges.Last()));
                    }
                });
        }

        private void FormatResourceChange(PSWhatIfChange resourceChange, bool isLast)
        {
            // Print resourceId.
            this.Builder
                .AppendLine()
                .Append(Indent())
                .Append(resourceChange.ChangeType.ToSymbol())
                .Append(Symbol.WhiteSpace)
                .Append(resourceChange.ShortResourceId);

            // Print properties.
            switch (resourceChange.ChangeType)
            {
                case ChangeType.Create when resourceChange.After != null:
                    this.FormatJson(resourceChange.After, indentLevel: 2);

                    break;

                case ChangeType.Delete when resourceChange.Before != null:
                    this.FormatJson(resourceChange.Before, indentLevel: 2);

                    break;

                case ChangeType.Deploy when resourceChange.Delta?.Count > 0:
                case ChangeType.Modify when resourceChange.Delta?.Count > 0:
                    using (this.Builder.NewColorScope(Color.Reset))
                    {
                        IList<PSWhatIfPropertyChange> propertyChanges = resourceChange.Delta
                            .OrderBy(pc => pc.PropertyChangeType, new PropertyChangeTypeComparer())
                            .ThenBy(pc => pc.Path)
                            .ToList();

                        this.Builder.AppendLine();
                        this.FormatPropertyChanges(propertyChanges);
                    }

                    break;

                default:
                    if (isLast)
                    {
                        this.Builder.AppendLine();
                    }

                    break;
            }
        }

        private void FormatPropertyChanges(IList<PSWhatIfPropertyChange> propertyChanges, int indentLevel = 2)
        {
            int maxPathLength = GetMaxPathLength(propertyChanges);
            propertyChanges.ForEach(pc =>
            {
                this.FormatPropertyChange(pc, maxPathLength, indentLevel);
                this.Builder.AppendLine();
            });
        }

        private void FormatPropertyChange(PSWhatIfPropertyChange propertyChange, int maxPathLength, int indentLevel)
        {
            this.FormatHead(propertyChange, maxPathLength, indentLevel);

            switch (propertyChange.PropertyChangeType)
            {
                case PropertyChangeType.Create:
                    this.FormatPropertyCreate(propertyChange.After, indentLevel + 1);
                    break;

                case PropertyChangeType.Delete:
                    this.FormatPropertyDelete(propertyChange.Before, indentLevel + 1);
                    break;

                case PropertyChangeType.Modify:
                    this.FormatPropertyModify(propertyChange, indentLevel + 1);
                    break;

                case PropertyChangeType.Array:
                    this.FormatPropertyArray(propertyChange.Children, indentLevel + 1);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void FormatPropertyCreate(JToken value, int indentLevel)
        {
            using (this.Builder.NewColorScope(Color.Green))
            {
                this.FormatJson(value, indentLevel: indentLevel);
            }
        }

        private void FormatPropertyDelete(JToken value, int indentLevel)
        {
            using (this.Builder.NewColorScope(Color.Red))
            {
                this.FormatJson(value, indentLevel: indentLevel);
            }
        }

        private void FormatPropertyModify(PSWhatIfPropertyChange propertyChange, int indentLevel)
        {
            if (propertyChange.Children != null)
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
                if (before is JObject objectValue && objectValue.Count > 0)
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
                this.Builder.Append(PropertyModifyIndicator);

                // Space after =>
                if (IsLeaf(after) || after is JArray)
                {
                    this.Builder.Append(Symbol.WhiteSpace);
                }

                // The after value.
                this.FormatPropertyCreate(after, indentLevel);

                if (!(before is JValue) && after is JValue)
                {
                    this.Builder.AppendLine();
                }
            }
        }

        private void FormatPropertyArray(IList<PSWhatIfPropertyChange> propertyChanges, int indentLevel)
        {
            if (propertyChanges.Count == 0)
            {
                this.Builder.AppendLine(EmptyArray);
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

        private void FormatHead(PSWhatIfPropertyChange propertyChange, int maxPathLength, int indentLevel)
        {
            this.FormatIndent(indentLevel);
            this.FormatPropertyChangeType(propertyChange.PropertyChangeType);
            this.FormatPath(propertyChange.Path);

            int paddingWidth = maxPathLength - propertyChange.Path.Length;

            switch (propertyChange.PropertyChangeType)
            {
                case PropertyChangeType.Create:
                    this.FormatPadding(propertyChange.After, paddingWidth);
                    break;

                case PropertyChangeType.Delete:
                case PropertyChangeType.Modify:
                    this.FormatPadding(propertyChange.Before, paddingWidth);
                    break;

                case PropertyChangeType.Array when propertyChange.Children?.Count == 0:
                    this.FormatPadding(EmptyArray, paddingWidth);
                    break;

                case PropertyChangeType.Array:
                    this.FormatPadding(1);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void FormatPropertyChangeType(PropertyChangeType propertyChangeType)
        {
            this.Builder
                .Append(propertyChangeType.ToSymbol(), propertyChangeType.ToColor())
                .Append(Symbol.WhiteSpace);
        }

        private void FormatPadding(JToken value, int paddingWidth)
        {
            if (IsLeaf(value))
            {
                // Add one for white space.
                this.FormatPadding(paddingWidth + 1);
            }
            else if (value is JArray)
            {
                this.FormatPadding(1);
            }
        }
    }
}

