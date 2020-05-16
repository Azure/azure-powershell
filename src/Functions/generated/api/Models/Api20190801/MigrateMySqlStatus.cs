namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>MySQL migration status.</summary>
    public partial class MigrateMySqlStatus :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatus,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>True if the web app has in app MySql enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? LocalMySqlEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal)Property).LocalMySqlEnabled; }

        /// <summary>Internal Acessors for LocalMySqlEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusInternal.LocalMySqlEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal)Property).LocalMySqlEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal)Property).LocalMySqlEnabled = value; }

        /// <summary>Internal Acessors for MigrationOperationStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusInternal.MigrationOperationStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal)Property).MigrationOperationStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal)Property).MigrationOperationStatus = value; }

        /// <summary>Internal Acessors for OperationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusInternal.OperationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal)Property).OperationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal)Property).OperationId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.MigrateMySqlStatusProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Status of the migration task.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? MigrationOperationStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal)Property).MigrationOperationStatus; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Operation ID for the migration task.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string OperationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal)Property).OperationId; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusProperties _property;

        /// <summary>MigrateMySqlStatus resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.MigrateMySqlStatusProperties()); set => this._property = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="MigrateMySqlStatus" /> instance.</summary>
        public MigrateMySqlStatus()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// MySQL migration status.
    public partial interface IMigrateMySqlStatus :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>True if the web app has in app MySql enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"True if the web app has in app MySql enabled",
        SerializedName = @"localMySqlEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LocalMySqlEnabled { get;  }
        /// <summary>Status of the migration task.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the migration task.",
        SerializedName = @"migrationOperationStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? MigrationOperationStatus { get;  }
        /// <summary>Operation ID for the migration task.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Operation ID for the migration task.",
        SerializedName = @"operationId",
        PossibleTypes = new [] { typeof(string) })]
        string OperationId { get;  }

    }
    /// MySQL migration status.
    internal partial interface IMigrateMySqlStatusInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>True if the web app has in app MySql enabled</summary>
        bool? LocalMySqlEnabled { get; set; }
        /// <summary>Status of the migration task.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? MigrationOperationStatus { get; set; }
        /// <summary>Operation ID for the migration task.</summary>
        string OperationId { get; set; }
        /// <summary>MigrateMySqlStatus resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusProperties Property { get; set; }

    }
}