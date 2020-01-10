using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    internal sealed partial class JsonBoolean : JsonNode
    {
        internal static readonly JsonBoolean True = new JsonBoolean(true);
        internal static readonly JsonBoolean False = new JsonBoolean(false);

        internal JsonBoolean(bool value)
        {
            Value = value;
        }

        internal bool Value { get; }

        internal override JsonType Type => JsonType.Boolean;

        internal static new JsonBoolean Parse(string text)
        {
            switch (text)
            {
                case "false": return False;
                case "true": return True;

                default: throw new ArgumentException($"Expected true or false. Was {text}.");
            }
        }

        #region Implicit Casts

        public static implicit operator bool(JsonBoolean data) => data.Value;

        public static implicit operator JsonBoolean(bool data) => new JsonBoolean(data);

        #endregion
    }
}