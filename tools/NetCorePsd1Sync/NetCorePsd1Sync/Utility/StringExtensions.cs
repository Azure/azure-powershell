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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using NetCorePsd1Sync.Model;
using static NetCorePsd1Sync.Model.PsDefinitionConstants;
using static NetCorePsd1Sync.Utility.AttributeHelper;

namespace NetCorePsd1Sync.Utility
{
    internal static class StringExtensions
    {
        private static bool GetDescription<TClass, TProp>(Expression<Func<TClass, TProp>> propertySelector, out string description)
        {
            var hasDescription = TryGetPropertyAttributeValue<TClass, TProp, DescriptionAttribute, string>(propertySelector, attr => attr.Description, out description);
            description = hasDescription ? $"{CommentPrefix}{description}" : null;
            return hasDescription;
        }

        private static (TProp value, string firstLeader) GetValue<TClass, TProp>(TClass targetClass, Expression<Func<TClass, TProp>> propertySelector)
        {
            var value = propertySelector.Compile()(targetClass);
            // https://stackoverflow.com/a/7580347/294804
            var firstLeader = value != null ? String.Empty : CommentPrefix;
            var hasDisplayName = TryGetPropertyAttributeValue<TClass, TProp, DisplayNameAttribute, string>(propertySelector, attr => attr.DisplayName, out var displayName);
            return (value, $"{firstLeader}{(hasDisplayName ? $"{displayName}{NameValueDelimiter}" : String.Empty)}");
        }

        // https://blogs.msdn.microsoft.com/csharpfaq/2010/03/11/how-can-i-get-objects-and-property-values-from-expression-trees/
        public static IEnumerable<string> ToDefinitionEntry<TClass, TProp>(this TClass targetClass, Expression<Func<TClass, TProp>> propertySelector)
        {
            if (GetDescription(propertySelector, out var description)) yield return description;
            (var value, var firstLeader) = GetValue(targetClass, propertySelector);
            yield return $"{firstLeader}{CreateValue(value, ElementPrefix, ElementPostfix)}";
            yield return String.Empty;
        }

        private static string CreateValue<TProp>(TProp value, string valuePrefix, string valuePostfix) =>
            $"{valuePrefix}{(value == null ? String.Empty : value.ToString())}{valuePostfix}";

        public static IEnumerable<string> ToDefinitionEntry<TClass>(this TClass targetClass, Expression<Func<TClass, bool?>> propertySelector)
        {
            if (GetDescription(propertySelector, out var description)) yield return description;
            (var value, var firstLeader) = GetValue(targetClass, propertySelector);
            var boolValue = value != null && value.Value;
            yield return $"{firstLeader}{(boolValue ? "$true" : "$false")}";
            yield return String.Empty;
        }

        public static IEnumerable<string> ToDefinitionEntry<TClass>(this TClass targetClass, Expression<Func<TClass, PsDefinitionHeader>> propertySelector)
        {
            (var header, var _) = GetValue(targetClass, propertySelector);
            if (header == null) yield break;

            foreach (var headerLine in header.ToDefinitionEntry())
            {
                yield return headerLine;
            }
            yield return String.Empty;
        }

        public static IEnumerable<string> ToDefinitionEntry(this PsDefinition psDefinition, Expression<Func<PsDefinition, PrivateData>> propertySelector)
        {
            if (GetDescription(propertySelector, out var description)) yield return description;
            (var privateData, var privateDataLeader) = GetValue(psDefinition, propertySelector);
            var privateDataDisplayName = GetPropertyAttributeValue<PsDefinition, PrivateData, DisplayNameAttribute, string>(pd => pd.PrivateData, attr => attr.DisplayName, nameof(PrivateData));
            var privateDataFollower = privateData == null ? String.Empty : $" {CommentPrefix}End of {privateDataDisplayName} hashtable";
            foreach (var privateDataLine in privateData.ToDefinitionEntry().ToList().UpdateFirstAndLast(privateDataLeader, privateDataFollower))
            {
                yield return privateDataLine;
            }

            yield return String.Empty;
        }

        public static IEnumerable<string> ToDefinitionEntry<TClass, TList>(this TClass targetClass, Expression<Func<TClass, List<TList>>> propertySelector)
        {
            if (GetDescription(propertySelector, out var description)) yield return description;
            (var values, var firstLeader) = GetValue(targetClass, propertySelector);

            var isStringList = typeof(TList) == typeof(string);
            var listPrefix = isStringList ? String.Empty : ObjectListPrefix;
            var listPostfix = isStringList ? String.Empty : ObjectListPostfix;
            var valuePrefix = isStringList ? ElementPrefix : String.Empty;
            var valuePostfix = isStringList ? ElementPostfix : String.Empty;

            foreach (var propertyValue in CreateListValues(values, firstLeader, listPrefix, listPostfix, valuePrefix, valuePostfix, isStringList))
            {
                yield return propertyValue;
            }

            yield return String.Empty;
        }

        private const int MaxLineLength = 70;
        private static IEnumerable<string> CreateListValues<TList>(IReadOnlyList<TList> values, string firstLeader, 
            string listPrefix, string listPostfix, string valuePrefix, string valuePostfix, bool hasMaxLengthRestriction)
        {
            if (values == null || !values.Any())
            {
                yield return $"{firstLeader}{ObjectListPrefix}{ObjectListPostfix}";
                yield break;
            }

            var currentLine = String.Empty;
            var firstLine = true;

            string GetLeader() => firstLine ? $"{firstLeader}{listPrefix}" : Indent;
            bool IsFirst(int index) => index == 0;
            bool IsLast(int index) => index == values.Count - 1;

            for (var i = 0; i < values.Count; ++i)
            {
                var line = $"{valuePrefix}{values[i]}{valuePostfix}{(IsLast(i) ? listPostfix : ", ")}";
                var priorCurrentLine = currentLine;
                currentLine += line;
                if (IsFirst(i) || hasMaxLengthRestriction && currentLine.Length <= MaxLineLength) continue;

                yield return $"{GetLeader()}{priorCurrentLine}";
                currentLine = line;
                firstLine = false;
            }
            if (currentLine != String.Empty)
            {
                yield return $"{GetLeader()}{currentLine}";
            }
        }

        public static IEnumerable<string> ToDefinitionEntry(this PsDefinitionHeader header)
        {
            if (header == null) yield break;

            yield return CommentToken;
            var moduleDisplayName = GetPropertyAttributeValue<PsDefinitionHeader, string, DisplayNameAttribute, string>(pd => pd.ModuleName, attr => attr.DisplayName, String.Empty);
            yield return $"{CommentPrefix}{moduleDisplayName} {ElementPrefix}{header.ModuleName}{ElementPostfix}";
            yield return CommentToken;
            var authorDisplayName = GetPropertyAttributeValue<PsDefinitionHeader, string, DisplayNameAttribute, string>(pd => pd.Author, attr => attr.DisplayName, String.Empty);
            yield return $"{CommentPrefix}{authorDisplayName}{HeaderDelimiter}{header.Author}";
            yield return CommentToken;
            var dateDisplayName = GetPropertyAttributeValue<PsDefinitionHeader, DateTime, DisplayNameAttribute, string>(pd => pd.Date, attr => attr.DisplayName, String.Empty);
            yield return $"{CommentPrefix}{dateDisplayName}{HeaderDelimiter}{header.Date:d}";
            yield return CommentToken;
        }

        public static IEnumerable<string> ToDefinitionEntry(this PsData psData)
        {
            if (psData == null)
            {
                yield return $"{ObjectPrefix}{ObjectPostfix}";
                yield break;
            }

            yield return ObjectPrefix;
            yield return String.Empty;
            foreach (var tagLine in psData.ToDefinitionEntry(d => d.Tags))
            {
                yield return String.IsNullOrEmpty(tagLine) ? String.Empty : $"{Indent}{tagLine}";
            }
            foreach (var licenseUriLine in psData.ToDefinitionEntry(d => d.LicenseUri))
            {
                yield return String.IsNullOrEmpty(licenseUriLine) ? String.Empty : $"{Indent}{licenseUriLine}";
            }
            foreach (var projectUriLine in psData.ToDefinitionEntry(d => d.ProjectUri))
            {
                yield return String.IsNullOrEmpty(projectUriLine) ? String.Empty : $"{Indent}{projectUriLine}";
            }
            foreach (var iconUriLine in psData.ToDefinitionEntry(d => d.IconUri))
            {
                yield return String.IsNullOrEmpty(iconUriLine) ? String.Empty : $"{Indent}{iconUriLine}";
            }
            foreach (var releaseNoteLine in psData.ToDefinitionEntry(d => d.ReleaseNotes))
            {
                yield return String.IsNullOrEmpty(releaseNoteLine) ? String.Empty : $"{Indent}{releaseNoteLine}";
            }
            foreach (var prereleaseLine in psData.ToDefinitionEntry(d => d.Prerelease))
            {
                yield return String.IsNullOrEmpty(prereleaseLine) ? String.Empty : $"{Indent}{prereleaseLine}";
            }
            foreach (var requireLicenseLine in psData.ToDefinitionEntry(d => d.RequireLicenseAcceptance))
            {
                yield return String.IsNullOrEmpty(requireLicenseLine) ? String.Empty : $"{Indent}{requireLicenseLine}";
            }
            foreach (var dependenciesLine in psData.ToDefinitionEntry(d => d.ExternalModuleDependencies))
            {
                yield return String.IsNullOrEmpty(dependenciesLine) ? String.Empty : $"{Indent}{dependenciesLine}";
            }
            yield return ObjectPostfix;
        }

        public static IEnumerable<string> ToDefinitionEntry(this PrivateData privateData)
        {
            if (privateData == null)
            {
                yield return $"{ObjectPrefix}{ObjectPostfix}";
                yield break;
            }

            yield return ObjectPrefix;
            yield return String.Empty;

            var psDataDisplayName = GetPropertyAttributeValue<PrivateData, PsData, DisplayNameAttribute, string>(pd => pd.PsData, attr => attr.DisplayName, nameof(PsData));
            var psDataLeader = $"{psDataDisplayName}{NameValueDelimiter}";
            var psDataFollower = privateData.PsData == null ? String.Empty : $" {CommentPrefix}End of {psDataDisplayName} hashtable";
            foreach (var psDataLine in privateData.PsData.ToDefinitionEntry().ToList().UpdateFirstAndLast(psDataLeader, psDataFollower))
            {
                yield return String.IsNullOrEmpty(psDataLine) ? String.Empty : $"{Indent}{psDataLine}";
            }

            yield return String.Empty;
            yield return ObjectPostfix;
        }

        public static IEnumerable<string> ToDefinitionEntry(this PsDefinition definition)
        {
            foreach (var line in definition.ToDefinitionEntry(d => d.ManifestHeader)) yield return line;

            yield return ObjectPrefix;
            yield return String.Empty;

            foreach (var line in definition.ToDefinitionEntry(d => d.RootModule)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.ModuleVersion)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.CompatiblePsEditions)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.Guid)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.Author)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.CompanyName)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.Copyright)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.Description)) yield return line;

            foreach (var line in definition.ToDefinitionEntry(d => d.PowerShellVersion)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.PowerShellHostName)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.PowerShellHostVersion)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.DotNetFrameworkVersion)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.ClrVersion)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.ProcessorArchitecture)) yield return line;

            foreach (var line in definition.ToDefinitionEntry(d => d.RequiredModules)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.RequiredAssemblies)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.ScriptsToProcess)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.TypesToProcess)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.FormatsToProcess)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.NestedModules)) yield return line;

            foreach (var line in definition.ToDefinitionEntry(d => d.FunctionsToExport)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.CmdletsToExport)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.VariablesToExport)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.AliasesToExport)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.DscResourcesToExport)) yield return line;

            foreach (var line in definition.ToDefinitionEntry(d => d.ModuleList)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.FileList)) yield return line;

            foreach (var line in definition.ToDefinitionEntry(d => d.PrivateData)) yield return line;

            foreach (var line in definition.ToDefinitionEntry(d => d.HelpInfoUri)) yield return line;
            foreach (var line in definition.ToDefinitionEntry(d => d.DefaultCommandPrefix)) yield return line;

            yield return ObjectPostfix;
            yield return String.Empty;
        }
    }
}
