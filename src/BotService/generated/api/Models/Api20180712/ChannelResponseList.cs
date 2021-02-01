namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The list of bot service channel operation response.</summary>
    public partial class ChannelResponseList :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelResponseList,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelResponseListInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannel[] Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelResponseListInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link used to get the next page of bot service channel resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannel[] _value;

        /// <summary>Gets the list of bot service channel results and their properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannel[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="ChannelResponseList" /> instance.</summary>
        public ChannelResponseList()
        {

        }
    }
    /// The list of bot service channel operation response.
    public partial interface IChannelResponseList :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>The link used to get the next page of bot service channel resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The link used to get the next page of bot service channel resources.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Gets the list of bot service channel results and their properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the list of bot service channel results and their properties.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannel) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannel[] Value { get;  }

    }
    /// The list of bot service channel operation response.
    internal partial interface IChannelResponseListInternal

    {
        /// <summary>The link used to get the next page of bot service channel resources.</summary>
        string NextLink { get; set; }
        /// <summary>Gets the list of bot service channel results and their properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannel[] Value { get; set; }

    }
}