namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Host REST Resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(HyperVHostTypeConverter))]
    public partial class HyperVHost
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVHost"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHost" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHost DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HyperVHost(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVHost"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHost" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHost DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HyperVHost(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HyperVHost" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHost FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVHost"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HyperVHost(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVHostPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).CreatedTimestamp = (string) content.GetValueForProperty("CreatedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).CreatedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).UpdatedTimestamp = (string) content.GetValueForProperty("UpdatedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).UpdatedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Fqdn = (string) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Fqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).RunAsAccountId = (string) content.GetValueForProperty("RunAsAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).RunAsAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Version = (string) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Version, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[]) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Error, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HealthErrorDetailsTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVHost"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HyperVHost(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVHostPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).CreatedTimestamp = (string) content.GetValueForProperty("CreatedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).CreatedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).UpdatedTimestamp = (string) content.GetValueForProperty("UpdatedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).UpdatedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Fqdn = (string) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Fqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).RunAsAccountId = (string) content.GetValueForProperty("RunAsAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).RunAsAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Version = (string) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Version, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[]) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostInternal)this).Error, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HealthErrorDetailsTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Host REST Resource.
    [System.ComponentModel.TypeConverter(typeof(HyperVHostTypeConverter))]
    public partial interface IHyperVHost

    {

    }
}