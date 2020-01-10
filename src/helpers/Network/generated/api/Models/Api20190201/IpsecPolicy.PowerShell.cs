namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>FIXME: Class IpsecPolicy is MISSING DESCRIPTION</summary>
    [System.ComponentModel.TypeConverter(typeof(IpsecPolicyTypeConverter))]
    public partial class IpsecPolicy
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IpsecPolicy"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new IpsecPolicy(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IpsecPolicy"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new IpsecPolicy(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="IpsecPolicy" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IpsecPolicy"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal IpsecPolicy(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).DhGroup = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup) content.GetValueForProperty("DhGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).DhGroup, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IkeEncryption = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption) content.GetValueForProperty("IkeEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IkeEncryption, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IkeIntegrity = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity) content.GetValueForProperty("IkeIntegrity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IkeIntegrity, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IpsecEncryption = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption) content.GetValueForProperty("IpsecEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IpsecEncryption, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IpsecIntegrity = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity) content.GetValueForProperty("IpsecIntegrity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IpsecIntegrity, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).PfsGroup = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup) content.GetValueForProperty("PfsGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).PfsGroup, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).SaDataSizeKilobyte = (int) content.GetValueForProperty("SaDataSizeKilobyte",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).SaDataSizeKilobyte, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).SaLifeTimeSecond = (int) content.GetValueForProperty("SaLifeTimeSecond",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).SaLifeTimeSecond, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IpsecPolicy"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal IpsecPolicy(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).DhGroup = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup) content.GetValueForProperty("DhGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).DhGroup, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IkeEncryption = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption) content.GetValueForProperty("IkeEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IkeEncryption, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IkeIntegrity = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity) content.GetValueForProperty("IkeIntegrity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IkeIntegrity, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IpsecEncryption = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption) content.GetValueForProperty("IpsecEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IpsecEncryption, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IpsecIntegrity = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity) content.GetValueForProperty("IpsecIntegrity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).IpsecIntegrity, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).PfsGroup = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup) content.GetValueForProperty("PfsGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).PfsGroup, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).SaDataSizeKilobyte = (int) content.GetValueForProperty("SaDataSizeKilobyte",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).SaDataSizeKilobyte, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).SaLifeTimeSecond = (int) content.GetValueForProperty("SaLifeTimeSecond",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)this).SaLifeTimeSecond, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// FIXME: Interface IIpsecPolicy is MISSING DESCRIPTION
    [System.ComponentModel.TypeConverter(typeof(IpsecPolicyTypeConverter))]
    public partial interface IIpsecPolicy

    {

    }
}