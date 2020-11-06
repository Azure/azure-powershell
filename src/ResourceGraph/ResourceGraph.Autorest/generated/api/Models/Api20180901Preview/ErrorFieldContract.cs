namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Extensions;

    /// <summary>Error Field contract.</summary>
    public partial class ErrorFieldContract :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IErrorFieldContract,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IErrorFieldContractInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Property level error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Human-readable representation of property-level error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private string _target;

        /// <summary>Property name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public string Target { get => this._target; set => this._target = value; }

        /// <summary>Creates an new <see cref="ErrorFieldContract" /> instance.</summary>
        public ErrorFieldContract()
        {

        }
    }
    /// Error Field contract.
    public partial interface IErrorFieldContract :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.IJsonSerializable
    {
        /// <summary>Property level error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Property level error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Human-readable representation of property-level error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Human-readable representation of property-level error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Property name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Property name.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get; set; }

    }
    /// Error Field contract.
    internal partial interface IErrorFieldContractInternal

    {
        /// <summary>Property level error code.</summary>
        string Code { get; set; }
        /// <summary>Human-readable representation of property-level error.</summary>
        string Message { get; set; }
        /// <summary>Property name.</summary>
        string Target { get; set; }

    }
}