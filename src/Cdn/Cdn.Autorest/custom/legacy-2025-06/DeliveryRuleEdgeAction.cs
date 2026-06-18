namespace Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime;
    using Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Json;

    public class DeliveryRuleEdgeAction : IDeliveryRuleAction
    {
        public string Name { get => "EdgeAction"; set { } }

        public string ParameterInvocationPoint { get; set; }

        public string ParameterTypeName { get; set; }

        public string ReferenceId { get; set; }

        public JsonNode ToJson(JsonObject container = null, SerializationMode serializationMode = SerializationMode.None)
        {
            container = container ?? new JsonObject();
            container.Add("name", Name);

            var parameters = new JsonObject();
            if (ParameterTypeName != null)
            {
                parameters.Add("typeName", ParameterTypeName);
            }
            if (ParameterInvocationPoint != null)
            {
                parameters.Add("invocationPoint", ParameterInvocationPoint);
            }
            if (ReferenceId != null)
            {
                var edgeActionReference = new JsonObject();
                edgeActionReference.Add("id", ReferenceId);
                parameters.Add("edgeActionReference", edgeActionReference);
            }

            container.Add("parameters", parameters);
            return container;
        }

        public string ToJsonString() => ToJson(null, SerializationMode.IncludeAll)?.ToString();

        public override string ToString() => ToJsonString();
    }
}