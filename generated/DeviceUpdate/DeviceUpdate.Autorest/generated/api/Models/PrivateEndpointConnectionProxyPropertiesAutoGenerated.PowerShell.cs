// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Runtime.PowerShell;

    /// <summary>Private endpoint connection proxy object properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(PrivateEndpointConnectionProxyPropertiesAutoGeneratedTypeConverter))]
    public partial class PrivateEndpointConnectionProxyPropertiesAutoGenerated
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.PrivateEndpointConnectionProxyPropertiesAutoGenerated"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGenerated"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGenerated DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PrivateEndpointConnectionProxyPropertiesAutoGenerated(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.PrivateEndpointConnectionProxyPropertiesAutoGenerated"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGenerated"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGenerated DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PrivateEndpointConnectionProxyPropertiesAutoGenerated(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PrivateEndpointConnectionProxyPropertiesAutoGenerated" />, deserializing the content
        /// from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="PrivateEndpointConnectionProxyPropertiesAutoGenerated" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGenerated FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.PrivateEndpointConnectionProxyPropertiesAutoGenerated"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PrivateEndpointConnectionProxyPropertiesAutoGenerated(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("RemotePrivateEndpoint"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IRemotePrivateEndpoint) content.GetValueForProperty("RemotePrivateEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpoint, Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.RemotePrivateEndpointTypeConverter.ConvertFrom);
            }
            if (content.Contains("ETag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).ETag = (string) content.GetValueForProperty("ETag",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).ETag, global::System.Convert.ToString);
            }
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).Status = (string) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).Status, global::System.Convert.ToString);
            }
            if (content.Contains("RemotePrivateEndpointId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointId = (string) content.GetValueForProperty("RemotePrivateEndpointId",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointId, global::System.Convert.ToString);
            }
            if (content.Contains("RemotePrivateEndpointLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointLocation = (string) content.GetValueForProperty("RemotePrivateEndpointLocation",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointLocation, global::System.Convert.ToString);
            }
            if (content.Contains("RemotePrivateEndpointConnectionDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointConnectionDetail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IConnectionDetails>) content.GetValueForProperty("RemotePrivateEndpointConnectionDetail",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointConnectionDetail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IConnectionDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.ConnectionDetailsTypeConverter.ConvertFrom));
            }
            if (content.Contains("RemotePrivateEndpointImmutableSubscriptionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointImmutableSubscriptionId = (string) content.GetValueForProperty("RemotePrivateEndpointImmutableSubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointImmutableSubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("RemotePrivateEndpointImmutableResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointImmutableResourceId = (string) content.GetValueForProperty("RemotePrivateEndpointImmutableResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointImmutableResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("RemotePrivateEndpointVnetTrafficTag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointVnetTrafficTag = (string) content.GetValueForProperty("RemotePrivateEndpointVnetTrafficTag",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointVnetTrafficTag, global::System.Convert.ToString);
            }
            if (content.Contains("RemotePrivateEndpointManualPrivateLinkServiceConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointManualPrivateLinkServiceConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateLinkServiceConnection>) content.GetValueForProperty("RemotePrivateEndpointManualPrivateLinkServiceConnection",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointManualPrivateLinkServiceConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateLinkServiceConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.PrivateLinkServiceConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("RemotePrivateEndpointPrivateLinkServiceConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointPrivateLinkServiceConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateLinkServiceConnection>) content.GetValueForProperty("RemotePrivateEndpointPrivateLinkServiceConnection",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointPrivateLinkServiceConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateLinkServiceConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.PrivateLinkServiceConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("RemotePrivateEndpointPrivateLinkServiceProxy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointPrivateLinkServiceProxy = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateLinkServiceProxy>) content.GetValueForProperty("RemotePrivateEndpointPrivateLinkServiceProxy",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointPrivateLinkServiceProxy, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateLinkServiceProxy>(__y, Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.PrivateLinkServiceProxyTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.PrivateEndpointConnectionProxyPropertiesAutoGenerated"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PrivateEndpointConnectionProxyPropertiesAutoGenerated(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("RemotePrivateEndpoint"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IRemotePrivateEndpoint) content.GetValueForProperty("RemotePrivateEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpoint, Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.RemotePrivateEndpointTypeConverter.ConvertFrom);
            }
            if (content.Contains("ETag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).ETag = (string) content.GetValueForProperty("ETag",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).ETag, global::System.Convert.ToString);
            }
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).Status = (string) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).Status, global::System.Convert.ToString);
            }
            if (content.Contains("RemotePrivateEndpointId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointId = (string) content.GetValueForProperty("RemotePrivateEndpointId",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointId, global::System.Convert.ToString);
            }
            if (content.Contains("RemotePrivateEndpointLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointLocation = (string) content.GetValueForProperty("RemotePrivateEndpointLocation",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointLocation, global::System.Convert.ToString);
            }
            if (content.Contains("RemotePrivateEndpointConnectionDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointConnectionDetail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IConnectionDetails>) content.GetValueForProperty("RemotePrivateEndpointConnectionDetail",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointConnectionDetail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IConnectionDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.ConnectionDetailsTypeConverter.ConvertFrom));
            }
            if (content.Contains("RemotePrivateEndpointImmutableSubscriptionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointImmutableSubscriptionId = (string) content.GetValueForProperty("RemotePrivateEndpointImmutableSubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointImmutableSubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("RemotePrivateEndpointImmutableResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointImmutableResourceId = (string) content.GetValueForProperty("RemotePrivateEndpointImmutableResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointImmutableResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("RemotePrivateEndpointVnetTrafficTag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointVnetTrafficTag = (string) content.GetValueForProperty("RemotePrivateEndpointVnetTrafficTag",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointVnetTrafficTag, global::System.Convert.ToString);
            }
            if (content.Contains("RemotePrivateEndpointManualPrivateLinkServiceConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointManualPrivateLinkServiceConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateLinkServiceConnection>) content.GetValueForProperty("RemotePrivateEndpointManualPrivateLinkServiceConnection",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointManualPrivateLinkServiceConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateLinkServiceConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.PrivateLinkServiceConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("RemotePrivateEndpointPrivateLinkServiceConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointPrivateLinkServiceConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateLinkServiceConnection>) content.GetValueForProperty("RemotePrivateEndpointPrivateLinkServiceConnection",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointPrivateLinkServiceConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateLinkServiceConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.PrivateLinkServiceConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("RemotePrivateEndpointPrivateLinkServiceProxy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointPrivateLinkServiceProxy = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateLinkServiceProxy>) content.GetValueForProperty("RemotePrivateEndpointPrivateLinkServiceProxy",((Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateEndpointConnectionProxyPropertiesAutoGeneratedInternal)this).RemotePrivateEndpointPrivateLinkServiceProxy, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IPrivateLinkServiceProxy>(__y, Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.PrivateLinkServiceProxyTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// Private endpoint connection proxy object properties.
    [System.ComponentModel.TypeConverter(typeof(PrivateEndpointConnectionProxyPropertiesAutoGeneratedTypeConverter))]
    public partial interface IPrivateEndpointConnectionProxyPropertiesAutoGenerated

    {

    }
}