namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Migration item.</summary>
    [System.ComponentModel.TypeConverter(typeof(MigrationItemTypeConverter))]
    public partial class MigrationItem
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationItem"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MigrationItem(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationItem"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MigrationItem(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MigrationItem" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationItem"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MigrationItem(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationItemPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).MigrationState = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState?) content.GetValueForProperty("MigrationState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).MigrationState, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).TestMigrateStateDescription = (string) content.GetValueForProperty("TestMigrateStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).TestMigrateStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).PolicyId = (string) content.GetValueForProperty("PolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).PolicyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).PolicyFriendlyName = (string) content.GetValueForProperty("PolicyFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).PolicyFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJob = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetails) content.GetValueForProperty("CurrentJob",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJob, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentJobDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).MigrationStateDescription = (string) content.GetValueForProperty("MigrationStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).MigrationStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).LastTestMigrationTime = (global::System.DateTime?) content.GetValueForProperty("LastTestMigrationTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).LastTestMigrationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).LastTestMigrationStatus = (string) content.GetValueForProperty("LastTestMigrationStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).LastTestMigrationStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).TestMigrateState = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState?) content.GetValueForProperty("TestMigrateState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).TestMigrateState, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).MachineName = (string) content.GetValueForProperty("MachineName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).MachineName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).Health = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth?) content.GetValueForProperty("Health",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).Health, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).HealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).HealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).AllowedOperation = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation[]) content.GetValueForProperty("AllowedOperation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).AllowedOperation, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).EventCorrelationId = (string) content.GetValueForProperty("EventCorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).EventCorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).ProviderSpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationProviderSpecificSettings) content.GetValueForProperty("ProviderSpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).ProviderSpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationProviderSpecificSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJobName = (string) content.GetValueForProperty("CurrentJobName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJobId = (string) content.GetValueForProperty("CurrentJobId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJobStartTime = (global::System.DateTime?) content.GetValueForProperty("CurrentJobStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJobStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationItem"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MigrationItem(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationItemPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).MigrationState = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState?) content.GetValueForProperty("MigrationState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).MigrationState, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).TestMigrateStateDescription = (string) content.GetValueForProperty("TestMigrateStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).TestMigrateStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).PolicyId = (string) content.GetValueForProperty("PolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).PolicyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).PolicyFriendlyName = (string) content.GetValueForProperty("PolicyFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).PolicyFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJob = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetails) content.GetValueForProperty("CurrentJob",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJob, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentJobDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).MigrationStateDescription = (string) content.GetValueForProperty("MigrationStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).MigrationStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).LastTestMigrationTime = (global::System.DateTime?) content.GetValueForProperty("LastTestMigrationTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).LastTestMigrationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).LastTestMigrationStatus = (string) content.GetValueForProperty("LastTestMigrationStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).LastTestMigrationStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).TestMigrateState = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState?) content.GetValueForProperty("TestMigrateState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).TestMigrateState, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).MachineName = (string) content.GetValueForProperty("MachineName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).MachineName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).Health = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth?) content.GetValueForProperty("Health",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).Health, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).HealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).HealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).AllowedOperation = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation[]) content.GetValueForProperty("AllowedOperation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).AllowedOperation, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).EventCorrelationId = (string) content.GetValueForProperty("EventCorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).EventCorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).ProviderSpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationProviderSpecificSettings) content.GetValueForProperty("ProviderSpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).ProviderSpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationProviderSpecificSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJobName = (string) content.GetValueForProperty("CurrentJobName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJobId = (string) content.GetValueForProperty("CurrentJobId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJobStartTime = (global::System.DateTime?) content.GetValueForProperty("CurrentJobStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal)this).CurrentJobStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Migration item.
    [System.ComponentModel.TypeConverter(typeof(MigrationItemTypeConverter))]
    public partial interface IMigrationItem

    {

    }
}