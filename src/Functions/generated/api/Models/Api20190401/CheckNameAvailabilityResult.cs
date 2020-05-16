namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The CheckNameAvailability operation response.</summary>
    public partial class CheckNameAvailabilityResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICheckNameAvailabilityResult,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICheckNameAvailabilityResultInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Gets an error message explaining the Reason value in more detail.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICheckNameAvailabilityResultInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for NameAvailable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICheckNameAvailabilityResultInternal.NameAvailable { get => this._nameAvailable; set { {_nameAvailable = value;} } }

        /// <summary>Internal Acessors for Reason</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Reason? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICheckNameAvailabilityResultInternal.Reason { get => this._reason; set { {_reason = value;} } }

        /// <summary>Backing field for <see cref="NameAvailable" /> property.</summary>
        private bool? _nameAvailable;

        /// <summary>
        /// Gets a boolean value that indicates whether the name is available for you to use. If true, the name is available. If false,
        /// the name has already been taken or is invalid and cannot be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? NameAvailable { get => this._nameAvailable; }

        /// <summary>Backing field for <see cref="Reason" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Reason? _reason;

        /// <summary>
        /// Gets the reason that a storage account name could not be used. The Reason element is only returned if NameAvailable is
        /// false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Reason? Reason { get => this._reason; }

        /// <summary>Creates an new <see cref="CheckNameAvailabilityResult" /> instance.</summary>
        public CheckNameAvailabilityResult()
        {

        }
    }
    /// The CheckNameAvailability operation response.
    public partial interface ICheckNameAvailabilityResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Gets an error message explaining the Reason value in more detail.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets an error message explaining the Reason value in more detail.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>
        /// Gets a boolean value that indicates whether the name is available for you to use. If true, the name is available. If false,
        /// the name has already been taken or is invalid and cannot be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a boolean value that indicates whether the name is available for you to use. If true, the name is available. If false, the name has already been taken or is invalid and cannot be used.",
        SerializedName = @"nameAvailable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? NameAvailable { get;  }
        /// <summary>
        /// Gets the reason that a storage account name could not be used. The Reason element is only returned if NameAvailable is
        /// false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the reason that a storage account name could not be used. The Reason element is only returned if NameAvailable is false.",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Reason) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Reason? Reason { get;  }

    }
    /// The CheckNameAvailability operation response.
    internal partial interface ICheckNameAvailabilityResultInternal

    {
        /// <summary>Gets an error message explaining the Reason value in more detail.</summary>
        string Message { get; set; }
        /// <summary>
        /// Gets a boolean value that indicates whether the name is available for you to use. If true, the name is available. If false,
        /// the name has already been taken or is invalid and cannot be used.
        /// </summary>
        bool? NameAvailable { get; set; }
        /// <summary>
        /// Gets the reason that a storage account name could not be used. The Reason element is only returned if NameAvailable is
        /// false.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Reason? Reason { get; set; }

    }
}