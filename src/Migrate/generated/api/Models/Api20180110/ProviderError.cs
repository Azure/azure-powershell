namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>This class contains the error details per object.</summary>
    public partial class ProviderError :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderError,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderErrorInternal
    {

        /// <summary>Backing field for <see cref="ErrorCode" /> property.</summary>
        private int? _errorCode;

        /// <summary>The Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ErrorCode { get => this._errorCode; set => this._errorCode = value; }

        /// <summary>Backing field for <see cref="ErrorId" /> property.</summary>
        private string _errorId;

        /// <summary>The Provider error Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorId { get => this._errorId; set => this._errorId = value; }

        /// <summary>Backing field for <see cref="ErrorMessage" /> property.</summary>
        private string _errorMessage;

        /// <summary>The Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorMessage { get => this._errorMessage; set => this._errorMessage = value; }

        /// <summary>Backing field for <see cref="PossibleCaus" /> property.</summary>
        private string _possibleCaus;

        /// <summary>The possible causes for the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PossibleCaus { get => this._possibleCaus; set => this._possibleCaus = value; }

        /// <summary>Backing field for <see cref="RecommendedAction" /> property.</summary>
        private string _recommendedAction;

        /// <summary>The recommended action to resolve the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecommendedAction { get => this._recommendedAction; set => this._recommendedAction = value; }

        /// <summary>Creates an new <see cref="ProviderError" /> instance.</summary>
        public ProviderError()
        {

        }
    }
    /// This class contains the error details per object.
    public partial interface IProviderError :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Error code.",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(int) })]
        int? ErrorCode { get; set; }
        /// <summary>The Provider error Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Provider error Id.",
        SerializedName = @"errorId",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorId { get; set; }
        /// <summary>The Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Error message.",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorMessage { get; set; }
        /// <summary>The possible causes for the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The possible causes for the error.",
        SerializedName = @"possibleCauses",
        PossibleTypes = new [] { typeof(string) })]
        string PossibleCaus { get; set; }
        /// <summary>The recommended action to resolve the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recommended action to resolve the error.",
        SerializedName = @"recommendedAction",
        PossibleTypes = new [] { typeof(string) })]
        string RecommendedAction { get; set; }

    }
    /// This class contains the error details per object.
    internal partial interface IProviderErrorInternal

    {
        /// <summary>The Error code.</summary>
        int? ErrorCode { get; set; }
        /// <summary>The Provider error Id.</summary>
        string ErrorId { get; set; }
        /// <summary>The Error message.</summary>
        string ErrorMessage { get; set; }
        /// <summary>The possible causes for the error.</summary>
        string PossibleCaus { get; set; }
        /// <summary>The recommended action to resolve the error.</summary>
        string RecommendedAction { get; set; }

    }
}