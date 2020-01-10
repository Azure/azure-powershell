namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the flow log format.</summary>
    public partial class FlowLogFormatParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParametersInternal
    {

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType? _type;

        /// <summary>The file type of flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType? Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private int? _version;

        /// <summary>The version (revision) of the flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="FlowLogFormatParameters" /> instance.</summary>
        public FlowLogFormatParameters()
        {

        }
    }
    /// Parameters that define the flow log format.
    public partial interface IFlowLogFormatParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The file type of flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The file type of flow log.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType? Type { get; set; }
        /// <summary>The version (revision) of the flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version (revision) of the flow log.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int? Version { get; set; }

    }
    /// Parameters that define the flow log format.
    internal partial interface IFlowLogFormatParametersInternal

    {
        /// <summary>The file type of flow log.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType? Type { get; set; }
        /// <summary>The version (revision) of the flow log.</summary>
        int? Version { get; set; }

    }
}