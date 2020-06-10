namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Information about the formal API definition for the app.</summary>
    public partial class ApiDefinitionInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiDefinitionInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiDefinitionInfoInternal
    {

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>The URL of the API definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Url { get => this._url; set => this._url = value; }

        /// <summary>Creates an new <see cref="ApiDefinitionInfo" /> instance.</summary>
        public ApiDefinitionInfo()
        {

        }
    }
    /// Information about the formal API definition for the app.
    public partial interface IApiDefinitionInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The URL of the API definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL of the API definition.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get; set; }

    }
    /// Information about the formal API definition for the app.
    internal partial interface IApiDefinitionInfoInternal

    {
        /// <summary>The URL of the API definition.</summary>
        string Url { get; set; }

    }
}