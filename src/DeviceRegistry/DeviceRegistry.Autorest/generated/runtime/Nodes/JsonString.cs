/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.Json
{
    public sealed partial class JsonString : JsonNode, IEquatable<JsonString>
    {
        private readonly string value;

        internal JsonString(string value)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
        }

        internal override JsonType Type => JsonType.String;

        internal string Value => value;

        internal int Length => value.Length;

        #region #region Implicit Casts

        public static implicit operator string(JsonString data) => data.Value;

        public static implicit operator JsonString(string value) => new JsonString(value);

        #endregion

        public override int GetHashCode() => value.GetHashCode();

        public override string ToString() => value;

        #region IEquatable<JsonString>

        bool IEquatable<JsonString>.Equals(JsonString other) => this.Value == other.Value;

        #endregion
    }
}