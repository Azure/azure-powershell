/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json
{
    internal sealed class XList<T> : JsonArray, IEnumerable<JsonNode>
    {
        private readonly IList<T> values;
        private readonly JsonType elementType;
        private readonly TypeCode elementCode;

        internal XList(IList<T> values)
        {
            this.values = values ?? throw new ArgumentNullException(nameof(values));
            this.elementCode = System.Type.GetTypeCode(typeof(T));
            this.elementType = XHelper.GetElementType(this.elementCode);
        }

        public override JsonNode this[int index] =>
            XHelper.Create(elementType, elementCode, values[index]);

        internal override JsonType? ElementType => elementType;

        public override int Count => values.Count;

        public bool IsReadOnly => values.IsReadOnly;

        #region IList

        public void Add(T value)
        {
            values.Add(value);
        }

        public bool Contains(T value) => values.Contains(value);

        #endregion

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
    }
}