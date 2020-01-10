namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Route Filter Resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(PatchRouteFilterTypeConverter))]
    public partial class PatchRouteFilter
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PatchRouteFilter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilter" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilter DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PatchRouteFilter(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PatchRouteFilter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilter" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilter DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PatchRouteFilter(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PatchRouteFilter" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilter FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PatchRouteFilter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PatchRouteFilter(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteFilterPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PatchRouteFilterTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Peering = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[]) content.GetValueForProperty("Peering",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Peering, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitPeeringTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Rule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule[]) content.GetValueForProperty("Rule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Rule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteFilterRuleTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PatchRouteFilter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PatchRouteFilter(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteFilterPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PatchRouteFilterTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Peering = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[]) content.GetValueForProperty("Peering",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Peering, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitPeeringTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Rule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule[]) content.GetValueForProperty("Rule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterInternal)this).Rule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteFilterRuleTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Route Filter Resource.
    [System.ComponentModel.TypeConverter(typeof(PatchRouteFilterTypeConverter))]
    public partial interface IPatchRouteFilter

    {

    }
}