namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>The state of a private link service connection.</summary>
    public partial class PrivateLinkServiceConnectionState :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkServiceConnectionState,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkServiceConnectionStateInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The private link service connection description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ConnectionStatus? _status;

        /// <summary>The private link service connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ConnectionStatus? Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="PrivateLinkServiceConnectionState" /> instance.</summary>
        public PrivateLinkServiceConnectionState()
        {

        }
    }
    /// The state of a private link service connection.
    public partial interface IPrivateLinkServiceConnectionState :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>The private link service connection description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private link service connection description.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The private link service connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private link service connection status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ConnectionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ConnectionStatus? Status { get; set; }

    }
    /// The state of a private link service connection.
    internal partial interface IPrivateLinkServiceConnectionStateInternal

    {
        /// <summary>The private link service connection description.</summary>
        string Description { get; set; }
        /// <summary>The private link service connection status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ConnectionStatus? Status { get; set; }

    }
}