namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The container execution command, for liveness or readiness probe</summary>
    public partial class ContainerExec :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExec,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExecInternal
    {

        /// <summary>Backing field for <see cref="Command" /> property.</summary>
        private string[] _command;

        /// <summary>The commands to execute within the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string[] Command { get => this._command; set => this._command = value; }

        /// <summary>Creates an new <see cref="ContainerExec" /> instance.</summary>
        public ContainerExec()
        {

        }
    }
    /// The container execution command, for liveness or readiness probe
    public partial interface IContainerExec :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The commands to execute within the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The commands to execute within the container.",
        SerializedName = @"command",
        PossibleTypes = new [] { typeof(string) })]
        string[] Command { get; set; }

    }
    /// The container execution command, for liveness or readiness probe
    internal partial interface IContainerExecInternal

    {
        /// <summary>The commands to execute within the container.</summary>
        string[] Command { get; set; }

    }
}