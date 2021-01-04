namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The parameters to provide for the Sms channel.</summary>
    public partial class SmsChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelProperties,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AccountSid" /> property.</summary>
        private string _accountSid;

        /// <summary>
        /// The Sms account SID. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string AccountSid { get => this._accountSid; set => this._accountSid = value; }

        /// <summary>Backing field for <see cref="AuthToken" /> property.</summary>
        private string _authToken;

        /// <summary>
        /// The Sms auth token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string AuthToken { get => this._authToken; set => this._authToken = value; }

        /// <summary>Backing field for <see cref="IsEnabled" /> property.</summary>
        private bool _isEnabled;

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool IsEnabled { get => this._isEnabled; set => this._isEnabled = value; }

        /// <summary>Backing field for <see cref="IsValidated" /> property.</summary>
        private bool? _isValidated;

        /// <summary>Whether this channel is validated for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? IsValidated { get => this._isValidated; set => this._isValidated = value; }

        /// <summary>Backing field for <see cref="Phone" /> property.</summary>
        private string _phone;

        /// <summary>The Sms phone</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Phone { get => this._phone; set => this._phone = value; }

        /// <summary>Creates an new <see cref="SmsChannelProperties" /> instance.</summary>
        public SmsChannelProperties()
        {

        }
    }
    /// The parameters to provide for the Sms channel.
    public partial interface ISmsChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The Sms account SID. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Sms account SID. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"accountSID",
        PossibleTypes = new [] { typeof(string) })]
        string AccountSid { get; set; }
        /// <summary>
        /// The Sms auth token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Sms auth token. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"authToken",
        PossibleTypes = new [] { typeof(string) })]
        string AuthToken { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether this channel is enabled for the bot",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsEnabled { get; set; }
        /// <summary>Whether this channel is validated for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether this channel is validated for the bot",
        SerializedName = @"isValidated",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsValidated { get; set; }
        /// <summary>The Sms phone</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Sms phone",
        SerializedName = @"phone",
        PossibleTypes = new [] { typeof(string) })]
        string Phone { get; set; }

    }
    /// The parameters to provide for the Sms channel.
    internal partial interface ISmsChannelPropertiesInternal

    {
        /// <summary>
        /// The Sms account SID. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string AccountSid { get; set; }
        /// <summary>
        /// The Sms auth token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string AuthToken { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        bool IsEnabled { get; set; }
        /// <summary>Whether this channel is validated for the bot</summary>
        bool? IsValidated { get; set; }
        /// <summary>The Sms phone</summary>
        string Phone { get; set; }

    }
}