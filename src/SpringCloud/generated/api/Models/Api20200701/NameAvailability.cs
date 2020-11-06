namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Name availability result payload</summary>
    public partial class NameAvailability :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INameAvailability,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INameAvailabilityInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Message why the name is not available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="NameAvailable" /> property.</summary>
        private bool? _nameAvailable;

        /// <summary>Indicates whether the name is available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public bool? NameAvailable { get => this._nameAvailable; set => this._nameAvailable = value; }

        /// <summary>Backing field for <see cref="Reason" /> property.</summary>
        private string _reason;

        /// <summary>Reason why the name is not available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Reason { get => this._reason; set => this._reason = value; }

        /// <summary>Creates an new <see cref="NameAvailability" /> instance.</summary>
        public NameAvailability()
        {

        }
    }
    /// Name availability result payload
    public partial interface INameAvailability :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Message why the name is not available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Message why the name is not available",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Indicates whether the name is available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether the name is available",
        SerializedName = @"nameAvailable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? NameAvailable { get; set; }
        /// <summary>Reason why the name is not available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Reason why the name is not available",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(string) })]
        string Reason { get; set; }

    }
    /// Name availability result payload
    public partial interface INameAvailabilityInternal

    {
        /// <summary>Message why the name is not available</summary>
        string Message { get; set; }
        /// <summary>Indicates whether the name is available</summary>
        bool? NameAvailable { get; set; }
        /// <summary>Reason why the name is not available</summary>
        string Reason { get; set; }

    }
}