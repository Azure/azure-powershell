namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Properties of the error resource.</summary>
    public partial class MigrateEventProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ClientRequestId" /> property.</summary>
        private string _clientRequestId;

        /// <summary>
        /// Gets or sets the client request Id of the payload for which the event is being reported.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ClientRequestId { get => this._clientRequestId; set => this._clientRequestId = value; }

        /// <summary>Backing field for <see cref="ErrorCode" /> property.</summary>
        private string _errorCode;

        /// <summary>Gets or sets the error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorCode { get => this._errorCode; set => this._errorCode = value; }

        /// <summary>Backing field for <see cref="ErrorMessage" /> property.</summary>
        private string _errorMessage;

        /// <summary>Gets or sets the error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorMessage { get => this._errorMessage; set => this._errorMessage = value; }

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventPropertiesInternal.InstanceType { get => this._instanceType; set { {_instanceType = value;} } }

        /// <summary>Backing field for <see cref="PossibleCaus" /> property.</summary>
        private string _possibleCaus;

        /// <summary>Gets or sets the possible causes for the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PossibleCaus { get => this._possibleCaus; set => this._possibleCaus = value; }

        /// <summary>Backing field for <see cref="Recommendation" /> property.</summary>
        private string _recommendation;

        /// <summary>Gets or sets the recommendation for the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Recommendation { get => this._recommendation; set => this._recommendation = value; }

        /// <summary>Backing field for <see cref="Solution" /> property.</summary>
        private string _solution;

        /// <summary>Gets or sets the solution for which the error is being reported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Solution { get => this._solution; set => this._solution = value; }

        /// <summary>Creates an new <see cref="MigrateEventProperties" /> instance.</summary>
        public MigrateEventProperties()
        {

        }
    }
    /// Properties of the error resource.
    public partial interface IMigrateEventProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets or sets the client request Id of the payload for which the event is being reported.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the client request Id of the payload for which the event is being reported.",
        SerializedName = @"clientRequestId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientRequestId { get; set; }
        /// <summary>Gets or sets the error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the error code.",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorCode { get; set; }
        /// <summary>Gets or sets the error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the error message.",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorMessage { get; set; }
        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the Instance type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get;  }
        /// <summary>Gets or sets the possible causes for the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the possible causes for the error.",
        SerializedName = @"possibleCauses",
        PossibleTypes = new [] { typeof(string) })]
        string PossibleCaus { get; set; }
        /// <summary>Gets or sets the recommendation for the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the recommendation for the error.",
        SerializedName = @"recommendation",
        PossibleTypes = new [] { typeof(string) })]
        string Recommendation { get; set; }
        /// <summary>Gets or sets the solution for which the error is being reported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the solution for which the error is being reported.",
        SerializedName = @"solution",
        PossibleTypes = new [] { typeof(string) })]
        string Solution { get; set; }

    }
    /// Properties of the error resource.
    internal partial interface IMigrateEventPropertiesInternal

    {
        /// <summary>
        /// Gets or sets the client request Id of the payload for which the event is being reported.
        /// </summary>
        string ClientRequestId { get; set; }
        /// <summary>Gets or sets the error code.</summary>
        string ErrorCode { get; set; }
        /// <summary>Gets or sets the error message.</summary>
        string ErrorMessage { get; set; }
        /// <summary>Gets the Instance type.</summary>
        string InstanceType { get; set; }
        /// <summary>Gets or sets the possible causes for the error.</summary>
        string PossibleCaus { get; set; }
        /// <summary>Gets or sets the recommendation for the error.</summary>
        string Recommendation { get; set; }
        /// <summary>Gets or sets the solution for which the error is being reported.</summary>
        string Solution { get; set; }

    }
}