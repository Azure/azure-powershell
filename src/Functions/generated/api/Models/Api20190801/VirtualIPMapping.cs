namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Virtual IP mapping.</summary>
    public partial class VirtualIPMapping :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMappingInternal
    {

        /// <summary>Backing field for <see cref="InUse" /> property.</summary>
        private bool? _inUse;

        /// <summary>Is virtual IP mapping in use.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? InUse { get => this._inUse; set => this._inUse = value; }

        /// <summary>Backing field for <see cref="InternalHttpPort" /> property.</summary>
        private int? _internalHttpPort;

        /// <summary>Internal HTTP port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? InternalHttpPort { get => this._internalHttpPort; set => this._internalHttpPort = value; }

        /// <summary>Backing field for <see cref="InternalHttpsPort" /> property.</summary>
        private int? _internalHttpsPort;

        /// <summary>Internal HTTPS port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? InternalHttpsPort { get => this._internalHttpsPort; set => this._internalHttpsPort = value; }

        /// <summary>Backing field for <see cref="ServiceName" /> property.</summary>
        private string _serviceName;

        /// <summary>name of the service that virtual IP is assigned to</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ServiceName { get => this._serviceName; set => this._serviceName = value; }

        /// <summary>Backing field for <see cref="VirtualIP" /> property.</summary>
        private string _virtualIP;

        /// <summary>Virtual IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VirtualIP { get => this._virtualIP; set => this._virtualIP = value; }

        /// <summary>Creates an new <see cref="VirtualIPMapping" /> instance.</summary>
        public VirtualIPMapping()
        {

        }
    }
    /// Virtual IP mapping.
    public partial interface IVirtualIPMapping :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Is virtual IP mapping in use.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Is virtual IP mapping in use.",
        SerializedName = @"inUse",
        PossibleTypes = new [] { typeof(bool) })]
        bool? InUse { get; set; }
        /// <summary>Internal HTTP port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Internal HTTP port.",
        SerializedName = @"internalHttpPort",
        PossibleTypes = new [] { typeof(int) })]
        int? InternalHttpPort { get; set; }
        /// <summary>Internal HTTPS port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Internal HTTPS port.",
        SerializedName = @"internalHttpsPort",
        PossibleTypes = new [] { typeof(int) })]
        int? InternalHttpsPort { get; set; }
        /// <summary>name of the service that virtual IP is assigned to</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"name of the service that virtual IP is assigned to",
        SerializedName = @"serviceName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceName { get; set; }
        /// <summary>Virtual IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Virtual IP address.",
        SerializedName = @"virtualIP",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualIP { get; set; }

    }
    /// Virtual IP mapping.
    internal partial interface IVirtualIPMappingInternal

    {
        /// <summary>Is virtual IP mapping in use.</summary>
        bool? InUse { get; set; }
        /// <summary>Internal HTTP port.</summary>
        int? InternalHttpPort { get; set; }
        /// <summary>Internal HTTPS port.</summary>
        int? InternalHttpsPort { get; set; }
        /// <summary>name of the service that virtual IP is assigned to</summary>
        string ServiceName { get; set; }
        /// <summary>Virtual IP address.</summary>
        string VirtualIP { get; set; }

    }
}