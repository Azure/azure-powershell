namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Network access control entry.</summary>
    public partial class NetworkAccessControlEntry :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntryInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessControlEntryAction? _action;

        /// <summary>Action object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessControlEntryAction? Action { get => this._action; set => this._action = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of network access control entry.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Order" /> property.</summary>
        private int? _order;

        /// <summary>Order of precedence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Order { get => this._order; set => this._order = value; }

        /// <summary>Backing field for <see cref="RemoteSubnet" /> property.</summary>
        private string _remoteSubnet;

        /// <summary>Remote subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RemoteSubnet { get => this._remoteSubnet; set => this._remoteSubnet = value; }

        /// <summary>Creates an new <see cref="NetworkAccessControlEntry" /> instance.</summary>
        public NetworkAccessControlEntry()
        {

        }
    }
    /// Network access control entry.
    public partial interface INetworkAccessControlEntry :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Action object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Action object.",
        SerializedName = @"action",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessControlEntryAction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessControlEntryAction? Action { get; set; }
        /// <summary>Description of network access control entry.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of network access control entry.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Order of precedence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Order of precedence.",
        SerializedName = @"order",
        PossibleTypes = new [] { typeof(int) })]
        int? Order { get; set; }
        /// <summary>Remote subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Remote subnet.",
        SerializedName = @"remoteSubnet",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteSubnet { get; set; }

    }
    /// Network access control entry.
    internal partial interface INetworkAccessControlEntryInternal

    {
        /// <summary>Action object.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessControlEntryAction? Action { get; set; }
        /// <summary>Description of network access control entry.</summary>
        string Description { get; set; }
        /// <summary>Order of precedence.</summary>
        int? Order { get; set; }
        /// <summary>Remote subnet.</summary>
        string RemoteSubnet { get; set; }

    }
}