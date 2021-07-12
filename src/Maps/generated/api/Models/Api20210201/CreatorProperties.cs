namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>Creator resource properties</summary>
    public partial class CreatorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorPropertiesInternal
    {

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The state of the resource provisioning, terminal states: Succeeded, Failed, Canceled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="StorageUnit" /> property.</summary>
        private int _storageUnit;

        /// <summary>The storage units to be allocated. Integer values from 1 to 100, inclusive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public int StorageUnit { get => this._storageUnit; set => this._storageUnit = value; }

        /// <summary>Creates an new <see cref="CreatorProperties" /> instance.</summary>
        public CreatorProperties()
        {

        }
    }
    /// Creator resource properties
    public partial interface ICreatorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The state of the resource provisioning, terminal states: Succeeded, Failed, Canceled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the resource provisioning, terminal states: Succeeded, Failed, Canceled",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The storage units to be allocated. Integer values from 1 to 100, inclusive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The storage units to be allocated. Integer values from 1 to 100, inclusive.",
        SerializedName = @"storageUnits",
        PossibleTypes = new [] { typeof(int) })]
        int StorageUnit { get; set; }

    }
    /// Creator resource properties
    internal partial interface ICreatorPropertiesInternal

    {
        /// <summary>
        /// The state of the resource provisioning, terminal states: Succeeded, Failed, Canceled
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The storage units to be allocated. Integer values from 1 to 100, inclusive.</summary>
        int StorageUnit { get; set; }

    }
}