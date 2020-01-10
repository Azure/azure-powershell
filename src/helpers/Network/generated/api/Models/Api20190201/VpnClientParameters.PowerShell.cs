namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Vpn Client Parameters for package generation</summary>
    [System.ComponentModel.TypeConverter(typeof(VpnClientParametersTypeConverter))]
    public partial class VpnClientParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VpnClientParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VpnClientParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VpnClientParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VpnClientParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).AuthenticationMethod = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod?) content.GetValueForProperty("AuthenticationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).AuthenticationMethod, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).ClientRootCertificate = (string[]) content.GetValueForProperty("ClientRootCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).ClientRootCertificate, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).ProcessorArchitecture = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture?) content.GetValueForProperty("ProcessorArchitecture",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).ProcessorArchitecture, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).RadiusServerAuthCertificate = (string) content.GetValueForProperty("RadiusServerAuthCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).RadiusServerAuthCertificate, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VpnClientParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).AuthenticationMethod = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod?) content.GetValueForProperty("AuthenticationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).AuthenticationMethod, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).ClientRootCertificate = (string[]) content.GetValueForProperty("ClientRootCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).ClientRootCertificate, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).ProcessorArchitecture = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture?) content.GetValueForProperty("ProcessorArchitecture",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).ProcessorArchitecture, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).RadiusServerAuthCertificate = (string) content.GetValueForProperty("RadiusServerAuthCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal)this).RadiusServerAuthCertificate, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Vpn Client Parameters for package generation
    [System.ComponentModel.TypeConverter(typeof(VpnClientParametersTypeConverter))]
    public partial interface IVpnClientParameters

    {

    }
}