/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.Json
{
    internal enum TokenKind
    {
        LeftBrace,      // {	Object start
        RightBrace,     // }	Object end

        LeftBracket,    // [	Array start
        RightBracket,   // ]	Array end

        Comma,          // ,	Comma
        Colon,          // :	Value indicator
        Dot,            // .	Access field indicator
        Terminator,     // \0	Stream terminator

        Boolean = 31,   // true or false
        Null = 33,      // null
        Number = 34,    // i.e. -1.93, -1, 0, 1, 1.1
        String = 35,    // i.e. "text"

        Eof = 50
    }

    internal /* readonly */ struct JsonToken
    {
        internal static readonly JsonToken BraceOpen = new JsonToken(TokenKind.LeftBrace, "{");
        internal static readonly JsonToken BraceClose = new JsonToken(TokenKind.RightBrace, "}");

        internal static readonly JsonToken BracketOpen = new JsonToken(TokenKind.LeftBracket, "[");
        internal static readonly JsonToken BracketClose = new JsonToken(TokenKind.RightBracket, "]");

        internal static readonly JsonToken Colon = new JsonToken(TokenKind.Colon, ":");
        internal static readonly JsonToken Comma = new JsonToken(TokenKind.Comma, ",");
        internal static readonly JsonToken Terminator = new JsonToken(TokenKind.Terminator, "\0");

        internal static readonly JsonToken True = new JsonToken(TokenKind.Boolean, "true");
        internal static readonly JsonToken False = new JsonToken(TokenKind.Boolean, "false");
        internal static readonly JsonToken Null = new JsonToken(TokenKind.Null, "null");

        internal static readonly JsonToken Eof = new JsonToken(TokenKind.Eof, null);

        internal JsonToken(TokenKind kind, string value)
        {
            Kind = kind;
            Value = value;
        }

        internal readonly TokenKind Kind;

        internal readonly string Value;

        public override string ToString() => Kind + ": " + Value;

        #region Helpers

        internal bool IsLiteral => (byte)Kind > 30 && (byte)Kind < 40;

        internal bool IsTerminator => Kind == TokenKind.Terminator;

        #endregion
    }
}