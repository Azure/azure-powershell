namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    using System;
    using System.Linq;

    public partial class XNodeArray
    {
        internal static XNodeArray Create<T>(T[] source, Func<T, JsonNode> selector)
        {
            if (source == null || selector == null)
            {
                return null;
            }
            var result = new XNodeArray();
            foreach (var item in source.Select(selector))
            {
                result.SafeAdd(item);
            }
            return result;
        }
        internal void SafeAdd(JsonNode item)
        {
            if (item != null)
            {
                items.Add(item);
            }
        }
        internal void SafeAdd(Func<JsonNode> itemFn)
        {
            if (itemFn != null)
            {
                var item = itemFn();
                if (item != null)
                {
                    items.Add(item);
                }
            }
        }
    }
}