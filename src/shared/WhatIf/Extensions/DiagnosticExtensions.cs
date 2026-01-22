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

namespace Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Extensions
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Formatters;

    /// <summary>
    /// Extension methods for diagnostic levels to map to colors.
    /// </summary>
    public static class DiagnosticExtensions
    {
        /// <summary>
        /// Common diagnostic level strings.
        /// </summary>
        public static class Level
        {
            public const string Error = "Error";
            public const string Warning = "Warning";
            public const string Info = "Info";
        }

        private static readonly IReadOnlyDictionary<string, Color> ColorsByDiagnosticLevel =
            new Dictionary<string, Color>
            {
                [Level.Error] = Color.Red,
                [Level.Warning] = Color.DarkYellow,
                [Level.Info] = Color.Reset,
            };

        /// <summary>
        /// Converts a diagnostic level string to a Color.
        /// </summary>
        /// <param name="level">The diagnostic level.</param>
        /// <returns>The corresponding color, or Gray if not found.</returns>
        public static Color ToColor(this string level)
        {
            bool success = ColorsByDiagnosticLevel.TryGetValue(level, out Color colorCode);

            if (!success)
            {
                return Color.Gray;
            }

            return colorCode;
        }
    }
}
