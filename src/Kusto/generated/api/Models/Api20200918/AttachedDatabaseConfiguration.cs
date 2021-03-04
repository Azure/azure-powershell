namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing an attached database configuration.</summary>
    public partial class AttachedDatabaseConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationInternal,
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
        public string[] AttachedDatabaseName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationPropertiesInternal)Property).AttachedDatabaseName; }

        /// <summary>
        /// The resource id of the cluster where the databases you would like to attach reside.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string ClusterResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationPropertiesInternal)Property).ClusterResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationPropertiesInternal)Property).ClusterResourceId = value; }

        /// <summary>
        /// The name of the database which you would like to attach, use * if you want to follow all current and future databases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string DatabaseName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationPropertiesInternal)Property).DatabaseName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationPropertiesInternal)Property).DatabaseName = value; }

        /// <summary>The default principals modification kind</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DefaultPrincipalsModificationKind DefaultPrincipalsModificationKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationPropertiesInternal)Property).DefaultPrincipalsModificationKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationPropertiesInternal)Property).DefaultPrincipalsModificationKind = value; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
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
        string[] Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationInternal.AttachedDatabaseName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationPropertiesInternal)Property).AttachedDatabaseName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationPropertiesInternal)Property).AttachedDatabaseName = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.AttachedDatabaseConfigurationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationProperties _property;

        /// <summary>The properties of the attached database configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.AttachedDatabaseConfigurationProperties()); set => this._property = value; }

        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
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
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DefaultPrincipalsModificationKind DefaultPrincipalsModificationKind { get; set; }
        /// <summary>Resource location.</summary>
        string Location { get; set; }
        /// <summary>The properties of the attached database configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IAttachedDatabaseConfigurationProperties Property { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get; set; }

    }
}