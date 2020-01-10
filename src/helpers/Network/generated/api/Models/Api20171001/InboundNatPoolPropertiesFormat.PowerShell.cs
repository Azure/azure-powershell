namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Properties of Inbound NAT pool.</summary>
    [System.ComponentModel.TypeConverter(typeof(InboundNatPoolPropertiesFormatTypeConverter))]
    public partial class InboundNatPoolPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.InboundNatPoolPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new InboundNatPoolPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.InboundNatPoolPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new InboundNatPoolPropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="InboundNatPoolPropertiesFormat" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.InboundNatPoolPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal InboundNatPoolPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) content.GetValueForProperty("FrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendIPConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).BackendPort = (int) content.GetValueForProperty("BackendPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).BackendPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendPortRangeEnd = (int) content.GetValueForProperty("FrontendPortRangeEnd",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendPortRangeEnd, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendPortRangeStart = (int) content.GetValueForProperty("FrontendPortRangeStart",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendPortRangeStart, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendIPConfigurationId = (string) content.GetValueForProperty("FrontendIPConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendIPConfigurationId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.InboundNatPoolPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal InboundNatPoolPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) content.GetValueForProperty("FrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendIPConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).BackendPort = (int) content.GetValueForProperty("BackendPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).BackendPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendPortRangeEnd = (int) content.GetValueForProperty("FrontendPortRangeEnd",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendPortRangeEnd, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendPortRangeStart = (int) content.GetValueForProperty("FrontendPortRangeStart",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendPortRangeStart, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendIPConfigurationId = (string) content.GetValueForProperty("FrontendIPConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal)this).FrontendIPConfigurationId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of Inbound NAT pool.
    [System.ComponentModel.TypeConverter(typeof(InboundNatPoolPropertiesFormatTypeConverter))]
    public partial interface IInboundNatPoolPropertiesFormat

    {

    }
}