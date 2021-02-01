namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell;

    /// <summary>Active Directory service principal information.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServicePrincipalTypeConverter))]
    public partial class ServicePrincipal
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ServicePrincipal"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServicePrincipal(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ServicePrincipal"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServicePrincipal(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServicePrincipal" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ServicePrincipal"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServicePrincipal(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AccountEnabled = (bool?) content.GetValueForProperty("AccountEnabled",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AccountEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AlternativeName = (string[]) content.GetValueForProperty("AlternativeName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AlternativeName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppDisplayName = (string) content.GetValueForProperty("AppDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppDisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppId = (string) content.GetValueForProperty("AppId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppOwnerTenantId = (string) content.GetValueForProperty("AppOwnerTenantId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppOwnerTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppRoleAssignmentRequired = (bool?) content.GetValueForProperty("AppRoleAssignmentRequired",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppRoleAssignmentRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppRole = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[]) content.GetValueForProperty("AppRole",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppRole, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.AppRoleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).ErrorUrl = (string) content.GetValueForProperty("ErrorUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).ErrorUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Homepage = (string) content.GetValueForProperty("Homepage",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Homepage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).KeyCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]) content.GetValueForProperty("KeyCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).KeyCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.KeyCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).LogoutUrl = (string) content.GetValueForProperty("LogoutUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).LogoutUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Oauth2Permission = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[]) content.GetValueForProperty("Oauth2Permission",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Oauth2Permission, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2PermissionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).PasswordCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]) content.GetValueForProperty("PasswordCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).PasswordCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).PreferredTokenSigningKeyThumbprint = (string) content.GetValueForProperty("PreferredTokenSigningKeyThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).PreferredTokenSigningKeyThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).PublisherName = (string) content.GetValueForProperty("PublisherName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).PublisherName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).ReplyUrl = (string[]) content.GetValueForProperty("ReplyUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).ReplyUrl, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).SamlMetadataUrl = (string) content.GetValueForProperty("SamlMetadataUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).SamlMetadataUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Name = (string[]) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Name, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Tag = (string[]) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Tag, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).DeletionTimestamp = (global::System.DateTime?) content.GetValueForProperty("DeletionTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).DeletionTimestamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectId = (string) content.GetValueForProperty("ObjectId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectType, global::System.Convert.ToString);
            // this type is a dictionary; copy elements from source to here.
            CopyFrom(content);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ServicePrincipal"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServicePrincipal(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AccountEnabled = (bool?) content.GetValueForProperty("AccountEnabled",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AccountEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AlternativeName = (string[]) content.GetValueForProperty("AlternativeName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AlternativeName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppDisplayName = (string) content.GetValueForProperty("AppDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppDisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppId = (string) content.GetValueForProperty("AppId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppOwnerTenantId = (string) content.GetValueForProperty("AppOwnerTenantId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppOwnerTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppRoleAssignmentRequired = (bool?) content.GetValueForProperty("AppRoleAssignmentRequired",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppRoleAssignmentRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppRole = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[]) content.GetValueForProperty("AppRole",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).AppRole, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.AppRoleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).ErrorUrl = (string) content.GetValueForProperty("ErrorUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).ErrorUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Homepage = (string) content.GetValueForProperty("Homepage",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Homepage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).KeyCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]) content.GetValueForProperty("KeyCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).KeyCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.KeyCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).LogoutUrl = (string) content.GetValueForProperty("LogoutUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).LogoutUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Oauth2Permission = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[]) content.GetValueForProperty("Oauth2Permission",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Oauth2Permission, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2PermissionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).PasswordCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]) content.GetValueForProperty("PasswordCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).PasswordCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).PreferredTokenSigningKeyThumbprint = (string) content.GetValueForProperty("PreferredTokenSigningKeyThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).PreferredTokenSigningKeyThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).PublisherName = (string) content.GetValueForProperty("PublisherName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).PublisherName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).ReplyUrl = (string[]) content.GetValueForProperty("ReplyUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).ReplyUrl, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).SamlMetadataUrl = (string) content.GetValueForProperty("SamlMetadataUrl",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).SamlMetadataUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Name = (string[]) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Name, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Tag = (string[]) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal)this).Tag, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).DeletionTimestamp = (global::System.DateTime?) content.GetValueForProperty("DeletionTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).DeletionTimestamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectId = (string) content.GetValueForProperty("ObjectId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectType, global::System.Convert.ToString);
            // this type is a dictionary; copy elements from source to here.
            CopyFrom(content);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Active Directory service principal information.
    [System.ComponentModel.TypeConverter(typeof(ServicePrincipalTypeConverter))]
    public partial interface IServicePrincipal

    {

    }
}