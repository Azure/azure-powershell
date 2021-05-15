namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// The properties that are associated with data sources that use OAuth as their authentication model.
    /// </summary>
    public partial class OAuthBasedDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="RefreshToken" /> property.</summary>
        private string _refreshToken;

        /// <summary>
        /// A refresh token that can be used to obtain a valid access token that can then be used to authenticate with the data source.
        /// A valid refresh token is currently only obtainable via the Azure Portal. It is recommended to put a dummy string value
        /// here when creating the data source and then going to the Azure Portal to authenticate the data source which will update
        /// this property with a valid refresh token. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string RefreshToken { get => this._refreshToken; set => this._refreshToken = value; }

        /// <summary>Backing field for <see cref="TokenUserDisplayName" /> property.</summary>
        private string _tokenUserDisplayName;

        /// <summary>
        /// The user display name of the user that was used to obtain the refresh token. Use this property to help remember which
        /// user was used to obtain the refresh token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string TokenUserDisplayName { get => this._tokenUserDisplayName; set => this._tokenUserDisplayName = value; }

        /// <summary>Backing field for <see cref="TokenUserPrincipalName" /> property.</summary>
        private string _tokenUserPrincipalName;

        /// <summary>
        /// The user principal name (UPN) of the user that was used to obtain the refresh token. Use this property to help remember
        /// which user was used to obtain the refresh token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string TokenUserPrincipalName { get => this._tokenUserPrincipalName; set => this._tokenUserPrincipalName = value; }

        /// <summary>Creates an new <see cref="OAuthBasedDataSourceProperties" /> instance.</summary>
        public OAuthBasedDataSourceProperties()
        {

        }
    }
    /// The properties that are associated with data sources that use OAuth as their authentication model.
    public partial interface IOAuthBasedDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A refresh token that can be used to obtain a valid access token that can then be used to authenticate with the data source.
        /// A valid refresh token is currently only obtainable via the Azure Portal. It is recommended to put a dummy string value
        /// here when creating the data source and then going to the Azure Portal to authenticate the data source which will update
        /// this property with a valid refresh token. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A refresh token that can be used to obtain a valid access token that can then be used to authenticate with the data source. A valid refresh token is currently only obtainable via the Azure Portal. It is recommended to put a dummy string value here when creating the data source and then going to the Azure Portal to authenticate the data source which will update this property with a valid refresh token. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"refreshToken",
        PossibleTypes = new [] { typeof(string) })]
        string RefreshToken { get; set; }
        /// <summary>
        /// The user display name of the user that was used to obtain the refresh token. Use this property to help remember which
        /// user was used to obtain the refresh token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user display name of the user that was used to obtain the refresh token. Use this property to help remember which user was used to obtain the refresh token.",
        SerializedName = @"tokenUserDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string TokenUserDisplayName { get; set; }
        /// <summary>
        /// The user principal name (UPN) of the user that was used to obtain the refresh token. Use this property to help remember
        /// which user was used to obtain the refresh token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user principal name (UPN) of the user that was used to obtain the refresh token. Use this property to help remember which user was used to obtain the refresh token.",
        SerializedName = @"tokenUserPrincipalName",
        PossibleTypes = new [] { typeof(string) })]
        string TokenUserPrincipalName { get; set; }

    }
    /// The properties that are associated with data sources that use OAuth as their authentication model.
    internal partial interface IOAuthBasedDataSourcePropertiesInternal

    {
        /// <summary>
        /// A refresh token that can be used to obtain a valid access token that can then be used to authenticate with the data source.
        /// A valid refresh token is currently only obtainable via the Azure Portal. It is recommended to put a dummy string value
        /// here when creating the data source and then going to the Azure Portal to authenticate the data source which will update
        /// this property with a valid refresh token. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string RefreshToken { get; set; }
        /// <summary>
        /// The user display name of the user that was used to obtain the refresh token. Use this property to help remember which
        /// user was used to obtain the refresh token.
        /// </summary>
        string TokenUserDisplayName { get; set; }
        /// <summary>
        /// The user principal name (UPN) of the user that was used to obtain the refresh token. Use this property to help remember
        /// which user was used to obtain the refresh token.
        /// </summary>
        string TokenUserPrincipalName { get; set; }

    }
}