namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Contains bgp community information offered in Service Community resources.</summary>
    [System.ComponentModel.TypeConverter(typeof(BgpCommunityTypeConverter))]
    public partial class BgpCommunity
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpCommunity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal BgpCommunity(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).CommunityName = (string) content.GetValueForProperty("CommunityName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).CommunityName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).CommunityPrefix = (string[]) content.GetValueForProperty("CommunityPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).CommunityPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).CommunityValue = (string) content.GetValueForProperty("CommunityValue",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).CommunityValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).IsAuthorizedToUse = (bool?) content.GetValueForProperty("IsAuthorizedToUse",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).IsAuthorizedToUse, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).ServiceGroup = (string) content.GetValueForProperty("ServiceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).ServiceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).ServiceSupportedRegion = (string) content.GetValueForProperty("ServiceSupportedRegion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).ServiceSupportedRegion, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpCommunity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal BgpCommunity(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).CommunityName = (string) content.GetValueForProperty("CommunityName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).CommunityName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).CommunityPrefix = (string[]) content.GetValueForProperty("CommunityPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).CommunityPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).CommunityValue = (string) content.GetValueForProperty("CommunityValue",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).CommunityValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).IsAuthorizedToUse = (bool?) content.GetValueForProperty("IsAuthorizedToUse",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).IsAuthorizedToUse, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).ServiceGroup = (string) content.GetValueForProperty("ServiceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).ServiceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).ServiceSupportedRegion = (string) content.GetValueForProperty("ServiceSupportedRegion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal)this).ServiceSupportedRegion, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpCommunity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunity DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new BgpCommunity(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpCommunity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunity DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new BgpCommunity(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BgpCommunity" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunity FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Contains bgp community information offered in Service Community resources.
    [System.ComponentModel.TypeConverter(typeof(BgpCommunityTypeConverter))]
    public partial interface IBgpCommunity

    {

    }
}