using System;
using System.IO;
using Newtonsoft.Json;
using Microsoft.CLU.Common.Properties;

namespace Microsoft.CLU
{
    /// <summary>
    /// Enum for supported primitve types.
    /// </summary>
    internal enum PrimitiveTypeCode
    {
        None,
        Char,
        Int16,
        UInt16,
        Int32,
        UInt32,
        Int64,
        UInt64,
        Single,
        Decimal,
        String,
        DateTimeOffset,
        DateTime,
        Uri,
        FileInfo,
        DirectoryInfo,
        JSON
    }

    /// <summary>
    /// Type that is used to help with operations on primitive types.
    /// </summary>
    internal static class PrimitiveType
    {
        /// <summary>
        /// Given string representaion of a primitive type, try to parse and convert it to an
        /// instance of primitive type.
        /// </summary>
        /// <param name="typeCode">Type code indicating the expected primitive type</param>
        /// <param name="strValue">Primitive value as string</param>
        /// <param name="value">strValue convered to primitive type</param>
        /// <returns>true if successfully parsed, false otherwise</returns>
        public static bool TryParse(PrimitiveTypeCode typeCode, string strValue, out object value)
        {
            value = null;
            bool parsed = false;
            switch (typeCode)
            {
                case PrimitiveTypeCode.Int16:
                    short s;
                    parsed = Int16.TryParse(strValue, out s);
                    value = s;
                    break;
                case PrimitiveTypeCode.UInt16:
                    ushort us;
                    parsed = UInt16.TryParse(strValue, out us);
                    value = us;
                    break;
                case PrimitiveTypeCode.Int32:
                    int i;
                    parsed = Int32.TryParse(strValue, out i);
                    value = i;
                    break;
                case PrimitiveTypeCode.UInt32:
                    uint ui;
                    parsed = UInt32.TryParse(strValue, out ui);
                    value = ui;
                    break;
                case PrimitiveTypeCode.Int64:
                    long l;
                    parsed = Int64.TryParse(strValue, out l);
                    value = l;
                    break;
                case PrimitiveTypeCode.UInt64:
                    ulong ul;
                    parsed = UInt64.TryParse(strValue, out ul);
                    value = ul;
                    break;
                case PrimitiveTypeCode.Single:
                    Single si;
                    parsed = Single.TryParse(strValue, out si);
                    value = si;
                    break;
                case PrimitiveTypeCode.Decimal:
                    Decimal d;
                    parsed = Decimal.TryParse(strValue, out d);
                    value = d;
                    break;
                case PrimitiveTypeCode.DateTime:
                    DateTime dt;
                    parsed = DateTime.TryParse(strValue, out dt);
                    value = dt;
                    break;
                case PrimitiveTypeCode.DateTimeOffset:
                    DateTimeOffset dto;
                    parsed = DateTimeOffset.TryParse(strValue, out dto);
                    value = dto;
                    break;
                case PrimitiveTypeCode.Uri:
                    try
                    {
                        value = new Uri(strValue);
                        parsed = true;
                    }
                    catch
                    {}
                    break;
                case PrimitiveTypeCode.FileInfo:
                    try
                    {
                        value = new FileInfo(strValue);
                        parsed = true;
                    }
                    catch
                    {}
                    break;
                case PrimitiveTypeCode.DirectoryInfo:
                    try
                    {
                        value = new DirectoryInfo(strValue);
                        parsed = true;
                    }
                    catch
                    {}
                    break;
                case PrimitiveTypeCode.String:
                    value = strValue;
                    parsed = true;
                    break;
                case PrimitiveTypeCode.JSON:
                    {
                        Exception exception = null;
                        try
                        {
                            value = JsonConvert.DeserializeObject(strValue);
                            parsed = true;
                        }
                        catch (Exception ex)
                        {
                            exception = ex;
                        }

                        return exception == null;
                    }
                default:
                    throw new ArgumentException(Strings.PrimitiveType_TryParse_InvalidCode);
            }

            return parsed;
        }
    }
}
