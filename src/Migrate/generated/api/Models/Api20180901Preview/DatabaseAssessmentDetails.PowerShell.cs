namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Assessment properties that can be shared by various publishers.</summary>
    [System.ComponentModel.TypeConverter(typeof(DatabaseAssessmentDetailsTypeConverter))]
    public partial class DatabaseAssessmentDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DatabaseAssessmentDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DatabaseAssessmentDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).AssessmentId = (string) content.GetValueForProperty("AssessmentId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).AssessmentId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).MigrationBlockersCount = (int?) content.GetValueForProperty("MigrationBlockersCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).MigrationBlockersCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).BreakingChangesCount = (int?) content.GetValueForProperty("BreakingChangesCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).BreakingChangesCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).IsReadyForMigration = (bool?) content.GetValueForProperty("IsReadyForMigration",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).IsReadyForMigration, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).AssessmentTargetType = (string) content.GetValueForProperty("AssessmentTargetType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).AssessmentTargetType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).LastAssessedTime = (global::System.DateTime?) content.GetValueForProperty("LastAssessedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).LastAssessedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).CompatibilityLevel = (string) content.GetValueForProperty("CompatibilityLevel",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).CompatibilityLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).DatabaseSizeInMb = (string) content.GetValueForProperty("DatabaseSizeInMb",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).DatabaseSizeInMb, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).LastUpdatedTime = (global::System.DateTime?) content.GetValueForProperty("LastUpdatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).LastUpdatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).EnqueueTime = (string) content.GetValueForProperty("EnqueueTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).EnqueueTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).SolutionName = (string) content.GetValueForProperty("SolutionName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).SolutionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).InstanceId = (string) content.GetValueForProperty("InstanceId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).InstanceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).DatabaseName = (string) content.GetValueForProperty("DatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).DatabaseName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).ExtendedInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsExtendedInfo) content.GetValueForProperty("ExtendedInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).ExtendedInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DatabaseAssessmentDetailsExtendedInfoTypeConverter.ConvertFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DatabaseAssessmentDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DatabaseAssessmentDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).AssessmentId = (string) content.GetValueForProperty("AssessmentId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).AssessmentId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).MigrationBlockersCount = (int?) content.GetValueForProperty("MigrationBlockersCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).MigrationBlockersCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).BreakingChangesCount = (int?) content.GetValueForProperty("BreakingChangesCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).BreakingChangesCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).IsReadyForMigration = (bool?) content.GetValueForProperty("IsReadyForMigration",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).IsReadyForMigration, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).AssessmentTargetType = (string) content.GetValueForProperty("AssessmentTargetType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).AssessmentTargetType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).LastAssessedTime = (global::System.DateTime?) content.GetValueForProperty("LastAssessedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).LastAssessedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).CompatibilityLevel = (string) content.GetValueForProperty("CompatibilityLevel",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).CompatibilityLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).DatabaseSizeInMb = (string) content.GetValueForProperty("DatabaseSizeInMb",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).DatabaseSizeInMb, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).LastUpdatedTime = (global::System.DateTime?) content.GetValueForProperty("LastUpdatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).LastUpdatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).EnqueueTime = (string) content.GetValueForProperty("EnqueueTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).EnqueueTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).SolutionName = (string) content.GetValueForProperty("SolutionName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).SolutionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).InstanceId = (string) content.GetValueForProperty("InstanceId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).InstanceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).DatabaseName = (string) content.GetValueForProperty("DatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).DatabaseName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).ExtendedInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsExtendedInfo) content.GetValueForProperty("ExtendedInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal)this).ExtendedInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DatabaseAssessmentDetailsExtendedInfoTypeConverter.ConvertFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DatabaseAssessmentDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DatabaseAssessmentDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DatabaseAssessmentDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DatabaseAssessmentDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DatabaseAssessmentDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Assessment properties that can be shared by various publishers.
    [System.ComponentModel.TypeConverter(typeof(DatabaseAssessmentDetailsTypeConverter))]
    public partial interface IDatabaseAssessmentDetails

    {

    }
}