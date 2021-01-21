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
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using Properties;
    using SdkModels.Deployments;

    public class WhatIfOperationResultFormatter : WhatIfJsonFormatter
    {
        private WhatIfOperationResultFormatter(ColoredStringBuilder builder)
            : base(builder)
        {
        }

        public static string Format(PSWhatIfOperationResult result)
        {
            if (result == null)
            {
                return null;
            }

            var builder = new ColoredStringBuilder();
            var formatter = new WhatIfOperationResultFormatter(builder);

            formatter.FormatNoiseNotice();
            formatter.FormatLegend(result.Changes);
            formatter.FormatResourceChanges(result.Changes);
            formatter.FormatStats(result.Changes);

            return builder.ToString();
        }

        private void FormatNoiseNotice()
        {
            this.Builder
                .AppendLine(Resources.WhatIfNoiseNotice)
                .AppendLine();
        }

        private static int GetMaxPathLength(IList<PSWhatIfPropertyChange> propertyChanges)
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

        private static bool ShouldConsiderPathLength(PSWhatIfPropertyChange propertyChange)
        {
            switch (propertyChange.PropertyChangeType)
            {
                case PropertyChangeType.Create:
                    return propertyChange.After.IsLeaf();

                case PropertyChangeType.Delete:
                case PropertyChangeType.Modify:
                    return propertyChange.Before.IsLeaf();

                default:
                    return propertyChange.Children == null || propertyChange.Children.Count == 0;
            }
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

            int scopeCount = resourceChanges.Select(rc => rc.Scope.ToUpperInvariant()).Distinct().Count();

            this.Builder
                .AppendLine()
                .Append("The deployment will update the following ")
                .AppendLine(scopeCount == 1 ? "scope:" : "scopes:");

            resourceChanges
                .OrderBy(rc => rc.Scope.ToUpperInvariant())
                .GroupBy(rc => rc.Scope.ToUpperInvariant())
                .ToDictionary(g => g.Key, g => g.ToList())
                .ForEach(kvp => FormatResourceChangesInScope(kvp.Value[0].Scope, kvp.Value));
        }

        private void FormatResourceChangesInScope(string scope, IList<PSWhatIfChange> resourceChanges)
        {
            // Scope.
            this.Builder
                .AppendLine()
                .AppendLine($"Scope: {scope}");

            // Resource changes.
            List<PSWhatIfChange> sortedResourceChanges = resourceChanges
                .OrderBy(rc => rc.ChangeType, new ChangeTypeComparer())
                .ThenBy(rc => rc.RelativeResourceId)
                .ToList();

            sortedResourceChanges
                .GroupBy(rc => rc.ChangeType)
                .ToDictionary(g => g.Key, g => g.ToList())
                .ForEach(kvp =>
                {
                    using (this.Builder.NewColorScope(kvp.Key.ToColor()))
                    {
                        kvp.Value.ForEach(rc => this.FormatResourceChange(rc, rc == sortedResourceChanges.Last()));
                    }
                });
        }

        private void FormatResourceChange(PSWhatIfChange resourceChange, bool isLast)
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

                    return;

                default:
                    if (isLast)
                    {
                        this.Builder.AppendLine();
                    }

                    return;
            }
        }

        private void FormatResourceChangePath(ChangeType changeType, string relativeResourceId, string apiVersion)
        {
            this.FormatPath(
                relativeResourceId,
                0,
                1,
                () => this.Builder.Append(changeType.ToSymbol()).Append(Symbol.WhiteSpace),
                () => this.FormatResourceChangeApiVersion(apiVersion));
        }

        private void FormatResourceChangeApiVersion(string apiVersion)
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
            //this.FormatHead(propertyChange, maxPathLength, indentLevel);

            PropertyChangeType propertyChangeType = propertyChange.PropertyChangeType;
            string path = propertyChange.Path;
            JToken before = propertyChange.Before;
            JToken after = propertyChange.After;
            IList<PSWhatIfPropertyChange> children = propertyChange.Children;

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
                    this.FormatPropertyArrayChange(propertyChange.Children, indentLevel + 1);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void FormatPropertyChangePath(
            PropertyChangeType propertyChangeType,
            string path,
            JToken valueAfterPath,
            IList<PSWhatIfPropertyChange> children,
            int maxPathLength,
            int indentLevel)
        {
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

        private void FormatPropertyChangeType(PropertyChangeType propertyChangeType)
        {
            this.Builder
                .Append(propertyChangeType.ToSymbol(), propertyChangeType.ToColor())
                .Append(Symbol.WhiteSpace);
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
            using (this.Builder.NewColorScope(Color.Orange))
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

        private void FormatPropertyArrayChange(IList<PSWhatIfPropertyChange> propertyChanges, int indentLevel)
        {
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
    }
}

