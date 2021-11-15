namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing an attached database configuration.</summary>
    public partial class AttachedDatabaseConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.Resource();

        /// <summary>
        /// The list of databases from the clusterResourceId which are currently attached to the cluster.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] AttachedDatabaseName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).AttachedDatabaseName; }

        /// <summary>
        /// The resource id of the cluster where the databases you would like to attach reside.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string ClusterResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).ClusterResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).ClusterResourceId = value ?? null; }

        /// <summary>
        /// The name of the database which you would like to attach, use * if you want to follow all current and future databases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string DatabaseName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).DatabaseName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).DatabaseName = value ?? null; }

        /// <summary>The default principals modification kind</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DefaultPrincipalsModificationKind? DefaultPrincipalsModificationKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).DefaultPrincipalsModificationKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).DefaultPrincipalsModificationKind = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DefaultPrincipalsModificationKind)""); }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__resource).Id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for AttachedDatabaseName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationInternal.AttachedDatabaseName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).AttachedDatabaseName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).AttachedDatabaseName = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.AttachedDatabaseConfigurationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for TableLevelSharingProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationInternal.TableLevelSharingProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingProperty = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationProperties _property;

        /// <summary>The properties of the attached database configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.AttachedDatabaseConfigurationProperties()); set => this._property = value; }

        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).ProvisioningState; }

        /// <summary>List of external tables exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] TableLevelSharingPropertyExternalTablesToExclude { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingPropertyExternalTablesToExclude; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingPropertyExternalTablesToExclude = value ?? null /* arrayOf */; }

        /// <summary>List of external tables to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] TableLevelSharingPropertyExternalTablesToInclude { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingPropertyExternalTablesToInclude; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingPropertyExternalTablesToInclude = value ?? null /* arrayOf */; }

        /// <summary>List of materialized views exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] TableLevelSharingPropertyMaterializedViewsToExclude { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingPropertyMaterializedViewsToExclude; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingPropertyMaterializedViewsToExclude = value ?? null /* arrayOf */; }

        /// <summary>List of materialized views to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] TableLevelSharingPropertyMaterializedViewsToInclude { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingPropertyMaterializedViewsToInclude; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingPropertyMaterializedViewsToInclude = value ?? null /* arrayOf */; }

        /// <summary>List of tables to exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] TableLevelSharingPropertyTablesToExclude { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingPropertyTablesToExclude; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingPropertyTablesToExclude = value ?? null /* arrayOf */; }

        /// <summary>List of tables to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string[] TableLevelSharingPropertyTablesToInclude { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingPropertyTablesToInclude; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationPropertiesInternal)Property).TableLevelSharingPropertyTablesToInclude = value ?? null /* arrayOf */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="AttachedDatabaseConfiguration" /> instance.</summary>
        public AttachedDatabaseConfiguration()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Class representing an attached database configuration.
    public partial interface IAttachedDatabaseConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResource
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
        Required = false,
        ReadOnly = false,
        Description = @"The resource id of the cluster where the databases you would like to attach reside.",
        SerializedName = @"clusterResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterResourceId { get; set; }
        /// <summary>
        /// The name of the database which you would like to attach, use * if you want to follow all current and future databases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the database which you would like to attach, use * if you want to follow all current and future databases.",
        SerializedName = @"databaseName",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseName { get; set; }
        /// <summary>The default principals modification kind</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The default principals modification kind",
        SerializedName = @"defaultPrincipalsModificationKind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DefaultPrincipalsModificationKind) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DefaultPrincipalsModificationKind? DefaultPrincipalsModificationKind { get; set; }
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
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
    /// Class representing an attached database configuration.
    internal partial interface IAttachedDatabaseConfigurationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal
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
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DefaultPrincipalsModificationKind? DefaultPrincipalsModificationKind { get; set; }
        /// <summary>Resource location.</summary>
        string Location { get; set; }
        /// <summary>The properties of the attached database configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IAttachedDatabaseConfigurationProperties Property { get; set; }
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