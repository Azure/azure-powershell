namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>A Facebook page for Facebook channel registration</summary>
    public partial class FacebookPage :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookPage,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookPageInternal
    {

        /// <summary>Backing field for <see cref="AccessToken" /> property.</summary>
        private string _accessToken;

        /// <summary>
        /// Facebook application access token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string AccessToken { get => this._accessToken; set => this._accessToken = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Page id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="FacebookPage" /> instance.</summary>
        public FacebookPage()
        {

        }
    }
    /// A Facebook page for Facebook channel registration
    public partial interface IFacebookPage :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Facebook application access token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Facebook application access token. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"accessToken",
        PossibleTypes = new [] { typeof(string) })]
        string AccessToken { get; set; }
        /// <summary>Page id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Page id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// A Facebook page for Facebook channel registration
    internal partial interface IFacebookPageInternal

    {
        /// <summary>
        /// Facebook application access token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string AccessToken { get; set; }
        /// <summary>Page id</summary>
        string Id { get; set; }

    }
}