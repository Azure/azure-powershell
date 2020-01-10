namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Details of on demand test probe request</summary>
    [System.ComponentModel.TypeConverter(typeof(ApplicationGatewayOnDemandProbeTypeConverter))]
    public partial class ApplicationGatewayOnDemandProbe
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayOnDemandProbe"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ApplicationGatewayOnDemandProbe(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("BackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendHttpSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("BackendHttpSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendHttpSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Match = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbeHealthResponseMatch) content.GetValueForProperty("Match",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Match, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayProbeHealthResponseMatchTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Path = (string) content.GetValueForProperty("Path",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Path, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Host = (string) content.GetValueForProperty("Host",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Host, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).PickHostNameFromBackendHttpSetting = (bool?) content.GetValueForProperty("PickHostNameFromBackendHttpSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).PickHostNameFromBackendHttpSetting, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Timeout = (int?) content.GetValueForProperty("Timeout",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Timeout, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol?) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendAddressPoolId = (string) content.GetValueForProperty("BackendAddressPoolId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendAddressPoolId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendHttpSettingId = (string) content.GetValueForProperty("BackendHttpSettingId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendHttpSettingId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).MatchBody = (string) content.GetValueForProperty("MatchBody",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).MatchBody, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).MatchStatusCode = (string[]) content.GetValueForProperty("MatchStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).MatchStatusCode, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayOnDemandProbe"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ApplicationGatewayOnDemandProbe(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("BackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendHttpSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("BackendHttpSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendHttpSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Match = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbeHealthResponseMatch) content.GetValueForProperty("Match",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Match, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayProbeHealthResponseMatchTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Path = (string) content.GetValueForProperty("Path",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Path, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Host = (string) content.GetValueForProperty("Host",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Host, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).PickHostNameFromBackendHttpSetting = (bool?) content.GetValueForProperty("PickHostNameFromBackendHttpSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).PickHostNameFromBackendHttpSetting, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Timeout = (int?) content.GetValueForProperty("Timeout",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Timeout, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol?) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendAddressPoolId = (string) content.GetValueForProperty("BackendAddressPoolId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendAddressPoolId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendHttpSettingId = (string) content.GetValueForProperty("BackendHttpSettingId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).BackendHttpSettingId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).MatchBody = (string) content.GetValueForProperty("MatchBody",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).MatchBody, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).MatchStatusCode = (string[]) content.GetValueForProperty("MatchStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal)this).MatchStatusCode, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayOnDemandProbe"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbe"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbe DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ApplicationGatewayOnDemandProbe(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayOnDemandProbe"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbe"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbe DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ApplicationGatewayOnDemandProbe(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApplicationGatewayOnDemandProbe" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbe FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Details of on demand test probe request
    [System.ComponentModel.TypeConverter(typeof(ApplicationGatewayOnDemandProbeTypeConverter))]
    public partial interface IApplicationGatewayOnDemandProbe

    {

    }
}