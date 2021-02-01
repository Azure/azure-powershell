namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.PowerShell;

    /// <summary>App resource payload</summary>
    [System.ComponentModel.TypeConverter(typeof(AppResourceTypeConverter))]
    public partial class AppResource
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.AppResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AppResource(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.AppResourcePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IManagedIdentityProperties) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ManagedIdentityPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).TemporaryDisk = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ITemporaryDisk) content.GetValueForProperty("TemporaryDisk",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).TemporaryDisk, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.TemporaryDiskTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDisk = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IPersistentDisk) content.GetValueForProperty("PersistentDisk",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDisk, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.PersistentDiskTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Public = (bool?) content.GetValueForProperty("Public",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Public, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Url = (string) content.GetValueForProperty("Url",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Url, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.AppResourceProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.AppResourceProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).ActiveDeploymentName = (string) content.GetValueForProperty("ActiveDeploymentName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).ActiveDeploymentName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Fqdn = (string) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Fqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).HttpsOnly = (bool?) content.GetValueForProperty("HttpsOnly",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).HttpsOnly, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).TemporaryDiskMountPath = (string) content.GetValueForProperty("TemporaryDiskMountPath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).TemporaryDiskMountPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDiskMountPath = (string) content.GetValueForProperty("PersistentDiskMountPath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDiskMountPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ManagedIdentityType?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ManagedIdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).CreatedTime = (global::System.DateTime?) content.GetValueForProperty("CreatedTime",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).CreatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDiskUsedInGb = (int?) content.GetValueForProperty("PersistentDiskUsedInGb",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDiskUsedInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDiskSizeInGb = (int?) content.GetValueForProperty("PersistentDiskSizeInGb",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDiskSizeInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).TemporaryDiskSizeInGb = (int?) content.GetValueForProperty("TemporaryDiskSizeInGb",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).TemporaryDiskSizeInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.AppResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AppResource(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.AppResourcePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IManagedIdentityProperties) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ManagedIdentityPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).TemporaryDisk = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ITemporaryDisk) content.GetValueForProperty("TemporaryDisk",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).TemporaryDisk, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.TemporaryDiskTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDisk = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IPersistentDisk) content.GetValueForProperty("PersistentDisk",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDisk, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.PersistentDiskTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Public = (bool?) content.GetValueForProperty("Public",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Public, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Url = (string) content.GetValueForProperty("Url",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Url, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.AppResourceProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.AppResourceProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).ActiveDeploymentName = (string) content.GetValueForProperty("ActiveDeploymentName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).ActiveDeploymentName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Fqdn = (string) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).Fqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).HttpsOnly = (bool?) content.GetValueForProperty("HttpsOnly",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).HttpsOnly, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).TemporaryDiskMountPath = (string) content.GetValueForProperty("TemporaryDiskMountPath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).TemporaryDiskMountPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDiskMountPath = (string) content.GetValueForProperty("PersistentDiskMountPath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDiskMountPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ManagedIdentityType?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ManagedIdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).CreatedTime = (global::System.DateTime?) content.GetValueForProperty("CreatedTime",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).CreatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDiskUsedInGb = (int?) content.GetValueForProperty("PersistentDiskUsedInGb",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDiskUsedInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDiskSizeInGb = (int?) content.GetValueForProperty("PersistentDiskSizeInGb",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).PersistentDiskSizeInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).TemporaryDiskSizeInGb = (int?) content.GetValueForProperty("TemporaryDiskSizeInGb",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceInternal)this).TemporaryDiskSizeInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.AppResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResource DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AppResource(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.AppResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResource DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AppResource(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AppResource" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResource FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// App resource payload
    [System.ComponentModel.TypeConverter(typeof(AppResourceTypeConverter))]
    public partial interface IAppResource

    {

    }
}