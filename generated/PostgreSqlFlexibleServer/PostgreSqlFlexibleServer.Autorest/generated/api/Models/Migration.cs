// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Properties of a migration.</summary>
    public partial class Migration :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.TrackedResource();

        /// <summary>Password for the user of the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Security.SecureString AdminCredentialsSourceServerPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).AdminCredentialsSourceServerPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).AdminCredentialsSourceServerPassword = value ?? null; }

        /// <summary>Password for the user of the target server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Security.SecureString AdminCredentialsTargetServerPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).AdminCredentialsTargetServerPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).AdminCredentialsTargetServerPassword = value ?? null; }

        /// <summary>Indicates if cancel must be triggered for the entire migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Cancel { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).Cancel; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).Cancel = value ?? null; }

        /// <summary>Error message, if any, for the migration state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 2, Width = 20)]
        public string CurrentStatusError { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentStatusError; }

        /// <summary>State of migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 1, Width = 18)]
        public string CurrentStatusState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentStatusState; }

        /// <summary>Substate of migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string CurrentSubStateDetailCurrentSubState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentSubStateDetailCurrentSubState; }

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails CurrentSubStateDetailDbDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentSubStateDetailDbDetail; }

        /// <summary>
        /// When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Collections.Generic.List<string> DbsToCancelMigrationOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).DbsToCancelMigrationOn; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).DbsToCancelMigrationOn = value ?? null /* arrayOf */; }

        /// <summary>Names of databases to migrate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 8, Width = 25)]
        public System.Collections.Generic.List<string> DbsToMigrate { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).DbsToMigrate; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).DbsToMigrate = value ?? null /* arrayOf */; }

        /// <summary>
        /// When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Collections.Generic.List<string> DbsToTriggerCutoverOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).DbsToTriggerCutoverOn; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).DbsToTriggerCutoverOn = value ?? null /* arrayOf */; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).Id; }

        /// <summary>Identifier of the private endpoint migration instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string InstanceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationInstanceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationInstanceResourceId = value ?? null; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)__trackedResource).Location = value ?? null; }

        /// <summary>Internal Acessors for CurrentStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatus Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.CurrentStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentStatus = value ?? null /* model class */; }

        /// <summary>Internal Acessors for CurrentStatusCurrentSubStateDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.CurrentStatusCurrentSubStateDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentStatusCurrentSubStateDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentStatusCurrentSubStateDetail = value ?? null /* model class */; }

        /// <summary>Internal Acessors for CurrentStatusError</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.CurrentStatusError { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentStatusError; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentStatusError = value ?? null; }

        /// <summary>Internal Acessors for CurrentStatusState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.CurrentStatusState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentStatusState; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentStatusState = value ?? null; }

        /// <summary>Internal Acessors for CurrentSubStateDetailCurrentSubState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.CurrentSubStateDetailCurrentSubState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentSubStateDetailCurrentSubState; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentSubStateDetailCurrentSubState = value ?? null; }

        /// <summary>Internal Acessors for CurrentSubStateDetailDbDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.CurrentSubStateDetailDbDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentSubStateDetailDbDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentSubStateDetailDbDetail = value ?? null /* model class */; }

        /// <summary>Internal Acessors for CurrentSubStateDetailValidationDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.CurrentSubStateDetailValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentSubStateDetailValidationDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).CurrentSubStateDetailValidationDetail = value ?? null /* model class */; }

        /// <summary>Internal Acessors for MigrationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.MigrationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationId = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for SecretParameter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParameters Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.SecretParameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SecretParameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SecretParameter = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SecretParameterAdminCredentials</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentials Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.SecretParameterAdminCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SecretParameterAdminCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SecretParameterAdminCredentials = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SourceDbServerMetadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.SourceDbServerMetadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadata = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SourceDbServerMetadataLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.SourceDbServerMetadataLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataLocation = value ?? null; }

        /// <summary>Internal Acessors for SourceDbServerMetadataSku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.SourceDbServerMetadataSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataSku = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SourceDbServerMetadataSkuName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.SourceDbServerMetadataSkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataSkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataSkuName = value ?? null; }

        /// <summary>Internal Acessors for SourceDbServerMetadataSkuTier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.SourceDbServerMetadataSkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataSkuTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataSkuTier = value ?? null; }

        /// <summary>Internal Acessors for SourceDbServerMetadataStorageMb</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.SourceDbServerMetadataStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataStorageMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataStorageMb = value ?? default(int); }

        /// <summary>Internal Acessors for SourceDbServerMetadataVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.SourceDbServerMetadataVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataVersion = value ?? null; }

        /// <summary>Internal Acessors for TargetDbServerMetadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.TargetDbServerMetadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadata = value ?? null /* model class */; }

        /// <summary>Internal Acessors for TargetDbServerMetadataLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.TargetDbServerMetadataLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataLocation = value ?? null; }

        /// <summary>Internal Acessors for TargetDbServerMetadataSku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.TargetDbServerMetadataSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataSku = value ?? null /* model class */; }

        /// <summary>Internal Acessors for TargetDbServerMetadataSkuName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.TargetDbServerMetadataSkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataSkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataSkuName = value ?? null; }

        /// <summary>Internal Acessors for TargetDbServerMetadataSkuTier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.TargetDbServerMetadataSkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataSkuTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataSkuTier = value ?? null; }

        /// <summary>Internal Acessors for TargetDbServerMetadataStorageMb</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.TargetDbServerMetadataStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataStorageMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataStorageMb = value ?? default(int); }

        /// <summary>Internal Acessors for TargetDbServerMetadataVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.TargetDbServerMetadataVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataVersion = value ?? null; }

        /// <summary>Internal Acessors for TargetDbServerResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.TargetDbServerResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerResourceId = value ?? null; }

        /// <summary>Internal Acessors for ValidationDetailDbLevelValidationDetail</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.ValidationDetailDbLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailDbLevelValidationDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailDbLevelValidationDetail = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ValidationDetailServerLevelValidationDetail</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.ValidationDetailServerLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailServerLevelValidationDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailServerLevelValidationDetail = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ValidationDetailStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.ValidationDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailStatus = value ?? null; }

        /// <summary>Internal Acessors for ValidationDetailValidationEndTimeInUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.ValidationDetailValidationEndTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailValidationEndTimeInUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailValidationEndTimeInUtc = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for ValidationDetailValidationStartTimeInUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationInternal.ValidationDetailValidationStartTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailValidationStartTimeInUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailValidationStartTimeInUtc = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).Type = value ?? null; }

        /// <summary>Indicates if roles and permissions must be migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 4, Width = 11)]
        public string MigrateRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrateRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrateRole = value ?? null; }

        /// <summary>Identifier of a migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string MigrationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationId; }

        /// <summary>Mode used to perform the migration: Online or Offline.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 10, Width = 10)]
        public string Mode { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationMode = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 0, Width = 20)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).Name; }

        /// <summary>Supported option for a migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 3, Width = 20)]
        public string Option { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationOption = value ?? null; }

        /// <summary>
        /// Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration
        /// workflow detects that the database already exists on the target server, it will wait for a confirmation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 9, Width = 25)]
        public string OverwriteDbsInTarget { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).OverwriteDbsInTarget; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).OverwriteDbsInTarget = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties _property;

        /// <summary>Migration properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationProperties()); set => this._property = value; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>
        /// Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SecretParameterSourceServerUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SecretParameterSourceServerUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SecretParameterSourceServerUsername = value ?? null; }

        /// <summary>
        /// Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SecretParameterTargetServerUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SecretParameterTargetServerUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SecretParameterTargetServerUsername = value ?? null; }

        /// <summary>Indicates whether to setup logical replication on source server, if needed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SetupLogicalReplicationOnSourceDbIfNeeded { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SetupLogicalReplicationOnSourceDbIfNeeded; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SetupLogicalReplicationOnSourceDbIfNeeded = value ?? null; }

        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the source server. This property is optional. When provided, the migration
        /// service will always use it to connect to the source server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SourceDbServerFullyQualifiedDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerFullyQualifiedDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerFullyQualifiedDomainName = value ?? null; }

        /// <summary>Location of database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SourceDbServerMetadataLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataLocation; }

        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SourceDbServerMetadataSkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataSkuName; }

        /// <summary>Tier of the compute assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SourceDbServerMetadataSkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataSkuTier; }

        /// <summary>Storage size (in MB) for database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public int? SourceDbServerMetadataStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataStorageMb; }

        /// <summary>Major version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SourceDbServerMetadataVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerMetadataVersion; }

        /// <summary>
        /// Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types
        /// this must be set to ipaddress:port@username or hostname:port@username.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 7, Width = 25)]
        public string SourceDbServerResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceDbServerResourceId = value ?? null; }

        /// <summary>
        /// Source server type used for the migration: ApsaraDB_RDS, AWS, AWS_AURORA, AWS_EC2, AWS_RDS, AzureVM, Crunchy_PostgreSQL,
        /// Digital_Ocean_Droplets, Digital_Ocean_PostgreSQL, EDB, EDB_Oracle_Server, EDB_PostgreSQL, GCP, GCP_AlloyDB, GCP_CloudSQL,
        /// GCP_Compute, Heroku_PostgreSQL, Huawei_Compute, Huawei_RDS, OnPremises, PostgreSQLCosmosDB, PostgreSQLFlexibleServer,
        /// PostgreSQLSingleServer, or Supabase_PostgreSQL
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 5, Width = 10)]
        public string SourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SourceType = value ?? null; }

        /// <summary>
        /// SSL mode used by a migration. Default SSL mode for 'PostgreSQLSingleServer' is 'VerifyFull'. Default SSL mode for other
        /// source types is 'Prefer'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SslMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SslMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).SslMode = value ?? null; }

        /// <summary>Indicates if data migration must start right away.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string StartDataMigration { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).StartDataMigration; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).StartDataMigration = value ?? null; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration
        /// service will always use it to connect to the target server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string TargetDbServerFullyQualifiedDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerFullyQualifiedDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerFullyQualifiedDomainName = value ?? null; }

        /// <summary>Location of database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string TargetDbServerMetadataLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataLocation; }

        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string TargetDbServerMetadataSkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataSkuName; }

        /// <summary>Tier of the compute assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string TargetDbServerMetadataSkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataSkuTier; }

        /// <summary>Storage size (in MB) for database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public int? TargetDbServerMetadataStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataStorageMb; }

        /// <summary>Major version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string TargetDbServerMetadataVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerMetadataVersion; }

        /// <summary>Identifier of the target database server resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string TargetDbServerResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TargetDbServerResourceId; }

        /// <summary>Indicates if cutover must be triggered for the entire migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 6, Width = 14)]
        public string TriggerCutover { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TriggerCutover; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).TriggerCutover = value ?? null; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__trackedResource).Type; }

        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> ValidationDetailDbLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailDbLevelValidationDetail; }

        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> ValidationDetailServerLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailServerLevelValidationDetail; }

        /// <summary>Validation status for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string ValidationDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailStatus; }

        /// <summary>End time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? ValidationDetailValidationEndTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailValidationEndTimeInUtc; }

        /// <summary>Start time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? ValidationDetailValidationStartTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).ValidationDetailValidationStartTimeInUtc; }

        /// <summary>End time (UTC) for migration window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? WindowEndTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationWindowEndTimeInUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationWindowEndTimeInUtc = value ?? default(global::System.DateTime); }

        /// <summary>Start time (UTC) for migration window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? WindowStartTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationWindowStartTimeInUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal)Property).MigrationWindowStartTimeInUtc = value ?? default(global::System.DateTime); }

        /// <summary>Creates an new <see cref="Migration" /> instance.</summary>
        public Migration()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// Properties of a migration.
    public partial interface IMigration :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResource
    {
        /// <summary>Password for the user of the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Password for the user of the source server.",
        SerializedName = @"sourceServerPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString AdminCredentialsSourceServerPassword { get; set; }
        /// <summary>Password for the user of the target server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Password for the user of the target server.",
        SerializedName = @"targetServerPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString AdminCredentialsTargetServerPassword { get; set; }
        /// <summary>Indicates if cancel must be triggered for the entire migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if cancel must be triggered for the entire migration.",
        SerializedName = @"cancel",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string Cancel { get; set; }
        /// <summary>Error message, if any, for the migration state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Error message, if any, for the migration state.",
        SerializedName = @"error",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentStatusError { get;  }
        /// <summary>State of migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"State of migration.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("InProgress", "WaitingForUserAction", "Canceled", "Failed", "Succeeded", "ValidationFailed", "CleaningUp")]
        string CurrentStatusState { get;  }
        /// <summary>Substate of migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Substate of migration.",
        SerializedName = @"currentSubState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("PerformingPreRequisiteSteps", "WaitingForLogicalReplicationSetupRequestOnSourceDB", "WaitingForDBsToMigrateSpecification", "WaitingForTargetDBOverwriteConfirmation", "WaitingForDataMigrationScheduling", "WaitingForDataMigrationWindow", "MigratingData", "WaitingForCutoverTrigger", "CompletingMigration", "Completed", "CancelingRequestedDBMigrations", "ValidationInProgress")]
        string CurrentSubStateDetailCurrentSubState { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"",
        SerializedName = @"dbDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails CurrentSubStateDetailDbDetail { get;  }
        /// <summary>
        /// When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases in this array.",
        SerializedName = @"dbsToCancelMigrationOn",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> DbsToCancelMigrationOn { get; set; }
        /// <summary>Names of databases to migrate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Names of databases to migrate.",
        SerializedName = @"dbsToMigrate",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> DbsToMigrate { get; set; }
        /// <summary>
        /// When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases in this array.",
        SerializedName = @"dbsToTriggerCutoverOn",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> DbsToTriggerCutoverOn { get; set; }
        /// <summary>Identifier of the private endpoint migration instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the private endpoint migration instance.",
        SerializedName = @"migrationInstanceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceResourceId { get; set; }
        /// <summary>Indicates if roles and permissions must be migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if roles and permissions must be migrated.",
        SerializedName = @"migrateRoles",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string MigrateRole { get; set; }
        /// <summary>Identifier of a migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Identifier of a migration.",
        SerializedName = @"migrationId",
        PossibleTypes = new [] { typeof(string) })]
        string MigrationId { get;  }
        /// <summary>Mode used to perform the migration: Online or Offline.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Mode used to perform the migration: Online or Offline.",
        SerializedName = @"migrationMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Offline", "Online")]
        string Mode { get; set; }
        /// <summary>Supported option for a migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Supported option for a migration.",
        SerializedName = @"migrationOption",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Validate", "Migrate", "ValidateAndMigrate")]
        string Option { get; set; }
        /// <summary>
        /// Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration
        /// workflow detects that the database already exists on the target server, it will wait for a confirmation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration workflow detects that the database already exists on the target server, it will wait for a confirmation.",
        SerializedName = @"overwriteDbsInTarget",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string OverwriteDbsInTarget { get; set; }
        /// <summary>
        /// Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.",
        SerializedName = @"sourceServerUsername",
        PossibleTypes = new [] { typeof(string) })]
        string SecretParameterSourceServerUsername { get; set; }
        /// <summary>
        /// Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.",
        SerializedName = @"targetServerUsername",
        PossibleTypes = new [] { typeof(string) })]
        string SecretParameterTargetServerUsername { get; set; }
        /// <summary>Indicates whether to setup logical replication on source server, if needed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates whether to setup logical replication on source server, if needed.",
        SerializedName = @"setupLogicalReplicationOnSourceDbIfNeeded",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string SetupLogicalReplicationOnSourceDbIfNeeded { get; set; }
        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the source server. This property is optional. When provided, the migration
        /// service will always use it to connect to the source server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Fully qualified domain name (FQDN) or IP address of the source server. This property is optional. When provided, the migration service will always use it to connect to the source server.",
        SerializedName = @"sourceDbServerFullyQualifiedDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string SourceDbServerFullyQualifiedDomainName { get; set; }
        /// <summary>Location of database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Location of database server.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string SourceDbServerMetadataLocation { get;  }
        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SourceDbServerMetadataSkuName { get;  }
        /// <summary>Tier of the compute assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Tier of the compute assigned to a server.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Burstable", "GeneralPurpose", "MemoryOptimized")]
        string SourceDbServerMetadataSkuTier { get;  }
        /// <summary>Storage size (in MB) for database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Storage size (in MB) for database server.",
        SerializedName = @"storageMb",
        PossibleTypes = new [] { typeof(int) })]
        int? SourceDbServerMetadataStorageMb { get;  }
        /// <summary>Major version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Major version of PostgreSQL database engine.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string SourceDbServerMetadataVersion { get;  }
        /// <summary>
        /// Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types
        /// this must be set to ipaddress:port@username or hostname:port@username.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types this must be set to ipaddress:port@username or hostname:port@username.",
        SerializedName = @"sourceDbServerResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceDbServerResourceId { get; set; }
        /// <summary>
        /// Source server type used for the migration: ApsaraDB_RDS, AWS, AWS_AURORA, AWS_EC2, AWS_RDS, AzureVM, Crunchy_PostgreSQL,
        /// Digital_Ocean_Droplets, Digital_Ocean_PostgreSQL, EDB, EDB_Oracle_Server, EDB_PostgreSQL, GCP, GCP_AlloyDB, GCP_CloudSQL,
        /// GCP_Compute, Heroku_PostgreSQL, Huawei_Compute, Huawei_RDS, OnPremises, PostgreSQLCosmosDB, PostgreSQLFlexibleServer,
        /// PostgreSQLSingleServer, or Supabase_PostgreSQL
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Source server type used for the migration: ApsaraDB_RDS, AWS, AWS_AURORA, AWS_EC2, AWS_RDS, AzureVM, Crunchy_PostgreSQL, Digital_Ocean_Droplets, Digital_Ocean_PostgreSQL, EDB, EDB_Oracle_Server, EDB_PostgreSQL, GCP, GCP_AlloyDB, GCP_CloudSQL, GCP_Compute, Heroku_PostgreSQL, Huawei_Compute, Huawei_RDS, OnPremises, PostgreSQLCosmosDB, PostgreSQLFlexibleServer, PostgreSQLSingleServer, or Supabase_PostgreSQL",
        SerializedName = @"sourceType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("OnPremises", "AWS", "GCP", "AzureVM", "PostgreSQLSingleServer", "AWS_RDS", "AWS_AURORA", "AWS_EC2", "GCP_CloudSQL", "GCP_AlloyDB", "GCP_Compute", "EDB", "EDB_Oracle_Server", "EDB_PostgreSQL", "PostgreSQLFlexibleServer", "PostgreSQLCosmosDB", "Huawei_RDS", "Huawei_Compute", "Heroku_PostgreSQL", "Crunchy_PostgreSQL", "ApsaraDB_RDS", "Digital_Ocean_Droplets", "Digital_Ocean_PostgreSQL", "Supabase_PostgreSQL")]
        string SourceType { get; set; }
        /// <summary>
        /// SSL mode used by a migration. Default SSL mode for 'PostgreSQLSingleServer' is 'VerifyFull'. Default SSL mode for other
        /// source types is 'Prefer'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"SSL mode used by a migration. Default SSL mode for 'PostgreSQLSingleServer' is 'VerifyFull'. Default SSL mode for other source types is 'Prefer'.",
        SerializedName = @"sslMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Prefer", "Require", "VerifyCA", "VerifyFull")]
        string SslMode { get; set; }
        /// <summary>Indicates if data migration must start right away.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if data migration must start right away.",
        SerializedName = @"startDataMigration",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string StartDataMigration { get; set; }
        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration
        /// service will always use it to connect to the target server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration service will always use it to connect to the target server.",
        SerializedName = @"targetDbServerFullyQualifiedDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string TargetDbServerFullyQualifiedDomainName { get; set; }
        /// <summary>Location of database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Location of database server.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string TargetDbServerMetadataLocation { get;  }
        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string TargetDbServerMetadataSkuName { get;  }
        /// <summary>Tier of the compute assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Tier of the compute assigned to a server.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Burstable", "GeneralPurpose", "MemoryOptimized")]
        string TargetDbServerMetadataSkuTier { get;  }
        /// <summary>Storage size (in MB) for database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Storage size (in MB) for database server.",
        SerializedName = @"storageMb",
        PossibleTypes = new [] { typeof(int) })]
        int? TargetDbServerMetadataStorageMb { get;  }
        /// <summary>Major version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Major version of PostgreSQL database engine.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string TargetDbServerMetadataVersion { get;  }
        /// <summary>Identifier of the target database server resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Identifier of the target database server resource.",
        SerializedName = @"targetDbServerResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetDbServerResourceId { get;  }
        /// <summary>Indicates if cutover must be triggered for the entire migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if cutover must be triggered for the entire migration.",
        SerializedName = @"triggerCutover",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string TriggerCutover { get; set; }
        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Details of server level validations.",
        SerializedName = @"dbLevelValidationDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> ValidationDetailDbLevelValidationDetail { get;  }
        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Details of server level validations.",
        SerializedName = @"serverLevelValidationDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> ValidationDetailServerLevelValidationDetail { get;  }
        /// <summary>Validation status for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Validation status for migration.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Failed", "Succeeded", "Warning")]
        string ValidationDetailStatus { get;  }
        /// <summary>End time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"End time (UTC) for validation.",
        SerializedName = @"validationEndTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ValidationDetailValidationEndTimeInUtc { get;  }
        /// <summary>Start time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Start time (UTC) for validation.",
        SerializedName = @"validationStartTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ValidationDetailValidationStartTimeInUtc { get;  }
        /// <summary>End time (UTC) for migration window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"End time (UTC) for migration window.",
        SerializedName = @"migrationWindowEndTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? WindowEndTimeInUtc { get; set; }
        /// <summary>Start time (UTC) for migration window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start time (UTC) for migration window.",
        SerializedName = @"migrationWindowStartTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? WindowStartTimeInUtc { get; set; }

    }
    /// Properties of a migration.
    internal partial interface IMigrationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal
    {
        /// <summary>Password for the user of the source server.</summary>
        System.Security.SecureString AdminCredentialsSourceServerPassword { get; set; }
        /// <summary>Password for the user of the target server.</summary>
        System.Security.SecureString AdminCredentialsTargetServerPassword { get; set; }
        /// <summary>Indicates if cancel must be triggered for the entire migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string Cancel { get; set; }
        /// <summary>Current status of a migration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatus CurrentStatus { get; set; }
        /// <summary>Current migration sub state details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails CurrentStatusCurrentSubStateDetail { get; set; }
        /// <summary>Error message, if any, for the migration state.</summary>
        string CurrentStatusError { get; set; }
        /// <summary>State of migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("InProgress", "WaitingForUserAction", "Canceled", "Failed", "Succeeded", "ValidationFailed", "CleaningUp")]
        string CurrentStatusState { get; set; }
        /// <summary>Substate of migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("PerformingPreRequisiteSteps", "WaitingForLogicalReplicationSetupRequestOnSourceDB", "WaitingForDBsToMigrateSpecification", "WaitingForTargetDBOverwriteConfirmation", "WaitingForDataMigrationScheduling", "WaitingForDataMigrationWindow", "MigratingData", "WaitingForCutoverTrigger", "CompletingMigration", "Completed", "CancelingRequestedDBMigrations", "ValidationInProgress")]
        string CurrentSubStateDetailCurrentSubState { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails CurrentSubStateDetailDbDetail { get; set; }
        /// <summary>Details for the validation for migration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails CurrentSubStateDetailValidationDetail { get; set; }
        /// <summary>
        /// When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        System.Collections.Generic.List<string> DbsToCancelMigrationOn { get; set; }
        /// <summary>Names of databases to migrate.</summary>
        System.Collections.Generic.List<string> DbsToMigrate { get; set; }
        /// <summary>
        /// When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        System.Collections.Generic.List<string> DbsToTriggerCutoverOn { get; set; }
        /// <summary>Identifier of the private endpoint migration instance.</summary>
        string InstanceResourceId { get; set; }
        /// <summary>Indicates if roles and permissions must be migrated.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string MigrateRole { get; set; }
        /// <summary>Identifier of a migration.</summary>
        string MigrationId { get; set; }
        /// <summary>Mode used to perform the migration: Online or Offline.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Offline", "Online")]
        string Mode { get; set; }
        /// <summary>Supported option for a migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Validate", "Migrate", "ValidateAndMigrate")]
        string Option { get; set; }
        /// <summary>
        /// Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration
        /// workflow detects that the database already exists on the target server, it will wait for a confirmation.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string OverwriteDbsInTarget { get; set; }
        /// <summary>Migration properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties Property { get; set; }
        /// <summary>Migration secret parameters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParameters SecretParameter { get; set; }
        /// <summary>Credentials of administrator users for source and target servers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentials SecretParameterAdminCredentials { get; set; }
        /// <summary>
        /// Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.
        /// </summary>
        string SecretParameterSourceServerUsername { get; set; }
        /// <summary>
        /// Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.
        /// </summary>
        string SecretParameterTargetServerUsername { get; set; }
        /// <summary>Indicates whether to setup logical replication on source server, if needed.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string SetupLogicalReplicationOnSourceDbIfNeeded { get; set; }
        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the source server. This property is optional. When provided, the migration
        /// service will always use it to connect to the source server.
        /// </summary>
        string SourceDbServerFullyQualifiedDomainName { get; set; }
        /// <summary>Metadata of source database server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata SourceDbServerMetadata { get; set; }
        /// <summary>Location of database server.</summary>
        string SourceDbServerMetadataLocation { get; set; }
        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku SourceDbServerMetadataSku { get; set; }
        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        string SourceDbServerMetadataSkuName { get; set; }
        /// <summary>Tier of the compute assigned to a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Burstable", "GeneralPurpose", "MemoryOptimized")]
        string SourceDbServerMetadataSkuTier { get; set; }
        /// <summary>Storage size (in MB) for database server.</summary>
        int? SourceDbServerMetadataStorageMb { get; set; }
        /// <summary>Major version of PostgreSQL database engine.</summary>
        string SourceDbServerMetadataVersion { get; set; }
        /// <summary>
        /// Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types
        /// this must be set to ipaddress:port@username or hostname:port@username.
        /// </summary>
        string SourceDbServerResourceId { get; set; }
        /// <summary>
        /// Source server type used for the migration: ApsaraDB_RDS, AWS, AWS_AURORA, AWS_EC2, AWS_RDS, AzureVM, Crunchy_PostgreSQL,
        /// Digital_Ocean_Droplets, Digital_Ocean_PostgreSQL, EDB, EDB_Oracle_Server, EDB_PostgreSQL, GCP, GCP_AlloyDB, GCP_CloudSQL,
        /// GCP_Compute, Heroku_PostgreSQL, Huawei_Compute, Huawei_RDS, OnPremises, PostgreSQLCosmosDB, PostgreSQLFlexibleServer,
        /// PostgreSQLSingleServer, or Supabase_PostgreSQL
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("OnPremises", "AWS", "GCP", "AzureVM", "PostgreSQLSingleServer", "AWS_RDS", "AWS_AURORA", "AWS_EC2", "GCP_CloudSQL", "GCP_AlloyDB", "GCP_Compute", "EDB", "EDB_Oracle_Server", "EDB_PostgreSQL", "PostgreSQLFlexibleServer", "PostgreSQLCosmosDB", "Huawei_RDS", "Huawei_Compute", "Heroku_PostgreSQL", "Crunchy_PostgreSQL", "ApsaraDB_RDS", "Digital_Ocean_Droplets", "Digital_Ocean_PostgreSQL", "Supabase_PostgreSQL")]
        string SourceType { get; set; }
        /// <summary>
        /// SSL mode used by a migration. Default SSL mode for 'PostgreSQLSingleServer' is 'VerifyFull'. Default SSL mode for other
        /// source types is 'Prefer'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Prefer", "Require", "VerifyCA", "VerifyFull")]
        string SslMode { get; set; }
        /// <summary>Indicates if data migration must start right away.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string StartDataMigration { get; set; }
        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration
        /// service will always use it to connect to the target server.
        /// </summary>
        string TargetDbServerFullyQualifiedDomainName { get; set; }
        /// <summary>Metadata of target database server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata TargetDbServerMetadata { get; set; }
        /// <summary>Location of database server.</summary>
        string TargetDbServerMetadataLocation { get; set; }
        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku TargetDbServerMetadataSku { get; set; }
        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        string TargetDbServerMetadataSkuName { get; set; }
        /// <summary>Tier of the compute assigned to a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Burstable", "GeneralPurpose", "MemoryOptimized")]
        string TargetDbServerMetadataSkuTier { get; set; }
        /// <summary>Storage size (in MB) for database server.</summary>
        int? TargetDbServerMetadataStorageMb { get; set; }
        /// <summary>Major version of PostgreSQL database engine.</summary>
        string TargetDbServerMetadataVersion { get; set; }
        /// <summary>Identifier of the target database server resource.</summary>
        string TargetDbServerResourceId { get; set; }
        /// <summary>Indicates if cutover must be triggered for the entire migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string TriggerCutover { get; set; }
        /// <summary>Details of server level validations.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> ValidationDetailDbLevelValidationDetail { get; set; }
        /// <summary>Details of server level validations.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> ValidationDetailServerLevelValidationDetail { get; set; }
        /// <summary>Validation status for migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Failed", "Succeeded", "Warning")]
        string ValidationDetailStatus { get; set; }
        /// <summary>End time (UTC) for validation.</summary>
        global::System.DateTime? ValidationDetailValidationEndTimeInUtc { get; set; }
        /// <summary>Start time (UTC) for validation.</summary>
        global::System.DateTime? ValidationDetailValidationStartTimeInUtc { get; set; }
        /// <summary>End time (UTC) for migration window.</summary>
        global::System.DateTime? WindowEndTimeInUtc { get; set; }
        /// <summary>Start time (UTC) for migration window.</summary>
        global::System.DateTime? WindowStartTimeInUtc { get; set; }

    }
}