namespace Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Extensions;

    /// <summary>The properties of the association.</summary>
    public partial class AssociationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IAssociationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IAssociationPropertiesInternal
    {

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IAssociationPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the association.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="TargetResourceId" /> property.</summary>
        private string _targetResourceId;

        /// <summary>The REST resource instance of the target resource for this association.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public string TargetResourceId { get => this._targetResourceId; set => this._targetResourceId = value; }

        /// <summary>Creates an new <see cref="AssociationProperties" /> instance.</summary>
        public AssociationProperties()
        {

        }
    }
    /// The properties of the association.
    public partial interface IAssociationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IJsonSerializable
    {
        /// <summary>The provisioning state of the association.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the association.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>The REST resource instance of the target resource for this association.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The REST resource instance of the target resource for this association.",
        SerializedName = @"targetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetResourceId { get; set; }

    }
    /// The properties of the association.
    internal partial interface IAssociationPropertiesInternal

    {
        /// <summary>The provisioning state of the association.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The REST resource instance of the target resource for this association.</summary>
        string TargetResourceId { get; set; }

    }
}