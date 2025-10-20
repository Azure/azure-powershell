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
    /// Extension methods for PropertyChangeType enum.
    /// </summary>
    public static class PropertyChangeTypeExtensions
    {
        private static readonly IReadOnlyDictionary<PropertyChangeType, Color> ColorsByPropertyChangeType =
            new Dictionary<PropertyChangeType, Color>
            {
                [PropertyChangeType.Create] = Color.Green,
                [PropertyChangeType.Delete] = Color.Orange,
                [PropertyChangeType.Modify] = Color.Purple,
                [PropertyChangeType.Array] = Color.Purple,
                [PropertyChangeType.NoEffect] = Color.Gray,
            };

        private static readonly IReadOnlyDictionary<PropertyChangeType, Symbol> SymbolsByPropertyChangeType =
            new Dictionary<PropertyChangeType, Symbol>
            {
                [PropertyChangeType.Create] = Symbol.Plus,
                [PropertyChangeType.Delete] = Symbol.Minus,
                [PropertyChangeType.Modify] = Symbol.Tilde,
                [PropertyChangeType.Array] = Symbol.Tilde,
                [PropertyChangeType.NoEffect] = Symbol.Cross,
            };

        private static readonly IReadOnlyDictionary<PropertyChangeType, PSChangeType> PSChangeTypesByPropertyChangeType =
            new Dictionary<PropertyChangeType, PSChangeType>
            {
                [PropertyChangeType.Create] = PSChangeType.Create,
                [PropertyChangeType.Delete] = PSChangeType.Delete,
                [PropertyChangeType.Modify] = PSChangeType.Modify,
                [PropertyChangeType.Array] = PSChangeType.Modify,
                [PropertyChangeType.NoEffect] = PSChangeType.NoEffect,
            };

        /// <summary>
        /// Converts a PropertyChangeType to its corresponding Color.
        /// </summary>
        public static Color ToColor(this PropertyChangeType propertyChangeType)
        {
            bool success = ColorsByPropertyChangeType.TryGetValue(propertyChangeType, out Color colorCode);

            if (!success)
            {
                throw new ArgumentOutOfRangeException(nameof(propertyChangeType));
            }

            return colorCode;
        }

        /// <summary>
        /// Converts a PropertyChangeType to its corresponding Symbol.
        /// </summary>
        public static Symbol ToSymbol(this PropertyChangeType propertyChangeType)
        {
            bool success = SymbolsByPropertyChangeType.TryGetValue(propertyChangeType, out Symbol symbol);

            if (!success)
            {
                throw new ArgumentOutOfRangeException(nameof(propertyChangeType));
            }

            return symbol;
        }

        /// <summary>
        /// Converts a PropertyChangeType to its corresponding PSChangeType.
        /// </summary>
        public static PSChangeType ToPSChangeType(this PropertyChangeType propertyChangeType)
        {
            bool success = PSChangeTypesByPropertyChangeType.TryGetValue(propertyChangeType, out PSChangeType changeType);

            if (!success)
            {
                throw new ArgumentOutOfRangeException(nameof(propertyChangeType));
            }

            return changeType;
        }

        /// <summary>
        /// Checks if the property change is a delete operation.
        /// </summary>
        public static bool IsDelete(this PropertyChangeType propertyChangeType)
        {
            return propertyChangeType == PropertyChangeType.Delete;
        }

        /// <summary>
        /// Checks if the property change is a create operation.
        /// </summary>
        public static bool IsCreate(this PropertyChangeType propertyChangeType)
        {
            return propertyChangeType == PropertyChangeType.Create;
        }

        /// <summary>
        /// Checks if the property change is a modify operation.
        /// </summary>
        public static bool IsModify(this PropertyChangeType propertyChangeType)
        {
            return propertyChangeType == PropertyChangeType.Modify;
        }

        /// <summary>
        /// Checks if the property change is an array operation.
        /// </summary>
        public static bool IsArray(this PropertyChangeType propertyChangeType)
        {
            return propertyChangeType == PropertyChangeType.Array;
        }
    }
}
