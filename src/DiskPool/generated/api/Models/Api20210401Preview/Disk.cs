namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>Azure Managed Disk to attach to the Disk Pool.</summary>
    public partial class Disk :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDisk,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Unique Azure Resource ID of the Managed Disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="Disk" /> instance.</summary>
        public Disk()
        {

        }
    }
    /// Azure Managed Disk to attach to the Disk Pool.
    public partial interface IDisk :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable
    {
        /// <summary>Unique Azure Resource ID of the Managed Disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Unique Azure Resource ID of the Managed Disk.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// Azure Managed Disk to attach to the Disk Pool.
    internal partial interface IDiskInternal

    {
        /// <summary>Unique Azure Resource ID of the Managed Disk.</summary>
        string Id { get; set; }

    }
}