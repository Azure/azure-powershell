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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using Formatters;
    using Management.ResourceManager.Models;
    using System;
    using System.Collections.Generic;

    public static class PropertyChangeTypeExtensions
    {
        private static readonly IReadOnlyDictionary<PropertyChangeType, Color> ColorsByPropertyChangeType =
            new Dictionary<PropertyChangeType, Color>
            {
                [PropertyChangeType.Create] = Color.Green,
                [PropertyChangeType.Delete] = Color.Orange,
                [PropertyChangeType.Modify] = Color.Purple,
                [PropertyChangeType.Array] = Color.Purple
            };

        private static readonly IReadOnlyDictionary<PropertyChangeType, Symbol> SymbolsByPropertyChangeType =
            new Dictionary<PropertyChangeType, Symbol>
            {
                [PropertyChangeType.Create] = Symbol.Plus,
                [PropertyChangeType.Delete] = Symbol.Minus,
                [PropertyChangeType.Modify] = Symbol.Tilde,
                [PropertyChangeType.Array] = Symbol.Tilde
            };

        private static readonly IReadOnlyDictionary<PropertyChangeType, ChangeType> ChangeTypesByPropertyChangeType =
            new Dictionary<PropertyChangeType, ChangeType>
            {
                [PropertyChangeType.Create] = ChangeType.Create,
                [PropertyChangeType.Delete] = ChangeType.Delete,
                [PropertyChangeType.Modify] = ChangeType.Modify,
                [PropertyChangeType.Array] = ChangeType.Modify
            };

        public static Color ToColor(this PropertyChangeType propertyChangeType)
        {
            bool success = ColorsByPropertyChangeType.TryGetValue(propertyChangeType, out Color colorCode);

            if (!success)
            {
                throw new ArgumentOutOfRangeException(nameof(propertyChangeType));
            }

            return colorCode;
        }

        public static Symbol ToSymbol(this PropertyChangeType propertyChangeType)
        {
            bool success = SymbolsByPropertyChangeType.TryGetValue(propertyChangeType, out Symbol symbol);

            if (!success)
            {
                throw new ArgumentOutOfRangeException(nameof(propertyChangeType));
            }

            return symbol;
        }

        public static ChangeType ToChangeType(this PropertyChangeType propertyChangeType)
        {
            bool success = ChangeTypesByPropertyChangeType.TryGetValue(propertyChangeType, out ChangeType changeType);

            if (!success)
            {
                throw new ArgumentOutOfRangeException(nameof(propertyChangeType));
            }

            return changeType;
        }

        public static bool IsDelete(this PropertyChangeType propertyChangeType)
        {
            return propertyChangeType == PropertyChangeType.Delete;
        }

        public static bool IsCreate(this PropertyChangeType propertyChangeType)
        {
            return propertyChangeType == PropertyChangeType.Create;
        }

        public static bool IsModify(this PropertyChangeType propertyChangeType)
        {
            return propertyChangeType == PropertyChangeType.Modify;
        }

        public static bool IsArray(this PropertyChangeType propertyChangeType)
        {
            return propertyChangeType == PropertyChangeType.Array;
        }
    }
}

