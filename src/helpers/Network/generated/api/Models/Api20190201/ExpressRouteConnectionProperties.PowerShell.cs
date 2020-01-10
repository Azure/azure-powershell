namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Properties of the ExpressRouteConnection subresource.</summary>
    [System.ComponentModel.TypeConverter(typeof(ExpressRouteConnectionPropertiesTypeConverter))]
    public partial class ExpressRouteConnectionProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ExpressRouteConnectionProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ExpressRouteConnectionProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ExpressRouteConnectionProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).ExpressRouteCircuitPeering = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringId) content.GetValueForProperty("ExpressRouteCircuitPeering",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).ExpressRouteCircuitPeering, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCircuitPeeringIdTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).AuthorizationKey = (string) content.GetValueForProperty("AuthorizationKey",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).AuthorizationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).RoutingWeight = (int?) content.GetValueForProperty("RoutingWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).RoutingWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).ExpressRouteCircuitPeeringId = (string) content.GetValueForProperty("ExpressRouteCircuitPeeringId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).ExpressRouteCircuitPeeringId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ExpressRouteConnectionProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).ExpressRouteCircuitPeering = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeeringId) content.GetValueForProperty("ExpressRouteCircuitPeering",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).ExpressRouteCircuitPeering, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCircuitPeeringIdTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).AuthorizationKey = (string) content.GetValueForProperty("AuthorizationKey",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).AuthorizationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).RoutingWeight = (int?) content.GetValueForProperty("RoutingWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).RoutingWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).ExpressRouteCircuitPeeringId = (string) content.GetValueForProperty("ExpressRouteCircuitPeeringId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionPropertiesInternal)this).ExpressRouteCircuitPeeringId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExpressRouteConnectionProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of the ExpressRouteConnection subresource.
    [System.ComponentModel.TypeConverter(typeof(ExpressRouteConnectionPropertiesTypeConverter))]
    public partial interface IExpressRouteConnectionProperties

    {

    }
}