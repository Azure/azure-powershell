namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>
    /// Class representing the an attached database configuration properties of kind specific.
    /// </summary>
    public partial class AttachedDatabaseConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AttachedDatabaseName" /> property.</summary>
        private string[] _attachedDatabaseName;

        /// <summary>
        /// The list of databases from the clusterResourceId which are currently attached to the cluster.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] AttachedDatabaseName { get => this._attachedDatabaseName; }

        /// <summary>Backing field for <see cref="ClusterResourceId" /> property.</summary>
        private string _clusterResourceId;

        /// <summary>
        /// The resource id of the cluster where the databases you would like to attach reside.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string ClusterResourceId { get => this._clusterResourceId; set => this._clusterResourceId = value; }

        /// <summary>Backing field for <see cref="DatabaseName" /> property.</summary>
        private string _databaseName;

        /// <summary>
        /// The name of the database which you would like to attach, use * if you want to follow all current and future databases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string DatabaseName { get => this._databaseName; set => this._databaseName = value; }

        /// <summary>Backing field for <see cref="DefaultPrincipalsModificationKind" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DefaultPrincipalsModificationKind _defaultPrincipalsModificationKind;

        /// <summary>The default principals modification kind</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DefaultPrincipalsModificationKind DefaultPrincipalsModificationKind { get => this._defaultPrincipalsModificationKind; set => this._defaultPrincipalsModificationKind = value; }

        /// <summary>Internal Acessors for AttachedDatabaseName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal.AttachedDatabaseName { get => this._attachedDatabaseName; set { {_attachedDatabaseName = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for TableLevelSharingProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal.TableLevelSharingProperty { get => (this._tableLevelSharingProperty = this._tableLevelSharingProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.TableLevelSharingProperties()); set { {_tableLevelSharingProperty = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="TableLevelSharingProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties _tableLevelSharingProperty;

        /// <summary>Table level sharing specifications</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties TableLevelSharingProperty { get => (this._tableLevelSharingProperty = this._tableLevelSharingProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.TableLevelSharingProperties()); set => this._tableLevelSharingProperty = value; }

        /// <summary>List of external tables exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] TableLevelSharingPropertyExternalTablesToExclude { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)TableLevelSharingProperty).ExternalTablesToExclude; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)TableLevelSharingProperty).ExternalTablesToExclude = value ?? null /* arrayOf */; }

        /// <summary>List of external tables to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] TableLevelSharingPropertyExternalTablesToInclude { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)TableLevelSharingProperty).ExternalTablesToInclude; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)TableLevelSharingProperty).ExternalTablesToInclude = value ?? null /* arrayOf */; }

        /// <summary>List of materialized views exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] TableLevelSharingPropertyMaterializedViewsToExclude { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)TableLevelSharingProperty).MaterializedViewsToExclude; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)TableLevelSharingProperty).MaterializedViewsToExclude = value ?? null /* arrayOf */; }

        /// <summary>List of materialized views to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] TableLevelSharingPropertyMaterializedViewsToInclude { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)TableLevelSharingProperty).MaterializedViewsToInclude; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)TableLevelSharingProperty).MaterializedViewsToInclude = value ?? null /* arrayOf */; }

        /// <summary>List of tables to exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] TableLevelSharingPropertyTablesToExclude { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)TableLevelSharingProperty).TablesToExclude; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)TableLevelSharingProperty).TablesToExclude = value ?? null /* arrayOf */; }

        /// <summary>List of tables to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] TableLevelSharingPropertyTablesToInclude { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)TableLevelSharingProperty).TablesToInclude; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)TableLevelSharingProperty).TablesToInclude = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="AttachedDatabaseConfigurationProperties" /> instance.</summary>
        public AttachedDatabaseConfigurationProperties()
        {

        }
    }
    /// Class representing the an attached database configuration properties of kind specific.
    public partial interface IAttachedDatabaseConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The list of databases from the clusterResourceId which are currently attached to the cluster.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of databases from the clusterResourceId which are currently attached to the cluster.",
        SerializedName = @"attachedDatabaseNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] AttachedDatabaseName { get;  }
        /// <summary>
        /// The resource id of the cluster where the databases you would like to attach reside.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource id of the cluster where the databases you would like to attach reside.",
        SerializedName = @"clusterResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterResourceId { get; set; }
        /// <summary>
        /// The name of the database which you would like to attach, use * if you want to follow all current and future databases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the database which you would like to attach, use * if you want to follow all current and future databases.",
        SerializedName = @"databaseName",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseName { get; set; }
        /// <summary>The default principals modification kind</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The default principals modification kind",
        SerializedName = @"defaultPrincipalsModificationKind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DefaultPrincipalsModificationKind) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DefaultPrincipalsModificationKind DefaultPrincipalsModificationKind { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioned state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>List of external tables exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of external tables exclude from the follower database",
        SerializedName = @"externalTablesToExclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] TableLevelSharingPropertyExternalTablesToExclude { get; set; }
        /// <summary>List of external tables to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of external tables to include in the follower database",
        SerializedName = @"externalTablesToInclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] TableLevelSharingPropertyExternalTablesToInclude { get; set; }
        /// <summary>List of materialized views exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of materialized views exclude from the follower database",
        SerializedName = @"materializedViewsToExclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] TableLevelSharingPropertyMaterializedViewsToExclude { get; set; }
        /// <summary>List of materialized views to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of materialized views to include in the follower database",
        SerializedName = @"materializedViewsToInclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] TableLevelSharingPropertyMaterializedViewsToInclude { get; set; }
        /// <summary>List of tables to exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of tables to exclude from the follower database",
        SerializedName = @"tablesToExclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] TableLevelSharingPropertyTablesToExclude { get; set; }
        /// <summary>List of tables to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of tables to include in the follower database",
        SerializedName = @"tablesToInclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] TableLevelSharingPropertyTablesToInclude { get; set; }

    }
    /// Class representing the an attached database configuration properties of kind specific.
    internal partial interface IAttachedDatabaseConfigurationPropertiesInternal

    {
        /// <summary>
        /// The list of databases from the clusterResourceId which are currently attached to the cluster.
        /// </summary>
        string[] AttachedDatabaseName { get; set; }
        /// <summary>
        /// The resource id of the cluster where the databases you would like to attach reside.
        /// </summary>
        string ClusterResourceId { get; set; }
        /// <summary>
        /// The name of the database which you would like to attach, use * if you want to follow all current and future databases.
        /// </summary>
        string DatabaseName { get; set; }
        /// <summary>The default principals modification kind</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DefaultPrincipalsModificationKind DefaultPrincipalsModificationKind { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Table level sharing specifications</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties TableLevelSharingProperty { get; set; }
        /// <summary>List of external tables exclude from the follower database</summary>
        string[] TableLevelSharingPropertyExternalTablesToExclude { get; set; }
        /// <summary>List of external tables to include in the follower database</summary>
        string[] TableLevelSharingPropertyExternalTablesToInclude { get; set; }
        /// <summary>List of materialized views exclude from the follower database</summary>
        string[] TableLevelSharingPropertyMaterializedViewsToExclude { get; set; }
        /// <summary>List of materialized views to include in the follower database</summary>
        string[] TableLevelSharingPropertyMaterializedViewsToInclude { get; set; }
        /// <summary>List of tables to exclude from the follower database</summary>
        string[] TableLevelSharingPropertyTablesToExclude { get; set; }
        /// <summary>List of tables to include in the follower database</summary>
        string[] TableLevelSharingPropertyTablesToInclude { get; set; }

    }
}