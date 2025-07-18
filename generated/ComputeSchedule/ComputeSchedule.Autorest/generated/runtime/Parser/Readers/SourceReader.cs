/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Globalization;
using System.IO;

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Json
{
    public sealed class SourceReader : IDisposable
    {
        private readonly TextReader source;

        private char current;

        private readonly SourceLocation location = new SourceLocation();

        private bool isEof = false;
        
        internal SourceReader(TextReader textReader)
        {
            this.source = textReader ?? throw new ArgumentNullException(nameof(textReader));
        }

        /// <summary>
        /// Advances to the next character
        /// </summary>
        internal void Next()
        {
            // Advance to the new line when we see a new line '\n'.
            // A new line may be prefixed by a carriage return  '\r'. 

            if (current == '\n')
            {
                location.MarkNewLine();
            }

            int charCode = source.Read(); // -1 for end

            if (charCode >= 0)
            {
                current = (char)charCode;
            }
            else
            {
                // If we've already marked this as the EOF, throw an exception
                if (isEof)
                {
                    throw new EndOfStreamException("Cannot advance past end of stream.");
                }

                isEof = true;

                current = '\0';
            }

            location.Advance();
        }

        internal void SkipWhitespace()
        {
            while (char.IsWhiteSpace(current))
            {
                Next();
            }
        }

        internal char ReadEscapeCode()
        {
            Next();

            char escapedChar = current;

            Next(); // Consume escaped character

            switch (escapedChar)
            {
                // Special escape codes
                case '"': return '"';   // " (Quotation mark)		U+0022
                case '/': return '/';   // / (Solidus)				U+002F
                case '\\': return '\\'; // \ (Reverse solidus)		U+005C

                // Control Characters
                case '0': return '\0';  // Nul (0)					U+0000
                case 'a': return '\a';  // Alert (7) 
                case 'b': return '\b';  // Backspace (8)			U+0008
                case 'f': return '\f';  // Form feed (12)			U+000C
                case 'n': return '\n';  // Line feed (10)			U+000A
                case 'r': return '\r';  // Carriage return (13)		U+000D
                case 't': return '\t';  // Horizontal tab (9)		U+0009
                case 'v': return '\v';  // Vertical tab

                // Unicode escape sequence						
                case 'u': return ReadUnicodeEscapeSequence();   //	U+XXXX

                default: throw new Exception($"Unrecognized escape sequence '\\{escapedChar}'");
            }
        }

        private readonly char[] hexCode = new char[4];

        private char ReadUnicodeEscapeSequence()
        {
            hexCode[0] = current; Next();
            hexCode[1] = current; Next();
            hexCode[2] = current; Next();
            hexCode[3] = current; Next();

            return Convert.ToChar(int.Parse(
                s       : new string(hexCode),
                style   : NumberStyles.HexNumber,
                provider: NumberFormatInfo.InvariantInfo
            ));
        }

        internal char Current => current;

        internal bool IsEof => isEof;

        internal char Peek() => (char)source.Peek();

        internal SourceLocation Location => location;

        public void Dispose()
        {
            source.Dispose();
        }
    }
}