namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.PowerShell;

    /// <summary>An HCX Enterprise Site resource</summary>
    [System.ComponentModel.TypeConverter(typeof(HcxEnterpriseSiteTypeConverter))]
    public partial class HcxEnterpriseSite
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.HcxEnterpriseSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSite" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSite DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HcxEnterpriseSite(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.HcxEnterpriseSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSite" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSite DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HcxEnterpriseSite(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HcxEnterpriseSite" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSite FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.HcxEnterpriseSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HcxEnterpriseSite(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.HcxEnterpriseSitePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal)this).ActivationKey = (string) content.GetValueForProperty("ActivationKey",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal)this).ActivationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.HcxEnterpriseSiteStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.HcxEnterpriseSiteStatus.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.HcxEnterpriseSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HcxEnterpriseSite(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.HcxEnterpriseSitePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal)this).ActivationKey = (string) content.GetValueForProperty("ActivationKey",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal)this).ActivationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.HcxEnterpriseSiteStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.HcxEnterpriseSiteStatus.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// An HCX Enterprise Site resource
    [System.ComponentModel.TypeConverter(typeof(HcxEnterpriseSiteTypeConverter))]
    public partial interface IHcxEnterpriseSite

    {

    }
}