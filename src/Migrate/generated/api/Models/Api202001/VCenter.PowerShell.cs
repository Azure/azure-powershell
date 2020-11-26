namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>VCenter REST Resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(VCenterTypeConverter))]
    public partial class VCenter
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VCenter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenter" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenter DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VCenter(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VCenter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenter" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenter DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VCenter(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VCenter" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenter FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VCenter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VCenter(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VCenterPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).CreatedTimestamp = (string) content.GetValueForProperty("CreatedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).CreatedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).UpdatedTimestamp = (string) content.GetValueForProperty("UpdatedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).UpdatedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Fqdn = (string) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Fqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Port = (string) content.GetValueForProperty("Port",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Port, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).RunAsAccountId = (string) content.GetValueForProperty("RunAsAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).RunAsAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Version = (string) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Version, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).PerfStatisticsLevel = (string) content.GetValueForProperty("PerfStatisticsLevel",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).PerfStatisticsLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).InstanceUuid = (string) content.GetValueForProperty("InstanceUuid",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).InstanceUuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[]) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Error, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HealthErrorDetailsTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VCenter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VCenter(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VCenterPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).CreatedTimestamp = (string) content.GetValueForProperty("CreatedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).CreatedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).UpdatedTimestamp = (string) content.GetValueForProperty("UpdatedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).UpdatedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Fqdn = (string) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Fqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Port = (string) content.GetValueForProperty("Port",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Port, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).RunAsAccountId = (string) content.GetValueForProperty("RunAsAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).RunAsAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Version = (string) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Version, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).PerfStatisticsLevel = (string) content.GetValueForProperty("PerfStatisticsLevel",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).PerfStatisticsLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).InstanceUuid = (string) content.GetValueForProperty("InstanceUuid",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).InstanceUuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[]) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterInternal)this).Error, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HealthErrorDetailsTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }
    }
    /// VCenter REST Resource.
    [System.ComponentModel.TypeConverter(typeof(VCenterTypeConverter))]
    public partial interface IVCenter

    {

    }
}