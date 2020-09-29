namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>A class representing follower database request.</summary>
    public partial class FollowerDatabaseDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IFollowerDatabaseDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IFollowerDatabaseDefinitionInternal
    {

        /// <summary>Backing field for <see cref="AttachedDatabaseConfigurationName" /> property.</summary>
        private string _attachedDatabaseConfigurationName;

        /// <summary>Resource name of the attached database configuration in the follower cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string AttachedDatabaseConfigurationName { get => this._attachedDatabaseConfigurationName; set => this._attachedDatabaseConfigurationName = value; }

        /// <summary>Backing field for <see cref="ClusterResourceId" /> property.</summary>
        private string _clusterResourceId;

        /// <summary>Resource id of the cluster that follows a database owned by this cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string ClusterResourceId { get => this._clusterResourceId; set => this._clusterResourceId = value; }

        /// <summary>Backing field for <see cref="DatabaseName" /> property.</summary>
        private string _databaseName;

        /// <summary>
        /// The database name owned by this cluster that was followed. * in case following all databases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string DatabaseName { get => this._databaseName; }

        /// <summary>Internal Acessors for DatabaseName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IFollowerDatabaseDefinitionInternal.DatabaseName { get => this._databaseName; set { {_databaseName = value;} } }

        /// <summary>Creates an new <see cref="FollowerDatabaseDefinition" /> instance.</summary>
        public FollowerDatabaseDefinition()
        {

        }
    }
    /// A class representing follower database request.
    public partial interface IFollowerDatabaseDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>Resource name of the attached database configuration in the follower cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource name of the attached database configuration in the follower cluster.",
        SerializedName = @"attachedDatabaseConfigurationName",
        PossibleTypes = new [] { typeof(string) })]
        string AttachedDatabaseConfigurationName { get; set; }
        /// <summary>Resource id of the cluster that follows a database owned by this cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource id of the cluster that follows a database owned by this cluster.",
        SerializedName = @"clusterResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterResourceId { get; set; }
        /// <summary>
        /// The database name owned by this cluster that was followed. * in case following all databases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The database name owned by this cluster that was followed. * in case following all databases.",
        SerializedName = @"databaseName",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseName { get;  }

    }
    /// A class representing follower database request.
    internal partial interface IFollowerDatabaseDefinitionInternal

    {
        /// <summary>Resource name of the attached database configuration in the follower cluster.</summary>
        string AttachedDatabaseConfigurationName { get; set; }
        /// <summary>Resource id of the cluster that follows a database owned by this cluster.</summary>
        string ClusterResourceId { get; set; }
        /// <summary>
        /// The database name owned by this cluster that was followed. * in case following all databases.
        /// </summary>
        string DatabaseName { get; set; }

    }
}