/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json
{
    using System;
    using System.Globalization;
    using System.Linq;

    public partial class JsonString
    {
        internal static string DateFormat = "yyyy-MM-dd";
        internal static string DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";
        internal static string DateTimeRfc1123Format = "R";

        internal static JsonString Create(string value) => value == null ? null : new JsonString(value);
        internal static JsonString Create(char? value) => value is char c ? new JsonString(c.ToString()) : null;

        internal static JsonString CreateDate(DateTime? value) => value is DateTime date ? new JsonString(date.ToString(DateFormat, CultureInfo.CurrentCulture)) : null;
        internal static JsonString CreateDateTime(DateTime? value) => value is DateTime date ? new JsonString(date.ToString(DateTimeFormat, CultureInfo.CurrentCulture)) : null;
        internal static JsonString CreateDateTimeRfc1123(DateTime? value) => value is DateTime date ? new JsonString(date.ToString(DateTimeRfc1123Format, CultureInfo.CurrentCulture)) : null;

        internal char ToChar() => this.Value?.ToString()?.FirstOrDefault() ?? default(char);
        public static implicit operator char(JsonString value) => value?.ToString()?.FirstOrDefault() ?? default(char);
        public static implicit operator char? (JsonString value) => value?.ToString()?.FirstOrDefault();

        public static implicit operator DateTime(JsonString value) => DateTime.TryParse(value, out var output) ? output : default(DateTime);
        public static implicit operator DateTime? (JsonString value) => DateTime.TryParse(value, out var output) ? output : default(DateTime?);

    }


}