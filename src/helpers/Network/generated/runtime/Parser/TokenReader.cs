using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
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