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
    using Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models;

    /// <summary>
    /// Extension methods for PSChangeType enum.
    /// </summary>
    public static class PSChangeTypeExtensions
    {
        private static readonly IReadOnlyDictionary<PSChangeType, Color> ColorsByPSChangeType =
            new Dictionary<PSChangeType, Color>
            {
                [PSChangeType.NoChange] = Color.Reset,
                [PSChangeType.Ignore] = Color.Gray,
                [PSChangeType.Deploy] = Color.Blue,
                [PSChangeType.Create] = Color.Green,
                [PSChangeType.Delete] = Color.Orange,
                [PSChangeType.Modify] = Color.Purple,
                [PSChangeType.Unsupported] = Color.Gray,
                [PSChangeType.NoEffect] = Color.Gray,
            };

        private static readonly IReadOnlyDictionary<PSChangeType, Symbol> SymbolsByPSChangeType =
            new Dictionary<PSChangeType, Symbol>
            {
                [PSChangeType.NoChange] = Symbol.Equal,
                [PSChangeType.Ignore] = Symbol.Asterisk,
                [PSChangeType.Deploy] = Symbol.ExclamationPoint,
                [PSChangeType.Create] = Symbol.Plus,
                [PSChangeType.Delete] = Symbol.Minus,
                [PSChangeType.Modify] = Symbol.Tilde,
                [PSChangeType.Unsupported] = Symbol.Cross,
                [PSChangeType.NoEffect] = Symbol.Cross,
            };

        /// <summary>
        /// Converts a PSChangeType to its corresponding Color.
        /// </summary>
        public static Color ToColor(this PSChangeType psChangeType)
        {
            bool success = ColorsByPSChangeType.TryGetValue(psChangeType, out Color colorCode);

            if (!success)
            {
                throw new ArgumentOutOfRangeException(nameof(psChangeType));
            }

            return colorCode;
        }

        /// <summary>
        /// Converts a PSChangeType to its corresponding Symbol.
        /// </summary>
        public static Symbol ToSymbol(this PSChangeType psChangeType)
        {
            bool success = SymbolsByPSChangeType.TryGetValue(psChangeType, out Symbol symbol);

            if (!success)
            {
                throw new ArgumentOutOfRangeException(nameof(psChangeType));
            }

            return symbol;
        }
    }
}
