namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>
    /// Class representing the an attached database configuration properties of kind specific.
    /// </summary>
    public partial class AttachedDatabaseConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAttachedDatabaseConfigurationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAttachedDatabaseConfigurationPropertiesInternal
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
        string[] Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAttachedDatabaseConfigurationPropertiesInternal.AttachedDatabaseName { get => this._attachedDatabaseName; set { {_attachedDatabaseName = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAttachedDatabaseConfigurationPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

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

    }
}