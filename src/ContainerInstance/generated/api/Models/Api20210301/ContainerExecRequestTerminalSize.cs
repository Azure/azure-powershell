namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The size of the terminal.</summary>
    public partial class ContainerExecRequestTerminalSize :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExecRequestTerminalSize,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExecRequestTerminalSizeInternal
    {

        /// <summary>Backing field for <see cref="Col" /> property.</summary>
        private int? _col;

        /// <summary>The column size of the terminal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int? Col { get => this._col; set => this._col = value; }

        /// <summary>Backing field for <see cref="Row" /> property.</summary>
        private int? _row;

        /// <summary>The row size of the terminal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int? Row { get => this._row; set => this._row = value; }

        /// <summary>Creates an new <see cref="ContainerExecRequestTerminalSize" /> instance.</summary>
        public ContainerExecRequestTerminalSize()
        {

        }
    }
    /// The size of the terminal.
    public partial interface IContainerExecRequestTerminalSize :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The column size of the terminal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The column size of the terminal",
        SerializedName = @"cols",
        PossibleTypes = new [] { typeof(int) })]
        int? Col { get; set; }
        /// <summary>The row size of the terminal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The row size of the terminal",
        SerializedName = @"rows",
        PossibleTypes = new [] { typeof(int) })]
        int? Row { get; set; }

    }
    /// The size of the terminal.
    internal partial interface IContainerExecRequestTerminalSizeInternal

    {
        /// <summary>The column size of the terminal</summary>
        int? Col { get; set; }
        /// <summary>The row size of the terminal</summary>
        int? Row { get; set; }

    }
}