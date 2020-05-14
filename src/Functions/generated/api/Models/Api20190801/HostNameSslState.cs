namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SSL-enabled hostname.</summary>
    public partial class HostNameSslState :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal
    {

        /// <summary>Backing field for <see cref="HostType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostType? _hostType;

        /// <summary>Indicates whether the hostname is a standard or repository hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostType? HostType { get => this._hostType; set => this._hostType = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="SslState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState? _sslState;

        /// <summary>SSL type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState? SslState { get => this._sslState; set => this._sslState = value; }

        /// <summary>Backing field for <see cref="Thumbprint" /> property.</summary>
        private string _thumbprint;

        /// <summary>SSL certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Thumbprint { get => this._thumbprint; set => this._thumbprint = value; }

        /// <summary>Backing field for <see cref="ToUpdate" /> property.</summary>
        private bool? _toUpdate;

        /// <summary>Set to <code>true</code> to update existing hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ToUpdate { get => this._toUpdate; set => this._toUpdate = value; }

        /// <summary>Backing field for <see cref="VirtualIP" /> property.</summary>
        private string _virtualIP;

        /// <summary>Virtual IP address assigned to the hostname if IP based SSL is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VirtualIP { get => this._virtualIP; set => this._virtualIP = value; }

        /// <summary>Creates an new <see cref="HostNameSslState" /> instance.</summary>
        public HostNameSslState()
        {

        }
    }
    /// SSL-enabled hostname.
    public partial interface IHostNameSslState :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Indicates whether the hostname is a standard or repository hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether the hostname is a standard or repository hostname.",
        SerializedName = @"hostType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostType? HostType { get; set; }
        /// <summary>Hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Hostname.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>SSL type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SSL type.",
        SerializedName = @"sslState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState? SslState { get; set; }
        /// <summary>SSL certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SSL certificate thumbprint.",
        SerializedName = @"thumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string Thumbprint { get; set; }
        /// <summary>Set to <code>true</code> to update existing hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Set to <code>true</code> to update existing hostname.",
        SerializedName = @"toUpdate",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ToUpdate { get; set; }
        /// <summary>Virtual IP address assigned to the hostname if IP based SSL is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Virtual IP address assigned to the hostname if IP based SSL is enabled.",
        SerializedName = @"virtualIP",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualIP { get; set; }

    }
    /// SSL-enabled hostname.
    internal partial interface IHostNameSslStateInternal

    {
        /// <summary>Indicates whether the hostname is a standard or repository hostname.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostType? HostType { get; set; }
        /// <summary>Hostname.</summary>
        string Name { get; set; }
        /// <summary>SSL type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState? SslState { get; set; }
        /// <summary>SSL certificate thumbprint.</summary>
        string Thumbprint { get; set; }
        /// <summary>Set to <code>true</code> to update existing hostname.</summary>
        bool? ToUpdate { get; set; }
        /// <summary>Virtual IP address assigned to the hostname if IP based SSL is enabled.</summary>
        string VirtualIP { get; set; }

    }
}