namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The parameters used to check the availability of the storage account name.</summary>
    public partial class StorageAccountCheckNameAvailabilityParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountCheckNameAvailabilityParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountCheckNameAvailabilityParametersInternal
    {

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountCheckNameAvailabilityParametersInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The storage account name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type= @"Microsoft.Storage/storageAccounts";

        /// <summary>The type of resource, Microsoft.Storage/storageAccounts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>
        /// Creates an new <see cref="StorageAccountCheckNameAvailabilityParameters" /> instance.
        /// </summary>
        public StorageAccountCheckNameAvailabilityParameters()
        {

        }
    }
    /// The parameters used to check the availability of the storage account name.
    public partial interface IStorageAccountCheckNameAvailabilityParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The storage account name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The storage account name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.Storage/storageAccounts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The type of resource, Microsoft.Storage/storageAccounts",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// The parameters used to check the availability of the storage account name.
    internal partial interface IStorageAccountCheckNameAvailabilityParametersInternal

    {
        /// <summary>The storage account name.</summary>
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.Storage/storageAccounts</summary>
        string Type { get; set; }

    }
}