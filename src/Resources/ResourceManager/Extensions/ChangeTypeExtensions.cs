namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using Formatters;
    using Management.ResourceManager.Models;
    using System;
    using System.Collections.Generic;

    public static class ChangeTypeExtensions
    {
        private static readonly IReadOnlyDictionary<ChangeType, Color> ColorsByChangeType =
            new Dictionary<ChangeType, Color>
            {
                [ChangeType.NoChange] = Color.Reset,
                [ChangeType.Ignore] = Color.Cyan,
                [ChangeType.Deploy] = Color.Blue,
                [ChangeType.Create] = Color.Green,
                [ChangeType.Delete] = Color.Red,
                [ChangeType.Modify] = Color.Yellow
            };

        private static readonly IReadOnlyDictionary<ChangeType, Symbol> SymbolsByChangeType =
            new Dictionary<ChangeType, Symbol>
            {
                [ChangeType.NoChange] = Symbol.Equal,
                [ChangeType.Ignore] = Symbol.Asterisk,
                [ChangeType.Deploy] = Symbol.ExclamationPoint,
                [ChangeType.Create] = Symbol.Plus,
                [ChangeType.Delete] = Symbol.Minus,
                [ChangeType.Modify] = Symbol.Tilde
            };

        public static Color ToColor(this ChangeType changeType)
        {
            bool success = ColorsByChangeType.TryGetValue(changeType, out Color colorCode);

            if (!success)
            {
                throw new ArgumentOutOfRangeException(nameof(changeType));
            }

            return colorCode;
        }

        public static Symbol ToSymbol(this ChangeType changeType)
        {
            bool success = SymbolsByChangeType.TryGetValue(changeType, out Symbol symbol);

            if (!success)
            {
                throw new ArgumentOutOfRangeException(nameof(changeType));
            }

            return symbol;
        }
    }
}

