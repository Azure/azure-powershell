/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.Json
{
    

    internal sealed partial class JsonDate : JsonNode, IEquatable<JsonDate>, IComparable<JsonDate>
    {
        internal static bool AssumeUtcWhenKindIsUnspecified = true;

        private readonly DateTimeOffset value;

        internal JsonDate(DateTime value)
        {
            if (value.Kind == DateTimeKind.Unspecified && AssumeUtcWhenKindIsUnspecified)
            {
                value = DateTime.SpecifyKind(value, DateTimeKind.Utc);
            }

            this.value = value;
        }

        internal JsonDate(DateTimeOffset value)
        {
            this.value = value;
        }

        internal override JsonType Type => JsonType.Date;

        #region Helpers

        internal DateTimeOffset ToDateTimeOffset()
        {
            return value;
        }

        internal DateTime ToDateTime()
        {
            if (value.Offset == TimeSpan.Zero)
            {
                return value.UtcDateTime;
            }

            return value.DateTime;
        }

        internal DateTime ToUtcDateTime() => value.UtcDateTime;

        internal int ToUnixTimeSeconds()
        {
            return (int)value.ToUnixTimeSeconds();
        }

        internal long ToUnixTimeMilliseconds()
        {
            return (int)value.ToUnixTimeMilliseconds();
        }

        internal string ToIsoString()
        {
            return IsoDate.FromDateTimeOffset(value).ToString();
        }

        #endregion

        public override string ToString()
        {
            return ToIsoString();
        }

        internal static new JsonDate Parse(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            // TODO support: unixtimeseconds.partialseconds

            if (text.Length > 4 && _IsNumber(text)) // UnixTime
            {
                var date = DateTimeOffset.FromUnixTimeSeconds(long.Parse(text));

                return new JsonDate(date);
            }
            else if (text.Length <= 4 || text[4] == '-') // ISO: 2012-
            {
                return new JsonDate(IsoDate.Parse(text).ToDateTimeOffset());
            }
            else
            {
                // NOT ISO ENCODED
                // "Thu, 5 Apr 2012 16:59:01 +0200",
                return new JsonDate(DateTimeOffset.Parse(text));
            }
        }

        private static bool _IsNumber(string text)
        {
            foreach (var c in text)
            {
                if (!char.IsDigit(c)) return false;
            }

            return true;
        }

        internal static JsonDate FromUnixTime(int seconds)
        {
            return new JsonDate(DateTimeOffset.FromUnixTimeSeconds(seconds));
        }

        internal static JsonDate FromUnixTime(double seconds)
        {
            var milliseconds = (long)(seconds * 1000d);

            return new JsonDate(DateTimeOffset.FromUnixTimeMilliseconds(milliseconds));
        }

        #region Implicit Casts

        public static implicit operator DateTimeOffset(JsonDate value)
            => value.ToDateTimeOffset();

        public static implicit operator DateTime(JsonDate value)
            => value.ToDateTime();

        // From Date
        public static implicit operator JsonDate(DateTimeOffset value)
        {
            return new JsonDate(value);
        }
        
        public static implicit operator JsonDate(DateTime value)
        {
            return new JsonDate(value);
        }

        // From String
        public static implicit operator JsonDate(string value)
        {
            return Parse(value);
        }

        #endregion

        #region Equality

        public override bool Equals(object obj)
        {
            return obj is JsonDate date && date.value == this.value;
        }

        public bool Equals(JsonDate other)
        {
            return this.value == other.value;
        }

        public override int GetHashCode() => value.GetHashCode();

        #endregion

        #region IComparable<XDate> Members

        int IComparable<JsonDate>.CompareTo(JsonDate other)
        {
            return value.CompareTo(other.value);
        }

        #endregion
    }
}