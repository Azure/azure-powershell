namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>The CheckNameAvailability operation response.</summary>
    public partial class CheckNameAvailabilityResult :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResult,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>An error message explaining the Reason value in more detail.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for NameAvailable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal.NameAvailable { get => this._nameAvailable; set { {_nameAvailable = value;} } }

        /// <summary>Internal Acessors for Reason</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.Reason? Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal.Reason { get => this._reason; set { {_reason = value;} } }

        /// <summary>Backing field for <see cref="NameAvailable" /> property.</summary>
        private bool? _nameAvailable;

        /// <summary>
        /// A boolean value that indicates whether the name is available for you to use. If true, the name is available. If false,
        /// the name has already been taken or is invalid and cannot be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public bool? NameAvailable { get => this._nameAvailable; }

        /// <summary>Backing field for <see cref="Reason" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.Reason? _reason;

        /// <summary>
        /// The reason that a vault name could not be used. The Reason element is only returned if NameAvailable is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.Reason? Reason { get => this._reason; }

        /// <summary>Creates an new <see cref="CheckNameAvailabilityResult" /> instance.</summary>
        public CheckNameAvailabilityResult()
        {

        }
    }
    /// The CheckNameAvailability operation response.
    public partial interface ICheckNameAvailabilityResult :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>An error message explaining the Reason value in more detail.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"An error message explaining the Reason value in more detail.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>
        /// A boolean value that indicates whether the name is available for you to use. If true, the name is available. If false,
        /// the name has already been taken or is invalid and cannot be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A boolean value that indicates whether the name is available for you to use. If true, the name is available. If false, the name has already been taken or is invalid and cannot be used.",
        SerializedName = @"nameAvailable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? NameAvailable { get;  }
        /// <summary>
        /// The reason that a vault name could not be used. The Reason element is only returned if NameAvailable is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The reason that a vault name could not be used. The Reason element is only returned if NameAvailable is false.",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.Reason) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.Reason? Reason { get;  }

    }
    /// The CheckNameAvailability operation response.
    internal partial interface ICheckNameAvailabilityResultInternal

    {
        /// <summary>An error message explaining the Reason value in more detail.</summary>
        string Message { get; set; }
        /// <summary>
        /// A boolean value that indicates whether the name is available for you to use. If true, the name is available. If false,
        /// the name has already been taken or is invalid and cannot be used.
        /// </summary>
        bool? NameAvailable { get; set; }
        /// <summary>
        /// The reason that a vault name could not be used. The Reason element is only returned if NameAvailable is false.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.Reason? Reason { get; set; }

    }
}