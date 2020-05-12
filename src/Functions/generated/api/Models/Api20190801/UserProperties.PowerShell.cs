namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>User resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(UserPropertiesTypeConverter))]
    public partial class UserProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.UserProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new UserProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.UserProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new UserProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UserProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.UserProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal UserProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingPassword = (string) content.GetValueForProperty("PublishingPassword",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingPasswordHash = (string) content.GetValueForProperty("PublishingPasswordHash",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingPasswordHash, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingPasswordHashSalt = (string) content.GetValueForProperty("PublishingPasswordHashSalt",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingPasswordHashSalt, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingUserName = (string) content.GetValueForProperty("PublishingUserName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingUserName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).ScmUri = (string) content.GetValueForProperty("ScmUri",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).ScmUri, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.UserProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal UserProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingPassword = (string) content.GetValueForProperty("PublishingPassword",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingPasswordHash = (string) content.GetValueForProperty("PublishingPasswordHash",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingPasswordHash, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingPasswordHashSalt = (string) content.GetValueForProperty("PublishingPasswordHashSalt",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingPasswordHashSalt, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingUserName = (string) content.GetValueForProperty("PublishingUserName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).PublishingUserName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).ScmUri = (string) content.GetValueForProperty("ScmUri",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal)this).ScmUri, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// User resource specific properties
    [System.ComponentModel.TypeConverter(typeof(UserPropertiesTypeConverter))]
    public partial interface IUserProperties

    {

    }
}