namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Network configuration diagnostic result corresponded to provided traffic query.</summary>
    [System.ComponentModel.TypeConverter(typeof(NetworkConfigurationDiagnosticResultTypeConverter))]
    public partial class NetworkConfigurationDiagnosticResult
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkConfigurationDiagnosticResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NetworkConfigurationDiagnosticResult(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkConfigurationDiagnosticResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NetworkConfigurationDiagnosticResult(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NetworkConfigurationDiagnosticResult" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkConfigurationDiagnosticResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NetworkConfigurationDiagnosticResult(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).NsgResult = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResult) content.GetValueForProperty("NsgResult",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).NsgResult, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkSecurityGroupResultTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).Profile = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile) content.GetValueForProperty("Profile",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).Profile, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkConfigurationDiagnosticProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileDirection = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction) content.GetValueForProperty("ProfileDirection",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileDirection, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).NsgResultEvaluatedNsg = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup[]) content.GetValueForProperty("NsgResultEvaluatedNsg",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).NsgResultEvaluatedNsg, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EvaluatedNetworkSecurityGroupTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).NsgResultSecurityRuleAccessResult = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess?) content.GetValueForProperty("NsgResultSecurityRuleAccessResult",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).NsgResultSecurityRuleAccessResult, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileDestination = (string) content.GetValueForProperty("ProfileDestination",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileDestination, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileDestinationPort = (string) content.GetValueForProperty("ProfileDestinationPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileDestinationPort, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileSource = (string) content.GetValueForProperty("ProfileSource",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileSource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileProtocol = (string) content.GetValueForProperty("ProfileProtocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileProtocol, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkConfigurationDiagnosticResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NetworkConfigurationDiagnosticResult(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).NsgResult = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResult) content.GetValueForProperty("NsgResult",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).NsgResult, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkSecurityGroupResultTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).Profile = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile) content.GetValueForProperty("Profile",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).Profile, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkConfigurationDiagnosticProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileDirection = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction) content.GetValueForProperty("ProfileDirection",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileDirection, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).NsgResultEvaluatedNsg = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup[]) content.GetValueForProperty("NsgResultEvaluatedNsg",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).NsgResultEvaluatedNsg, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EvaluatedNetworkSecurityGroupTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).NsgResultSecurityRuleAccessResult = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess?) content.GetValueForProperty("NsgResultSecurityRuleAccessResult",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).NsgResultSecurityRuleAccessResult, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileDestination = (string) content.GetValueForProperty("ProfileDestination",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileDestination, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileDestinationPort = (string) content.GetValueForProperty("ProfileDestinationPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileDestinationPort, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileSource = (string) content.GetValueForProperty("ProfileSource",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileSource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileProtocol = (string) content.GetValueForProperty("ProfileProtocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal)this).ProfileProtocol, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Network configuration diagnostic result corresponded to provided traffic query.
    [System.ComponentModel.TypeConverter(typeof(NetworkConfigurationDiagnosticResultTypeConverter))]
    public partial interface INetworkConfigurationDiagnosticResult

    {

    }
}