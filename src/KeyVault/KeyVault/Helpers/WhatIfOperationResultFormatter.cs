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

using Microsoft.Azure.Commands.KeyVault.Comparers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.KeyVault.Extensions;
using Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault.Helpers
{
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
            Builder
                .AppendLine("WhatIfNoiseNotice")
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
                case PropertyChangeType.NoEffect:
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
            Builder.AppendLine().Append("Resource changes: ");

            if (resourceChanges == null || resourceChanges.Count == 0)
            {
                Builder.Append("no change");
            }
            else
            {
                IEnumerable<string> stats = resourceChanges
                    .OrderBy(rc => rc.ChangeType, new ChangeTypeComparer())
                    .GroupBy(rc => rc.ChangeType)
                    .Select(g => new { ChangeType = g.Key, Count = g.Count() })
                    .Where(x => x.Count != 0)
                    .Select(x => FormatChangeTypeCount(x.ChangeType, x.Count));

                Builder.Append(string.Join(", ", stats));
            }

            Builder.Append(".");
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
                case ChangeType.Unsupported:
                    return $"{count} unsupported";
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

            var psChangeTypeSet = new HashSet<PSChangeType>();

            void PopulateChangeTypeSet(IList<PSWhatIfPropertyChange> propertyChanges)
            {
                propertyChanges?.ForEach(propertyChange =>
                {
                    psChangeTypeSet.Add(propertyChange.PropertyChangeType.ToPSChangeType());
                    PopulateChangeTypeSet(propertyChange.Children);
                });
            }

            foreach (PSWhatIfChange resourceChange in resourceChanges)
            {
                psChangeTypeSet.Add(resourceChange.ChangeType.ToPSChangeType());
                PopulateChangeTypeSet(resourceChange.Delta);
            }

            Builder
                .Append("Resource and property changes are indicated with ")
                .AppendLine(psChangeTypeSet.Count == 1 ? "this symbol:" : "these symbols:");

            psChangeTypeSet
                .OrderBy(x => x, new PSChangeTypeComparer())
                .ForEach(x => Builder
                    .Append(Indent())
                    .Append(x.ToSymbol(), x.ToColor())
                    .Append(Symbol.WhiteSpace)
                    .Append(x)
                    .AppendLine());
        }

        private void FormatResourceChanges(IList<PSWhatIfChange> resourceChanges)
        {
            if (resourceChanges == null || resourceChanges.Count == 0)
            {
                return;
            }

            int scopeCount = resourceChanges.Select(rc => rc.Scope.ToUpperInvariant()).Distinct().Count();

            Builder
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
            Builder
                .AppendLine()
                .AppendLine($"Scope: {scope}");

            // Resource changes.
            List<PSWhatIfChange> sortedResourceChanges = resourceChanges
                .OrderBy(rc => rc.ChangeType, new ChangeTypeComparer())
                .OrderBy(rc => rc.RelativeResourceId)
                .ToList();

            sortedResourceChanges
                .GroupBy(rc => rc.ChangeType)
                .ToDictionary(g => g.Key, g => g.ToList())
                .ForEach(kvp =>
                {
                    using (Builder.NewColorScope(kvp.Key.ToColor()))
                    {
                        kvp.Value.ForEach(rc => FormatResourceChange(rc, rc == sortedResourceChanges.Last()));
                    }
                });
        }

        private void FormatResourceChange(PSWhatIfChange resourceChange, bool isLast)
        {
            Builder.AppendLine();
            FormatResourceChangePath(
                resourceChange.ChangeType,
                resourceChange.RelativeResourceId,
                resourceChange.ApiVersion);

            switch (resourceChange.ChangeType)
            {
                case ChangeType.Create when resourceChange.After != null:
                    FormatJson(resourceChange.After, indentLevel: 2);

                    return;

                case ChangeType.Delete when resourceChange.Before != null:
                    FormatJson(resourceChange.Before, indentLevel: 2);

                    return;

                default:
                    if (resourceChange.Delta?.Count > 0)
                    {
                        using (Builder.NewColorScope(Color.Reset))
                        {
                            IList<PSWhatIfPropertyChange> propertyChanges = resourceChange.Delta
                                .OrderBy(pc => pc.PropertyChangeType, new PropertyChangeTypeComparer())
                                .ThenBy(pc => pc.Path)
                                .ToList();

                            Builder.AppendLine();
                            FormatPropertyChanges(propertyChanges);
                        }

                        return;
                    }

                    if (isLast)
                    {
                        Builder.AppendLine();
                    }

                    return;
            }
        }

        private void FormatResourceChangePath(ChangeType changeType, string relativeResourceId, string apiVersion)
        {
            FormatPath(
                relativeResourceId,
                0,
                1,
                () => Builder.Append(changeType.ToSymbol()).Append(Symbol.WhiteSpace),
                () => FormatResourceChangeApiVersion(apiVersion));
        }

        private void FormatResourceChangeApiVersion(string apiVersion)
        {
            if (string.IsNullOrEmpty(apiVersion))
            {
                return;
            }

            using (Builder.NewColorScope(Color.Reset))
            {
                Builder
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
                FormatPropertyChange(pc, maxPathLength, indentLevel);
                Builder.AppendLine();
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
                    FormatPropertyChangePath(propertyChangeType, path, after, children, maxPathLength, indentLevel);
                    FormatPropertyCreate(after, indentLevel + 1);
                    break;

                case PropertyChangeType.Delete:
                    FormatPropertyChangePath(propertyChangeType, path, before, children, maxPathLength, indentLevel);
                    FormatPropertyDelete(before, indentLevel + 1);
                    break;

                case PropertyChangeType.Modify:
                    FormatPropertyChangePath(propertyChangeType, path, before, children, maxPathLength, indentLevel);
                    FormatPropertyModify(propertyChange, indentLevel + 1);
                    break;

                case PropertyChangeType.Array:
                    FormatPropertyChangePath(propertyChangeType, path, null, children, maxPathLength, indentLevel);
                    FormatPropertyArrayChange(propertyChange.Children, indentLevel + 1);
                    break;

                case PropertyChangeType.NoEffect:
                    FormatPropertyChangePath(propertyChangeType, path, after, children, maxPathLength, indentLevel);
                    FormatPropertyNoEffect(after, indentLevel + 1);
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

            if (valueAfterPath.IsNonEmptyArray() || propertyChangeType == PropertyChangeType.Array && hasChildren)
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

            FormatPath(
                path,
                paddingWidth,
                indentLevel,
                () => FormatPropertyChangeType(propertyChangeType),
                FormatColon);
        }

        private void FormatPropertyChangeType(PropertyChangeType propertyChangeType)
        {
            Builder
                .Append(propertyChangeType.ToSymbol(), propertyChangeType.ToColor())
                .Append(Symbol.WhiteSpace);
        }

        private void FormatPropertyCreate(JToken value, int indentLevel)
        {
            using (Builder.NewColorScope(Color.Green))
            {
                FormatJson(value, indentLevel: indentLevel);
            }
        }

        private void FormatPropertyDelete(JToken value, int indentLevel)
        {
            using (Builder.NewColorScope(Color.Orange))
            {
                FormatJson(value, indentLevel: indentLevel);
            }
        }

        private void FormatPropertyModify(PSWhatIfPropertyChange propertyChange, int indentLevel)
        {
            if (propertyChange.Children != null)
            {
                // Has nested changes.
                Builder.AppendLine().AppendLine();
                FormatPropertyChanges(propertyChange.Children
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
                FormatPropertyDelete(before, indentLevel);

                // Space before =>
                if (before.IsNonEmptyObject())
                {
                    Builder
                        .AppendLine()
                        .Append(Indent(indentLevel));
                }
                else
                {
                    Builder.Append(Symbol.WhiteSpace);
                }

                // =>
                Builder.Append("=>");

                // Space after =>
                if (!after.IsNonEmptyObject())
                {
                    Builder.Append(Symbol.WhiteSpace);
                }

                // The after value.
                FormatPropertyCreate(after, indentLevel);

                if (!before.IsLeaf() && after.IsLeaf())
                {
                    Builder.AppendLine();
                }
            }
        }

        private void FormatPropertyArrayChange(IList<PSWhatIfPropertyChange> propertyChanges, int indentLevel)
        {
            if (propertyChanges.Count == 0)
            {
                Builder.AppendLine("[]");
                return;
            }

            // [
            Builder
                .Append(Symbol.LeftSquareBracket)
                .AppendLine();

            FormatPropertyChanges(propertyChanges
                    .OrderBy(pc => int.Parse(pc.Path))
                    .ThenBy(pc => pc.PropertyChangeType, new PropertyChangeTypeComparer())
                    .ToList(),
                indentLevel);

            // ]
            Builder
                .Append(Indent(indentLevel))
                .Append(Symbol.RightSquareBracket);
        }

        private void FormatPropertyNoEffect(JToken value, int indentLevel)
        {
            using (Builder.NewColorScope(Color.Gray))
            {
                FormatJson(value, indentLevel: indentLevel);
            }
        }
    }
}