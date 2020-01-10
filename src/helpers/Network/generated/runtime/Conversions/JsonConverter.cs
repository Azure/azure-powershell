namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    public abstract class JsonConverter<T> : IJsonConverter
    {
        internal abstract T FromJson(JsonNode node);

        internal abstract JsonNode ToJson(T value);

        #region IConverter

        object IJsonConverter.FromJson(JsonNode node) => FromJson(node);

        JsonNode IJsonConverter.ToJson(object value) => ToJson((T)value);

        #endregion
    }
}