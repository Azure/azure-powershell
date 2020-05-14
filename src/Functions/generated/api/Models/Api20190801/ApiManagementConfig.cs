namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Azure API management (APIM) configuration linked to the app.</summary>
    public partial class ApiManagementConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiManagementConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiManagementConfigInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>APIM-Api Identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="ApiManagementConfig" /> instance.</summary>
        public ApiManagementConfig()
        {

        }
    }
    /// Azure API management (APIM) configuration linked to the app.
    public partial interface IApiManagementConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>APIM-Api Identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"APIM-Api Identifier.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// Azure API management (APIM) configuration linked to the app.
    internal partial interface IApiManagementConfigInternal

    {
        /// <summary>APIM-Api Identifier.</summary>
        string Id { get; set; }

    }
}