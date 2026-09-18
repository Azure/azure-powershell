/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.Json
{
    internal static class XHelper
    {
        internal static JsonNode Create(JsonType type, TypeCode code, object value)
        {
            switch (type)
            {
                case JsonType.Binary  : return new XBinary((byte[])value);
                case JsonType.Boolean : return new JsonBoolean((bool)value);
                case JsonType.Number  : return new JsonNumber(value.ToString());
                case JsonType.String  : return new JsonString((string)value);
            }

            throw new Exception($"JsonType '{type}' does not have a fast conversion");
        }

        internal static bool TryGetElementType(TypeCode code, out JsonType type)
        {
            switch (code)
            {
                case TypeCode.Boolean  : type = JsonType.Boolean;  return true;
                case TypeCode.Byte     : type = JsonType.Number;   return true;
                case TypeCode.DateTime : type = JsonType.Date;     return true;
                case TypeCode.Decimal  : type = JsonType.Number;   return true;
                case TypeCode.Double   : type = JsonType.Number;   return true;
                case TypeCode.Empty    : type = JsonType.Null;     return true;
                case TypeCode.Int16    : type = JsonType.Number;   return true;
                case TypeCode.Int32    : type = JsonType.Number;   return true;
                case TypeCode.Int64    : type = JsonType.Number;   return true;
                case TypeCode.SByte    : type = JsonType.Number;   return true;
                case TypeCode.Single   : type = JsonType.Number;   return true;
                case TypeCode.String   : type = JsonType.String;   return true;
                case TypeCode.UInt16   : type = JsonType.Number;   return true;
                case TypeCode.UInt32   : type = JsonType.Number;   return true;
                case TypeCode.UInt64   : type = JsonType.Number;   return true;
            }

            type = default;

            return false;
        }

        internal static JsonType GetElementType(TypeCode code)
        {
            switch (code)
            {
                case TypeCode.Boolean   : return JsonType.Boolean;
                case TypeCode.Byte      : return JsonType.Number;
                case TypeCode.DateTime  : return JsonType.Date;
                case TypeCode.Decimal   : return JsonType.Number;
                case TypeCode.Double    : return JsonType.Number;
                case TypeCode.Empty     : return JsonType.Null;
                case TypeCode.Int16     : return JsonType.Number;
                case TypeCode.Int32     : return JsonType.Number;
                case TypeCode.Int64     : return JsonType.Number;
                case TypeCode.SByte     : return JsonType.Number;
                case TypeCode.Single    : return JsonType.Number;
                case TypeCode.String    : return JsonType.String;
                case TypeCode.UInt16    : return JsonType.Number;
                case TypeCode.UInt32    : return JsonType.Number;
                case TypeCode.UInt64    : return JsonType.Number;
                default                 : return JsonType.Object;
            }

            throw new Exception($"TypeCode '{code}' does not have a fast converter");
        }
    }
}