using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    //Based on https://github.com/PowerShell/PowerShell/blob/master/src/System.Management.Automation/utils/EncodingUtils.cs
    internal class EncodingUtils
    {
        internal static class EncodingConversion
        {
            internal const string Unknown = "unknown";
            internal const string String = "string";
            internal const string Unicode = "unicode";
            internal const string Byte = "byte";
            internal const string BigEndianUnicode = "bigendianunicode";
            internal const string Ascii = "ascii";
            internal const string Utf8 = "utf8";
            internal const string Utf7 = "utf7";
            internal const string Utf32 = "utf32";
            internal const string Default = "default";
            internal const string Oem = "oem";
            internal const string BigEndianUtf32 = "bigendianutf32";

            internal static readonly string[] TabCompletionResults =
            {
                Unknown, String, Unicode, Byte, BigEndianUnicode, Ascii, Utf8, Utf7, Utf32, Default, Oem, BigEndianUtf32
            };
            internal static Encoding Convert(Cmdlet cmdlet, string encoding)
            {
                switch (encoding)
                {
                    case EncodingConversion.Byte:
                    case EncodingConversion.String:
                        return Encoding.UTF8;
                    case EncodingConversion.Unicode:
                        return Encoding.Unicode;
                    case EncodingConversion.BigEndianUnicode:
                        return Encoding.BigEndianUnicode;
                    case EncodingConversion.Utf8:
                        return Encoding.UTF8;
                    case EncodingConversion.Utf7:
                        return Encoding.UTF7;
                    case EncodingConversion.Utf32:
                        return Encoding.UTF32;
                    case EncodingConversion.Ascii:
                        return Encoding.ASCII;
                    case EncodingConversion.Default:
                        return Encoding.UTF8;
                    case EncodingConversion.Oem:
                    {
                        var oemCP = NativeMethods.GetOEMCP();
                        return Encoding.GetEncoding((int)oemCP);
                    }
                    
                }

                // error condition: unknown encoding value
                string validEncodingValues = string.Join(", ", TabCompletionResults);
                string msg = "somjething";

                ErrorRecord errorRecord = new ErrorRecord(
                    new ArgumentException("Encoding"),
                    "WriteToFileEncodingUnknown",
                    ErrorCategory.InvalidArgument,
                    null);

                errorRecord.ErrorDetails = new ErrorDetails(msg);
                cmdlet.ThrowTerminatingError(errorRecord);

                return null;
            }

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
                        case EncodingConversion.String:
                            return Encoding.UTF8;
                        case EncodingConversion.Unicode:
                            return Encoding.Unicode;
                        case EncodingConversion.BigEndianUnicode:
                            return Encoding.BigEndianUnicode;
                        case EncodingConversion.Utf8:
                            return Encoding.UTF8;
                        case EncodingConversion.Utf7:
                            return Encoding.UTF7;
                        case EncodingConversion.Utf32:
                            return Encoding.UTF32;
                        case EncodingConversion.Ascii:
                            return Encoding.ASCII;
                        case EncodingConversion.Default:
                            return Encoding.UTF8;
                        case EncodingConversion.Oem:
                        {
                            var oemCP = NativeMethods.GetOEMCP();
                            return Encoding.GetEncoding((int) oemCP);
                        }
                        default:
                            // Default to unicode encoding
                            return Encoding.UTF8;
                    }
                }

                return inputData;
            }

        }

        /// <summary>
        /// Duplicate of 
        /// https://github.com/PowerShell/PowerShell/blob/master/src/System.Management.Automation/engine/CommandCompletion/ExtensibleCompletion.cs#L169
        /// Current version of system.management.automation does not have this
        /// </summary>
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
        public class ArgumentCompletionsAttribute : Attribute
        {
            private string[] _completions;

            /// <summary>
            /// Initializes a new instance of the ArgumentCompletionsAttribute class
            /// </summary>
            /// <param name="completions">list of complete values</param>
            /// <exception cref="ArgumentNullException">for null arguments</exception>
            /// <exception cref="ArgumentOutOfRangeException">for invalid arguments</exception>
            public ArgumentCompletionsAttribute(params string[] completions)
            {
                if (completions == null)
                {
                    throw new ArgumentNullException(nameof(completions));
                }

                if (completions.Length == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(completions));
                }

                _completions = completions;
            }

            /// <summary>
            /// The function returns completions for arguments.
            /// </summary>
            public IEnumerable<CompletionResult> CompleteArgument(string commandName, string parameterName, string wordToComplete, CommandAst commandAst, IDictionary fakeBoundParameters)
            {
                var wordToCompletePattern = WildcardPattern.Get(string.IsNullOrWhiteSpace(wordToComplete) ? "*" : wordToComplete + "*", WildcardOptions.IgnoreCase);

                foreach (var str in _completions)
                {
                    if (wordToCompletePattern.IsMatch(str))
                    {
                        yield return new CompletionResult(str, str, CompletionResultType.ParameterValue, str);
                    }
                }
            }
        }

        public class EncodingCompleterAttribute : ArgumentCompleterAttribute
        {
            public EncodingCompleterAttribute() : base(CreateScriptBlock())
            {
            }
            public static string[] FindEncodings()
            {
                return new String[] { EncodingConversion.Unknown, EncodingConversion.String, EncodingConversion.Unicode, EncodingConversion.Byte, EncodingConversion.BigEndianUnicode, EncodingConversion.Ascii, EncodingConversion.Utf8, EncodingConversion.Utf7, EncodingConversion.Utf32, EncodingConversion.Default, EncodingConversion.Oem, EncodingConversion.BigEndianUtf32 };
            }

            /// <summary>
            /// Create ScriptBlock that registers the correct location for tab completetion of the -Location parameter
            /// </summary>
            /// <param name="resourceTypes"></param>
            /// <returns></returns>
            public static ScriptBlock CreateScriptBlock()
            {
                string script =
                    "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                    "$locations = [Microsoft.Azure.Commands.DataLakeStore.Models.EncodingCompleterAttribute]::FindEncodings()\n" +
                    "$locations | Where-Object { $_ -Like \"'$wordToComplete*\" } | Sort-Object | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
                ScriptBlock scriptBlock = ScriptBlock.Create(script);
                return scriptBlock;
            }
        }
    }
}
