namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>DomainOwnershipIdentifier resource specific properties</summary>
    public partial class DomainOwnershipIdentifierProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainOwnershipIdentifierProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainOwnershipIdentifierPropertiesInternal
    {

        /// <summary>Backing field for <see cref="OwnershipId" /> property.</summary>
        private string _ownershipId;

        /// <summary>Ownership Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string OwnershipId { get => this._ownershipId; set => this._ownershipId = value; }

        /// <summary>Creates an new <see cref="DomainOwnershipIdentifierProperties" /> instance.</summary>
        public DomainOwnershipIdentifierProperties()
        {

        }
    }
    /// DomainOwnershipIdentifier resource specific properties
    public partial interface IDomainOwnershipIdentifierProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Ownership Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Ownership Id.",
        SerializedName = @"ownershipId",
        PossibleTypes = new [] { typeof(string) })]
        string OwnershipId { get; set; }

    }
    /// DomainOwnershipIdentifier resource specific properties
    internal partial interface IDomainOwnershipIdentifierPropertiesInternal

    {
        /// <summary>Ownership Id.</summary>
        string OwnershipId { get; set; }

    }
}