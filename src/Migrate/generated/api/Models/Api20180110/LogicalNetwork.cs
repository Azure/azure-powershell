namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Logical network data model.</summary>
    public partial class LogicalNetwork :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetwork,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Resource();

        /// <summary>A value indicating whether logical network definitions are isolated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DefinitionsStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkPropertiesInternal)Property).LogicalNetworkDefinitionsStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkPropertiesInternal)Property).LogicalNetworkDefinitionsStatus = value ?? null; }

        /// <summary>The Friendly Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkPropertiesInternal)Property).FriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkPropertiesInternal)Property).FriendlyName = value ?? null; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; }

        /// <summary>Resource Location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.LogicalNetworkProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; }

        /// <summary>
        /// A value indicating whether Network Virtualization is enabled for the logical network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string NetworkVirtualizationStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkPropertiesInternal)Property).NetworkVirtualizationStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkPropertiesInternal)Property).NetworkVirtualizationStatus = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkProperties _property;

        /// <summary>The Logical Network Properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.LogicalNetworkProperties()); set => this._property = value; }

        /// <summary>Resource Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; }

        /// <summary>
        /// A value indicating whether logical network is used as private test network by test failover.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Usage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkPropertiesInternal)Property).LogicalNetworkUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkPropertiesInternal)Property).LogicalNetworkUsage = value ?? null; }

        /// <summary>Creates an new <see cref="LogicalNetwork" /> instance.</summary>
        public LogicalNetwork()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Logical network data model.
    public partial interface ILogicalNetwork :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource
    {
        /// <summary>A value indicating whether logical network definitions are isolated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether logical network definitions are isolated.",
        SerializedName = @"logicalNetworkDefinitionsStatus",
        PossibleTypes = new [] { typeof(string) })]
        string DefinitionsStatus { get; set; }
        /// <summary>The Friendly Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Friendly Name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>
        /// A value indicating whether Network Virtualization is enabled for the logical network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether Network Virtualization is enabled for the logical network.",
        SerializedName = @"networkVirtualizationStatus",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkVirtualizationStatus { get; set; }
        /// <summary>
        /// A value indicating whether logical network is used as private test network by test failover.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether logical network is used as private test network by test failover.",
        SerializedName = @"logicalNetworkUsage",
        PossibleTypes = new [] { typeof(string) })]
        string Usage { get; set; }

    }
    /// Logical network data model.
    internal partial interface ILogicalNetworkInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal
    {
        /// <summary>A value indicating whether logical network definitions are isolated.</summary>
        string DefinitionsStatus { get; set; }
        /// <summary>The Friendly Name.</summary>
        string FriendlyName { get; set; }
        /// <summary>
        /// A value indicating whether Network Virtualization is enabled for the logical network.
        /// </summary>
        string NetworkVirtualizationStatus { get; set; }
        /// <summary>The Logical Network Properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkProperties Property { get; set; }
        /// <summary>
        /// A value indicating whether logical network is used as private test network by test failover.
        /// </summary>
        string Usage { get; set; }

    }
}