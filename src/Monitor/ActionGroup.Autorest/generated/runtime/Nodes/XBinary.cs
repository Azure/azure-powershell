/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.Json
{
    internal sealed class XBinary : JsonNode
    {
        private readonly byte[] _value;
        private readonly string _base64;

        internal XBinary(byte[] value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        internal XBinary(string base64EncodedString)
        {
            _base64 = base64EncodedString ?? throw new ArgumentNullException(nameof(base64EncodedString));
        }

        internal override JsonType Type => JsonType.Binary;

        internal byte[] Value => _value ?? Convert.FromBase64String(_base64);

        #region #region Implicit Casts

        public static implicit operator byte[] (XBinary data) => data.Value;

        public static implicit operator XBinary(byte[] data) => new XBinary(data);

        #endregion

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => _base64 ?? Convert.ToBase64String(_value);
    }
}