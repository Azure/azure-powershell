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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
    using System;
    using System.Collections.Generic;

    public static class ChangeTypeExtensions
    {
        private static readonly IReadOnlyDictionary<ChangeType, Color> ColorsByChangeType =
            new Dictionary<ChangeType, Color>
            {
                [ChangeType.NoChange] = Color.Reset,
                [ChangeType.Ignore] = Color.Gray,
                [ChangeType.Deploy] = Color.Blue,
                [ChangeType.Create] = Color.Green,
                [ChangeType.Delete] = Color.Orange,
                [ChangeType.Modify] = Color.Purple,
                [ChangeType.Unsupported] = Color.Gray,
            };

        private static readonly IReadOnlyDictionary<ChangeType, Symbol> SymbolsByChangeType =
            new Dictionary<ChangeType, Symbol>
            {
                [ChangeType.NoChange] = Symbol.Equal,
                [ChangeType.Ignore] = Symbol.Asterisk,
                [ChangeType.Deploy] = Symbol.ExclamationPoint,
                [ChangeType.Create] = Symbol.Plus,
                [ChangeType.Delete] = Symbol.Minus,
                [ChangeType.Modify] = Symbol.Tilde,
                [ChangeType.Unsupported] = Symbol.Cross,
            };

        private static readonly IReadOnlyDictionary<ChangeType, PSChangeType> PSChangeTypesByChangeType =
            new Dictionary<ChangeType, PSChangeType>
            {
                [ChangeType.NoChange] = PSChangeType.NoChange,
                [ChangeType.Ignore] = PSChangeType.Ignore,
                [ChangeType.Deploy] = PSChangeType.Deploy,
                [ChangeType.Create] = PSChangeType.Create,
                [ChangeType.Delete] = PSChangeType.Delete,
                [ChangeType.Modify] = PSChangeType.Modify,
                [ChangeType.Unsupported] = PSChangeType.Unsupported,
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

        public static PSChangeType ToPSChangeType(this ChangeType changeType)
        {
            bool success = PSChangeTypesByChangeType.TryGetValue(changeType, out PSChangeType psChangeType);

            if (!success)
            {
                throw new ArgumentOutOfRangeException(nameof(changeType));
            }

            return psChangeType;
        }

    }
}


