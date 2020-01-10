namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>ExpressRoute gateway resource properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(ExpressRouteGatewayPropertiesTypeConverter))]
    public partial class ExpressRouteGatewayProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ExpressRouteGatewayProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ExpressRouteGatewayProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ExpressRouteGatewayProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).AutoScaleConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfiguration) content.GetValueForProperty("AutoScaleConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).AutoScaleConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayPropertiesAutoScaleConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).VirtualHub = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubId) content.GetValueForProperty("VirtualHub",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).VirtualHub, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubIdTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).ExpressRouteConnection = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection[]) content.GetValueForProperty("ExpressRouteConnection",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).ExpressRouteConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteConnectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).VirtualHubId = (string) content.GetValueForProperty("VirtualHubId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).VirtualHubId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).AutoScaleConfigurationBound = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds) content.GetValueForProperty("AutoScaleConfigurationBound",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).AutoScaleConfigurationBound, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).BoundMax = (int?) content.GetValueForProperty("BoundMax",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).BoundMax, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).BoundMin = (int?) content.GetValueForProperty("BoundMin",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).BoundMin, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ExpressRouteGatewayProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).AutoScaleConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfiguration) content.GetValueForProperty("AutoScaleConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).AutoScaleConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayPropertiesAutoScaleConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).VirtualHub = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubId) content.GetValueForProperty("VirtualHub",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).VirtualHub, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubIdTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).ExpressRouteConnection = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection[]) content.GetValueForProperty("ExpressRouteConnection",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).ExpressRouteConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteConnectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).VirtualHubId = (string) content.GetValueForProperty("VirtualHubId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).VirtualHubId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).AutoScaleConfigurationBound = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds) content.GetValueForProperty("AutoScaleConfigurationBound",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).AutoScaleConfigurationBound, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).BoundMax = (int?) content.GetValueForProperty("BoundMax",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).BoundMax, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).BoundMin = (int?) content.GetValueForProperty("BoundMin",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)this).BoundMin, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExpressRouteGatewayProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// ExpressRoute gateway resource properties.
    [System.ComponentModel.TypeConverter(typeof(ExpressRouteGatewayPropertiesTypeConverter))]
    public partial interface IExpressRouteGatewayProperties

    {

    }
}