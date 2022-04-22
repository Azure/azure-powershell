/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    public abstract partial class JsonArray : JsonNode, IEnumerable<JsonNode>
    {
        internal override JsonType Type => JsonType.Array;

        internal abstract JsonType? ElementType { get; }

        public abstract int Count { get; }

        internal virtual bool IsSet => false;

        internal bool IsEmpty => Count == 0;

        #region IEnumerable

        IEnumerator<JsonNode> IEnumerable<JsonNode>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Static Helpers

        internal static JsonArray Create(short[] values)
            => new XImmutableArray<short>(values);

        internal static JsonArray Create(int[] values)
            => new XImmutableArray<int>(values);

        internal static JsonArray Create(long[] values)
            => new XImmutableArray<long>(values);

        internal static JsonArray Create(decimal[] values)
            => new XImmutableArray<decimal>(values);

        internal static JsonArray Create(float[] values)
            => new XImmutableArray<float>(values);

        internal static JsonArray Create(string[] values)
            => new XImmutableArray<string>(values);

        internal static JsonArray Create(XBinary[] values)
            => new XImmutableArray<XBinary>(values);

        #endregion

        internal static new JsonArray Parse(string text)
            => (JsonArray)JsonNode.Parse(text);
    }
}