namespace Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.Extensions;

    public partial class ExpressionEvaluationDetails
    {
        // creating this partial class so that we can define the BeforeFromJson method

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name= "returnNow" />
        /// output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>
        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.Json.JsonObject json, ref bool returnNow)
        {
            // this method mimics the class constructor, but parses the properties targetValue and expressionValue differently

            // set the returnNow variable to true so that the rest of the generated deserialization is not processed
            returnNow = true;

            {_result = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.Json.JsonString>("result"), out var __jsonResult) ? (string)__jsonResult : (string)_result;}
            {_expression = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.Json.JsonString>("expression"), out var __jsonExpression) ? (string)__jsonExpression : (string)_expression;}
            {_expressionKind = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.Json.JsonString>("expressionKind"), out var __jsonExpressionKind) ? (string)__jsonExpressionKind : (string)_expressionKind;}
            {_path = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.Json.JsonString>("path"), out var __jsonPath) ? (string)__jsonPath : (string)_path;}
            {_expressionValue = json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.Json.JsonNode>("expressionValue")?.ToString() ?? (string)_expressionValue;}
            {_targetValue = json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.Json.JsonNode>("targetValue")?.ToString() ?? (string)_targetValue;}
            {_operator = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.Json.JsonString>("operator"), out var __jsonOperator) ? (string)__jsonOperator : (string)_operator;}
        }
    }
}
