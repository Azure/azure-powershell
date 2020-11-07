namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>KeyVaultReferenceCollection resource specific properties</summary>
    public partial class KeyVaultReferenceCollectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyVaultReferenceCollectionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyVaultReferenceCollectionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="KeyToReferenceStatuses" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyVaultReferenceCollectionPropertiesKeyToReferenceStatuses _keyToReferenceStatuses;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyVaultReferenceCollectionPropertiesKeyToReferenceStatuses KeyToReferenceStatuses { get => (this._keyToReferenceStatuses = this._keyToReferenceStatuses ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.KeyVaultReferenceCollectionPropertiesKeyToReferenceStatuses()); set => this._keyToReferenceStatuses = value; }

        /// <summary>Creates an new <see cref="KeyVaultReferenceCollectionProperties" /> instance.</summary>
        public KeyVaultReferenceCollectionProperties()
        {

        }
    }
    /// KeyVaultReferenceCollection resource specific properties
    public partial interface IKeyVaultReferenceCollectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"keyToReferenceStatuses",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyVaultReferenceCollectionPropertiesKeyToReferenceStatuses) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyVaultReferenceCollectionPropertiesKeyToReferenceStatuses KeyToReferenceStatuses { get; set; }

    }
    /// KeyVaultReferenceCollection resource specific properties
    internal partial interface IKeyVaultReferenceCollectionPropertiesInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyVaultReferenceCollectionPropertiesKeyToReferenceStatuses KeyToReferenceStatuses { get; set; }

    }
}