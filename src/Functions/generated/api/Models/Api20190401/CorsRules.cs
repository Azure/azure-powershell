namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Sets the CORS rules. You can include up to five CorsRule elements in the request.
    /// </summary>
    public partial class CorsRules :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRules,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRulesInternal
    {

        /// <summary>Backing field for <see cref="CorsRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule[] _corsRule;

        /// <summary>
        /// The List of CORS rules. You can include up to five CorsRule elements in the request.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule[] CorsRule { get => this._corsRule; set => this._corsRule = value; }

        /// <summary>Creates an new <see cref="CorsRules" /> instance.</summary>
        public CorsRules()
        {

        }
    }
    /// Sets the CORS rules. You can include up to five CorsRule elements in the request.
    public partial interface ICorsRules :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The List of CORS rules. You can include up to five CorsRule elements in the request.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The List of CORS rules. You can include up to five CorsRule elements in the request. ",
        SerializedName = @"corsRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule[] CorsRule { get; set; }

    }
    /// Sets the CORS rules. You can include up to five CorsRule elements in the request.
    internal partial interface ICorsRulesInternal

    {
        /// <summary>
        /// The List of CORS rules. You can include up to five CorsRule elements in the request.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule[] CorsRule { get; set; }

    }
}