namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Migration item properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(MigrationItemPropertiesTypeConverter))]
    public partial class MigrationItemProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationItemProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MigrationItemProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationItemProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MigrationItemProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MigrationItemProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationItemProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MigrationItemProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJob = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetails) content.GetValueForProperty("CurrentJob",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJob, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentJobDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).MachineName = (string) content.GetValueForProperty("MachineName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).MachineName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).PolicyId = (string) content.GetValueForProperty("PolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).PolicyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).PolicyFriendlyName = (string) content.GetValueForProperty("PolicyFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).PolicyFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).MigrationState = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState?) content.GetValueForProperty("MigrationState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).MigrationState, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).MigrationStateDescription = (string) content.GetValueForProperty("MigrationStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).MigrationStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).LastTestMigrationTime = (global::System.DateTime?) content.GetValueForProperty("LastTestMigrationTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).LastTestMigrationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).LastTestMigrationStatus = (string) content.GetValueForProperty("LastTestMigrationStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).LastTestMigrationStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).TestMigrateState = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState?) content.GetValueForProperty("TestMigrateState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).TestMigrateState, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).TestMigrateStateDescription = (string) content.GetValueForProperty("TestMigrateStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).TestMigrateStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).Health = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth?) content.GetValueForProperty("Health",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).Health, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).HealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).HealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).AllowedOperation = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation[]) content.GetValueForProperty("AllowedOperation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).AllowedOperation, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).EventCorrelationId = (string) content.GetValueForProperty("EventCorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).EventCorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).ProviderSpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationProviderSpecificSettings) content.GetValueForProperty("ProviderSpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).ProviderSpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationProviderSpecificSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJobName = (string) content.GetValueForProperty("CurrentJobName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJobId = (string) content.GetValueForProperty("CurrentJobId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJobStartTime = (global::System.DateTime?) content.GetValueForProperty("CurrentJobStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJobStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationItemProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MigrationItemProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJob = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetails) content.GetValueForProperty("CurrentJob",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJob, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentJobDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).MachineName = (string) content.GetValueForProperty("MachineName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).MachineName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).PolicyId = (string) content.GetValueForProperty("PolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).PolicyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).PolicyFriendlyName = (string) content.GetValueForProperty("PolicyFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).PolicyFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).MigrationState = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState?) content.GetValueForProperty("MigrationState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).MigrationState, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).MigrationStateDescription = (string) content.GetValueForProperty("MigrationStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).MigrationStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).LastTestMigrationTime = (global::System.DateTime?) content.GetValueForProperty("LastTestMigrationTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).LastTestMigrationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).LastTestMigrationStatus = (string) content.GetValueForProperty("LastTestMigrationStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).LastTestMigrationStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).TestMigrateState = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState?) content.GetValueForProperty("TestMigrateState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).TestMigrateState, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).TestMigrateStateDescription = (string) content.GetValueForProperty("TestMigrateStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).TestMigrateStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).Health = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth?) content.GetValueForProperty("Health",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).Health, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).HealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).HealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).AllowedOperation = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation[]) content.GetValueForProperty("AllowedOperation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).AllowedOperation, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).EventCorrelationId = (string) content.GetValueForProperty("EventCorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).EventCorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).ProviderSpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationProviderSpecificSettings) content.GetValueForProperty("ProviderSpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).ProviderSpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationProviderSpecificSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJobName = (string) content.GetValueForProperty("CurrentJobName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJobName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJobId = (string) content.GetValueForProperty("CurrentJobId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJobStartTime = (global::System.DateTime?) content.GetValueForProperty("CurrentJobStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)this).CurrentJobStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Migration item properties.
    [System.ComponentModel.TypeConverter(typeof(MigrationItemPropertiesTypeConverter))]
    public partial interface IMigrationItemProperties

    {

    }
}