using System;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    //Based on https://github.com/PowerShell/PowerShell/blob/master/src/System.Management.Automation/utils/EncodingUtils.cs
    internal static class EncodingUtils
    {
        internal const string Unknown = "unknown";
        internal const string String = "string";
        internal const string Unicode = "unicode";
        internal const string BigEndianUnicode = "bigendianunicode";
        internal const string Ascii = "ascii";
        internal const string Utf8 = "utf8";
        internal const string Utf7 = "utf7";
        internal const string Utf32 = "utf32";
        internal const string Default = "default";
        internal const string Oem = "oem";
        internal const string BigEndianUtf32 = "bigendianutf32";
        internal const string Byte = "byte";
    }

    internal sealed class ArgumentToEncodingTransformationAttribute : ArgumentTransformationAttribute
    {
        public override object Transform(EngineIntrinsics engineIntrinsics, object inputData)
        {
            string encodingName = inputData as string;
            if (encodingName != null)
            {
                encodingName = encodingName.ToLower();
                switch (encodingName)
                {
                    case EncodingUtils.String:
                        return Encoding.UTF8;
                    case EncodingUtils.Unicode:
                        return Encoding.Unicode;
                    case EncodingUtils.BigEndianUnicode:
                        return Encoding.BigEndianUnicode;
                    case EncodingUtils.Utf8:
                        return Encoding.UTF8;
                    case EncodingUtils.Utf7:
                        return Encoding.UTF7;
                    case EncodingUtils.Utf32:
                        return Encoding.UTF32;
                    case EncodingUtils.Ascii:
                        return Encoding.ASCII;
                    case EncodingUtils.Default:
                        return Encoding.UTF8;
                    case EncodingUtils.Oem:
                        {
                            var oemCP = NativeMethods.GetOEMCP();
                            return Encoding.GetEncoding((int)oemCP);
                        }
                    case EncodingUtils.Byte:
                        return new ByteEncoding();
                    default:
                        // Default to unicode encoding
                        throw new ArgumentException($"{encodingName} is not a supported Encoding type");
                }
            }

            return inputData;
        }

    }

    internal static class NativeMethods
    {
        [DllImport("api-ms-win-core-localization-l1-2-1.dll", SetLastError = false, CharSet = CharSet.Unicode)]
        internal static extern uint GetOEMCP();
    }



}
