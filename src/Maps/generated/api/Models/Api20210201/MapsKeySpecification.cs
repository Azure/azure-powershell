namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>Whether the operation refers to the primary or secondary key.</summary>
    public partial class MapsKeySpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsKeySpecification,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsKeySpecificationInternal
    {

        /// <summary>Backing field for <see cref="KeyType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.KeyType _keyType;

        /// <summary>Whether the operation refers to the primary or secondary key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.KeyType KeyType { get => this._keyType; set => this._keyType = value; }

        /// <summary>Creates an new <see cref="MapsKeySpecification" /> instance.</summary>
        public MapsKeySpecification()
        {

        }
    }
    /// Whether the operation refers to the primary or secondary key.
    public partial interface IMapsKeySpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable
    {
        /// <summary>Whether the operation refers to the primary or secondary key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether the operation refers to the primary or secondary key.",
        SerializedName = @"keyType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.KeyType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.KeyType KeyType { get; set; }

    }
    /// Whether the operation refers to the primary or secondary key.
    internal partial interface IMapsKeySpecificationInternal

    {
        /// <summary>Whether the operation refers to the primary or secondary key.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.KeyType KeyType { get; set; }

    }
}