using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    public sealed class DateTimeConverter : JsonConverter<DateTime>
    {
        internal override JsonNode ToJson(DateTime value)
        {
            return new JsonDate(value);
        }

        internal override DateTime FromJson(JsonNode node) => (DateTime)node;
    }
}