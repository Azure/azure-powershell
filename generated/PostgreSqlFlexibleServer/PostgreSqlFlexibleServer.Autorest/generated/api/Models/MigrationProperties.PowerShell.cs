// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;

    /// <summary>Migration.</summary>
    [System.ComponentModel.TypeConverter(typeof(MigrationPropertiesTypeConverter))]
    public partial class MigrationProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MigrationProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MigrationProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MigrationProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="MigrationProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MigrationProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("CurrentStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatus = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatus) content.GetValueForProperty("CurrentStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatus, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadata"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadata = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata) content.GetValueForProperty("SourceDbServerMetadata",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadata, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadataTypeConverter.ConvertFrom);
            }
            if (content.Contains("TargetDbServerMetadata"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadata = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata) content.GetValueForProperty("TargetDbServerMetadata",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadata, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadataTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecretParameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameter = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParameters) content.GetValueForProperty("SecretParameter",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameter, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSecretParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("MigrationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationId = (string) content.GetValueForProperty("MigrationId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationId, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationInstanceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationInstanceResourceId = (string) content.GetValueForProperty("MigrationInstanceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationInstanceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationMode = (string) content.GetValueForProperty("MigrationMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationMode, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationOption = (string) content.GetValueForProperty("MigrationOption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationOption, global::System.Convert.ToString);
            }
            if (content.Contains("SourceType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceType = (string) content.GetValueForProperty("SourceType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceType, global::System.Convert.ToString);
            }
            if (content.Contains("SslMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SslMode = (string) content.GetValueForProperty("SslMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SslMode, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerResourceId = (string) content.GetValueForProperty("SourceDbServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerFullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerFullyQualifiedDomainName = (string) content.GetValueForProperty("SourceDbServerFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerFullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerResourceId = (string) content.GetValueForProperty("TargetDbServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerFullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerFullyQualifiedDomainName = (string) content.GetValueForProperty("TargetDbServerFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerFullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToMigrate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).DbsToMigrate = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToMigrate",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).DbsToMigrate, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SetupLogicalReplicationOnSourceDbIfNeeded"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SetupLogicalReplicationOnSourceDbIfNeeded = (string) content.GetValueForProperty("SetupLogicalReplicationOnSourceDbIfNeeded",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SetupLogicalReplicationOnSourceDbIfNeeded, global::System.Convert.ToString);
            }
            if (content.Contains("OverwriteDbsInTarget"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).OverwriteDbsInTarget = (string) content.GetValueForProperty("OverwriteDbsInTarget",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).OverwriteDbsInTarget, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationWindowStartTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationWindowStartTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("MigrationWindowStartTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationWindowStartTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("MigrationWindowEndTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationWindowEndTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("MigrationWindowEndTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationWindowEndTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("MigrateRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrateRole = (string) content.GetValueForProperty("MigrateRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrateRole, global::System.Convert.ToString);
            }
            if (content.Contains("StartDataMigration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).StartDataMigration = (string) content.GetValueForProperty("StartDataMigration",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).StartDataMigration, global::System.Convert.ToString);
            }
            if (content.Contains("TriggerCutover"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TriggerCutover = (string) content.GetValueForProperty("TriggerCutover",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TriggerCutover, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToTriggerCutoverOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).DbsToTriggerCutoverOn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToTriggerCutoverOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).DbsToTriggerCutoverOn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("Cancel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).Cancel = (string) content.GetValueForProperty("Cancel",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).Cancel, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToCancelMigrationOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).DbsToCancelMigrationOn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToCancelMigrationOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).DbsToCancelMigrationOn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SecretParameterAdminCredentials"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameterAdminCredentials = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentials) content.GetValueForProperty("SecretParameterAdminCredentials",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameterAdminCredentials, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AdminCredentialsTypeConverter.ConvertFrom);
            }
            if (content.Contains("CurrentStatusCurrentSubStateDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatusCurrentSubStateDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails) content.GetValueForProperty("CurrentStatusCurrentSubStateDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatusCurrentSubStateDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSubstateDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("CurrentStatusState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatusState = (string) content.GetValueForProperty("CurrentStatusState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatusState, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentStatusError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatusError = (string) content.GetValueForProperty("CurrentStatusError",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatusError, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentSubStateDetailValidationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentSubStateDetailValidationDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails) content.GetValueForProperty("CurrentSubStateDetailValidationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentSubStateDetailValidationDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ValidationDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadataSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataSku = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku) content.GetValueForProperty("SourceDbServerMetadataSku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataSku, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadataLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataLocation = (string) content.GetValueForProperty("SourceDbServerMetadataLocation",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataLocation, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerMetadataVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataVersion = (string) content.GetValueForProperty("SourceDbServerMetadataVersion",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataVersion, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerMetadataStorageMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataStorageMb = (int?) content.GetValueForProperty("SourceDbServerMetadataStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SourceDbServerMetadataSkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataSkuTier = (string) content.GetValueForProperty("SourceDbServerMetadataSkuTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataSkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataSku = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku) content.GetValueForProperty("TargetDbServerMetadataSku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataSku, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("TargetDbServerMetadataLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataLocation = (string) content.GetValueForProperty("TargetDbServerMetadataLocation",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataLocation, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataVersion = (string) content.GetValueForProperty("TargetDbServerMetadataVersion",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataVersion, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataStorageMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataStorageMb = (int?) content.GetValueForProperty("TargetDbServerMetadataStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("TargetDbServerMetadataSkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataSkuTier = (string) content.GetValueForProperty("TargetDbServerMetadataSkuTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataSkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("SecretParameterSourceServerUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameterSourceServerUsername = (string) content.GetValueForProperty("SecretParameterSourceServerUsername",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameterSourceServerUsername, global::System.Convert.ToString);
            }
            if (content.Contains("SecretParameterTargetServerUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameterTargetServerUsername = (string) content.GetValueForProperty("SecretParameterTargetServerUsername",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameterTargetServerUsername, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentSubStateDetailCurrentSubState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentSubStateDetailCurrentSubState = (string) content.GetValueForProperty("CurrentSubStateDetailCurrentSubState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentSubStateDetailCurrentSubState, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentSubStateDetailDbDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentSubStateDetailDbDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails) content.GetValueForProperty("CurrentSubStateDetailDbDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentSubStateDetailDbDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSubstateDetailsDbDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadataSkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataSkuName = (string) content.GetValueForProperty("SourceDbServerMetadataSkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataSkuName, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataSkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataSkuName = (string) content.GetValueForProperty("TargetDbServerMetadataSkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataSkuName, global::System.Convert.ToString);
            }
            if (content.Contains("AdminCredentialsSourceServerPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).AdminCredentialsSourceServerPassword = (System.Security.SecureString) content.GetValueForProperty("AdminCredentialsSourceServerPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).AdminCredentialsSourceServerPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("AdminCredentialsTargetServerPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).AdminCredentialsTargetServerPassword = (System.Security.SecureString) content.GetValueForProperty("AdminCredentialsTargetServerPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).AdminCredentialsTargetServerPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("ValidationDetailStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailStatus = (string) content.GetValueForProperty("ValidationDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailStatus, global::System.Convert.ToString);
            }
            if (content.Contains("ValidationDetailValidationStartTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailValidationStartTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("ValidationDetailValidationStartTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailValidationStartTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ValidationDetailValidationEndTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailValidationEndTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("ValidationDetailValidationEndTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailValidationEndTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ValidationDetailServerLevelValidationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailServerLevelValidationDetail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem>) content.GetValueForProperty("ValidationDetailServerLevelValidationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailServerLevelValidationDetail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ValidationSummaryItemTypeConverter.ConvertFrom));
            }
            if (content.Contains("ValidationDetailDbLevelValidationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailDbLevelValidationDetail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus>) content.GetValueForProperty("ValidationDetailDbLevelValidationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailDbLevelValidationDetail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbLevelValidationStatusTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MigrationProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("CurrentStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatus = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatus) content.GetValueForProperty("CurrentStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatus, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadata"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadata = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata) content.GetValueForProperty("SourceDbServerMetadata",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadata, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadataTypeConverter.ConvertFrom);
            }
            if (content.Contains("TargetDbServerMetadata"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadata = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata) content.GetValueForProperty("TargetDbServerMetadata",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadata, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadataTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecretParameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameter = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParameters) content.GetValueForProperty("SecretParameter",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameter, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSecretParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("MigrationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationId = (string) content.GetValueForProperty("MigrationId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationId, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationInstanceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationInstanceResourceId = (string) content.GetValueForProperty("MigrationInstanceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationInstanceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationMode = (string) content.GetValueForProperty("MigrationMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationMode, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationOption = (string) content.GetValueForProperty("MigrationOption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationOption, global::System.Convert.ToString);
            }
            if (content.Contains("SourceType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceType = (string) content.GetValueForProperty("SourceType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceType, global::System.Convert.ToString);
            }
            if (content.Contains("SslMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SslMode = (string) content.GetValueForProperty("SslMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SslMode, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerResourceId = (string) content.GetValueForProperty("SourceDbServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerFullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerFullyQualifiedDomainName = (string) content.GetValueForProperty("SourceDbServerFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerFullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerResourceId = (string) content.GetValueForProperty("TargetDbServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerFullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerFullyQualifiedDomainName = (string) content.GetValueForProperty("TargetDbServerFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerFullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToMigrate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).DbsToMigrate = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToMigrate",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).DbsToMigrate, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SetupLogicalReplicationOnSourceDbIfNeeded"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SetupLogicalReplicationOnSourceDbIfNeeded = (string) content.GetValueForProperty("SetupLogicalReplicationOnSourceDbIfNeeded",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SetupLogicalReplicationOnSourceDbIfNeeded, global::System.Convert.ToString);
            }
            if (content.Contains("OverwriteDbsInTarget"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).OverwriteDbsInTarget = (string) content.GetValueForProperty("OverwriteDbsInTarget",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).OverwriteDbsInTarget, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationWindowStartTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationWindowStartTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("MigrationWindowStartTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationWindowStartTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("MigrationWindowEndTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationWindowEndTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("MigrationWindowEndTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrationWindowEndTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("MigrateRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrateRole = (string) content.GetValueForProperty("MigrateRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).MigrateRole, global::System.Convert.ToString);
            }
            if (content.Contains("StartDataMigration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).StartDataMigration = (string) content.GetValueForProperty("StartDataMigration",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).StartDataMigration, global::System.Convert.ToString);
            }
            if (content.Contains("TriggerCutover"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TriggerCutover = (string) content.GetValueForProperty("TriggerCutover",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TriggerCutover, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToTriggerCutoverOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).DbsToTriggerCutoverOn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToTriggerCutoverOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).DbsToTriggerCutoverOn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("Cancel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).Cancel = (string) content.GetValueForProperty("Cancel",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).Cancel, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToCancelMigrationOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).DbsToCancelMigrationOn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToCancelMigrationOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).DbsToCancelMigrationOn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SecretParameterAdminCredentials"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameterAdminCredentials = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentials) content.GetValueForProperty("SecretParameterAdminCredentials",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameterAdminCredentials, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AdminCredentialsTypeConverter.ConvertFrom);
            }
            if (content.Contains("CurrentStatusCurrentSubStateDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatusCurrentSubStateDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails) content.GetValueForProperty("CurrentStatusCurrentSubStateDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatusCurrentSubStateDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSubstateDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("CurrentStatusState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatusState = (string) content.GetValueForProperty("CurrentStatusState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatusState, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentStatusError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatusError = (string) content.GetValueForProperty("CurrentStatusError",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentStatusError, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentSubStateDetailValidationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentSubStateDetailValidationDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails) content.GetValueForProperty("CurrentSubStateDetailValidationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentSubStateDetailValidationDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ValidationDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadataSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataSku = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku) content.GetValueForProperty("SourceDbServerMetadataSku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataSku, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadataLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataLocation = (string) content.GetValueForProperty("SourceDbServerMetadataLocation",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataLocation, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerMetadataVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataVersion = (string) content.GetValueForProperty("SourceDbServerMetadataVersion",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataVersion, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerMetadataStorageMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataStorageMb = (int?) content.GetValueForProperty("SourceDbServerMetadataStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SourceDbServerMetadataSkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataSkuTier = (string) content.GetValueForProperty("SourceDbServerMetadataSkuTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataSkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataSku = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku) content.GetValueForProperty("TargetDbServerMetadataSku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataSku, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("TargetDbServerMetadataLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataLocation = (string) content.GetValueForProperty("TargetDbServerMetadataLocation",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataLocation, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataVersion = (string) content.GetValueForProperty("TargetDbServerMetadataVersion",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataVersion, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataStorageMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataStorageMb = (int?) content.GetValueForProperty("TargetDbServerMetadataStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("TargetDbServerMetadataSkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataSkuTier = (string) content.GetValueForProperty("TargetDbServerMetadataSkuTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataSkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("SecretParameterSourceServerUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameterSourceServerUsername = (string) content.GetValueForProperty("SecretParameterSourceServerUsername",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameterSourceServerUsername, global::System.Convert.ToString);
            }
            if (content.Contains("SecretParameterTargetServerUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameterTargetServerUsername = (string) content.GetValueForProperty("SecretParameterTargetServerUsername",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SecretParameterTargetServerUsername, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentSubStateDetailCurrentSubState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentSubStateDetailCurrentSubState = (string) content.GetValueForProperty("CurrentSubStateDetailCurrentSubState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentSubStateDetailCurrentSubState, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentSubStateDetailDbDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentSubStateDetailDbDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails) content.GetValueForProperty("CurrentSubStateDetailDbDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).CurrentSubStateDetailDbDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSubstateDetailsDbDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerMetadataSkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataSkuName = (string) content.GetValueForProperty("SourceDbServerMetadataSkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).SourceDbServerMetadataSkuName, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerMetadataSkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataSkuName = (string) content.GetValueForProperty("TargetDbServerMetadataSkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).TargetDbServerMetadataSkuName, global::System.Convert.ToString);
            }
            if (content.Contains("AdminCredentialsSourceServerPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).AdminCredentialsSourceServerPassword = (System.Security.SecureString) content.GetValueForProperty("AdminCredentialsSourceServerPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).AdminCredentialsSourceServerPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("AdminCredentialsTargetServerPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).AdminCredentialsTargetServerPassword = (System.Security.SecureString) content.GetValueForProperty("AdminCredentialsTargetServerPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).AdminCredentialsTargetServerPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("ValidationDetailStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailStatus = (string) content.GetValueForProperty("ValidationDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailStatus, global::System.Convert.ToString);
            }
            if (content.Contains("ValidationDetailValidationStartTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailValidationStartTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("ValidationDetailValidationStartTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailValidationStartTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ValidationDetailValidationEndTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailValidationEndTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("ValidationDetailValidationEndTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailValidationEndTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ValidationDetailServerLevelValidationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailServerLevelValidationDetail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem>) content.GetValueForProperty("ValidationDetailServerLevelValidationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailServerLevelValidationDetail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ValidationSummaryItemTypeConverter.ConvertFrom));
            }
            if (content.Contains("ValidationDetailDbLevelValidationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailDbLevelValidationDetail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus>) content.GetValueForProperty("ValidationDetailDbLevelValidationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)this).ValidationDetailDbLevelValidationDetail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbLevelValidationStatusTypeConverter.ConvertFrom));
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
    /// Migration.
    [System.ComponentModel.TypeConverter(typeof(MigrationPropertiesTypeConverter))]
    public partial interface IMigrationProperties

    {

    }
}