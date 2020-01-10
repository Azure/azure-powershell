using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    public sealed class HashSetConverter<T> : JsonConverter<HashSet<T>>
    {
        internal override JsonNode ToJson(HashSet<T> value)
        {
            return new XSet<T>(value); 
        }

        internal override HashSet<T> FromJson(JsonNode node)
        {
            var collection = node as ICollection<JsonNode>;

            if (collection.Count == 0) return null;
            
            // TODO: Remove Linq depedency
            return new HashSet<T>(collection.Cast<T>());
        }
    }
}