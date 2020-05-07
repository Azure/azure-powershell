namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>The result of a request to check the availability of a resource name.</summary>
    public partial class NameAvailabilityStatus :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.INameAvailabilityStatus,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.INameAvailabilityStatusInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>
        /// If any, the error message that provides more detail for the reason that the name is not available.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.INameAvailabilityStatusInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for NameAvailable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.INameAvailabilityStatusInternal.NameAvailable { get => this._nameAvailable; set { {_nameAvailable = value;} } }

        /// <summary>Internal Acessors for Reason</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.INameAvailabilityStatusInternal.Reason { get => this._reason; set { {_reason = value;} } }

        /// <summary>Backing field for <see cref="NameAvailable" /> property.</summary>
        private bool? _nameAvailable;

        /// <summary>The value indicating whether the resource name is available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public bool? NameAvailable { get => this._nameAvailable; }

        /// <summary>Backing field for <see cref="Reason" /> property.</summary>
        private string _reason;

        /// <summary>If any, the reason that the name is not available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Reason { get => this._reason; }

        /// <summary>Creates an new <see cref="NameAvailabilityStatus" /> instance.</summary>
        public NameAvailabilityStatus()
        {

        }
    }
    /// The result of a request to check the availability of a resource name.
    public partial interface INameAvailabilityStatus :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>
        /// If any, the error message that provides more detail for the reason that the name is not available.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"If any, the error message that provides more detail for the reason that the name is not available.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>The value indicating whether the resource name is available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The value indicating whether the resource name is available.",
        SerializedName = @"nameAvailable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? NameAvailable { get;  }
        /// <summary>If any, the reason that the name is not available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"If any, the reason that the name is not available.",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(string) })]
        string Reason { get;  }

    }
    /// The result of a request to check the availability of a resource name.
    internal partial interface INameAvailabilityStatusInternal

    {
        /// <summary>
        /// If any, the error message that provides more detail for the reason that the name is not available.
        /// </summary>
        string Message { get; set; }
        /// <summary>The value indicating whether the resource name is available.</summary>
        bool? NameAvailable { get; set; }
        /// <summary>If any, the reason that the name is not available.</summary>
        string Reason { get; set; }

    }
}