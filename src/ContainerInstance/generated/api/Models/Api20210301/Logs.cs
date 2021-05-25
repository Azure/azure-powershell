namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The logs.</summary>
    public partial class Logs :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogs,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogsInternal
    {

        /// <summary>Backing field for <see cref="Content" /> property.</summary>
        private string _content;

        /// <summary>The content of the log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Content { get => this._content; set => this._content = value; }

        /// <summary>Creates an new <see cref="Logs" /> instance.</summary>
        public Logs()
        {

        }
    }
    /// The logs.
    public partial interface ILogs :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The content of the log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The content of the log.",
        SerializedName = @"content",
        PossibleTypes = new [] { typeof(string) })]
        string Content { get; set; }

    }
    /// The logs.
    internal partial interface ILogsInternal

    {
        /// <summary>The content of the log.</summary>
        string Content { get; set; }

    }
}