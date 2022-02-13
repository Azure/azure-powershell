namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.PowerShell;

    /// <summary>Forest Trust Setting</summary>
    [System.ComponentModel.TypeConverter(typeof(ForestTrustTypeConverter))]
    public partial class ForestTrust
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ForestTrust"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ForestTrust(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ForestTrust"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ForestTrust(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ForestTrust"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ForestTrust(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).TrustedDomainFqdn = (string) content.GetValueForProperty("TrustedDomainFqdn",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).TrustedDomainFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).TrustDirection = (string) content.GetValueForProperty("TrustDirection",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).TrustDirection, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).RemoteDnsIP = (string) content.GetValueForProperty("RemoteDnsIP",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).RemoteDnsIP, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).TrustPassword = (string) content.GetValueForProperty("TrustPassword",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).TrustPassword, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ForestTrust"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ForestTrust(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).TrustedDomainFqdn = (string) content.GetValueForProperty("TrustedDomainFqdn",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).TrustedDomainFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).TrustDirection = (string) content.GetValueForProperty("TrustDirection",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).TrustDirection, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).RemoteDnsIP = (string) content.GetValueForProperty("RemoteDnsIP",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).RemoteDnsIP, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).TrustPassword = (string) content.GetValueForProperty("TrustPassword",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal)this).TrustPassword, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ForestTrust" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Forest Trust Setting
    [System.ComponentModel.TypeConverter(typeof(ForestTrustTypeConverter))]
    public partial interface IForestTrust

    {

    }
}