namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of ResourceNavigationLink.</summary>
    public partial class ResourceNavigationLinkFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceNavigationLinkFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceNavigationLinkFormatInternal
    {

        /// <summary>Backing field for <see cref="Link" /> property.</summary>
        private string _link;

        /// <summary>Link to the external resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Link { get => this._link; set => this._link = value; }

        /// <summary>Backing field for <see cref="LinkedResourceType" /> property.</summary>
        private string _linkedResourceType;

        /// <summary>Resource type of the linked resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LinkedResourceType { get => this._linkedResourceType; set => this._linkedResourceType = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceNavigationLinkFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>Provisioning state of the ResourceNavigationLink resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="ResourceNavigationLinkFormat" /> instance.</summary>
        public ResourceNavigationLinkFormat()
        {

        }
    }
    /// Properties of ResourceNavigationLink.
    public partial interface IResourceNavigationLinkFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Link to the external resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link to the external resource",
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
        /// <summary>Provisioning state of the ResourceNavigationLink resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the ResourceNavigationLink resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// Properties of ResourceNavigationLink.
    internal partial interface IResourceNavigationLinkFormatInternal

    {
        /// <summary>Link to the external resource</summary>
        string Link { get; set; }
        /// <summary>Resource type of the linked resource.</summary>
        string LinkedResourceType { get; set; }
        /// <summary>Provisioning state of the ResourceNavigationLink resource.</summary>
        string ProvisioningState { get; set; }

    }
}