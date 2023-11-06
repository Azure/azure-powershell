/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.Json
{
    public class TokenReader : IDisposable
    {
        private readonly JsonTokenizer tokenizer;
        private JsonToken current;

        internal TokenReader(JsonTokenizer tokenizer)
        {
            this.tokenizer = tokenizer ?? throw new ArgumentNullException(nameof(tokenizer));
        }

        internal void Next()
        {
            current = tokenizer.ReadNext();
        }

        internal JsonToken Current => current;

        internal void Ensure(TokenKind kind, string readerName)
        {
            if (current.Kind != kind)
            {
                throw new ParserException($"Expected {kind} while reading {readerName}). Was {current}.");
            }
        }

        public void Dispose()
        {
            tokenizer.Dispose();
        }
    }
}