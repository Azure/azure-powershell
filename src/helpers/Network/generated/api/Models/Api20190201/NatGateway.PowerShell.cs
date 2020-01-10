namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Nat Gateway resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(NatGatewayTypeConverter))]
    public partial class NatGateway
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NatGateway"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGateway" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGateway DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NatGateway(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NatGateway"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGateway" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGateway DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NatGateway(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NatGateway" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGateway FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NatGateway"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NatGateway(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NatGatewayPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewaySku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NatGatewaySkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).IdleTimeoutInMinutes = (int?) content.GetValueForProperty("IdleTimeoutInMinutes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).IdleTimeoutInMinutes, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).PublicIPAddress = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("PublicIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).PublicIPAddress, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).PublicIPPrefix = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("PublicIPPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).PublicIPPrefix, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Subnet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("Subnet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Subnet, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NatGatewaySkuName?) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NatGatewaySkuName.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NatGateway"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NatGateway(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NatGatewayPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewaySku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NatGatewaySkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).IdleTimeoutInMinutes = (int?) content.GetValueForProperty("IdleTimeoutInMinutes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).IdleTimeoutInMinutes, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).PublicIPAddress = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("PublicIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).PublicIPAddress, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).PublicIPPrefix = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("PublicIPPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).PublicIPPrefix, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Subnet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("Subnet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).Subnet, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NatGatewaySkuName?) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewayInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NatGatewaySkuName.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Nat Gateway resource.
    [System.ComponentModel.TypeConverter(typeof(NatGatewayTypeConverter))]
    public partial interface INatGateway

    {

    }
}