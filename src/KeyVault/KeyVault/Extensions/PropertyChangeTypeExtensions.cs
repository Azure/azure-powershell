using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Extensions
{
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

        public static PSChangeType ToPSChangeType(this PropertyChangeType propertyChangeType)
        {
            bool success = PSChangeTypesByPropertyChangeType.TryGetValue(propertyChangeType, out PSChangeType changeType);

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
