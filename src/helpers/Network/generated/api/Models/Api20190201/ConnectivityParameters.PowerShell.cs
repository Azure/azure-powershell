namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Parameters that determine how the connectivity check will be performed.</summary>
    [System.ComponentModel.TypeConverter(typeof(ConnectivityParametersTypeConverter))]
    public partial class ConnectivityParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivityParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ConnectivityParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).Destination = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestination) content.GetValueForProperty("Destination",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).Destination, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivityDestinationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).ProtocolConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfiguration) content.GetValueForProperty("ProtocolConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).ProtocolConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ProtocolConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).Source = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivitySource) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).Source, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivitySourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol?) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).ProtocolConfigurationHttpConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfiguration) content.GetValueForProperty("ProtocolConfigurationHttpConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).ProtocolConfigurationHttpConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.HttpConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).DestinationAddress = (string) content.GetValueForProperty("DestinationAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).DestinationAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).DestinationPort = (int?) content.GetValueForProperty("DestinationPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).DestinationPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).DestinationResourceId = (string) content.GetValueForProperty("DestinationResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).DestinationResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).SourcePort = (int?) content.GetValueForProperty("SourcePort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).SourcePort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).SourceResourceId = (string) content.GetValueForProperty("SourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).SourceResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).HttpConfigurationMethod = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod?) content.GetValueForProperty("HttpConfigurationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).HttpConfigurationMethod, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).HttpConfigurationHeader = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[]) content.GetValueForProperty("HttpConfigurationHeader",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).HttpConfigurationHeader, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.HttpHeaderTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).HttpConfigurationValidStatusCode = (int[]) content.GetValueForProperty("HttpConfigurationValidStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).HttpConfigurationValidStatusCode, __y => TypeConverterExtensions.SelectToArray<int>(__y, (__w)=> (int) global::System.Convert.ChangeType(__w, typeof(int))));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivityParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ConnectivityParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).Destination = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestination) content.GetValueForProperty("Destination",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).Destination, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivityDestinationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).ProtocolConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfiguration) content.GetValueForProperty("ProtocolConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).ProtocolConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ProtocolConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).Source = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivitySource) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).Source, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivitySourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol?) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).ProtocolConfigurationHttpConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfiguration) content.GetValueForProperty("ProtocolConfigurationHttpConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).ProtocolConfigurationHttpConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.HttpConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).DestinationAddress = (string) content.GetValueForProperty("DestinationAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).DestinationAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).DestinationPort = (int?) content.GetValueForProperty("DestinationPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).DestinationPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).DestinationResourceId = (string) content.GetValueForProperty("DestinationResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).DestinationResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).SourcePort = (int?) content.GetValueForProperty("SourcePort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).SourcePort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).SourceResourceId = (string) content.GetValueForProperty("SourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).SourceResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).HttpConfigurationMethod = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod?) content.GetValueForProperty("HttpConfigurationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).HttpConfigurationMethod, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).HttpConfigurationHeader = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[]) content.GetValueForProperty("HttpConfigurationHeader",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).HttpConfigurationHeader, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.HttpHeaderTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).HttpConfigurationValidStatusCode = (int[]) content.GetValueForProperty("HttpConfigurationValidStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal)this).HttpConfigurationValidStatusCode, __y => TypeConverterExtensions.SelectToArray<int>(__y, (__w)=> (int) global::System.Convert.ChangeType(__w, typeof(int))));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivityParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ConnectivityParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivityParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ConnectivityParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConnectivityParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Parameters that determine how the connectivity check will be performed.
    [System.ComponentModel.TypeConverter(typeof(ConnectivityParametersTypeConverter))]
    public partial interface IConnectivityParameters

    {

    }
}