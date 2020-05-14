namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>
    /// Full view of network features for an app (presently VNET integration and Hybrid Connections).
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(NetworkFeaturesTypeConverter))]
    public partial class NetworkFeatures
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NetworkFeatures"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeatures" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeatures DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NetworkFeatures(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NetworkFeatures"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeatures" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeatures DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NetworkFeatures(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NetworkFeatures" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeatures FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NetworkFeatures"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NetworkFeatures(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NetworkFeaturesPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnection = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfo) content.GetValueForProperty("VirtualNetworkConnection",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnection, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).HybridConnectionsV2 = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnection[]) content.GetValueForProperty("HybridConnectionsV2",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).HybridConnectionsV2, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HybridConnectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkName = (string) content.GetValueForProperty("VirtualNetworkName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).HybridConnection = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntity[]) content.GetValueForProperty("HybridConnection",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).HybridConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntity>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RelayServiceConnectionEntityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionName = (string) content.GetValueForProperty("VirtualNetworkConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionId = (string) content.GetValueForProperty("VirtualNetworkConnectionId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionKind = (string) content.GetValueForProperty("VirtualNetworkConnectionKind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties) content.GetValueForProperty("VirtualNetworkConnectionProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfoPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionType = (string) content.GetValueForProperty("VirtualNetworkConnectionType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).CertBlob = (string) content.GetValueForProperty("CertBlob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).CertBlob, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VnetResourceId = (string) content.GetValueForProperty("VnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VnetResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).DnsServer = (string) content.GetValueForProperty("DnsServer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).DnsServer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).IsSwift = (bool?) content.GetValueForProperty("IsSwift",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).IsSwift, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).ResyncRequired = (bool?) content.GetValueForProperty("ResyncRequired",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).ResyncRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).Route = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[]) content.GetValueForProperty("Route",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).Route, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetRouteTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).CertThumbprint = (string) content.GetValueForProperty("CertThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).CertThumbprint, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NetworkFeatures"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NetworkFeatures(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NetworkFeaturesPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnection = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfo) content.GetValueForProperty("VirtualNetworkConnection",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnection, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).HybridConnectionsV2 = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnection[]) content.GetValueForProperty("HybridConnectionsV2",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).HybridConnectionsV2, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HybridConnectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkName = (string) content.GetValueForProperty("VirtualNetworkName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).HybridConnection = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntity[]) content.GetValueForProperty("HybridConnection",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).HybridConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntity>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RelayServiceConnectionEntityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionName = (string) content.GetValueForProperty("VirtualNetworkConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionId = (string) content.GetValueForProperty("VirtualNetworkConnectionId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionKind = (string) content.GetValueForProperty("VirtualNetworkConnectionKind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties) content.GetValueForProperty("VirtualNetworkConnectionProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfoPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionType = (string) content.GetValueForProperty("VirtualNetworkConnectionType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VirtualNetworkConnectionType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).CertBlob = (string) content.GetValueForProperty("CertBlob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).CertBlob, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VnetResourceId = (string) content.GetValueForProperty("VnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).VnetResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).DnsServer = (string) content.GetValueForProperty("DnsServer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).DnsServer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).IsSwift = (bool?) content.GetValueForProperty("IsSwift",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).IsSwift, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).ResyncRequired = (bool?) content.GetValueForProperty("ResyncRequired",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).ResyncRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).Route = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[]) content.GetValueForProperty("Route",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).Route, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetRouteTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).CertThumbprint = (string) content.GetValueForProperty("CertThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal)this).CertThumbprint, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Full view of network features for an app (presently VNET integration and Hybrid Connections).
    [System.ComponentModel.TypeConverter(typeof(NetworkFeaturesTypeConverter))]
    public partial interface INetworkFeatures

    {

    }
}