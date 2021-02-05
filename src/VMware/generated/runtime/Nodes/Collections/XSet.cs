/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json
{
    internal sealed class XSet<T> : JsonArray, IEnumerable<JsonNode>
    {
        private readonly HashSet<T> values;
        private readonly JsonType elementType;
        private readonly TypeCode elementCode;

        internal XSet(IEnumerable<T> values)
            : this(new HashSet<T>(values))
        { }

        internal XSet(HashSet<T> values)
        {
            this.values = values ?? throw new ArgumentNullException(nameof(values));
            this.elementCode = System.Type.GetTypeCode(typeof(T));
            this.elementType = XHelper.GetElementType(this.elementCode);
        }

        internal override JsonType Type => JsonType.Array;

        internal override JsonType? ElementType => elementType;

        public bool IsReadOnly => true;

        public override int Count => values.Count;

        internal override bool IsSet => true;

        #region IEnumerable Members

        IEnumerator<JsonNode> IEnumerable<JsonNode>.GetEnumerator()
        {
            foreach (var value in values)
            {
                yield return XHelper.Create(elementType, elementCode, value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var value in values)
            {
                yield return XHelper.Create(elementType, elementCode, value);
            }
        }

        #endregion

        internal HashSet<T> AsHashSet() => values;
    }
}