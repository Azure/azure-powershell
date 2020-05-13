namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing a database principal assignment.</summary>
    public partial class DatabasePrincipalAssignment :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignment,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignmentInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IProxyResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ProxyResource();

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__proxyResource).Id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__proxyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__proxyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__proxyResource).Type = value; }

        /// <summary>Internal Acessors for PrincipalName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignmentInternal.PrincipalName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).PrincipalName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).PrincipalName = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignmentInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.DatabasePrincipalProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignmentInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for TenantName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignmentInternal.TenantName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).TenantName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).TenantName = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__proxyResource).Name; }

        /// <summary>
        /// The principal ID assigned to the database principal. It can be a user email, application ID, or security group name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string PrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).PrincipalId = value; }

        /// <summary>The principal name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string PrincipalName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).PrincipalName; }

        /// <summary>Principal type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalType PrincipalType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).PrincipalType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).PrincipalType = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalProperties _property;

        /// <summary>The database principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.DatabasePrincipalProperties()); set => this._property = value; }

        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Database principal role.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole Role { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).Role; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).Role = value; }

        /// <summary>The tenant id of the principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).TenantId = value; }

        /// <summary>The tenant name of the principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string TenantName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)Property).TenantName; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__proxyResource).Type; }

        /// <summary>Creates an new <see cref="DatabasePrincipalAssignment" /> instance.</summary>
        public DatabasePrincipalAssignment()
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
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// Class representing a database principal assignment.
    public partial interface IDatabasePrincipalAssignment :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IProxyResource
    {
        /// <summary>
        /// The principal ID assigned to the database principal. It can be a user email, application ID, or security group name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The principal ID assigned to the database principal. It can be a user email, application ID, or security group name.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get; set; }
        /// <summary>The principal name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principal name",
        SerializedName = @"principalName",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalName { get;  }
        /// <summary>Principal type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Principal type.",
        SerializedName = @"principalType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalType PrincipalType { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioned state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>Database principal role.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Database principal role.",
        SerializedName = @"role",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole Role { get; set; }
        /// <summary>The tenant id of the principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tenant id of the principal",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }
        /// <summary>The tenant name of the principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tenant name of the principal",
        SerializedName = @"tenantName",
        PossibleTypes = new [] { typeof(string) })]
        string TenantName { get;  }

    }
    /// Class representing a database principal assignment.
    internal partial interface IDatabasePrincipalAssignmentInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IProxyResourceInternal
    {
        /// <summary>
        /// The principal ID assigned to the database principal. It can be a user email, application ID, or security group name.
        /// </summary>
        string PrincipalId { get; set; }
        /// <summary>The principal name</summary>
        string PrincipalName { get; set; }
        /// <summary>Principal type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalType PrincipalType { get; set; }
        /// <summary>The database principal.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalProperties Property { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Database principal role.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole Role { get; set; }
        /// <summary>The tenant id of the principal</summary>
        string TenantId { get; set; }
        /// <summary>The tenant name of the principal</summary>
        string TenantName { get; set; }

    }
}