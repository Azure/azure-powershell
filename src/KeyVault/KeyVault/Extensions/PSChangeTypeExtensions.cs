using Microsoft.Azure.Commands.KeyVault.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Extensions
{
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

        public static Color ToColor(this PSChangeType psChangeType)
        {
            bool success = ColorsByPSChangeType.TryGetValue(psChangeType, out Color colorCode);

            if (!success)
            {
                throw new ArgumentOutOfRangeException(nameof(psChangeType));
            }

            return colorCode;
        }

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
