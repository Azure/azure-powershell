namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Properties specific to ExpressRoutePort resources.</summary>
    [System.ComponentModel.TypeConverter(typeof(ExpressRoutePortPropertiesFormatTypeConverter))]
    public partial class ExpressRoutePortPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRoutePortPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ExpressRoutePortPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRoutePortPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ExpressRoutePortPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRoutePortPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ExpressRoutePortPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).AllocationDate = (string) content.GetValueForProperty("AllocationDate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).AllocationDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).BandwidthInGbps = (int?) content.GetValueForProperty("BandwidthInGbps",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).BandwidthInGbps, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Circuit = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("Circuit",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Circuit, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Encapsulation = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation?) content.GetValueForProperty("Encapsulation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Encapsulation, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).EtherType = (string) content.GetValueForProperty("EtherType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).EtherType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Link = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLink[]) content.GetValueForProperty("Link",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Link, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLink>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteLinkTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Mtu = (string) content.GetValueForProperty("Mtu",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Mtu, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).PeeringLocation = (string) content.GetValueForProperty("PeeringLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).PeeringLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).ProvisionedBandwidthInGbps = (float?) content.GetValueForProperty("ProvisionedBandwidthInGbps",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).ProvisionedBandwidthInGbps, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRoutePortPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ExpressRoutePortPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).AllocationDate = (string) content.GetValueForProperty("AllocationDate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).AllocationDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).BandwidthInGbps = (int?) content.GetValueForProperty("BandwidthInGbps",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).BandwidthInGbps, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Circuit = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("Circuit",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Circuit, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Encapsulation = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation?) content.GetValueForProperty("Encapsulation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Encapsulation, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).EtherType = (string) content.GetValueForProperty("EtherType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).EtherType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Link = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLink[]) content.GetValueForProperty("Link",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Link, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLink>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteLinkTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Mtu = (string) content.GetValueForProperty("Mtu",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).Mtu, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).PeeringLocation = (string) content.GetValueForProperty("PeeringLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).PeeringLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).ProvisionedBandwidthInGbps = (float?) content.GetValueForProperty("ProvisionedBandwidthInGbps",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).ProvisionedBandwidthInGbps, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExpressRoutePortPropertiesFormat" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties specific to ExpressRoutePort resources.
    [System.ComponentModel.TypeConverter(typeof(ExpressRoutePortPropertiesFormatTypeConverter))]
    public partial interface IExpressRoutePortPropertiesFormat

    {

    }
}