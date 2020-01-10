namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of ServiceAssociationLink.</summary>
    public partial class ServiceAssociationLinkPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceAssociationLinkPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceAssociationLinkPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="Link" /> property.</summary>
        private string _link;

        /// <summary>Link to the external resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Link { get => this._link; set => this._link = value; }

        /// <summary>Backing field for <see cref="LinkedResourceType" /> property.</summary>
        private string _linkedResourceType;

        /// <summary>Resource type of the linked resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LinkedResourceType { get => this._linkedResourceType; set => this._linkedResourceType = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceAssociationLinkPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>Provisioning state of the ServiceAssociationLink resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="ServiceAssociationLinkPropertiesFormat" /> instance.</summary>
        public ServiceAssociationLinkPropertiesFormat()
        {

        }
    }
    /// Properties of ServiceAssociationLink.
    public partial interface IServiceAssociationLinkPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Link to the external resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link to the external resource.",
        SerializedName = @"link",
        PossibleTypes = new [] { typeof(string) })]
        string Link { get; set; }
        /// <summary>Resource type of the linked resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource type of the linked resource.",
        SerializedName = @"linkedResourceType",
        PossibleTypes = new [] { typeof(string) })]
        string LinkedResourceType { get; set; }
        /// <summary>Provisioning state of the ServiceAssociationLink resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the ServiceAssociationLink resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// Properties of ServiceAssociationLink.
    internal partial interface IServiceAssociationLinkPropertiesFormatInternal

    {
        /// <summary>Link to the external resource.</summary>
        string Link { get; set; }
        /// <summary>Resource type of the linked resource.</summary>
        string LinkedResourceType { get; set; }
        /// <summary>Provisioning state of the ServiceAssociationLink resource.</summary>
        string ProvisioningState { get; set; }

    }
}