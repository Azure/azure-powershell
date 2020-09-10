namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Settings for Azure Files identity based authentication.</summary>
    [System.ComponentModel.TypeConverter(typeof(AzureFilesIdentityBasedAuthenticationTypeConverter))]
    public partial class AzureFilesIdentityBasedAuthentication
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.AzureFilesIdentityBasedAuthentication"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AzureFilesIdentityBasedAuthentication(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryProperties) content.GetValueForProperty("ActiveDirectoryProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ActiveDirectoryPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).DirectoryServiceOption = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions) content.GetValueForProperty("DirectoryServiceOption",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).DirectoryServiceOption, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyDomainGuid = (string) content.GetValueForProperty("ActiveDirectoryPropertyDomainGuid",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyDomainGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyDomainName = (string) content.GetValueForProperty("ActiveDirectoryPropertyDomainName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyDomainName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyDomainSid = (string) content.GetValueForProperty("ActiveDirectoryPropertyDomainSid",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyDomainSid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyForestName = (string) content.GetValueForProperty("ActiveDirectoryPropertyForestName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyForestName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyAzureStorageSid = (string) content.GetValueForProperty("ActiveDirectoryPropertyAzureStorageSid",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyAzureStorageSid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyNetBiosDomainName = (string) content.GetValueForProperty("ActiveDirectoryPropertyNetBiosDomainName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyNetBiosDomainName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.AzureFilesIdentityBasedAuthentication"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AzureFilesIdentityBasedAuthentication(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryProperties) content.GetValueForProperty("ActiveDirectoryProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ActiveDirectoryPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).DirectoryServiceOption = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions) content.GetValueForProperty("DirectoryServiceOption",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).DirectoryServiceOption, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyDomainGuid = (string) content.GetValueForProperty("ActiveDirectoryPropertyDomainGuid",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyDomainGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyDomainName = (string) content.GetValueForProperty("ActiveDirectoryPropertyDomainName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyDomainName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyDomainSid = (string) content.GetValueForProperty("ActiveDirectoryPropertyDomainSid",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyDomainSid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyForestName = (string) content.GetValueForProperty("ActiveDirectoryPropertyForestName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyForestName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyAzureStorageSid = (string) content.GetValueForProperty("ActiveDirectoryPropertyAzureStorageSid",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyAzureStorageSid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyNetBiosDomainName = (string) content.GetValueForProperty("ActiveDirectoryPropertyNetBiosDomainName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)this).ActiveDirectoryPropertyNetBiosDomainName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.AzureFilesIdentityBasedAuthentication"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AzureFilesIdentityBasedAuthentication(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.AzureFilesIdentityBasedAuthentication"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AzureFilesIdentityBasedAuthentication(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureFilesIdentityBasedAuthentication" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Settings for Azure Files identity based authentication.
    [System.ComponentModel.TypeConverter(typeof(AzureFilesIdentityBasedAuthenticationTypeConverter))]
    public partial interface IAzureFilesIdentityBasedAuthentication

    {

    }
}