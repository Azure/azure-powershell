namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Extensions;

    /// <summary>
    /// Name availability payload which is exposed in the response of the resource provider.
    /// </summary>
    public partial class NameAvailability :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.INameAvailability,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.INameAvailabilityInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Gets or sets the message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="NameAvailable" /> property.</summary>
        private bool? _nameAvailable;

        /// <summary>Gets or sets the value indicating whether the name is available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public bool? NameAvailable { get => this._nameAvailable; set => this._nameAvailable = value; }

        /// <summary>Backing field for <see cref="Reason" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.NameAvailabilityReason? _reason;

        /// <summary>Gets or sets the name availability reason.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.NameAvailabilityReason? Reason { get => this._reason; set => this._reason = value; }

        /// <summary>Creates an new <see cref="NameAvailability" /> instance.</summary>
        public NameAvailability()
        {

        }
    }
    /// Name availability payload which is exposed in the response of the resource provider.
    public partial interface INameAvailability :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Gets or sets the value indicating whether the name is available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the value indicating whether the name is available.",
        SerializedName = @"nameAvailable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? NameAvailable { get; set; }
        /// <summary>Gets or sets the name availability reason.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the name availability reason.",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.NameAvailabilityReason) })]
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.NameAvailabilityReason? Reason { get; set; }

    }
    /// Name availability payload which is exposed in the response of the resource provider.
    internal partial interface INameAvailabilityInternal

    {
        /// <summary>Gets or sets the message.</summary>
        string Message { get; set; }
        /// <summary>Gets or sets the value indicating whether the name is available.</summary>
        bool? NameAvailable { get; set; }
        /// <summary>Gets or sets the name availability reason.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.NameAvailabilityReason? Reason { get; set; }

    }
}