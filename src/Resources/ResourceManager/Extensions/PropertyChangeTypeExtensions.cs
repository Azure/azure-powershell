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
                [PropertyChangeType.Delete] = Color.Red,
                [PropertyChangeType.Modify] = Color.Yellow,
                [PropertyChangeType.Array] = Color.Yellow
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

