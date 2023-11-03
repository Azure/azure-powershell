/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json
{
    using System;

    public partial class JsonNumber
    {
        internal static readonly DateTime EpochDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static long ToUnixTime(DateTime dateTime)
        {
            return (long)dateTime.Subtract(EpochDate).TotalSeconds;
        }
        private static DateTime FromUnixTime(long totalSeconds)
        {
            return EpochDate.AddSeconds(totalSeconds);
        }
        internal byte ToByte() => this;
        internal int ToInt() => this;
        internal long ToLong() => this;
        internal short ToShort() => this;
        internal UInt16 ToUInt16() => this;
        internal UInt32 ToUInt32() => this;
        internal UInt64 ToUInt64() => this;
        internal decimal ToDecimal() => this;
        internal double ToDouble() => this;
        internal float ToFloat() => this;

        internal static JsonNumber Create(int? value) => value is int n ? new JsonNumber(n) : null;
        internal static JsonNumber Create(long? value) => value is long n ? new JsonNumber(n) : null;
        internal static JsonNumber Create(float? value) => value is float n ? new JsonNumber(n) : null;
        internal static JsonNumber Create(double? value) => value is double n ? new JsonNumber(n) : null;
        internal static JsonNumber Create(decimal? value) => value is decimal n ? new JsonNumber(n) : null;
        internal static JsonNumber Create(DateTime? value) => value is DateTime date ? new JsonNumber(ToUnixTime(date)) : null;

        public static implicit operator DateTime(JsonNumber number) => FromUnixTime(number);
        internal DateTime ToDateTime() => this;

        internal JsonNumber(decimal value)
        {
            this.value = value.ToString();
        }
        internal override object ToValue()
        {
            if (IsInteger)
            {
                if (int.TryParse(this.value, out int iValue))
                {
                    return iValue;
                }
                if (long.TryParse(this.value, out long lValue))
                {
                    return lValue;
                }
            }
            else
            {
                if (float.TryParse(this.value, out float fValue))
                {
                    return fValue;
                }
                if (double.TryParse(this.value, out double dValue))
                {
                    return dValue;
                }
                if (decimal.TryParse(this.value, out decimal dcValue))
                {
                    return dcValue;
                }
            }
            return null;
        }
    }


}