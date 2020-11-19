namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// Represents the error used to indicate why the target compute size is not applicable.
    /// </summary>
    public partial class ComputeSizeErrorDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IComputeSizeErrorDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IComputeSizeErrorDetailsInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="Severity" /> property.</summary>
        private string _severity;

        /// <summary>The severity of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Severity { get => this._severity; set => this._severity = value; }

        /// <summary>Creates an new <see cref="ComputeSizeErrorDetails" /> instance.</summary>
        public ComputeSizeErrorDetails()
        {

        }
    }
    /// Represents the error used to indicate why the target compute size is not applicable.
    public partial interface IComputeSizeErrorDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>The severity of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The severity of the error.",
        SerializedName = @"severity",
        PossibleTypes = new [] { typeof(string) })]
        string Severity { get; set; }

    }
    /// Represents the error used to indicate why the target compute size is not applicable.
    internal partial interface IComputeSizeErrorDetailsInternal

    {
        /// <summary>The error message.</summary>
        string Message { get; set; }
        /// <summary>The severity of the error.</summary>
        string Severity { get; set; }

    }
}