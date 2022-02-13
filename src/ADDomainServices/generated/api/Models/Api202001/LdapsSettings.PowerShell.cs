namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.PowerShell;

    /// <summary>Secure LDAP Settings</summary>
    [System.ComponentModel.TypeConverter(typeof(LdapsSettingsTypeConverter))]
    public partial class LdapsSettings
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettings" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettings DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new LdapsSettings(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettings" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettings DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new LdapsSettings(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="LdapsSettings" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettings FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal LdapsSettings(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).Ldap = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps?) content.GetValueForProperty("Ldap",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).Ldap, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).PfxCertificate = (string) content.GetValueForProperty("PfxCertificate",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).PfxCertificate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).PfxCertificatePassword = (string) content.GetValueForProperty("PfxCertificatePassword",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).PfxCertificatePassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).PublicCertificate = (string) content.GetValueForProperty("PublicCertificate",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).PublicCertificate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).CertificateThumbprint = (string) content.GetValueForProperty("CertificateThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).CertificateThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).CertificateNotAfter = (global::System.DateTime?) content.GetValueForProperty("CertificateNotAfter",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).CertificateNotAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).ExternalAccess = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess?) content.GetValueForProperty("ExternalAccess",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).ExternalAccess, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal LdapsSettings(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).Ldap = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps?) content.GetValueForProperty("Ldap",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).Ldap, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).PfxCertificate = (string) content.GetValueForProperty("PfxCertificate",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).PfxCertificate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).PfxCertificatePassword = (string) content.GetValueForProperty("PfxCertificatePassword",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).PfxCertificatePassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).PublicCertificate = (string) content.GetValueForProperty("PublicCertificate",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).PublicCertificate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).CertificateThumbprint = (string) content.GetValueForProperty("CertificateThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).CertificateThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).CertificateNotAfter = (global::System.DateTime?) content.GetValueForProperty("CertificateNotAfter",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).CertificateNotAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).ExternalAccess = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess?) content.GetValueForProperty("ExternalAccess",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)this).ExternalAccess, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Secure LDAP Settings
    [System.ComponentModel.TypeConverter(typeof(LdapsSettingsTypeConverter))]
    public partial interface ILdapsSettings

    {

    }
}