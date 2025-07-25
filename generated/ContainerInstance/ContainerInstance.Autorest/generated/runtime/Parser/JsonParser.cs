/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    public class JsonParser : IDisposable
    {
        private readonly TokenReader reader;

        internal JsonParser(TextReader reader)
            : this(new SourceReader(reader)) { }

        internal JsonParser(SourceReader sourceReader)
        {
            if (sourceReader == null)
                throw new ArgumentNullException(nameof(sourceReader));

            this.reader = new TokenReader(new JsonTokenizer(sourceReader));

            this.reader.Next(); // Start with the first token
        }

        internal IEnumerable<JsonNode> ReadNodes()
        {
            JsonNode node;

            while ((node = ReadNode()) != null) yield return node;
        }

        internal JsonNode ReadNode()
        {
            if (reader.Current.Kind == TokenKind.Eof || reader.Current.IsTerminator)
            {
                return null;
            }

            switch (reader.Current.Kind)
            {
                case TokenKind.LeftBrace   : return ReadObject(); // {
                case TokenKind.LeftBracket : return ReadArray();  // [

                default: throw new ParserException($"Expected '{{' or '['. Was {reader.Current}.");
            }
        }

        private JsonNode ReadFieldValue()
        {
            // Boolean, Date, Null, Number, String, Uri
            if (reader.Current.IsLiteral)
            {
                return ReadLiteral();
            }
            else
            {
                switch (reader.Current.Kind)
                {
                    case TokenKind.LeftBracket: return ReadArray();
                    case TokenKind.LeftBrace   : return ReadObject();

                    default: throw new ParserException($"Unexpected token reading field value. Was {reader.Current}.");
                }
            }
        }

        private JsonNode ReadLiteral()
        {
            var literal = reader.Current;

            reader.Next(); // Read the literal token

            switch (literal.Kind)
            {
                case TokenKind.Boolean  : return JsonBoolean.Parse(literal.Value);
                case TokenKind.Null     : return XNull.Instance;
                case TokenKind.Number   : return new JsonNumber(literal.Value);
                case TokenKind.String   : return new JsonString(literal.Value);

                default: throw new ParserException($"Unexpected token reading literal. Was {literal}.");
            }
        }

        internal JsonObject ReadObject()
        {
            reader.Ensure(TokenKind.LeftBrace, "object");

            reader.Next(); // Read '{' (Object start)

            var jsonObject = new JsonObject();

            // Read the object's fields until we reach the end of the object ('}')
            while (reader.Current.Kind != TokenKind.RightBrace)
            {
                if (reader.Current.Kind == TokenKind.Comma)
                {
                    reader.Next(); // Read ',' (Seperator)
                }

                // Ensure we have a field name
                reader.Ensure(TokenKind.String, "Expected field name");

                var field = ReadField();

                jsonObject.Add(field.Key, field.Value);
            }

            reader.Next(); // Read '}' (Object end)

            return jsonObject;
        }


        // TODO: Use ValueTuple in C#7
        private KeyValuePair<string, JsonNode> ReadField()
        {
            var fieldName = reader.Current.Value;

            reader.Next(); // Read the field name

            reader.Ensure(TokenKind.Colon, "field");

            reader.Next(); // Read ':' (Field value indicator)

            return new KeyValuePair<string, JsonNode>(fieldName, ReadFieldValue());
        }


        internal JsonArray ReadArray()
        {
            reader.Ensure(TokenKind.LeftBracket, "array");

            var array = new XNodeArray();

            reader.Next(); // Read the '[' (Array start)

            // Read the array's items
            while (reader.Current.Kind != TokenKind.RightBracket)
            {
                if (reader.Current.Kind == TokenKind.Comma)
                {
                    reader.Next(); // Read the ',' (Seperator)
                }

                if (reader.Current.IsLiteral)
                {
                    array.Add(ReadLiteral()); // Boolean, Date, Number, Null, String, Uri
                }
                else if (reader.Current.Kind == TokenKind.LeftBracket)
                {
                    array.Add(ReadArray()); // Array
                }
                else if (reader.Current.Kind == TokenKind.LeftBrace)
                {
                    array.Add(ReadObject()); // Object
                }
                else
                {
                    throw new ParserException($"Expected comma, literal, or object. Was {reader.Current}.");
                }
            }

            reader.Next(); // Read the ']' (Array end)

            return array;
        }

        #region IDisposable

        public void Dispose()
        {
            reader.Dispose();
        }

        #endregion
    }
}