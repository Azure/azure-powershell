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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Formatter for Deployment Stack What-If operation results.
    /// Produces output matching Azure CLI format exactly.
    /// </summary>
    public class DeploymentStackWhatIfFormatter
    {
        private const int IndentSize = 2;

        private static readonly string[] AllWhatIfTopLevelChangeTypes = new[]
        {
            "Create",
            "Unsupported",
            "Modify",
            "Delete",
            "NoChange",
            "Detach"
        };

        private static readonly Dictionary<string, string> ChangeTypeSymbols = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Array", "~" },
            { "Create", "+" },
            { "Delete", "-" },
            { "Detach", "v" },
            { "Modify", "~" },
            { "NoChange", "=" },
            { "NoEffect", "=" },
            { "Unsupported", "!" }
        };

        private static readonly Dictionary<string, Color> ChangeTypeColors = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase)
        {
            { "Array", Color.Purple },
            { "Create", Color.Green },
            { "Delete", Color.Red },
            { "Detach", Color.Blue },
            { "Modify", Color.Purple }
        };

        private readonly ColoredStringBuilder builder;
        private PSDeploymentStackWhatIfResult whatIfResult;
        private DeploymentStackWhatIfProperties whatIfProps;
        private DeploymentStackWhatIfChanges whatIfChanges;

        public DeploymentStackWhatIfFormatter(ColoredStringBuilder builder)
        {
            this.builder = builder ?? new ColoredStringBuilder();
        }

        /// <summary>
        /// Formats a Deployment Stack What-If result.
        /// </summary>
        public static string Format(PSDeploymentStackWhatIfResult result)
        {
            if (result == null)
            {
                return null;
            }

            var builder = new ColoredStringBuilder();
            var formatter = new DeploymentStackWhatIfFormatter(builder);

            return formatter.FormatInternal(result);
        }

        private string FormatInternal(PSDeploymentStackWhatIfResult result)
        {
            this.whatIfResult = result;
            this.whatIfProps = result.Properties;
            this.whatIfChanges = this.whatIfProps?.Changes;

            if (FormatChangeTypeLegend())
            {
                this.builder.EnsureNumNewLines(2);
            }

            if (FormatStackChanges())
            {
                this.builder.EnsureNumNewLines(2);
            }

            if (FormatResourceChangesAndDeletionSummary())
            {
                this.builder.EnsureNumNewLines(2);
            }

            FormatDiagnostics();

            string output = this.builder.ToString();

            this.whatIfResult = null;
            this.whatIfProps = null;
            this.whatIfChanges = null;

            return output;
        }

        private bool FormatChangeTypeLegend()
        {
            const int changeTypeMaxLength = 20;

            this.builder.AppendLine("Resource and property changes are indicated with these symbols:");
            this.builder.PushIndent(new string(' ', IndentSize));

            for (int i = 0; i < AllWhatIfTopLevelChangeTypes.Length; i++)
            {
                string changeType = AllWhatIfTopLevelChangeTypes[i];
                var (symbol, color) = GetChangeTypeFormatting(changeType);

                this.builder.Append(symbol, color).Append(" ");
                this.builder.Append(changeType.PadRight(changeTypeMaxLength - symbol.Length));

                if (i % 2 == 0 && i < AllWhatIfTopLevelChangeTypes.Length - 1)
                {
                    this.builder.Append(" ");
                }
                else if (i < AllWhatIfTopLevelChangeTypes.Length - 1)
                {
                    this.builder.AppendLine();
                }
            }

            this.builder.PopIndent();
            this.builder.AppendLine();

            return true;
        }

        private bool FormatStackChanges()
        {
            if (this.whatIfChanges == null)
            {
                return false;
            }

            bool printed = false;
            int titleIndex = this.builder.GetCurrentIndex();

            if (this.whatIfChanges.DeploymentScopeChange != null &&
                !IsNullNoChange(this.whatIfChanges.DeploymentScopeChange))
            {
                if (FormatPrimitiveChange(this.whatIfChanges.DeploymentScopeChange, "DeploymentScope"))
                {
                    printed = true;
                }
            }

            if (this.whatIfChanges.DenySettingsChange != null)
            {
                if (FormatDenySettingsChange(this.whatIfChanges.DenySettingsChange))
                {
                    printed = true;
                }
            }

            if (printed)
            {
                this.builder.InsertLine(titleIndex,
                    $"Changes to Stack {this.whatIfProps.DeploymentStackResourceId}:",
                    Color.DarkYellow);
            }

            return printed;
        }

        private bool FormatDenySettingsChange(DeploymentStackChangeDeltaRecord denySettingsChange)
        {
            if (denySettingsChange?.Delta == null || denySettingsChange.Delta.Count == 0)
            {
                return false;
            }

            bool printed = false;

            foreach (var change in denySettingsChange.Delta)
            {
                string fullPath = $"DenySettings.{change.Path}";

                if (string.Equals(change.ChangeType, "Array", StringComparison.OrdinalIgnoreCase))
                {
                    if (FormatArrayChange(change, fullPath))
                    {
                        printed = true;
                    }
                }
                else
                {
                    if (FormatPrimitiveChange(change, fullPath))
                    {
                        printed = true;
                    }
                }
            }

            return printed;
        }

        private bool FormatArrayChange(DeploymentStackPropertyChange arrayChange, string path)
        {
            var (symbol, color) = GetChangeTypeFormatting("Modify");

            this.builder.Append(symbol, color).Append(" ").Append(path).AppendLine(": ", color);
            this.builder.PushIndent(new string(' ', IndentSize));

            if (arrayChange.Children != null && arrayChange.Children.Count > 0)
            {
                bool hasIndices = arrayChange.Children.All(c => !string.IsNullOrEmpty(c.Path));

                var sortedChildren = hasIndices
                    ? arrayChange.Children.OrderBy(c => int.TryParse(c.Path, out int idx) ? idx : int.MaxValue).ToList()
                    : arrayChange.Children.ToList();

                foreach (var child in sortedChildren)
                {
                    if (hasIndices)
                    {
                        var (childSymbol, childColor) = GetChangeTypeFormatting(child.ChangeType);
                        this.builder.Append(childSymbol, childColor).AppendLine($" {child.Path}:");
                        this.builder.PushIndent(new string(' ', IndentSize));

                        FormatPrimitiveValue(child);

                        this.builder.PopIndent();
                    }
                    else
                    {
                        FormatPrimitiveValue(child);
                    }
                }
            }

            this.builder.PopIndent();

            return true;
        }

        private void FormatPrimitiveValue(DeploymentStackPropertyChange change)
        {
            var (symbol, color) = GetChangeTypeFormatting(change.ChangeType);
            this.builder.Append(symbol, color).Append(" ").AppendLine(FormatValue(change.After), color);
        }

        private bool FormatResourceChangesAndDeletionSummary()
        {
            if (this.whatIfChanges?.ResourceChanges == null || this.whatIfChanges.ResourceChanges.Count == 0)
            {
                return false;
            }

            bool printed = false;
            var resourceChangesSorted = SortResourceChanges(this.whatIfChanges.ResourceChanges);

            if (FormatResourceChanges(resourceChangesSorted))
            {
                printed = true;
            }

            if (FormatResourceDeletionsSummary(resourceChangesSorted))
            {
                printed = true;
            }

            return printed;
        }

        private List<DeploymentStackResourceChange> SortResourceChanges(
            IList<DeploymentStackResourceChange> resourceChanges)
        {
            return resourceChanges
                .OrderBy(x => string.IsNullOrEmpty(x.Id) ? 1 : 0)
                .ThenBy(x => GetChangeCertaintyPriority(x.ChangeCertainty))
                .ThenBy(x => x.Id?.ToLowerInvariant() ?? "")
                .ThenBy(x => x.Extension?.Name ?? "")
                .ThenBy(x => x.Extension?.Version ?? "")
                .ToList();
        }

        private int GetChangeCertaintyPriority(string certainty)
        {
            return string.Equals(certainty, "Definite", StringComparison.OrdinalIgnoreCase) ? 0 : 1;
        }

        private bool FormatResourceChanges(List<DeploymentStackResourceChange> resourceChangesSorted)
        {
            if (resourceChangesSorted == null || resourceChangesSorted.Count == 0)
            {
                return false;
            }

            this.builder.AppendLine("Changes to Managed Resources:", Color.DarkYellow);
            this.builder.AppendLine();

            string lastGroup = null;
            bool hasPotentialChanges = false;

            foreach (var change in resourceChangesSorted)
            {
                string group = FormatResourceClassHeader(change);

                if (group != lastGroup)
                {
                    lastGroup = group;
                    hasPotentialChanges = false;
                    this.builder.AppendLine(group);
                }

                if (!hasPotentialChanges &&
                    string.Equals(change.ChangeCertainty, "Potential", StringComparison.OrdinalIgnoreCase))
                {
                    this.builder.Append(">> ").AppendLine(
                        "Potential Resource Changes (Learn more at https://aka.ms/whatIfPotentialChanges)",
                        Color.Purple);
                    hasPotentialChanges = true;
                }

                FormatResourceChange(change);
            }

            return true;
        }

        private void FormatResourceChange(DeploymentStackResourceChange resourceChange)
        {
            FormatResourceHeadingLine(resourceChange);

            this.builder.PushIndent(new string(' ', IndentSize));

            if (resourceChange.ManagementStatusChange != null)
            {
                FormatPrimitiveChange(resourceChange.ManagementStatusChange, "Management Status");
            }

            if (resourceChange.DenyStatusChange != null)
            {
                FormatPrimitiveChange(resourceChange.DenyStatusChange, "Deny Status");
            }

            if (resourceChange.ResourceConfigurationChanges?.Delta != null)
            {
                foreach (var delta in resourceChange.ResourceConfigurationChanges.Delta)
                {
                    if (string.Equals(delta.ChangeType, "Array", StringComparison.OrdinalIgnoreCase))
                    {
                        FormatArrayChange(delta, delta.Path);
                    }
                    else
                    {
                        FormatPrimitiveChange(delta, delta.Path);
                    }
                }
            }

            this.builder.PopIndent();
        }

        private void FormatResourceHeadingLine(DeploymentStackResourceChange resourceChange)
        {
            var (symbol, color) = GetChangeTypeFormatting(resourceChange.ChangeType);
            bool isPotential = string.Equals(resourceChange.ChangeCertainty, "Potential", StringComparison.OrdinalIgnoreCase);

            if (isPotential)
            {
                this.builder.Append("?", Color.Cyan);
            }

            this.builder.Append(symbol, color).Append(" ");

            if (isPotential)
            {
                this.builder.Append("[Potential] ", Color.Cyan);
            }

            string resourceId = !string.IsNullOrEmpty(resourceChange.Id)
                ? resourceChange.Id
                : $"{resourceChange.Type} {FormatExtResourceIdentifiers(resourceChange.Identifiers)}";

            // Source API version from top-level apiVersion, or fall back to resourceConfigurationChanges.after
            string apiVersion = resourceChange.ApiVersion;
            if (string.IsNullOrEmpty(apiVersion) && resourceChange.ResourceConfigurationChanges?.After is JObject afterObj)
            {
                apiVersion = afterObj["apiVersion"]?.ToString();
            }

            string heading = !string.IsNullOrEmpty(apiVersion)
                ? $"{resourceId} [{apiVersion}]"
                : resourceId;

            this.builder.AppendLine(heading, color);
        }

        private bool FormatResourceDeletionsSummary(List<DeploymentStackResourceChange> resourceChangesSorted)
        {
            var deleteChanges = resourceChangesSorted
                .Where(x => string.Equals(x.ChangeType, "Delete", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (deleteChanges.Count == 0)
            {
                return false;
            }

            this.builder.Append("Deleting - ", Color.Red);
            this.builder.AppendLine($"Resources Marked for Deletion {deleteChanges.Count} total:");
            this.builder.AppendLine();

            string lastGroup = null;
            bool hasPotentialDeletions = false;

            foreach (var change in deleteChanges)
            {
                string group = FormatResourceClassHeader(change);

                if (group != lastGroup)
                {
                    lastGroup = group;
                    hasPotentialDeletions = false;
                    this.builder.AppendLine(group);
                }

                if (!hasPotentialDeletions &&
                    string.Equals(change.ChangeCertainty, "Potential", StringComparison.OrdinalIgnoreCase))
                {
                    int numPotential = deleteChanges.Skip(deleteChanges.IndexOf(change))
                        .TakeWhile(c => string.Equals(c.ChangeCertainty, "Potential", StringComparison.OrdinalIgnoreCase))
                        .Count();

                    this.builder.Append(">> ").AppendLine(
                        $"Potential Deletions {numPotential} total (Learn more at https://aka.ms/whatIfPotentialChanges)",
                        Color.Red);
                    hasPotentialDeletions = true;
                }

                FormatResourceHeadingLine(change);
            }

            return true;
        }

        private void FormatDiagnostics()
        {
            if (this.whatIfProps?.Diagnostics == null || this.whatIfProps.Diagnostics.Count == 0)
            {
                return;
            }

            var diagnosticsSorted = this.whatIfProps.Diagnostics
                .OrderBy(x => GetDiagnosticLevelPriority(x.Level))
                .ThenBy(x => x.Code ?? "")
                .ToList();

            this.builder.AppendLine($"Diagnostics ({diagnosticsSorted.Count}):");

            foreach (var diagnostic in diagnosticsSorted)
            {
                Color color = GetDiagnosticColor(diagnostic.Level);
                this.builder.AppendLine(
                $"{diagnostic.Level?.ToUpperInvariant()}: [{diagnostic.Code}] {diagnostic.Message}",
                color);
            }
        }

        private bool FormatPrimitiveChange(object change, string path)
        {
            var baseChange = change as DeploymentStackChangeBase;
            var propertyChange = change as DeploymentStackPropertyChange;

            if (baseChange == null && propertyChange == null)
            {
                return false;
            }

            object before = baseChange?.Before ?? propertyChange?.Before;
            object after = baseChange?.After ?? propertyChange?.After;
            string changeType = baseChange?.ChangeType ?? propertyChange?.ChangeType;

            if (changeType == null)
            {
                changeType = Equals(before, after) ? "NoEffect" : "Modify";
            }

            var (symbol, color) = GetChangeTypeFormatting(changeType);

            this.builder.Append(symbol, color).Append(" ");
            this.builder.Append(path).Append(": ");

            if (string.Equals(changeType, "Modify", StringComparison.OrdinalIgnoreCase))
            {
                this.builder.AppendLine($"{FormatValue(before)} => {FormatValue(after)}", color);
            }
            else
            {
                object value = string.Equals(changeType, "Delete", StringComparison.OrdinalIgnoreCase) ? before : after;
                this.builder.AppendLine(FormatValue(value));
            }

            return true;
        }

        private static bool IsNullValue(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is JToken token)
            {
                return token.Type == JTokenType.Null;
            }

            return false;
        }

        private static bool IsNullNoChange(DeploymentStackChangeBase change)
        {
            if (change == null)
            {
                return true;
            }

            bool isNoChange = change.ChangeType == null ||
                string.Equals(change.ChangeType, "NoChange", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(change.ChangeType, "NoEffect", StringComparison.OrdinalIgnoreCase);

            return isNoChange && IsNullValue(change.Before) && IsNullValue(change.After);
        }

        private static string FormatValue(object value)
        {
            if (value == null)
            {
                return "null";
            }

            if (value is string strValue)
            {
                return $"\"{strValue}\"";
            }

            if (value is bool boolValue)
            {
                return $"\"{(boolValue ? "True" : "False")}\"";
            }

            return value.ToString();
        }

        private static (string symbol, Color color) GetChangeTypeFormatting(string changeType)
        {
            if (changeType == null)
            {
                return (null, Color.Reset);
            }

            string symbol;
            if (!ChangeTypeSymbols.TryGetValue(changeType, out symbol))
            {
                symbol = "?";
            }

            Color color;
            if (!ChangeTypeColors.TryGetValue(changeType, out color))
            {
                color = Color.Reset;
            }

            return (symbol, color);
        }

        private static string FormatResourceClassHeader(DeploymentStackResourceChange change)
        {
            if (!string.IsNullOrEmpty(change.Id))
            {
                return "Azure";
            }

            if (change.Extension == null)
            {
                return "Unknown";
            }

            string result = $"{change.Extension.Name}@{change.Extension.Version}";

            if (change.Extension.Config != null && change.Extension.Config.Count > 0)
            {
                var configParts = new List<string>();

                foreach (var kvp in change.Extension.Config.OrderBy(c => c.Value?.KeyVaultReference != null).ThenBy(c => c.Key))
                {
                    if (kvp.Value == null)
                    {
                        continue;
                    }

                    if (kvp.Value.KeyVaultReference != null)
                    {
                        string secretName = kvp.Value.KeyVaultReference.SecretName;
                        string secretVersion = kvp.Value.KeyVaultReference.SecretVersion;
                        string kvId = kvp.Value.KeyVaultReference.KeyVault?.Id;
                        string versionSuffix = !string.IsNullOrEmpty(secretVersion) ? $"@{secretVersion}" : "";

                        configParts.Add($"{kvp.Key}=<Secret '{secretName}'{versionSuffix} in key vault '{kvId}'>");
                    }
                    else if (kvp.Value.Value != null)
                    {
                        string jsonValue = JsonConvert.SerializeObject(kvp.Value.Value);
                        configParts.Add($"{kvp.Key}={jsonValue}");
                    }
                }

                if (configParts.Count > 0)
                {
                    result += $" {string.Join(", ", configParts)}";
                }
            }

            return result;
        }

        private static string FormatExtResourceIdentifiers(IDictionary<string, object> identifiers)
        {
            if (identifiers == null || identifiers.Count == 0)
            {
                return string.Empty;
            }

            return string.Join(", ", identifiers.OrderBy(kvp => kvp.Key)
                .Select(kvp => $"{kvp.Key}={JsonConvert.SerializeObject(kvp.Value)}"));
        }

        private static int GetDiagnosticLevelPriority(string level)
        {
            switch (level?.ToLowerInvariant())
            {
                case "info":
                    return 1;
                case "warning":
                    return 2;
                case "error":
                    return 3;
                default:
                    return 0;
            }
        }

        private static Color GetDiagnosticColor(string level)
        {
            switch (level?.ToLowerInvariant())
            {
                case "warning":
                    return Color.DarkYellow;
                case "error":
                    return Color.Red;
                default:
                    return Color.Reset;
            }
        }
    }
}