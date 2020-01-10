namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Minimum and maximum number of scale units to deploy.</summary>
    [System.ComponentModel.TypeConverter(typeof(ExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsTypeConverter))]
    public partial class ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal)this).Max = (int?) content.GetValueForProperty("Max",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal)this).Max, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal)this).Min = (int?) content.GetValueForProperty("Min",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal)this).Min, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal)this).Max = (int?) content.GetValueForProperty("Max",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal)this).Max, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal)this).Min = (int?) content.GetValueForProperty("Min",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal)this).Min, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds" />, deserializing the
        /// content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Minimum and maximum number of scale units to deploy.
    [System.ComponentModel.TypeConverter(typeof(ExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsTypeConverter))]
    public partial interface IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds

    {

    }
}