// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;

    /// <summary>Properties of a migration.</summary>
    [System.ComponentModel.TypeConverter(typeof(MigrationTypeConverter))]
    public partial class Migration
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Migration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Migration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Migration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Migration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Migration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="Migration" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Migration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Migration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.TrackedResourceTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("Mode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Mode = (string) content.GetValueForProperty("Mode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Mode, global::System.Convert.ToString);
            }
            if (content.Contains("Option"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Option = (string) content.GetValueForProperty("Option",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Option, global::System.Convert.ToString);
            }
            if (content.Contains("SourceType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceType = (string) content.GetValueForProperty("SourceType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceType, global::System.Convert.ToString);
            }
            if (content.Contains("SslMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SslMode = (string) content.GetValueForProperty("SslMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SslMode, global::System.Convert.ToString);
            }
            if (content.Contains("TriggerCutover"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TriggerCutover = (string) content.GetValueForProperty("TriggerCutover",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TriggerCutover, global::System.Convert.ToString);
            }
            if (content.Contains("Cancel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Cancel = (string) content.GetValueForProperty("Cancel",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Cancel, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatus = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatus) content.GetValueForProperty("CurrentStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatus, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadata"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadata = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata) content.GetValueForProperty("SourceDbServerMetadata",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadata, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadataTypeConverter.ConvertFrom);
            }
            if (content.Contains("TargetDbServerMetadata"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadata = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata) content.GetValueForProperty("TargetDbServerMetadata",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadata, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadataTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecretParameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameter = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParameters) content.GetValueForProperty("SecretParameter",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameter, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSecretParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("MigrationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).MigrationId = (string) content.GetValueForProperty("MigrationId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).MigrationId, global::System.Convert.ToString);
            }
            if (content.Contains("InstanceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).InstanceResourceId = (string) content.GetValueForProperty("InstanceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).InstanceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerResourceId = (string) content.GetValueForProperty("SourceDbServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerFullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerFullyQualifiedDomainName = (string) content.GetValueForProperty("SourceDbServerFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerFullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerResourceId = (string) content.GetValueForProperty("TargetDbServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerFullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerFullyQualifiedDomainName = (string) content.GetValueForProperty("TargetDbServerFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerFullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToMigrate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).DbsToMigrate = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToMigrate",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).DbsToMigrate, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SetupLogicalReplicationOnSourceDbIfNeeded"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SetupLogicalReplicationOnSourceDbIfNeeded = (string) content.GetValueForProperty("SetupLogicalReplicationOnSourceDbIfNeeded",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SetupLogicalReplicationOnSourceDbIfNeeded, global::System.Convert.ToString);
            }
            if (content.Contains("OverwriteDbsInTarget"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).OverwriteDbsInTarget = (string) content.GetValueForProperty("OverwriteDbsInTarget",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).OverwriteDbsInTarget, global::System.Convert.ToString);
            }
            if (content.Contains("WindowStartTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).WindowStartTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("WindowStartTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).WindowStartTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("WindowEndTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).WindowEndTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("WindowEndTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).WindowEndTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("MigrateRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).MigrateRole = (string) content.GetValueForProperty("MigrateRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).MigrateRole, global::System.Convert.ToString);
            }
            if (content.Contains("StartDataMigration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).StartDataMigration = (string) content.GetValueForProperty("StartDataMigration",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).StartDataMigration, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToTriggerCutoverOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).DbsToTriggerCutoverOn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToTriggerCutoverOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).DbsToTriggerCutoverOn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DbsToCancelMigrationOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).DbsToCancelMigrationOn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToCancelMigrationOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).DbsToCancelMigrationOn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SecretParameterAdminCredentials"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameterAdminCredentials = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentials) content.GetValueForProperty("SecretParameterAdminCredentials",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameterAdminCredentials, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AdminCredentialsTypeConverter.ConvertFrom);
            }
            if (content.Contains("CurrentStatusCurrentSubStateDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatusCurrentSubStateDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails) content.GetValueForProperty("CurrentStatusCurrentSubStateDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatusCurrentSubStateDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSubstateDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("CurrentStatusState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatusState = (string) content.GetValueForProperty("CurrentStatusState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatusState, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentStatusError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatusError = (string) content.GetValueForProperty("CurrentStatusError",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatusError, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentSubStateDetailValidationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentSubStateDetailValidationDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails) content.GetValueForProperty("CurrentSubStateDetailValidationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentSubStateDetailValidationDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ValidationDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadataSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataSku = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku) content.GetValueForProperty("SourceDbServerMetadataSku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataSku, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadataLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataLocation = (string) content.GetValueForProperty("SourceDbServerMetadataLocation",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataLocation, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerMetadataVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataVersion = (string) content.GetValueForProperty("SourceDbServerMetadataVersion",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataVersion, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerMetadataStorageMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataStorageMb = (int?) content.GetValueForProperty("SourceDbServerMetadataStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SourceDbServerMetadataSkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataSkuTier = (string) content.GetValueForProperty("SourceDbServerMetadataSkuTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataSkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataSku = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku) content.GetValueForProperty("TargetDbServerMetadataSku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataSku, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("TargetDbServerMetadataLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataLocation = (string) content.GetValueForProperty("TargetDbServerMetadataLocation",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataLocation, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataVersion = (string) content.GetValueForProperty("TargetDbServerMetadataVersion",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataVersion, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataStorageMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataStorageMb = (int?) content.GetValueForProperty("TargetDbServerMetadataStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("TargetDbServerMetadataSkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataSkuTier = (string) content.GetValueForProperty("TargetDbServerMetadataSkuTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataSkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("SecretParameterSourceServerUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameterSourceServerUsername = (string) content.GetValueForProperty("SecretParameterSourceServerUsername",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameterSourceServerUsername, global::System.Convert.ToString);
            }
            if (content.Contains("SecretParameterTargetServerUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameterTargetServerUsername = (string) content.GetValueForProperty("SecretParameterTargetServerUsername",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameterTargetServerUsername, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentSubStateDetailCurrentSubState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentSubStateDetailCurrentSubState = (string) content.GetValueForProperty("CurrentSubStateDetailCurrentSubState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentSubStateDetailCurrentSubState, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentSubStateDetailDbDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentSubStateDetailDbDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails) content.GetValueForProperty("CurrentSubStateDetailDbDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentSubStateDetailDbDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSubstateDetailsDbDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadataSkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataSkuName = (string) content.GetValueForProperty("SourceDbServerMetadataSkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataSkuName, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataSkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataSkuName = (string) content.GetValueForProperty("TargetDbServerMetadataSkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataSkuName, global::System.Convert.ToString);
            }
            if (content.Contains("AdminCredentialsSourceServerPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).AdminCredentialsSourceServerPassword = (System.Security.SecureString) content.GetValueForProperty("AdminCredentialsSourceServerPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).AdminCredentialsSourceServerPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("AdminCredentialsTargetServerPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).AdminCredentialsTargetServerPassword = (System.Security.SecureString) content.GetValueForProperty("AdminCredentialsTargetServerPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).AdminCredentialsTargetServerPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("ValidationDetailStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailStatus = (string) content.GetValueForProperty("ValidationDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailStatus, global::System.Convert.ToString);
            }
            if (content.Contains("ValidationDetailValidationStartTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailValidationStartTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("ValidationDetailValidationStartTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailValidationStartTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ValidationDetailValidationEndTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailValidationEndTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("ValidationDetailValidationEndTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailValidationEndTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ValidationDetailServerLevelValidationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailServerLevelValidationDetail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem>) content.GetValueForProperty("ValidationDetailServerLevelValidationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailServerLevelValidationDetail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ValidationSummaryItemTypeConverter.ConvertFrom));
            }
            if (content.Contains("ValidationDetailDbLevelValidationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailDbLevelValidationDetail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus>) content.GetValueForProperty("ValidationDetailDbLevelValidationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailDbLevelValidationDetail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbLevelValidationStatusTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Migration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Migration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.TrackedResourceTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("Mode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Mode = (string) content.GetValueForProperty("Mode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Mode, global::System.Convert.ToString);
            }
            if (content.Contains("Option"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Option = (string) content.GetValueForProperty("Option",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Option, global::System.Convert.ToString);
            }
            if (content.Contains("SourceType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceType = (string) content.GetValueForProperty("SourceType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceType, global::System.Convert.ToString);
            }
            if (content.Contains("SslMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SslMode = (string) content.GetValueForProperty("SslMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SslMode, global::System.Convert.ToString);
            }
            if (content.Contains("TriggerCutover"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TriggerCutover = (string) content.GetValueForProperty("TriggerCutover",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TriggerCutover, global::System.Convert.ToString);
            }
            if (content.Contains("Cancel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Cancel = (string) content.GetValueForProperty("Cancel",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).Cancel, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatus = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatus) content.GetValueForProperty("CurrentStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatus, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadata"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadata = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata) content.GetValueForProperty("SourceDbServerMetadata",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadata, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadataTypeConverter.ConvertFrom);
            }
            if (content.Contains("TargetDbServerMetadata"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadata = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata) content.GetValueForProperty("TargetDbServerMetadata",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadata, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadataTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecretParameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameter = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParameters) content.GetValueForProperty("SecretParameter",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameter, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSecretParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("MigrationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).MigrationId = (string) content.GetValueForProperty("MigrationId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).MigrationId, global::System.Convert.ToString);
            }
            if (content.Contains("InstanceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).InstanceResourceId = (string) content.GetValueForProperty("InstanceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).InstanceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerResourceId = (string) content.GetValueForProperty("SourceDbServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerFullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerFullyQualifiedDomainName = (string) content.GetValueForProperty("SourceDbServerFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerFullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerResourceId = (string) content.GetValueForProperty("TargetDbServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerFullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerFullyQualifiedDomainName = (string) content.GetValueForProperty("TargetDbServerFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerFullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToMigrate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).DbsToMigrate = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToMigrate",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).DbsToMigrate, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SetupLogicalReplicationOnSourceDbIfNeeded"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SetupLogicalReplicationOnSourceDbIfNeeded = (string) content.GetValueForProperty("SetupLogicalReplicationOnSourceDbIfNeeded",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SetupLogicalReplicationOnSourceDbIfNeeded, global::System.Convert.ToString);
            }
            if (content.Contains("OverwriteDbsInTarget"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).OverwriteDbsInTarget = (string) content.GetValueForProperty("OverwriteDbsInTarget",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).OverwriteDbsInTarget, global::System.Convert.ToString);
            }
            if (content.Contains("WindowStartTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).WindowStartTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("WindowStartTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).WindowStartTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("WindowEndTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).WindowEndTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("WindowEndTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).WindowEndTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("MigrateRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).MigrateRole = (string) content.GetValueForProperty("MigrateRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).MigrateRole, global::System.Convert.ToString);
            }
            if (content.Contains("StartDataMigration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).StartDataMigration = (string) content.GetValueForProperty("StartDataMigration",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).StartDataMigration, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToTriggerCutoverOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).DbsToTriggerCutoverOn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToTriggerCutoverOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).DbsToTriggerCutoverOn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DbsToCancelMigrationOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).DbsToCancelMigrationOn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToCancelMigrationOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).DbsToCancelMigrationOn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SecretParameterAdminCredentials"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameterAdminCredentials = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentials) content.GetValueForProperty("SecretParameterAdminCredentials",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameterAdminCredentials, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AdminCredentialsTypeConverter.ConvertFrom);
            }
            if (content.Contains("CurrentStatusCurrentSubStateDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatusCurrentSubStateDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails) content.GetValueForProperty("CurrentStatusCurrentSubStateDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatusCurrentSubStateDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSubstateDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("CurrentStatusState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatusState = (string) content.GetValueForProperty("CurrentStatusState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatusState, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentStatusError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatusError = (string) content.GetValueForProperty("CurrentStatusError",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentStatusError, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentSubStateDetailValidationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentSubStateDetailValidationDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails) content.GetValueForProperty("CurrentSubStateDetailValidationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentSubStateDetailValidationDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ValidationDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadataSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataSku = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku) content.GetValueForProperty("SourceDbServerMetadataSku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataSku, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadataLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataLocation = (string) content.GetValueForProperty("SourceDbServerMetadataLocation",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataLocation, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerMetadataVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataVersion = (string) content.GetValueForProperty("SourceDbServerMetadataVersion",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataVersion, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerMetadataStorageMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataStorageMb = (int?) content.GetValueForProperty("SourceDbServerMetadataStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SourceDbServerMetadataSkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataSkuTier = (string) content.GetValueForProperty("SourceDbServerMetadataSkuTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataSkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataSku = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku) content.GetValueForProperty("TargetDbServerMetadataSku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataSku, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("TargetDbServerMetadataLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataLocation = (string) content.GetValueForProperty("TargetDbServerMetadataLocation",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataLocation, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataVersion = (string) content.GetValueForProperty("TargetDbServerMetadataVersion",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataVersion, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataStorageMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataStorageMb = (int?) content.GetValueForProperty("TargetDbServerMetadataStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("TargetDbServerMetadataSkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataSkuTier = (string) content.GetValueForProperty("TargetDbServerMetadataSkuTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataSkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("SecretParameterSourceServerUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameterSourceServerUsername = (string) content.GetValueForProperty("SecretParameterSourceServerUsername",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameterSourceServerUsername, global::System.Convert.ToString);
            }
            if (content.Contains("SecretParameterTargetServerUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameterTargetServerUsername = (string) content.GetValueForProperty("SecretParameterTargetServerUsername",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SecretParameterTargetServerUsername, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentSubStateDetailCurrentSubState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentSubStateDetailCurrentSubState = (string) content.GetValueForProperty("CurrentSubStateDetailCurrentSubState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentSubStateDetailCurrentSubState, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentSubStateDetailDbDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentSubStateDetailDbDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails) content.GetValueForProperty("CurrentSubStateDetailDbDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).CurrentSubStateDetailDbDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSubstateDetailsDbDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadataSkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataSkuName = (string) content.GetValueForProperty("SourceDbServerMetadataSkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).SourceDbServerMetadataSkuName, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataSkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataSkuName = (string) content.GetValueForProperty("TargetDbServerMetadataSkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).TargetDbServerMetadataSkuName, global::System.Convert.ToString);
            }
            if (content.Contains("AdminCredentialsSourceServerPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).AdminCredentialsSourceServerPassword = (System.Security.SecureString) content.GetValueForProperty("AdminCredentialsSourceServerPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).AdminCredentialsSourceServerPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("AdminCredentialsTargetServerPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).AdminCredentialsTargetServerPassword = (System.Security.SecureString) content.GetValueForProperty("AdminCredentialsTargetServerPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).AdminCredentialsTargetServerPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("ValidationDetailStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailStatus = (string) content.GetValueForProperty("ValidationDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailStatus, global::System.Convert.ToString);
            }
            if (content.Contains("ValidationDetailValidationStartTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailValidationStartTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("ValidationDetailValidationStartTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailValidationStartTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ValidationDetailValidationEndTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailValidationEndTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("ValidationDetailValidationEndTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailValidationEndTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ValidationDetailServerLevelValidationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailServerLevelValidationDetail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem>) content.GetValueForProperty("ValidationDetailServerLevelValidationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailServerLevelValidationDetail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ValidationSummaryItemTypeConverter.ConvertFrom));
            }
            if (content.Contains("ValidationDetailDbLevelValidationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailDbLevelValidationDetail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus>) content.GetValueForProperty("ValidationDetailDbLevelValidationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal)this).ValidationDetailDbLevelValidationDetail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbLevelValidationStatusTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// Properties of a migration.
    [System.ComponentModel.TypeConverter(typeof(MigrationTypeConverter))]
    public partial interface IMigration

    {

    }
}