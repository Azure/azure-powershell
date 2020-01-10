using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    public sealed class UriConverter : JsonConverter<Uri>
    {
        internal override JsonNode ToJson(Uri value) => new JsonString(value.AbsoluteUri);

        internal override Uri FromJson(JsonNode node) => (Uri)node;
    }
}