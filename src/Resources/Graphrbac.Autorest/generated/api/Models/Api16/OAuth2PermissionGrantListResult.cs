namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Server response for get oauth2 permissions grants</summary>
    public partial class OAuth2PermissionGrantListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantListResult,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantListResultInternal
    {

        /// <summary>Backing field for <see cref="OdataNextLink" /> property.</summary>
        private string _odataNextLink;

        /// <summary>the URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string OdataNextLink { get => this._odataNextLink; set => this._odataNextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant[] _value;

        /// <summary>the list of oauth2 permissions grants</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OAuth2PermissionGrantListResult" /> instance.</summary>
        public OAuth2PermissionGrantListResult()
        {

        }
    }
    /// Server response for get oauth2 permissions grants
    public partial interface IOAuth2PermissionGrantListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>the URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the URL to get the next set of results.",
        SerializedName = @"odata.nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string OdataNextLink { get; set; }
        /// <summary>the list of oauth2 permissions grants</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the list of oauth2 permissions grants",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant[] Value { get; set; }

    }
    /// Server response for get oauth2 permissions grants
    internal partial interface IOAuth2PermissionGrantListResultInternal

    {
        /// <summary>the URL to get the next set of results.</summary>
        string OdataNextLink { get; set; }
        /// <summary>the list of oauth2 permissions grants</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant[] Value { get; set; }

    }
}