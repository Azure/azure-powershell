/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    internal sealed class XImmutableArray<T> : JsonArray, IEnumerable<JsonNode>
    {
        private readonly T[] values;
        private readonly JsonType elementType;
        private readonly TypeCode elementCode;

        internal XImmutableArray(T[] values)
        {
            this.values = values ?? throw new ArgumentNullException(nameof(values));
            this.elementCode = System.Type.GetTypeCode(typeof(T));
            this.elementType = XHelper.GetElementType(this.elementCode);
        }

        public override JsonNode this[int index] => 
            XHelper.Create(elementType, elementCode, values[index]);

        internal override JsonType? ElementType => elementType;

        public override int Count => values.Length;

        public bool IsReadOnly => true;

        #region IEnumerable Members

        IEnumerator<JsonNode> IEnumerable<JsonNode>.GetEnumerator()
        {
            foreach (T value in values)
            {
                yield return XHelper.Create(elementType, elementCode, value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (T value in values)
            {
                yield return XHelper.Create(elementType, elementCode, value);
            }
        }

        #endregion

        #region Static Constructor

        internal XImmutableArray<T> Create(T[] items)
        {
            return new XImmutableArray<T>(items);
        }

        #endregion
    }
}