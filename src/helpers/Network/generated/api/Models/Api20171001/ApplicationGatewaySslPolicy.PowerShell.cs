namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Application Gateway Ssl policy.</summary>
    [System.ComponentModel.TypeConverter(typeof(ApplicationGatewaySslPolicyTypeConverter))]
    public partial class ApplicationGatewaySslPolicy
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewaySslPolicy"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ApplicationGatewaySslPolicy(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).CipherSuite = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[]) content.GetValueForProperty("CipherSuite",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).CipherSuite, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).DisabledSslProtocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[]) content.GetValueForProperty("DisabledSslProtocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).DisabledSslProtocol, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).MinProtocolVersion = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol?) content.GetValueForProperty("MinProtocolVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).MinProtocolVersion, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).PolicyName = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName?) content.GetValueForProperty("PolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).PolicyName, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).PolicyType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType?) content.GetValueForProperty("PolicyType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).PolicyType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewaySslPolicy"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ApplicationGatewaySslPolicy(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).CipherSuite = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[]) content.GetValueForProperty("CipherSuite",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).CipherSuite, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).DisabledSslProtocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[]) content.GetValueForProperty("DisabledSslProtocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).DisabledSslProtocol, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).MinProtocolVersion = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol?) content.GetValueForProperty("MinProtocolVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).MinProtocolVersion, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).PolicyName = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName?) content.GetValueForProperty("PolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).PolicyName, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).PolicyType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType?) content.GetValueForProperty("PolicyType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)this).PolicyType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewaySslPolicy"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicy"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicy DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ApplicationGatewaySslPolicy(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewaySslPolicy"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicy"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicy DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ApplicationGatewaySslPolicy(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApplicationGatewaySslPolicy" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicy FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Application Gateway Ssl policy.
    [System.ComponentModel.TypeConverter(typeof(ApplicationGatewaySslPolicyTypeConverter))]
    public partial interface IApplicationGatewaySslPolicy

    {

    }
}