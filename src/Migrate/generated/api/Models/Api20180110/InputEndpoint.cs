namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Azure VM input endpoint details.</summary>
    public partial class InputEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpointInternal
    {

        /// <summary>Backing field for <see cref="EndpointName" /> property.</summary>
        private string _endpointName;

        /// <summary>The input endpoint name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EndpointName { get => this._endpointName; set => this._endpointName = value; }

        /// <summary>Backing field for <see cref="PrivatePort" /> property.</summary>
        private int? _privatePort;

        /// <summary>The input endpoint private port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? PrivatePort { get => this._privatePort; set => this._privatePort = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private string _protocol;

        /// <summary>The input endpoint protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="PublicPort" /> property.</summary>
        private int? _publicPort;

        /// <summary>The input endpoint public port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? PublicPort { get => this._publicPort; set => this._publicPort = value; }

        /// <summary>Creates an new <see cref="InputEndpoint" /> instance.</summary>
        public InputEndpoint()
        {

        }
    }
    /// Azure VM input endpoint details.
    public partial interface IInputEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The input endpoint name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The input endpoint name.",
        SerializedName = @"endpointName",
        PossibleTypes = new [] { typeof(string) })]
        string EndpointName { get; set; }
        /// <summary>The input endpoint private port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The input endpoint private port.",
        SerializedName = @"privatePort",
        PossibleTypes = new [] { typeof(int) })]
        int? PrivatePort { get; set; }
        /// <summary>The input endpoint protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The input endpoint protocol.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(string) })]
        string Protocol { get; set; }
        /// <summary>The input endpoint public port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The input endpoint public port.",
        SerializedName = @"publicPort",
        PossibleTypes = new [] { typeof(int) })]
        int? PublicPort { get; set; }

    }
    /// Azure VM input endpoint details.
    internal partial interface IInputEndpointInternal

    {
        /// <summary>The input endpoint name.</summary>
        string EndpointName { get; set; }
        /// <summary>The input endpoint private port.</summary>
        int? PrivatePort { get; set; }
        /// <summary>The input endpoint protocol.</summary>
        string Protocol { get; set; }
        /// <summary>The input endpoint public port.</summary>
        int? PublicPort { get; set; }

    }
}