namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>StorageMigrationResponse resource specific properties</summary>
    public partial class StorageMigrationResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationResponseProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationResponsePropertiesInternal
    {

        /// <summary>Internal Acessors for OperationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStorageMigrationResponsePropertiesInternal.OperationId { get => this._operationId; set { {_operationId = value;} } }

        /// <summary>Backing field for <see cref="OperationId" /> property.</summary>
        private string _operationId;

        /// <summary>
        /// When server starts the migration process, it will return an operation ID identifying that particular migration operation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string OperationId { get => this._operationId; }

        /// <summary>Creates an new <see cref="StorageMigrationResponseProperties" /> instance.</summary>
        public StorageMigrationResponseProperties()
        {

        }
    }
    /// StorageMigrationResponse resource specific properties
    public partial interface IStorageMigrationResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// When server starts the migration process, it will return an operation ID identifying that particular migration operation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"When server starts the migration process, it will return an operation ID identifying that particular migration operation.",
        SerializedName = @"operationId",
        PossibleTypes = new [] { typeof(string) })]
        string OperationId { get;  }

    }
    /// StorageMigrationResponse resource specific properties
    internal partial interface IStorageMigrationResponsePropertiesInternal

    {
        /// <summary>
        /// When server starts the migration process, it will return an operation ID identifying that particular migration operation.
        /// </summary>
        string OperationId { get; set; }

    }
}