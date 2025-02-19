/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.Json
{
    public sealed partial class JsonNumber : JsonNode
    {
        private readonly string value;
        private readonly bool overflows = false;

        internal JsonNumber(string value)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
        }

        internal JsonNumber(int value)
        {
            this.value = value.ToString();
        }

        internal JsonNumber(long value)
        {
            this.value = value.ToString();

            if (value > 9007199254740991)
            {
                overflows = true;
            }
        }

        internal JsonNumber(float value)
        {
            this.value = value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        internal JsonNumber(double value)
        {
            this.value = value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        internal override JsonType Type => JsonType.Number;

        internal string Value => value;

        #region Helpers

        internal bool Overflows => overflows;

        internal bool IsInteger => !value.Contains(".");

        internal bool IsFloat => value.Contains(".");

        #endregion

        #region Casting

        public static implicit operator byte(JsonNumber number)
            => byte.Parse(number.Value);

        public static implicit operator short(JsonNumber number)
            => short.Parse(number.Value);

        public static implicit operator int(JsonNumber number)
            => int.Parse(number.Value);

        public static implicit operator long(JsonNumber number)
            => long.Parse(number.value);

        public static implicit operator UInt16(JsonNumber number)
            => ushort.Parse(number.Value);

        public static implicit operator UInt32(JsonNumber number)
            => uint.Parse(number.Value);

        public static implicit operator UInt64(JsonNumber number)
            => ulong.Parse(number.Value);

        public static implicit operator decimal(JsonNumber number)
            => decimal.Parse(number.Value, System.Globalization.CultureInfo.InvariantCulture);

        public static implicit operator Double(JsonNumber number)
            => double.Parse(number.value, System.Globalization.CultureInfo.InvariantCulture);

        public static implicit operator float(JsonNumber number)
            => float.Parse(number.value, System.Globalization.CultureInfo.InvariantCulture);

        public static implicit operator JsonNumber(short data)
            => new JsonNumber(data.ToString());

        public static implicit operator JsonNumber(int data)
            => new JsonNumber(data);

        public static implicit operator JsonNumber(long data)
            => new JsonNumber(data);

        public static implicit operator JsonNumber(Single data)
            => new JsonNumber(data.ToString());

        public static implicit operator JsonNumber(double data)
            => new JsonNumber(data.ToString());

        #endregion

        public override string ToString() => value;
    }
}