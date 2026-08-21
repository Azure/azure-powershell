// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;

    /// <summary>Migration.</summary>
    [System.ComponentModel.TypeConverter(typeof(MigrationResourceForPatchTypeConverter))]
    public partial class MigrationResourceForPatch
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationResourceForPatch"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatch"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatch DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MigrationResourceForPatch(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationResourceForPatch"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatch"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatch DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MigrationResourceForPatch(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MigrationResourceForPatch" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="MigrationResourceForPatch" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatch FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationResourceForPatch"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MigrationResourceForPatch(global::System.Collections.IDictionary content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatch) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationPropertiesForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationResourceForPatchTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("TriggerCutover"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).TriggerCutover = (string) content.GetValueForProperty("TriggerCutover",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).TriggerCutover, global::System.Convert.ToString);
            }
            if (content.Contains("Cancel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).Cancel = (string) content.GetValueForProperty("Cancel",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).Cancel, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).MigrationMode = (string) content.GetValueForProperty("MigrationMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).MigrationMode, global::System.Convert.ToString);
            }
            if (content.Contains("SecretParameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameter = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatch) content.GetValueForProperty("SecretParameter",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameter, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSecretParametersForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SourceDbServerResourceId = (string) content.GetValueForProperty("SourceDbServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SourceDbServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerFullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SourceDbServerFullyQualifiedDomainName = (string) content.GetValueForProperty("SourceDbServerFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SourceDbServerFullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerFullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).TargetDbServerFullyQualifiedDomainName = (string) content.GetValueForProperty("TargetDbServerFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).TargetDbServerFullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToMigrate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).DbsToMigrate = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToMigrate",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).DbsToMigrate, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SetupLogicalReplicationOnSourceDbIfNeeded"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SetupLogicalReplicationOnSourceDbIfNeeded = (string) content.GetValueForProperty("SetupLogicalReplicationOnSourceDbIfNeeded",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SetupLogicalReplicationOnSourceDbIfNeeded, global::System.Convert.ToString);
            }
            if (content.Contains("OverwriteDbsInTarget"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).OverwriteDbsInTarget = (string) content.GetValueForProperty("OverwriteDbsInTarget",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).OverwriteDbsInTarget, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationWindowStartTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).MigrationWindowStartTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("MigrationWindowStartTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).MigrationWindowStartTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("MigrateRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).MigrateRole = (string) content.GetValueForProperty("MigrateRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).MigrateRole, global::System.Convert.ToString);
            }
            if (content.Contains("StartDataMigration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).StartDataMigration = (string) content.GetValueForProperty("StartDataMigration",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).StartDataMigration, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToTriggerCutoverOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).DbsToTriggerCutoverOn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToTriggerCutoverOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).DbsToTriggerCutoverOn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DbsToCancelMigrationOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).DbsToCancelMigrationOn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToCancelMigrationOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).DbsToCancelMigrationOn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SecretParameterAdminCredentials"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameterAdminCredentials = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentialsForPatch) content.GetValueForProperty("SecretParameterAdminCredentials",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameterAdminCredentials, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AdminCredentialsForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecretParameterSourceServerUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameterSourceServerUsername = (string) content.GetValueForProperty("SecretParameterSourceServerUsername",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameterSourceServerUsername, global::System.Convert.ToString);
            }
            if (content.Contains("SecretParameterTargetServerUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameterTargetServerUsername = (string) content.GetValueForProperty("SecretParameterTargetServerUsername",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameterTargetServerUsername, global::System.Convert.ToString);
            }
            if (content.Contains("AdminCredentialsSourceServerPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).AdminCredentialsSourceServerPassword = (System.Security.SecureString) content.GetValueForProperty("AdminCredentialsSourceServerPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).AdminCredentialsSourceServerPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("AdminCredentialsTargetServerPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).AdminCredentialsTargetServerPassword = (System.Security.SecureString) content.GetValueForProperty("AdminCredentialsTargetServerPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).AdminCredentialsTargetServerPassword, (object ss) => (System.Security.SecureString)ss);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationResourceForPatch"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MigrationResourceForPatch(global::System.Management.Automation.PSObject content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatch) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationPropertiesForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationResourceForPatchTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("TriggerCutover"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).TriggerCutover = (string) content.GetValueForProperty("TriggerCutover",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).TriggerCutover, global::System.Convert.ToString);
            }
            if (content.Contains("Cancel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).Cancel = (string) content.GetValueForProperty("Cancel",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).Cancel, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).MigrationMode = (string) content.GetValueForProperty("MigrationMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).MigrationMode, global::System.Convert.ToString);
            }
            if (content.Contains("SecretParameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameter = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatch) content.GetValueForProperty("SecretParameter",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameter, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSecretParametersForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDbServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SourceDbServerResourceId = (string) content.GetValueForProperty("SourceDbServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SourceDbServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("SourceDbServerFullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SourceDbServerFullyQualifiedDomainName = (string) content.GetValueForProperty("SourceDbServerFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SourceDbServerFullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("TargetDbServerFullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).TargetDbServerFullyQualifiedDomainName = (string) content.GetValueForProperty("TargetDbServerFullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).TargetDbServerFullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToMigrate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).DbsToMigrate = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToMigrate",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).DbsToMigrate, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SetupLogicalReplicationOnSourceDbIfNeeded"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SetupLogicalReplicationOnSourceDbIfNeeded = (string) content.GetValueForProperty("SetupLogicalReplicationOnSourceDbIfNeeded",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SetupLogicalReplicationOnSourceDbIfNeeded, global::System.Convert.ToString);
            }
            if (content.Contains("OverwriteDbsInTarget"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).OverwriteDbsInTarget = (string) content.GetValueForProperty("OverwriteDbsInTarget",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).OverwriteDbsInTarget, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationWindowStartTimeInUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).MigrationWindowStartTimeInUtc = (global::System.DateTime?) content.GetValueForProperty("MigrationWindowStartTimeInUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).MigrationWindowStartTimeInUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("MigrateRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).MigrateRole = (string) content.GetValueForProperty("MigrateRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).MigrateRole, global::System.Convert.ToString);
            }
            if (content.Contains("StartDataMigration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).StartDataMigration = (string) content.GetValueForProperty("StartDataMigration",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).StartDataMigration, global::System.Convert.ToString);
            }
            if (content.Contains("DbsToTriggerCutoverOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).DbsToTriggerCutoverOn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToTriggerCutoverOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).DbsToTriggerCutoverOn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DbsToCancelMigrationOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).DbsToCancelMigrationOn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DbsToCancelMigrationOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).DbsToCancelMigrationOn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SecretParameterAdminCredentials"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameterAdminCredentials = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentialsForPatch) content.GetValueForProperty("SecretParameterAdminCredentials",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameterAdminCredentials, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AdminCredentialsForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecretParameterSourceServerUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameterSourceServerUsername = (string) content.GetValueForProperty("SecretParameterSourceServerUsername",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameterSourceServerUsername, global::System.Convert.ToString);
            }
            if (content.Contains("SecretParameterTargetServerUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameterTargetServerUsername = (string) content.GetValueForProperty("SecretParameterTargetServerUsername",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).SecretParameterTargetServerUsername, global::System.Convert.ToString);
            }
            if (content.Contains("AdminCredentialsSourceServerPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).AdminCredentialsSourceServerPassword = (System.Security.SecureString) content.GetValueForProperty("AdminCredentialsSourceServerPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).AdminCredentialsSourceServerPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("AdminCredentialsTargetServerPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).AdminCredentialsTargetServerPassword = (System.Security.SecureString) content.GetValueForProperty("AdminCredentialsTargetServerPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal)this).AdminCredentialsTargetServerPassword, (object ss) => (System.Security.SecureString)ss);
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
    [System.ComponentModel.TypeConverter(typeof(MigrationResourceForPatchTypeConverter))]
    public partial interface IMigrationResourceForPatch

    {

    }
}